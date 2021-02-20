using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project_SWDCarRental.Models
{
    public partial class CarRentalDBContext : DbContext
    {
        public CarRentalDBContext()
        {
        }

        public CarRentalDBContext(DbContextOptions<CarRentalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CarRentalDB;User ID=sa;Password=12346789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(30)
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountName).HasMaxLength(50);

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(50)
                    .HasColumnName("GoogleID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(10);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.ToTable("Booking");

                entity.Property(e => e.ResId).HasColumnName("ResID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(30)
                    .HasColumnName("AccountID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                //entity.HasOne(d => d.Account)
                //    .WithMany(p => p.Bookings)
                //    .HasForeignKey(d => d.AccountId)
                //    .HasConstraintName("FK_Booking_Account");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("BookingDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ResId).HasColumnName("ResID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ResId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingDetail_Booking1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.ToTable("Category");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.Manufacture).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.ToTable("Garage");

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ImageLink).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(30)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.IdentityCard)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.ProfileImage).HasMaxLength(50);

                //entity.HasOne(d => d.Account)
                //    .WithMany(p => p.Users)
                //    .HasForeignKey(d => d.AccountId)
                //    .HasConstraintName("FK_User_Account");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VelNo);

                entity.ToTable("Vehicle");

                entity.Property(e => e.VelNo).ValueGeneratedOnAdd();

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.DescriptionCar).HasMaxLength(50);

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.ImageLink).HasMaxLength(200);

                entity.Property(e => e.LicensePlates).HasMaxLength(50);

                entity.Property(e => e.VehicleFare).HasMaxLength(50);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Car_Category");

                entity.HasOne(d => d.Garage)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.GarageId)
                    .HasConstraintName("FK_Vehicle_Garage");

                entity.HasOne(d => d.VelNoNavigation)
                    .WithOne(p => p.Vehicle)
                    .HasForeignKey<Vehicle>(d => d.VelNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_BookingDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
