using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context= new ApplicationDbContext();
        }

        //GET/api/customers
        public IEnumerable<CustomerDto> Getcustomers()
        {
           return _context.Customerses.Include(c => c.MembershipType).ToList().
                Select(Mapper.Map<Customers, CustomerDto>);
        }

        //GET/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customerses.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<Customers,CustomerDto>(customer));
        }

        //POST/api/customers
        [HttpPost]
        public IHttpActionResult CreaCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customer = Mapper.Map<CustomerDto, Customers>(customerDto);

            _context.Customerses.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        // PUT/api/Customers
        [HttpPut]
        public void UpdateCustomers(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customerses.SingleOrDefault(c => c.Id == id);

            if (customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        //DELETE/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customerses.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customerses.Remove(customer);
            _context.SaveChanges();
        }

    }
}
