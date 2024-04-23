using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WatchShop.Model
{
    public partial class WatchShopDatabaseContext : DbContext
    {
        public WatchShopDatabaseContext()
        {
        }

        public WatchShopDatabaseContext(DbContextOptions<WatchShopDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePrivilege> RolePrivileges { get; set; }
        public virtual DbSet<ScriptHistory> ScriptHistories { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<StyleWatch> StyleWatches { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Watch> Watches { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=WatchShopDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(32, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_Cart_UserId");

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Watch_Cart_WatchId");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).ValueGeneratedNever();

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("Condition");

                entity.Property(e => e.ConditionId).ValueGeneratedNever();

                entity.Property(e => e.ConditionName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.ToTable("Privilege");

                entity.Property(e => e.PrivilegeId).ValueGeneratedNever();

                entity.Property(e => e.PrivilegeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.PurchaseId).ValueGeneratedNever();

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(32, 0)");

                entity.Property(e => e.TimeOfPurchase).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_Purchase_UserId");

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Watch_Purchase_WatchId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RolePrivilege>(entity =>
            {
                entity.ToTable("RolePrivilege");

                entity.Property(e => e.RolePrivilegeId).ValueGeneratedNever();

                entity.HasOne(d => d.Privilege)
                    .WithMany(p => p.RolePrivileges)
                    .HasForeignKey(d => d.PrivilegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Privilege_RolePrivilege_PrivilegeId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePrivileges)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Role_RolePrivilege_RoleId");
            });

            modelBuilder.Entity<ScriptHistory>(entity =>
            {
                entity.ToTable("ScriptHistory");

                entity.Property(e => e.ScriptHistoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.Property(e => e.StyleId).ValueGeneratedNever();

                entity.Property(e => e.StyleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StyleWatch>(entity =>
            {
                entity.HasKey(e => new { e.StyleWatchId, e.StyleId, e.WatchId })
                    .HasName("Pk_StyleWatch_StyleWatchIdStyleIdWatchId");

                entity.ToTable("StyleWatch");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.StyleWatches)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Style_StyleWatch_StyleId");

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.StyleWatches)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Watch_StyleWatch_WatchId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("Pk_UserRole_UserIdRoleId");

                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Role_UserRole_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_UserRole_UserId");
            });

            modelBuilder.Entity<Watch>(entity =>
            {
                entity.ToTable("Watch");

                entity.Property(e => e.WatchId).ValueGeneratedNever();

                entity.Property(e => e.BraceletMaterial)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CaseDiameter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DatePublished).HasColumnType("date");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(32, 0)");

                entity.Property(e => e.ShippingPrice).HasColumnType("decimal(32, 0)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Watches)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Brand_Watch_BrandId");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Watches)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Color_Watch_ColorId");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Watches)
                    .HasForeignKey(d => d.ConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Condition_Watch_ConditionId");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Watches)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Gender_Watch_GenderId");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.WishListId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_WishList_UserId");

                entity.HasOne(d => d.Watch)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.WatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Watch_WishList_WatchId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
