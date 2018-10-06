using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrderManagementWebAPI.Models
{
    public partial class OrderManagementContext : DbContext
    {
        public OrderManagementContext()
        {
        }

        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<ClientMaster> ClientMaster { get; set; }
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D6FS7LS;Database=OrderManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientMaster>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemMaster>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemCategory)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderDate).HasColumnType("date");
            });
        }
    }
}
