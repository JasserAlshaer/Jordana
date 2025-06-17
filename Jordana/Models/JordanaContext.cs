using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Jordana.Models
{
    public partial class JordanaContext : DbContext
    {
        public JordanaContext() { }

        public JordanaContext(DbContextOptions<JordanaContext> options) : base(options) { }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingMember> BookingMembers { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<SiteMedium> SiteMedia { get; set; } = null!;
        public virtual DbSet<TouristsSite> TouristsSites { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserFavorite> UserFavorites { get; set; } = null!;
        public virtual DbSet<SupportMessage> SupportMessages { get; set; } = null!;
        public virtual DbSet<PaymentCard> PaymentCards { get; set; } = null!;
     



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);
                entity.Property(e => e.BookingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Booking_ID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime").HasColumnName("Booking_Date");
                entity.Property(e => e.BookingEndDate).HasColumnType("datetime").HasColumnName("Booking_EndDate");
                entity.Property(e => e.BookingStatus).HasMaxLength(15).IsUnicode(false).HasColumnName("Booking_Status");
                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.SiteId).HasColumnName("Site_ID");
                entity.Property(e => e.Transportation).IsUnicode(false);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteBook");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBook");
            });

            modelBuilder.Entity<BookingMember>(entity =>
            {
                entity.HasKey(e => e.MemId).HasName("PK_Mem");
                entity.ToTable("Booking_Members");

                entity.Property(e => e.MemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Mem_ID");

                entity.Property(e => e.BookingId).HasColumnName("Booking_ID");
                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.Gender).IsUnicode(false);
                entity.Property(e => e.Name).IsUnicode(false);
                entity.Property(e => e.NationalId).HasMaxLength(10).IsUnicode(false).HasColumnName("NationalID");
                entity.Property(e => e.PassportNumber).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.PhoneNumber).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.ReferencePhoneNumber).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingMembers)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BI");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId);
                entity.Property(e => e.ReviewId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Review_ID");

                entity.Property(e => e.Comment).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.Rating).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.ReviewDate).HasColumnType("datetime").HasColumnName("Review_Date");
                entity.Property(e => e.SiteId).HasColumnName("Site_ID");
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Site");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User");
            });

            modelBuilder.Entity<SiteMedium>(entity =>
            {
                entity.HasKey(e => e.MediaId).HasName("PK_Media");
                entity.ToTable("Site_Media");

                entity.Property(e => e.MediaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Media_ID");

                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.SiteId).HasColumnName("Site_ID");
                entity.Property(e => e.Type).IsUnicode(false);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
                entity.Property(e => e.Url).IsUnicode(false).HasColumnName("URL");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.SiteMedia)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_SM");
            });

            modelBuilder.Entity<TouristsSite>(entity =>
            {
                entity.HasKey(e => e.SiteId).HasName("PK_Site");
                entity.ToTable("Tourists_Sites");

                entity.HasIndex(e => e.SiteName, "UK_Name").IsUnique();

                entity.Property(e => e.SiteId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Site_ID");

                entity.Property(e => e.Category).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.City).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.EntryFee).HasMaxLength(20).IsUnicode(false).HasColumnName("Entry_Fee");
                entity.Property(e => e.OpeningHours).HasMaxLength(20).IsUnicode(false).HasColumnName("Opening_Hours");
                entity.Property(e => e.Region).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.SiteDescription).HasMaxLength(1000).IsUnicode(false).HasColumnName("Site_Description");
                entity.Property(e => e.SiteLocation).HasMaxLength(100).IsUnicode(false).HasColumnName("Site_Location");
                entity.Property(e => e.SiteName).HasMaxLength(30).IsUnicode(false).HasColumnName("Site_Name");
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.Email, "UK_Email").IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("User_ID");

                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.PhoneNumber).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.ProfileImage).IsUnicode(false);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
                entity.Property(e => e.UserType).HasMaxLength(10).IsUnicode(false).HasColumnName("User_Type");
                entity.Property(e => e.Username).HasMaxLength(60).IsUnicode(false);
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasKey(e => e.FavId).HasName("PK_Fav");
                entity.ToTable("User_Favorite");

                entity.Property(e => e.FavId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Fav_ID");

                entity.Property(e => e.CreatedBy).IsUnicode(false).HasDefaultValueSql("('System')");
                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(now())");
                entity.Property(e => e.SiteId).HasColumnName("Site_ID");
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_SF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UF");
            });
            modelBuilder.Entity<SupportMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");
            });
            modelBuilder.Entity<PaymentCard>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.PaymentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PaymentId");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
