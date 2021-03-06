﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityTest.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Sessie>()
                .ToTable("Sessies");

            builder.Entity<Tijdvak>()
                .ToTable("Tijdvakken");

            builder.Entity<Ruimte>()
                .ToTable("Ruimtes");

            builder.Entity<Maxima>()
                .ToTable("Maxima");

            builder.Entity<TrackTijdvak>()
                .ToTable("TrackTijdvakken");

            
            builder.Entity<ApplicationUserSessie>()
               .HasKey(bc => new { bc.ApplicationUserId, bc.SessieId });

            builder.Entity<ApplicationUserSessie>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.UserSessies)
                .HasForeignKey(bc => bc.ApplicationUserId);

            builder.Entity<ApplicationUserSessie>()
                .HasOne(bc => bc.Sessie)
                .WithMany(c => c.UserSessies)
                .HasForeignKey(bc => bc.SessieId);

            builder.Entity<TrackTijdvak>()
                .HasKey(c => new { c.TrackID, c.TijdvakID });
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Ruimte> Ruimtes { get; set; }
        public DbSet<Tijdvak> Tijdvakken { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackTijdvak> TrackTijdvakken { get; set; }
        public DbSet<Maxima> Maxima { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
