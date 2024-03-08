using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BSOSApi.Models;

namespace BSOSApi.Data;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreCategory> StoreCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F600D2859");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(225)
                .HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3213E83F0828853E");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DurationTime).HasColumnName("duration_time");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(512)
                .HasColumnName("service_description");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .HasColumnName("service_name");
            entity.Property(e => e.ServicePrice).HasColumnName("service_price");
            entity.Property(e => e.StoreCategoryId).HasColumnName("store_category_id");

            entity.HasOne(d => d.StoreCategory).WithMany(p => p.Services)
                .HasForeignKey(d => d.StoreCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service__store_c__3F466844");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Store__3213E83F39791719");

            entity.ToTable("Store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StoreAdress)
                .HasMaxLength(225)
                .HasColumnName("store_adress");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .HasColumnName("store_name");
            entity.Property(e => e.StoreOwner)
                .HasMaxLength(225)
                .HasColumnName("store_owner");
        });

        modelBuilder.Entity<StoreCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StoreCat__3213E83F425FCF46");

            entity.ToTable("StoreCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Category).WithMany(p => p.StoreCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StoreCate__categ__3C69FB99");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreCategories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StoreCate__store__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
