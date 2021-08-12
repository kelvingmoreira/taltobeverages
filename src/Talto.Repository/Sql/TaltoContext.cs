using Microsoft.EntityFrameworkCore;
using Talto.Repository.Models;

namespace Talto.Repository.Sql
{
    public class TaltoContext : DbContext
    {
        /// <summary>
        /// Cria um novo <see cref="DbContext"/> de <see cref="TaltoContext"/>.
        /// </summary>
        public TaltoContext() { }

        /// <summary>
        /// Cria um novo <see cref="DbContext"/> de <see cref="TaltoContext"/> com opções personalizadas.
        /// </summary>
        /// <param name="options">As opções do <see cref="DbContext"/>.</param>
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

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Entries)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderEntry>()
                .HasOne(x => x.Beverage)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }

        /// <summary>
        /// Obtém ou define o <see cref="DbSet{TEntity}"/> para <see cref="Beverage"/>.
        /// </summary>
        public virtual DbSet<Beverage> Beverages { get; set; }

        /// <summary>
        /// Obtém ou define o <see cref="DbSet{TEntity}"/> para <see cref="Cashback"/>.
        /// </summary>
        public virtual DbSet<Cashback> Cashbacks { get; set; }

        /// <summary>
        /// Obtém ou define o <see cref="DbSet{TEntity}"/> para <see cref="Order"/>.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Obtém ou define o <see cref="DbSet{TEntity}"/> para <see cref="OrderEntry"/>.
        /// </summary>
        public virtual DbSet<OrderEntry> OrderEntries { get; set; }
    }
}
