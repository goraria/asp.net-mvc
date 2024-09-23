using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mvc.Models.Tables;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Nickname> Nicknames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Demo;User Id=sa;Password=Japtor@1999;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity);

            entity.ToTable("City");

            entity.Property(e => e.IdCity)
                .HasMaxLength(10)
                .HasColumnName("id_city");
            entity.Property(e => e.Country)
                .HasMaxLength(127)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(127)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Nickname>(entity =>
        {
            entity.HasKey(e => e.IdNickname);

            entity.ToTable("Nickname");

            entity.Property(e => e.IdNickname)
                .HasMaxLength(10)
                .HasColumnName("id_nickname");
            entity.Property(e => e.Address)
                .HasMaxLength(127)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Firstname)
                .HasMaxLength(127)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(31)
                .HasColumnName("gender");
            entity.Property(e => e.IdCity)
                .HasMaxLength(10)
                .HasColumnName("id_city");
            entity.Property(e => e.Job)
                .HasMaxLength(127)
                .HasColumnName("job");
            entity.Property(e => e.Lastname)
                .HasMaxLength(127)
                .HasColumnName("lastname");
            entity.Property(e => e.Type)
                .HasMaxLength(127)
                .HasColumnName("type");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Nicknames)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("FK_Nickname_City");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
