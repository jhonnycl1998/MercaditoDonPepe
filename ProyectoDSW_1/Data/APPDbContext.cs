using ProyectoDSW_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDSW_1.Data
{ 
    public class APPDbContext : DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Dueno> Duenos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Damos indicaciones adicionales a la relacion entre pago y deuda
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Deuda)
                .WithOne(d => d.Pago)
                .HasForeignKey<Pago>(p => p.DeudaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pago>()
                .HasIndex(p => p.DeudaId)
                .IsUnique();

            modelBuilder.Entity<Pago>()
                .Property(p => p.MontoPago)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Deuda>()
                .Property(d => d.MontoDeuda)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Servicio>()
                .Property(s => s.Costo)
                .HasPrecision(18, 2);
        }
    }

}
