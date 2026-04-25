using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIGW.Models;

public partial class WareHouseContext : DbContext
{
    public WareHouseContext()
    {
    }

    public WareHouseContext(DbContextOptions<WareHouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mainsrv.office.aviv.com.ua;Database=WareHouse;Authentication=Active Directory Integrated;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(90);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("Type_id");
            entity.Property(e => e.Visible).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
