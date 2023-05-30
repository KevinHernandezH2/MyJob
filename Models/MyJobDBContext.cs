
using Microsoft.EntityFrameworkCore;
using MyJob.Models;

namespace MyJob.Models
{
    public class MyJobDBContext : DbContext
    {
        public MyJobDBContext(DbContextOptions<MyJobDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Empleo> Empleos { get; set; }
        public DbSet<Postulaciones> Postulaciones { get; set; }

        internal static void Initialize(MyJobDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Postulacion>()
        //        .HasOne(p => p.Usuario)
        //        .WithMany(u => u.Postulaciones)
        //        .HasForeignKey(p => p.UsuarioId);

        //    modelBuilder.Entity<Postulacion>()
        //        .HasOne(p => p.Empleo)
        //        .WithMany(e => e.Postulaciones)
        //        .HasForeignKey(p => p.EmpleoId);

        //    modelBuilder.Entity<Empleo>()
        //        .HasOne(e => e.Empresa)
        //        .WithMany(c => c.Empleos)
        //        .HasForeignKey(e => e.EmpresaId);
        //}
    }
}







