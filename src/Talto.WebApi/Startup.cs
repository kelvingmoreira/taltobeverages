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

namespace Talto.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Enviroment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Enviroment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaltoContext>((provider, option) => {
                var db = option.UseSqlServer(Configuration.GetConnectionString("ReleaseConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                if (Enviroment.IsDevelopment())
                {
                    db.EnableSensitiveDataLogging()
                    .UseLoggerFactory((ILoggerFactory)provider.GetService(typeof(ILoggerFactory)));

                }
            });

            //injeção de dependência
            services.AddScoped<IBeverageRepository, SqlBeverageRepository>();

            services.AddControllers();

            services.AddMvc().AddNewtonsoftJson();

            services.AddSwaggerGen(setup => {
                setup.CustomSchemaIds(x => x.FullName);
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
