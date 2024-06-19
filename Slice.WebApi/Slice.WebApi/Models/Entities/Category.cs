using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slice.WebApi.Models.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ArtworkCategory> ArtworkCategories { get; set; } = new List<ArtworkCategory>();
    }
}
