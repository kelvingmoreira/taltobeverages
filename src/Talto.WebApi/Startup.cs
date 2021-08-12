using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository.Sql;
using Talto.Repository;
using System.Reflection;
using System.IO;

namespace Talto.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaltoContext>((provider, option) => {
                var db = option.UseSqlServer(Configuration.GetConnectionString("ReleaseConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                if (Environment.IsDevelopment())
                {
                    db.EnableSensitiveDataLogging()
                    .UseLoggerFactory(provider.GetService<ILoggerFactory>());

                }
            });

            //injeção de dependência
            services.AddScoped<IBeverageRepository, SqlBeverageRepository>();

            services.AddControllers();

            services.AddMvc().AddNewtonsoftJson();

            services.AddSwaggerGen(setup => {
                setup.CustomSchemaIds(x => x.FullName);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setup.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Verifica se a connection está definida. 
            //Se não estiver, defina o valor de ReleaseConnection em appsettings.Development.json para a demonstração
            if (string.IsNullOrWhiteSpace(Configuration.GetConnectionString("ReleaseConnection")))
                throw new NullReferenceException("É necessário definir a connection string do banco de dados");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setup =>
                {
                    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Sonarv1");
                    setup.DefaultModelsExpandDepth(-1);
                });
            }

            //Certifica que o banco de dados existe. Se não exisitr, o schema será aplicado no caminho da connection string.
            using (var scope = app.ApplicationServices.CreateScope())
                using (var context = scope.ServiceProvider.GetService<TaltoContext>())
                    context.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
