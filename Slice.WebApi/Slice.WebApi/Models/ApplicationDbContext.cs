using Microsoft.EntityFrameworkCore;
using Slice.WebApi.Models.Entities;

namespace Slice.WebApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ArtworkCategory> ArtworkCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.HasMany(u => u.Artworks)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Comments)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Reactions)
                      .WithOne(r => r.User)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Artwork configurations
            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.HasKey(a => a.ArtworkId);

                entity.HasMany(a => a.Comments)
                      .WithOne(c => c.Artwork)
                      .HasForeignKey(c => c.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.Reactions)
                      .WithOne(r => r.Artwork)
                      .HasForeignKey(r => r.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.ArtworkCategories)
                      .WithOne(ac => ac.Artwork)
                      .HasForeignKey(ac => ac.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Comment configurations
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);

                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Artwork)
                      .WithMany(a => a.Comments)
                      .HasForeignKey(c => c.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Category configurations
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);

                entity.HasMany(c => c.ArtworkCategories)
                      .WithOne(ac => ac.Category)
                      .HasForeignKey(ac => ac.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Reaction configurations
            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.HasKey(r => r.ReactionId);

                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reactions)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Artwork)
                      .WithMany(a => a.Reactions)
                      .HasForeignKey(r => r.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ArtworkCategory configurations
            modelBuilder.Entity<ArtworkCategory>(entity =>
            {
                entity.HasKey(ac => new { ac.ArtworkId, ac.CategoryId });

                entity.HasOne(ac => ac.Artwork)
                      .WithMany(a => a.ArtworkCategories)
                      .HasForeignKey(ac => ac.ArtworkId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ac => ac.Category)
                      .WithMany(c => c.ArtworkCategories)
                      .HasForeignKey(ac => ac.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
