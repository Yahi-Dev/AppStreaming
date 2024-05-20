using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> optiones) : base(optiones) { }
        public DbSet<Series> Series { get; set; }
        public DbSet<Productora> Productora { get; set; }
        public DbSet<Genero> Genero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tables
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Productora>().ToTable("Productora");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Series>().HasKey(s => s.SerieId); //Lambda
            modelBuilder.Entity<Productora>().HasKey(p => p.ProductoraId);
            modelBuilder.Entity<Genero>().HasKey(g => g.GeneroId); //Lambda
            #endregion

            #region RelationShip

            #region Relación uno a muchos con SerieGenero Y Relación uno a uno con Genero
            modelBuilder.Entity<Genero>()
                .HasMany<Series>(g => g.Series1)
                .WithOne(s => s.Genero1)
                .HasForeignKey(sg => sg.Genero1Id)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Genero>()
                .HasMany<Series>(g => g.Series2)
                .WithOne(s => s.Genero2)
                .HasForeignKey(sg => sg.Genero2Id)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Relación uno a muchos entre Productora y Series
            modelBuilder.Entity<Productora>()
                .HasMany<Series>(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(s => s.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #endregion

            #region "Property cofiguration"

            #region Series
            modelBuilder.Entity<Series>()
                .Property(s => s.Titulo)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #region Productora
            modelBuilder.Entity<Productora>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #region Genero
            modelBuilder.Entity<Genero>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
