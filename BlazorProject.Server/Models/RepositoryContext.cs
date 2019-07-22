using System;
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

        public virtual DbSet<Abilities> Abilities { get; set; }
        public virtual DbSet<AbilitiesProse> AbilitiesProse { get; set; }
        public virtual DbSet<DamageClass> DamageClass { get; set; }
        public virtual DbSet<EvolutionTriggers> EvolutionTriggers { get; set; }
        public virtual DbSet<Generation> Generation { get; set; }
        public virtual DbSet<GrowthRate> GrowthRate { get; set; }
        public virtual DbSet<ItemCategories> ItemCategories { get; set; }
        public virtual DbSet<ItemFlingEffects> ItemFlingEffects { get; set; }
        public virtual DbSet<ItemPockets> ItemPockets { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MainRegion> MainRegion { get; set; }
        public virtual DbSet<MoveEffects> MoveEffects { get; set; }
        public virtual DbSet<MoveTargets> MoveTargets { get; set; }
        public virtual DbSet<Moves> Moves { get; set; }
        public virtual DbSet<PokemonAbilities> PokemonAbilities { get; set; }
        public virtual DbSet<PokemonEvolution> PokemonEvolution { get; set; }
        public virtual DbSet<PokemonStats> PokemonStats { get; set; }
        public virtual DbSet<PokemonTypes> PokemonTypes { get; set; }
        public virtual DbSet<Pokemons> Pokemons { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<TypeEfficacy> TypeEfficacy { get; set; }
        public virtual DbSet<Types> Types { get; set; }

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

            modelBuilder.Entity<Abilities>(entity =>
            {
                entity.ToTable("abilities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Effect)
                    .HasColumnName("effect")
                    .IsUnicode(false);

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.IsMainSeries).HasColumnName("is_main_series");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ShortEffect)
                    .HasColumnName("short_effect")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AbilitiesProse>(entity =>
            {
                entity.ToTable("abilities_prose");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasMaxLength(2071)
                    .IsUnicode(false);

                entity.Property(e => e.ShortEffect)
                    .IsRequired()
                    .HasColumnName("short_effect")
                    .HasMaxLength(320)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DamageClass>(entity =>
            {
                entity.ToTable("damage_class");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

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
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
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

            modelBuilder.Entity<PokemonStats>(entity =>
            {
                entity.ToTable("pokemon_stats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attack).HasColumnName("attack");

                entity.Property(e => e.Defense).HasColumnName("defense");

                entity.Property(e => e.Hp).HasColumnName("hp");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.SpAttack).HasColumnName("sp_attack");

                entity.Property(e => e.SpDefense).HasColumnName("sp_defense");

                entity.Property(e => e.Speed).HasColumnName("speed");

            });

            modelBuilder.Entity<PokemonAbilities>(entity =>
            {
                entity.ToTable("pokemon_abilities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.Slot).HasColumnName("slot");
            });

            modelBuilder.Entity<PokemonTypes>(entity =>
            {
                entity.ToTable("pokemon_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonTypes)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemon_Types_Pokemon");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PokemonTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemon_Types_Types");
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

                //entity.HasOne(d => d.Species)
                //    .WithMany(p => p.Pokemons)
                //    .HasForeignKey(d => d.SpeciesId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Pokemons_Species");
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

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GrowthRateId).HasColumnName("growth_rate_id");

                entity.Property(e => e.HasGenderDifferences).HasColumnName("has_gender_differences");

                entity.Property(e => e.HatchCounter).HasColumnName("hatch_counter");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.HasOne(d => d.EvolvesFromSpecies)
                    .WithMany(p => p.InverseEvolvesFromSpecies)
                    .HasForeignKey(d => d.EvolvesFromSpeciesId)
                    .HasConstraintName("FK_Species_Evolves_From_Species");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Species_Generation");

                entity.HasOne(d => d.GrowthRate)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.GrowthRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Species_Growth_Rate");
            });

            modelBuilder.Entity<TypeEfficacy>(entity =>
            {
                entity.ToTable("type_efficacy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DamageFactor).HasColumnName("damage_factor");

                entity.Property(e => e.DamageTypeId).HasColumnName("damage_type_id");

                entity.Property(e => e.TargetTypeId).HasColumnName("target_type_id");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DamageClassId).HasColumnName("damage_class_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.DamageClass)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.DamageClassId)
                    .HasConstraintName("FK_Types_Damage_Class");

                entity.HasOne(d => d.Generation)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.GenerationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Types_Generation");
            });

            modelBuilder.Entity<EvolutionTriggers>(entity =>
            {
                entity.ToTable("evolution_triggers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemCategories>(entity =>
            {
                entity.ToTable("item_categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemPocketId).HasColumnName("item_pocket_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemFlingEffects>(entity =>
            {
                entity.ToTable("item_fling_effects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemPockets>(entity =>
            {
                entity.ToTable("item_pockets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.FlingPower).HasColumnName("fling_power");

                entity.Property(e => e.ItemCategoryId).HasColumnName("item_category_id");

                entity.Property(e => e.ItemFlingEffectId).HasColumnName("item_fling_effect_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(31)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MainRegionId).HasColumnName("main_region_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                //entity.HasOne(d => d.MainRegion)
                //    .WithMany(p => p.Locations)
                //    .HasForeignKey(d => d.MainRegionId)
                //    .HasConstraintName("FK_Locations_Main_Region");
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

            modelBuilder.Entity<MoveEffects>(entity =>
            {
                entity.ToTable("move_effects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasMaxLength(4103)
                    .IsUnicode(false);

                entity.Property(e => e.ShortEffect)
                    .IsRequired()
                    .HasColumnName("short_effect")
                    .HasMaxLength(148)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoveTargets>(entity =>
            {
                entity.ToTable("move_targets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Moves>(entity =>
            {
                entity.ToTable("moves");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.DamageClassId).HasColumnName("damage_class_id");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.MoveEffectChance).HasColumnName("move_effect_chance");

                entity.Property(e => e.MoveEffectId).HasColumnName("move_effect_id");

                entity.Property(e => e.MoveTargetId).HasColumnName("move_target_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Pp).HasColumnName("pp");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.TypeId).HasColumnName("type_id");
            });

            modelBuilder.Entity<PokemonAbilities>(entity =>
            {
                entity.ToTable("pokemon_abilities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");

                entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonAbilities)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemon_Abilities_Pokemon");
            });

            modelBuilder.Entity<PokemonEvolution>(entity =>
            {
                entity.ToTable("pokemon_evolution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EvolutionTriggerId).HasColumnName("evolution_trigger_id");

                entity.Property(e => e.EvolvedSpeciesId).HasColumnName("evolved_species_id");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HeldItemId).HasColumnName("held_item_id");

                entity.Property(e => e.KnownMoveId).HasColumnName("known_move_id");

                entity.Property(e => e.KnownMoveTypeId).HasColumnName("known_move_type_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MinimumAffection).HasColumnName("minimum_affection");

                entity.Property(e => e.MinimumBeauty).HasColumnName("minimum_beauty");

                entity.Property(e => e.MinimumHappiness).HasColumnName("minimum_happiness");

                entity.Property(e => e.MinimumLevel).HasColumnName("minimum_level");

                entity.Property(e => e.NeedsOverworldRain).HasColumnName("needs_overworld_rain");

                entity.Property(e => e.PartySpeciesId).HasColumnName("party_species_id");

                entity.Property(e => e.PartyTypeId).HasColumnName("party_type_id");

                entity.Property(e => e.RelativePhysicalStats).HasColumnName("relative_physical_stats");

                entity.Property(e => e.TimeOfDay)
                    .HasColumnName("time_of_day")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TradeSpeciesId).HasColumnName("trade_species_id");

                entity.Property(e => e.TriggerItemId).HasColumnName("trigger_item_id");

                entity.Property(e => e.TurnUpsideDown).HasColumnName("turn_upside_down");

                //entity.HasOne(d => d.EvolutionTrigger)
                //    .WithMany(p => p.PokemonEvolution)
                //    .HasForeignKey(d => d.EvolutionTriggerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Pokemon_Evolution_Evolved_Trigger");

                //entity.HasOne(d => d.EvolvedSpecies)
                //    .WithMany(p => p.PokemonEvolutionEvolvedSpecies)
                //    .HasForeignKey(d => d.EvolvedSpeciesId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Pokemon_Evolution_Evolved_Species");

                //entity.HasOne(d => d.HeldItem)
                //    .WithMany(p => p.PokemonEvolutionHeldItem)
                //    .HasForeignKey(d => d.HeldItemId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Held_Item");

                //entity.HasOne(d => d.KnownMove)
                //    .WithMany(p => p.PokemonEvolution)
                //    .HasForeignKey(d => d.KnownMoveId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Know_Move");

                //entity.HasOne(d => d.KnownMoveType)
                //    .WithMany(p => p.PokemonEvolutionKnownMoveType)
                //    .HasForeignKey(d => d.KnownMoveTypeId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Know_Move_Type");

                //entity.HasOne(d => d.Location)
                //    .WithMany(p => p.PokemonEvolution)
                //    .HasForeignKey(d => d.LocationId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Location");

                //entity.HasOne(d => d.PartySpecies)
                //    .WithMany(p => p.PokemonEvolutionPartySpecies)
                //    .HasForeignKey(d => d.PartySpeciesId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Party_Species");

                //entity.HasOne(d => d.PartyType)
                //    .WithMany(p => p.PokemonEvolutionPartyType)
                //    .HasForeignKey(d => d.PartyTypeId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Party_Type");

                //entity.HasOne(d => d.TradeSpecies)
                //    .WithMany(p => p.PokemonEvolutionTradeSpecies)
                //    .HasForeignKey(d => d.TradeSpeciesId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Trade_Species");

                //entity.HasOne(d => d.TriggerItem)
                //    .WithMany(p => p.PokemonEvolutionTriggerItem)
                //    .HasForeignKey(d => d.TriggerItemId)
                //    .HasConstraintName("FK_Pokemon_Evolution_Trigger_Item");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
