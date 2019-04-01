using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name.")]
        public string Name { get; set; }

        [Display(Name = "Movie Genre")]
        [Required(ErrorMessage = "Movie Genre is required.")]
        public int GenreId { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int Stock { get; set; }

        [Display(Name = "Realese Date")]
        public DateTime RealeseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            Genre = movie.Genre;
            Stock = movie.Stock;
            RealeseDate = movie.RealeseDate;
            DateAdded = movie.DateAdded;

        }



    }
}