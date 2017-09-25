using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.CustomerSet
                .Include(m=>m.MembershipTypes)
                .ToList()
                .Select(Mapper.Map<Customers, CustomersDto>);
       
               
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.CustomerSet.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomersDto>(customer));

        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomersDto, Customers>(customerDto);
            customer.Id = _context.CustomerSet.ToList().Count + 1;

            customerDto.Id = customer.Id;
            _context.CustomerSet.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existedCustomer = _context.CustomerSet.SingleOrDefault(c => c.Id == id);
            if (existedCustomer == null)
                return NotFound();
            Mapper.Map(customersDto,existedCustomer);
            _context.SaveChanges();
            return Ok("Customer with id " + id + " was updated");
        }

        [HttpDelete]

        public IHttpActionResult DeleteCustomer(int id)
        {
            var existedCustomer = _context.CustomerSet.SingleOrDefault(c => c.Id == id);
            if (existedCustomer == null)
                return NotFound();

            _context.CustomerSet.Remove(existedCustomer);
            _context.SaveChanges();

            return Ok("Customer with id " + " was deleted");
        }
    }
}
