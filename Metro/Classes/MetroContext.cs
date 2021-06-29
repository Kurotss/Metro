using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Metro
{
    public partial class MetroContext : DbContext
    {
        public MetroContext()
        {
        }

        public MetroContext(DbContextOptions<MetroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<LinesStation> LinesStations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StopTraffic> StopTraffics { get; set; }
        public virtual DbSet<StopsStation> StopsStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-62MFGKR;Database=Metro;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Line>(entity =>
            {
                entity.HasKey(e => e.IdLine)
                    .HasName("PK__Lines__31D8A6F390C00E89");

                entity.Property(e => e.NameLine)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LinesStation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LinesStations");

                entity.Property(e => e.GpsCoordinates)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameLine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.IdStation)
                    .HasName("PK__Stations__FBB9BA0A21ACFAE3");

                entity.Property(e => e.GpsCoordinates)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLineNavigation)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.IdLine)
                    .HasConstraintName("FK__Stations__IdLine__4BAC3F29");
            });

            modelBuilder.Entity<StopTraffic>(entity =>
            {
                entity.HasKey(e => e.IdStop)
                    .HasName("PK__StopTraf__A3FC1DFE65F43072");

                entity.Property(e => e.DateEndStop).HasColumnType("datetime");

                entity.Property(e => e.DateStartStop).HasColumnType("datetime");

                entity.HasOne(d => d.IdFirstStationNavigation)
                    .WithMany(p => p.StopTrafficIdFirstStationNavigations)
                    .HasForeignKey(d => d.IdFirstStation)
                    .HasConstraintName("FK__StopTraff__IdFir__4E88ABD4");

                entity.HasOne(d => d.IdSecondStationNavigation)
                    .WithMany(p => p.StopTrafficIdSecondStationNavigations)
                    .HasForeignKey(d => d.IdSecondStation)
                    .HasConstraintName("FK__StopTraff__IdSec__4F7CD00D");
            });

            modelBuilder.Entity<StopsStation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StopsStations");

                entity.Property(e => e.DateEndStop).HasColumnType("datetime");

                entity.Property(e => e.DateStartStop).HasColumnType("datetime");

                entity.Property(e => e.NameFirst)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameSecond)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
