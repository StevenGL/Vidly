using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = new List<Movie>
            {
                new Movie { Name = "Sherk"},
                new Movie { Name = "Hitman"}
            };

            /*var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customerses = customer
            };*/

            return View(movie);
        }
    }
}