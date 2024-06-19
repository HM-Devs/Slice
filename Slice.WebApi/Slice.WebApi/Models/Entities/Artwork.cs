using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slice.WebApi.Models.Entities
{
    public class Artwork
    {
        public Guid ArtworkId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<ArtworkCategory> ArtworkCategories { get; set; } = new List<ArtworkCategory>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
