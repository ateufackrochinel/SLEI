using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLEI.Domain;
using System.Net;

namespace SLEI.Insfrastructure.Data
{
 public   class SLEIContext : DbContext
    {
        
        public SLEIContext(DbContextOptions<SLEIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Logement>()         
                .HasMany(l => l.Appartements)       // un Logement peut avoir plusieurs appartements 
                .WithOne(a => a.logement)           // un appartement appartient a un seul logement
                .HasForeignKey(a => a.LogementId);   // Clé étrangère

            modelBuilder.Entity<Logement>()
               .HasMany(l => l.Studios)
               .WithOne(s => s.logement)
               .HasForeignKey(s => s.LogementId);

            modelBuilder.Entity<Logement>()
               .HasMany(l => l.Images)
               .WithOne(i => i.logement)
               .HasForeignKey(i => i.LogementId);

            modelBuilder.Entity<Appartement>()
               .HasMany(a => a.Images)
               .WithOne(i => i.appartement)
               .HasForeignKey(i => i.AppartementId);

            modelBuilder.Entity<Appartement>()
               .HasMany(a => a.RDVs)
               .WithOne(r => r.appartement)
               .HasForeignKey(r => r.RDVId);

            modelBuilder.Entity<Studio>()
               .HasMany(s => s.Images)
               .WithOne(i => i.studio)
               .HasForeignKey(i => i.StudioId);

            modelBuilder.Entity<Studio>()
               .HasMany(s => s.RDVs)
               .WithOne(r => r.studio)
               .HasForeignKey(r => r.StudioId);

            modelBuilder.Entity<Province>()
                .HasOne(p => p.image)
                .WithOne(i => i.province)
                .HasForeignKey<Province>(p => p.ImageId); // clé étrangère dans Province
                                                          //  .HasForeignKey(i => i.ProvinceId);
            modelBuilder.Entity<Province>()
               .HasMany(p => p.Villes)
               .WithOne(v => v.province)
               .HasForeignKey(v => v.ProvinceId);

            modelBuilder.Entity<Ville>()
                .HasMany(v => v.Logements)
                .WithOne(l => l.ville)
                .HasForeignKey(l => l.VilleId); // clé étrangère dans Ville


        }



        public DbSet<Logement> Logements { get; set; }

        public DbSet<Appartement> Appartements { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<RDV> RDVs { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Ville> Villes { get; set; }


    }
}
