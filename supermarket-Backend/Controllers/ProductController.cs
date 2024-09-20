using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Supermarket_Managementsystem.Models;
using Supermarket_multiplemodels.Data;

namespace Supermarket_Managementsystem.Controllers
{
    [ApiController]
    [Route("apiprd/[controller]")]
    public class ProductController : Controller
    {
        private readonly marketDbContext _Mdb;

        public ProductController(marketDbContext mdb)
        {
            _Mdb = mdb;
        }
        //saveing product in market
        [HttpPost]
        public IActionResult saveproduct(Product p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(p);
            }
            _Mdb.Products.Add(p);
            _Mdb.SaveChanges();
            return Ok();
        }
        //getting product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> getproductbyid(int id)
        {
            var p = await _Mdb.Products.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        //get product  by name 
        [HttpGet("name/{name}")]
        public IActionResult getproductbyname(string n)
        {
            var p = _Mdb.Products.FirstOrDefault(x => x.name.ToLower() == n.ToLower());
            if (p == null)
            {
                return NotFound(p);
            }
            return Ok(p);
        }

        //delete product
        [HttpDelete("{id}")]
        public IActionResult deleteproductbyid(int id)
        {
            var p = _Mdb.Products.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            _Mdb.Products.Remove(p);
            _Mdb.SaveChanges();
            return Ok("successfull deleted item with id {id}");
        }

        //editing product
        [HttpPut("{id}")]
        public IActionResult editproductbyid(int id,Product p)
        {
            var c = _Mdb.Products.Find(id);
            if (c == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("model should be valid");
            }
            c.name = p.name;
            c.quantity = p.quantity;
            c.price = p.price;
            c.categoryid = p.categoryid;
            _Mdb.SaveChanges();
            return Ok("data changed successfully");
        }

        //get all products in category (list of product in the category)

        [HttpGet("getproductlist/{categoryname}")]
        public IActionResult GetProductsByCategory(string categoryname)
        {
            var category = _Mdb.Categories.Include(c => c.products).FirstOrDefault(c=>c.name.ToLower() == categoryname.ToLower());
            if(category == null)
            {
                return NotFound($"Category with name'{categoryname}' is not found");
            }
            return Ok(category.products);
        }
        


    }
}
