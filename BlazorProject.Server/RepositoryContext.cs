﻿using System;
using BlazorProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorProject.Server
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Generation> Generation { get; set; }
        public virtual DbSet<GrowthRate> GrowthRate { get; set; }
        public virtual DbSet<MainRegion> MainRegion { get; set; }
        public virtual DbSet<Pokemons> Pokemons { get; set; }
        public virtual DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Generation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MainRegionId).HasColumnName("main_region_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.MainRegion)
                    .WithMany(p => p.Generation)
                    .HasForeignKey(d => d.MainRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Generation_Main_Region");
            });

            modelBuilder.Entity<GrowthRate>(entity =>
            {
                entity.ToTable("growth_rate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasColumnName("formula")
                    .HasMaxLength(388)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MainRegion>(entity =>
            {
                entity.ToTable("main_region");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pokemons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseExperience).HasColumnName("base_experience");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemons_Species");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseHappiness).HasColumnName("base_happiness");

                entity.Property(e => e.CaptureRate).HasColumnName("capture_rate");

                entity.Property(e => e.EvolutionChain).HasColumnName("evolution_chain");

                entity.Property(e => e.EvolvesFromSpeciesId).HasColumnName("evolves_from_species_id");

                entity.Property(e => e.FormsSwitchable).HasColumnName("forms_switchable");

                entity.Property(e => e.GenderRate).HasColumnName("gender_rate");

                entity.Property(e => e.HasGenderDifferences).HasColumnName("has_gender_differences");

                entity.Property(e => e.HatchCounter).HasColumnName("hatch_counter");

                entity.Property(e => e.IsBaby).HasColumnName("is_baby");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Position).HasColumnName("position");

                entity.HasOne(d => d.EvolvesFromSpecies)
                    .WithMany(p => p.InverseEvolvesFromSpecies)
                    .HasForeignKey(d => d.EvolvesFromSpeciesId)
                    .HasConstraintName("FK_Species_Evolves_From_Species");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
