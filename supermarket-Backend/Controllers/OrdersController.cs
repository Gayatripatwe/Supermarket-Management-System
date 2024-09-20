using Microsoft.AspNetCore.Mvc;
using Supermarket_Managementsystem.DTOS;
using Supermarket_Managementsystem.Models;
using Supermarket_multiplemodels.Data;

namespace Supermarket_Managementsystem.Controllers
{
    [ApiController]
    [Route("apiorder/[controller]")]
    public class OrdersController : Controller
    {
        private readonly marketDbContext _mdb;
        public OrdersController(marketDbContext mdb)
        {
            _mdb = mdb;
        }

        //posting data
        [HttpPost]
        public IActionResult saveorder(Orderdto o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = new Order
            {
                id = o.id,
                totalprice=o.totalprice,
                date=o.date,
                Customerid=o.Customerid
            };
            _mdb.orders.Add(order);
            _mdb.SaveChanges();
            return Ok(o);
        }

        //getting orders by id
        [HttpGet("{id}")]
        public IActionResult getproductbyid(int id)
        {
            var o = _mdb.orders.Find(id);
            if (o == null)
            {
                return NotFound();
            }
            return Ok(o);
        }

        //get order by customer name


        //delete order
        [HttpDelete("{id}")]
        public IActionResult deletorderbyid(int id)
        {
            var o = _mdb.orders.Find(id);
            if (o == null)
            {
                return NotFound("this order never placed");
            }
            _mdb.orders.Remove(o);
            _mdb.SaveChanges();
            return NoContent();
        }

        //editing order
        [HttpPut("{id}")]
        public IActionResult editorder(int id,Order o)
        {
            var oldo = _mdb.orders.Find(id);
            if (oldo == null)
            {
                return NotFound(oldo);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            oldo.id = o.id;
            oldo.totalprice = o.totalprice;
            oldo.date = o.date;
            oldo.Customerid = o.Customerid;
            _mdb.SaveChanges();
            return Ok(oldo);
        }




    }
}
