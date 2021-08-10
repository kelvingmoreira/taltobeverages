using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models;

namespace Talto.Repository.Sql
{
    public class TaltoContext : DbContext
    {
        public TaltoContext() { }
        public TaltoContext(DbContextOptions<TaltoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Beverage>()
                .HasMany(x => x.Cashbacks)
                .WithOne(x => x.Beverage)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cashback>()
                .HasKey(c => new { c.BeverageId, c.DayOfWeek });
        }

        public virtual DbSet<Beverage> Beverages { get; set; }

        public virtual DbSet<Cashback> Cashbacks { get; set; }
    }
}
