using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T25_Models_ER_Ex3.Model
{
    public class APIContext : DbContext
    {
        // IMPORTAMOS LOS METODOS DE DBCONTEXT
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // ATRIBUTOS, GETTERS Y SETTERS
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }

        // CREAMOS EL MODELO
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>(almacen =>
            {
                // NOMBRE DE LA TABLA
                almacen.ToTable("CAJAS");

                // DEFINICIÓN DE COLUMNAS
                almacen.Property(e => e.Codigo)
                    .HasColumnName("Codigo");

                almacen.Property(e => e.Lugar)
                    .HasColumnName("Lugar")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                almacen.Property(e => e.Capacidad)
                    .HasColumnName("Capacidad");

                // DEFINICIÓN DE CLAVES
                almacen.HasKey(k => k.Codigo);
            });

            modelBuilder.Entity<Caja>(caja =>
            {
                // NOMBRE DE LA TABLA
                caja.ToTable("CAJAS");

                // DEFINICIÓN DE COLUMNAS
                caja.Property(e => e.NumReferencia)
                    .HasColumnName("NumReferencia");

                caja.Property(e => e.Contenido)
                    .HasColumnName("Contenido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                caja.Property(e => e.Valor)
                    .HasColumnName("Valor");

                caja.Property(e => e.Almacen)
                    .HasColumnName("Almacen");

                // DEFINICIÓN DE CLAVES
                caja.HasKey(k => k.NumReferencia);

                // DEFINICIÓN DE RELACIONES
                caja.HasOne(r => r.Almacenes)
                    .WithMany(m => m.Cajas)
                    .HasForeignKey(f => f.Almacen)
                    .HasConstraintName("Almacen_fk");
            });
        }
    }
}
