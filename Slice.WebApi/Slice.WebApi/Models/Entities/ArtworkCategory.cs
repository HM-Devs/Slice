using System;

namespace Slice.WebApi.Models.Entities
{
    public class ArtworkCategory
    {
        public Guid ArtworkId { get; set; }
        public Artwork Artwork { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
