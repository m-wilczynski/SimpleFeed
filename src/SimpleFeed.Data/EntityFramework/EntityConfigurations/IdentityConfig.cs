namespace SimpleFeed.Data.EntityFramework.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;
    using Core.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public static class IdentityConfig
    {
        public static void WithIdentityMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>(b =>
            {
                b.Property<Guid>("Id").ValueGeneratedOnAdd();
                b.Property<string>("ConcurrencyStamp").IsConcurrencyToken();
                b.Property<string>("Name").HasAnnotation("MaxLength", 256);
                b.Property<string>("NormalizedName").HasAnnotation("MaxLength", 256);

                b.HasKey("Id");
                b.HasIndex("NormalizedName").HasName("RoleNameIndex");
                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd();
                b.Property<string>("ClaimType");
                b.Property<string>("ClaimValue");
                b.Property<Guid>("RoleId").IsRequired();

                b.HasKey("Id");
                b.HasIndex("RoleId");
                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd();
                b.Property<string>("ClaimType");
                b.Property<string>("ClaimValue");
                b.Property<Guid>("UserId").IsRequired();

                b.HasKey("Id");
                b.HasIndex("UserId");
                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.Property<string>("LoginProvider");
                b.Property<string>("ProviderKey");
                b.Property<string>("ProviderDisplayName");
                b.Property<Guid>("UserId").IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");
                b.HasIndex("UserId");
                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.Property<Guid>("UserId");
                b.Property<Guid>("RoleId");

                b.HasKey("UserId", "RoleId");
                b.HasIndex("RoleId");
                b.HasIndex("UserId");
                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.Property<Guid>("UserId");
                b.Property<string>("LoginProvider");
                b.Property<string>("Name");
                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");
                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property<Guid>("Id");
                b.Property<int>("AccessFailedCount");
                b.Property<string>("ConcurrencyStamp").IsConcurrencyToken();
                b.Property<string>("Email").HasAnnotation("MaxLength", 256);
                b.Property<bool>("EmailConfirmed");
                b.Property<bool>("LockoutEnabled");
                b.Property<DateTimeOffset?>("LockoutEnd");
                b.Property<string>("NormalizedEmail").HasAnnotation("MaxLength", 256);
                b.Property<string>("NormalizedUserName").HasAnnotation("MaxLength", 256);
                b.Property<string>("PasswordHash");
                b.Property<string>("PhoneNumber");
                b.Property<bool>("PhoneNumberConfirmed");
                b.Property<string>("SecurityStamp");
                b.Property<bool>("TwoFactorEnabled");
                b.Property<string>("UserName").HasAnnotation("MaxLength", 256);

                b.HasKey("Id");
                b.HasIndex("NormalizedEmail").HasName("EmailIndex");
                b.HasIndex("NormalizedUserName").IsUnique().HasName("UserNameIndex");
                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.HasOne<IdentityRole<Guid>>()
                    .WithMany("Claims")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.HasOne<ApplicationUser>()
                    .WithMany("Claims")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.HasOne<ApplicationUser>()
                    .WithMany("Logins")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.HasOne<IdentityRole<Guid>>()
                    .WithMany("Users")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<ApplicationUser>()
                    .WithMany("Roles")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
