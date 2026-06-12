using Crudderegistrodeevento.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudderegistrodeevento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evento>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                b.Property(e => e.Fecha).IsRequired();
                
            });
        }
    }
}
