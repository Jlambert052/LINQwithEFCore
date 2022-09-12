using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LINQwithEFCore
{
    public partial class PurchaseRequestSystemContext : DbContext
    {
        public PurchaseRequestSystemContext()
        {
        }

        public PurchaseRequestSystemContext(DbContextOptions<PurchaseRequestSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestLine> RequestLines { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=PurchaseRequestSystem;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.PartNbr, "UQ__Products__DAFC0C1EF9BC4A9E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PartNbr)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Unit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Each')");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Vendor__2F10007B");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeliveryMode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PICKUP')");

                entity.Property(e => e.Description)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Justification)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RejectionReason)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NEW')");

                entity.Property(e => e.Total).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__UserID__34C8D9D1");
            });

            modelBuilder.Entity<RequestLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RequestLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Produ__38996AB5");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestLines)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Reque__37A5467C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E48348826E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.IsReviewer).HasColumnName("isReviewer");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasIndex(e => e.Code, "UQ__Vendors__A25C5AA70FD27136")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OH')")
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
