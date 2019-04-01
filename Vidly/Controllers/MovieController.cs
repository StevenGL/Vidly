using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();

            //var Test = ValidacionCedula.isCedulaValida("402-2529783-6");

           // if (User.IsInRole(RoleName.CanManageMovies))
            return View("List", movie);

           // return View("ReadOnlyList", movie);

        }

       // [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewmodel = new MovieFormViewModel(new Movie())
            {
                Genres = genre
                
            };

            return View("MovieForm",viewmodel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var viewmodel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewmodel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.RealeseDate = movie.RealeseDate;
                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.Stock = movie.Stock;
            }

            _context.SaveChanges();
          
            return RedirectToAction("Index","Movie");
        }

        public ActionResult Edit (int id)
        {

            var movie = _context.Movies.Include(c => c.Genre).Single(c => c.Id == id);
            
            if (movie ==  null)
            {
                return HttpNotFound();
            }

            else
            {
                var viewmodel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm",viewmodel);
            }

            
        }

        public ActionResult DeteteMovie(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            
            return RedirectToAction("Index","Movie");
        }


    }
}
