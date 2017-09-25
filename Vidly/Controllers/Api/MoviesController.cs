using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.MovieSet
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movies, MoviesDto>);
            return Ok(movies);
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.MovieSet.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            
            return Ok(Mapper.Map<Movies, MoviesDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDto, Movies>(moviesDto);
            movie.Id = _context.MovieSet.ToList().Count + 1;
            moviesDto.Id = movie.Id;
            _context.MovieSet.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var existedMovie = _context.MovieSet.SingleOrDefault(m => m.Id == id);
            if (existedMovie == null)
                return NotFound();
            Mapper.Map(moviesDto, existedMovie);
            _context.SaveChanges();
            return Ok("Movie with id " + id + " was updated");
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var existedMovie = _context.MovieSet.SingleOrDefault(m => m.Id == id);
            if (existedMovie == null)
                return NotFound();
            _context.MovieSet.Remove(existedMovie);
            _context.SaveChanges();
            return Ok("Movie with id " + id + " was deleted");
        }
    }
}
