using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Slice.WebApi.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
