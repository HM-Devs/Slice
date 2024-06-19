using System;
using System.ComponentModel.DataAnnotations;

namespace Slice.WebApi.Models.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
    }
}
