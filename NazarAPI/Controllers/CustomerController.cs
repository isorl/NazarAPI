using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NazarAPI;
using NazarAPI.Models;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using AutoMapper;

namespace NazarAPI.Controllers
{


    public class CustomerController : ApiController
    {
        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<Customer> Get()
        {
            IList<Customer> _customers = new List<Customer>();
            DataModel _context = new DataModel();

            _customers = _context.Customers.ToList();
            return _customers;
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public Customer Get(int id)
        {
            Customer _customer = new Customer();
            DataModel _context = new DataModel();

            _customer = _context.Customers.Find(id);
            return _customer;
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public int Post([FromBody]Customer _customer)
        {

            DataModel _context = new DataModel();
            if (_context.Customers.Where(src => src.CustomerName == _customer.CustomerName).ToList().Count() == 0)
            {
                _context.Customers.Add(_customer);
                if (_customer.Transactions != null)
                {
                    foreach (Transaction t in _customer.Transactions)
                    {
                        _context.Transactions.Add(t);
                    }
                }
                _context.SaveChanges();
                return _context.Customers.First(src => src.CustomerName == _customer.CustomerName).Id;
            }
            return 0;
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public int Put(int id, [FromBody]Customer _customer)
        {
            DataModel _context = new DataModel();

                if (_context.Customers.Find(id) != null)
                {
                    _context.Entry(_customer).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    return id;
                }
            return 0;
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public int Delete(int id)
        {
            DataModel _context = new DataModel();

            if (_context.Customers.Find(id) != null)
                {
                    _context.Customers.Remove(_context.Customers.Find(id));
                    _context.SaveChanges();

                    return id;
                }
            return 0;
        }
    }
}
