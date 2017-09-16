using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.MovieSet.Include(m => m.Genre).ToList();
            return View(movies);
        }


        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                id = 1;
            var selectedMovie = _context.MovieSet.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (selectedMovie == null)
                return HttpNotFound();
            return View(selectedMovie);
        }

        public ActionResult Create()
        {
            var genres = _context.GenreSet.ToList();
            var viewModel = new MoviesViewModel()
            {
                Movie = new Movies(),
                Genres = genres
            };
            TempData["ButtonName"] = "Create";
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {
            if (!ModelState.IsValid)
            {
                Create();
            }
            if (movie.Id == 0)
            {
                movie.Id = _context.MovieSet.ToList().Count + 1;
                movie.AddedDate=DateTime.Now;
                _context.MovieSet.Add(movie);
            }
            else
            {
                var existedMovie = _context.MovieSet.Single(m => m.Id == movie.Id);
                if (existedMovie == null)
                    return HttpNotFound();
                existedMovie.Name = movie.Name;
                existedMovie.GenreId = movie.GenreId;
                existedMovie.ReleasedDate = movie.ReleasedDate;
                existedMovie.Stock = movie.Stock;
            }
            _context.SaveChanges();
            TempData["ButtonName"] = "Save";
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var selectedMovie = _context.MovieSet.SingleOrDefault(m => m.Id == id);
            if (selectedMovie == null)
                return HttpNotFound();
            var viewModel = new MoviesViewModel()
            {
                Movie = selectedMovie,
                Genres = _context.GenreSet.ToList()
            };
            TempData["ButtonName"] = "Edit";
            return View("MoviesForm", viewModel);
        }
    }
}