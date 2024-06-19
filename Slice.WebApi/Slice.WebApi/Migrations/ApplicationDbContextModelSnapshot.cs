﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slice.WebApi.Models;

#nullable disable

namespace Slice.WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Artwork", b =>
                {
                    b.Property<Guid>("ArtworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtworkId");

                    b.HasIndex("UserId");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.ArtworkCategory", b =>
                {
                    b.Property<Guid>("ArtworkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtworkId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArtworkCategories");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtworkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentId");

                    b.HasIndex("ArtworkId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Reaction", b =>
                {
                    b.Property<Guid>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtworkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReactionType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReactionId");

                    b.HasIndex("ArtworkId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Artwork", b =>
                {
                    b.HasOne("Slice.WebApi.Models.Entities.User", "User")
                        .WithMany("Artworks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.ArtworkCategory", b =>
                {
                    b.HasOne("Slice.WebApi.Models.Entities.Artwork", "Artwork")
                        .WithMany("ArtworkCategories")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Slice.WebApi.Models.Entities.Category", "Category")
                        .WithMany("ArtworkCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Comment", b =>
                {
                    b.HasOne("Slice.WebApi.Models.Entities.Artwork", "Artwork")
                        .WithMany("Comments")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Slice.WebApi.Models.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Reaction", b =>
                {
                    b.HasOne("Slice.WebApi.Models.Entities.Artwork", "Artwork")
                        .WithMany("Reactions")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Slice.WebApi.Models.Entities.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Artwork", b =>
                {
                    b.Navigation("ArtworkCategories");

                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.Category", b =>
                {
                    b.Navigation("ArtworkCategories");
                });

            modelBuilder.Entity("Slice.WebApi.Models.Entities.User", b =>
                {
                    b.Navigation("Artworks");

                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
