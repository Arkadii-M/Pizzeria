using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class PizzeriaContext : DbContext
{
    public PizzeriaContext()
    {
    }

    public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomProduct> CustomProducts { get; set; }

    public virtual DbSet<CustomizedMenuProduct> CustomizedMenuProducts { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("custom_products_pkey");

            entity.ToTable("custom_products");

            entity.HasIndex(e => e.ProductName, "custom_products_product_name_key").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.CustomProducts)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("custom_products_product_type_id_fkey");
        });

        modelBuilder.Entity<CustomizedMenuProduct>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ItemId }).HasName("customized_menu_products_pkey");

            entity.ToTable("customized_menu_products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.ItemTypeId).HasName("item_type_pkey");

            entity.ToTable("item_type");

            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.ItemTypeName)
                .HasMaxLength(30)
                .HasColumnName("item_type_name");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.HasIndex(e => e.ItemName, "menu_item_name_key").IsUnique();

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.IsCustom)
                .HasDefaultValueSql("true")
                .HasColumnName("is_custom");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .HasColumnName("item_name");
            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Menus)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("item_type_id_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatusId)
                .HasDefaultValueSql("1")
                .HasColumnName("order_status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("order_status_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_fk");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("order_details_pkey");

            entity.ToTable("order_details");

            entity.Property(e => e.OrderDetailsId).HasColumnName("order_details_id");
            entity.Property(e => e.IsReady)
                .HasDefaultValueSql("false")
                .HasColumnName("is_ready");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("item_order_details_fk");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_detail_fk");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("order_status_pkey");

            entity.ToTable("order_status");

            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(30)
                .HasColumnName("order_status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("1")
                .HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .HasColumnName("user_name");
            entity.Property(e => e.UserStatusId)
                .HasDefaultValueSql("1")
                .HasColumnName("user_status_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("role_fk");

            entity.HasOne(d => d.UserStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserStatusId)
                .HasConstraintName("user_status_fk");
        });

        modelBuilder.Entity<UserStatus>(entity =>
        {
            entity.HasKey(e => e.UserStatusId).HasName("user_status_pkey");

            entity.ToTable("user_status");

            entity.Property(e => e.UserStatusId).HasColumnName("user_status_id");
            entity.Property(e => e.UserStatusName)
                .HasMaxLength(30)
                .HasColumnName("user_status_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
