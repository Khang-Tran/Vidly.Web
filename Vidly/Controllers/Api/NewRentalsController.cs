﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given..");
            var customer = _context.CustomerSet.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            
            var movies = _context.MovieSet.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            if (customer == null)
                return BadRequest("Customer ID is not valid..");

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movies id is not valid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie with Id " + movie.Id + " is not available");
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.RentalSet.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
