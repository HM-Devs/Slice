using System;
using System.ComponentModel.DataAnnotations;

namespace Slice.WebApi.Models.Entities
{
    public class Reaction
    {
        public Guid ReactionId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid ArtworkId { get; set; }
        public Artwork Artwork { get; set; }

        [Required]
        public ReactionType ReactionType { get; set; }
    }
}
