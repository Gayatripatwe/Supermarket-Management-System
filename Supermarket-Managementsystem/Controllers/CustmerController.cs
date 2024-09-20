using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Supermarket_Managementsystem.Models;
using Supermarket_multiplemodels.Data;
using System.Xml.Linq;

namespace Supermarket_Managementsystem.Controllers
{
    [ApiController]
    [Route("cutmapi/[controller]")]
    public class CustmerController : Controller
    {
        private readonly marketDbContext _Mdb;
        public CustmerController(marketDbContext mdb)
        {
            _Mdb = mdb;
        }

        //savecutomer in db
        [HttpPost]
        public IActionResult Savecustomer(Customer c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _Mdb.customers.Add(c);
            _Mdb.SaveChanges();
            return Ok();
        }

        //get customer by id
        [HttpGet("{id}")]
        public IActionResult Getcutomerbyid(int id)
        {
            var c = _Mdb.customers.Find(id);   //find used for searching with primary key 
            if (c == null)
            {
                return NotFound();
            }
            return Ok(c);
        }

        //get customer by name
        //[HttpGet("customer/{n}")]
        //public IActionResult getcutomerbyname(string n)
        //{
        //    var c = _Mdb.customers.FirstOrDefault(x => string.Equals(x.name, n, StringComparison.OrdinalIgnoreCase));      //firstordefault used whene we r finding data without using primary key
        //    if (c == null)
        //    {
        //        return NotFound(n);
        //    }
        //    return Ok(c);
        //}

        // Get customer by name
        [HttpGet("customer/{name}")]
        public IActionResult GetCustomerByName(string name)
        {
            var customer = _Mdb.customers.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
            if (customer == null)
            {
                return NotFound($"Customer with name '{name}' not found.");
            }
            return Ok(customer);
        }


        //deleting cutomer
        [HttpDelete("{id}")]
        public IActionResult deletecutomer(int id)
        {
            var c = _Mdb.customers.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            _Mdb.customers.Remove(c);
            _Mdb.SaveChanges();
            return NoContent();
        }

        //editing cutomer
        [HttpPut("{id}")]
        public IActionResult Editcutomer(int id,Customer newc)
        {
            var c = _Mdb.customers.Find(id);
            if (c == null)
            {
                return NotFound(newc);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            c.name = newc.name;
            c.phoneno = newc.phoneno;
            c.email = newc.email;
            _Mdb.SaveChanges();
            return Ok(c);
        }




    }
}
