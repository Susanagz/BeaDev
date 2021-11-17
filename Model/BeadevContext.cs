using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model
{
    public partial class BeadevContext : DbContext
    {
        public BeadevContext()
        {
        }

        public BeadevContext(DbContextOptions<BeadevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProgrammingIcon> ProgrammingIcons { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EVELIO;Database=Beadev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ProgrammingIcon>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProgrammingLanguage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdIcon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistryDate).HasColumnType("date");

                entity.Property(e => e.SalaryRange).HasColumnType("money");

                entity.Property(e => e.StackDescription)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIconNavigation)
                    .WithMany(p => p.ProgrammingLanguages)
                    .HasForeignKey(d => d.IdIcon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgrammingLanguages_ProgrammingIcons");
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MonthID)
                    .IsRequired();

                    entity.Property(e => e.ProgrammLangID)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
