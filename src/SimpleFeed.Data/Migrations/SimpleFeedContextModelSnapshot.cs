using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleFeed.Data;

namespace SimpleFeed.Data.Migrations
{
    [DbContext(typeof(SimpleFeedContext))]
    partial class SimpleFeedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SimpleFeed.Core.User.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("creator_id");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsPublished")
                        .HasColumnName("is_published")
                        .HasColumnType("bit(1)");

                    b.HasKey("Id");

                    b.ToTable("feed_entries");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FeedEntryEntity");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.CommentVoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("creator_id");

                    b.Property<bool>("IsPositive")
                        .HasColumnName("is_positive")
                        .HasColumnType("bit(1)");

                    b.Property<Guid?>("VotedCommentId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("VotedCommentId");

                    b.ToTable("feed_entry_comment_vote");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.FeedEntryCommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("binary(16)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnName("comment_content");

                    b.Property<Guid?>("CommentedEntityId")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("creator_id");

                    b.HasKey("Id");

                    b.HasIndex("CommentedEntityId");

                    b.ToTable("feed_entry_comment");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.FeedEntryVoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("creator_id");

                    b.Property<bool>("IsPositive")
                        .HasColumnName("is_positive");

                    b.Property<Guid?>("VotedEntryId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("VotedEntryId");

                    b.ToTable("feed_entry_vote");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.FeedEntries.ExternalLinkFeedEntryEntity", b =>
                {
                    b.HasBaseType("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity");

                    b.Property<string>("LinkAddress")
                        .IsRequired()
                        .HasColumnName("link_uri");

                    b.ToTable("ExternalLinkFeedEntryEntity");

                    b.HasDiscriminator().HasValue("ExternalLinkFeedEntryEntity");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.FeedEntries.UploadedFileFeedEntryEntity", b =>
                {
                    b.HasBaseType("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity");

                    b.Property<string>("RelativeFilePath")
                        .IsRequired()
                        .HasColumnName("relative_file_path");

                    b.ToTable("UploadedFileFeedEntryEntity");

                    b.HasDiscriminator().HasValue("UploadedFileFeedEntryEntity");
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.FeedEntries.UploadedTextFeedEntryEntity", b =>
                {
                    b.HasBaseType("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("text_content");

                    b.ToTable("UploadedTextFeedEntryEntity");

                    b.HasDiscriminator().HasValue("UploadedTextFeedEntryEntity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SimpleFeed.Core.User.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SimpleFeed.Core.User.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleFeed.Core.User.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.CommentVoteEntity", b =>
                {
                    b.HasOne("SimpleFeed.Data.Entities.Interactions.FeedEntryCommentEntity", "VotedComment")
                        .WithMany("Votes")
                        .HasForeignKey("VotedCommentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.FeedEntryCommentEntity", b =>
                {
                    b.HasOne("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity", "CommentedEntity")
                        .WithMany("Comments")
                        .HasForeignKey("CommentedEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleFeed.Data.Entities.Interactions.FeedEntryVoteEntity", b =>
                {
                    b.HasOne("SimpleFeed.Data.Entities.FeedEntries.FeedEntryEntity", "VotedEntry")
                        .WithMany("Votes")
                        .HasForeignKey("VotedEntryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
