using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Supermarket_Managementsystem.DTOS;
using Supermarket_Managementsystem.Models;
using Supermarket_multiplemodels.Data;

namespace Supermarket_Managementsystem.Controllers
{
    [ApiController]
    [Route("oiapi/[controller]")]
    public class OrderitemController : Controller
    {
        private readonly marketDbContext _mdb;
        public OrderitemController(marketDbContext mdb)
        {
            _mdb = mdb;
        }

        [HttpPost("saveitem")]
        public IActionResult saveitem(itemdto i)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var item = new Orderitem
            {
                id= i.id,
                price=i.price,
                Quantity=i.Quantity,
                orderid=i.orderid,
                productid=i.productid
            };
            _mdb.orderitems.Add(item);
            _mdb.SaveChanges();
            return Ok(i);
        }

        [HttpGet("{id}")]
        public IActionResult getitem(int id)
        {
            var c = _mdb.orderitems.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteitem(int id)
        {
            var c = _mdb.orderitems.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            _mdb.orderitems.Remove(c);
            _mdb.SaveChanges();
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult edititem(int id,itemdto i)
        {
            var c = _mdb.orderitems.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            c.id = i.id;
            c.Quantity = i.Quantity;
            c.price = i.price;
            
            _mdb.SaveChanges();
            return Ok(c);
        }

    }
}
