using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Movie Genre is required.")]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
        
        [Range(1, 20)]
        public int Stock { get; set; }

        public DateTime RealeseDate { get; set; }

        public DateTime DateAdded { get; set; }
    }
}