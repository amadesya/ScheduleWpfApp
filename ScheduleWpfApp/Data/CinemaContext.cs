using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScheduleWpfApp.Models;

namespace ScheduleWpfApp.Data;

public partial class CinemaContext : DbContext
{
    public CinemaContext()
    {
    }

    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CinemaHall> CinemaHalls { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = mssql; Initial Catalog = ispp3512; User ID = ispp3512; Password = 3512; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CinemaHall>(entity =>
        {
            entity.HasKey(e => e.IdCinemaHall);

            entity.ToTable("CinemaHall");

            entity.Property(e => e.IdCinemaHall).ValueGeneratedOnAdd();
            entity.Property(e => e.Cinema)
                .HasMaxLength(50)
                .HasDefaultValue("Макси");
            entity.Property(e => e.IsVip).HasColumnName("IsVIP");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.IdFilm);

            entity.ToTable("Film", tb => tb.HasTrigger("trDeletedFilm"));

            entity.Property(e => e.AgeRating)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FilmDescription)
                .HasMaxLength(500)
                .HasDefaultValueSql("((90))");
            entity.Property(e => e.FilmName).HasMaxLength(100);
            entity.Property(e => e.Poster).IsUnicode(false);
            entity.Property(e => e.YearPublication).HasDefaultValueSql("(datepart(year,getdate()))");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdSession);

            entity.ToTable("Session");

            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price)
                .HasDefaultValue(200m)
                .HasColumnType("decimal(4, 0)");

            entity.HasOne(d => d.Halls).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdCinemaHall)
                .HasConstraintName("FK_Session_CinemaHall");

            entity.HasOne(d => d.Films).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdFilm)
                .HasConstraintName("FK_Session_Film");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
