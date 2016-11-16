using FifaFanApp.Models;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace FifaFanApp.DAL
{

    public partial class FifaDbContext : DbContext
    {
        public FifaDbContext()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<FifaClub> FifaClubs { get; set; }
        public virtual DbSet<FifaNation> FifaNations { get; set; }
protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                 .Property(e => e.PlayerPath)
                 .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.NationalityPath)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.ClubPath)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.ClubName)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.MinWorth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Player>()
                .Property(e => e.MaxWorth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Player>()
                .Property(e => e.Foot)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasOptional(e => e.Image)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Player>()
                .HasOptional(e => e.Rating)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Player>()
                .HasOptional(e => e.Skill)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FifaClub>()
              .Property(e => e.ClubName)
              .IsUnicode(false);

            modelBuilder.Entity<FifaClub>()
                .Property(e => e.ClubImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<FifaNation>()
                .Property(e => e.NationName)
                .IsUnicode(false);

            modelBuilder.Entity<FifaNation>()
                .Property(e => e.NationImagePath)
                .IsUnicode(false);
        }
    }
}
