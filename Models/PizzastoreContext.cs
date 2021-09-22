using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaStore.Models
{
    public partial class PizzastoreContext : DbContext
    {
        public PizzastoreContext()
        {
        }

        public PizzastoreContext(DbContextOptions<PizzastoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItemsDetail> OrderItemsDetails { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-456\\SQLSERVER2021CV;user id=sa;password=Chandancv@123;Initial catalog=pizzastore");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.DeliveryCharges).HasColumnName("Delivery_charges");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnName("Total_amount");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserEmail)
                    .HasConstraintName("FK__Orders__user_ema__3E52440B");
            });

            modelBuilder.Entity<OrderItemsDetail>(entity =>
            {
                entity.HasKey(e => new { e.ItemNumber, e.ToppingsNumber })
                    .HasName("PK__Order_It__9B55A57969A7C6EF");

                entity.ToTable("Order_Items_Details");

                entity.Property(e => e.ItemNumber).HasColumnName("Item_Number");

                entity.Property(e => e.ToppingsNumber).HasColumnName("Toppings_Number");

                entity.HasOne(d => d.ItemNumberNavigation)
                    .WithMany(p => p.OrderItemsDetails)
                    .HasForeignKey(d => d.ItemNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Item___44FF419A");

                entity.HasOne(d => d.ToppingsNumberNavigation)
                    .WithMany(p => p.OrderItemsDetails)
                    .HasForeignKey(d => d.ToppingsNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Toppi__45F365D3");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.HasKey(e => e.ItemNumber)
                    .HasName("PK__Orders_d__336577605B11A786");

                entity.ToTable("Orders_details");

                entity.Property(e => e.ItemNumber).HasColumnName("Item_Number");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PizzaNumber).HasColumnName("Pizza_Number");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Orders_de__Order__412EB0B6");

                entity.HasOne(d => d.PizzaNumberNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.PizzaNumber)
                    .HasConstraintName("FK__Orders_de__Pizza__4222D4EF");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.PizzaNumber)
                    .HasName("PK__Pizza__C922AA6E33735190");

                entity.ToTable("Pizza");

                entity.Property(e => e.PizzaNumber).HasColumnName("Pizza_Number");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.ToppingsNumber)
                    .HasName("PK__Toppings__830D219B7A4F6898");

                entity.Property(e => e.ToppingsNumber).HasColumnName("Toppings_Number");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserEmail)
                    .HasName("PK__Users__B0FBA213F7B4106B");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Address");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
