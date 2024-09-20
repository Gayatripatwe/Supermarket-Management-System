using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket_Managementsystem.Models;
using Supermarket_multiplemodels.Data;

namespace Supermarket_Managementsystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly marketDbContext _Mdb;
        public CategoryController(marketDbContext Mdb)
        {
            _Mdb = Mdb;
        }
        //action method for getting category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> getcategorybyid(int id)
        {
            var i = await _Mdb.Categories.FindAsync(id);
            if (i == null)
            {
                return NotFound();
            }
            return Ok(i);
        }

        //action method for create category
        [HttpPost]
        public IActionResult createcategory(Category c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _Mdb.Categories.Add(c);
            _Mdb.SaveChanges();
            return Ok();
        }

        //action method for delete
        [HttpDelete("{id}")]
        public IActionResult deletebyid(int id)
        {
            var c = _Mdb.Categories.Find(id);
            if (c==null)
            {
                return NotFound();
            }
            _Mdb.Categories.Remove(c);
            _Mdb.SaveChanges();
            return NoContent();
        }

        ///action method for editing category <summary>
        [HttpPut("{id}")]
        public IActionResult Editcategorybyid(int id,Category newc)
        {
            var c = _Mdb.Categories.Find(id);
            if (c == null)
            {
                return NotFound(newc);
            }
               if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            
            c.name = newc.name;
            c.discription = newc.discription;
            _Mdb.SaveChanges();
            return Ok(c);

        }

        [HttpPatch("{id}")]
        public IActionResult editcatpartiallbyid(int id,Category newc)
        {
            var c = _Mdb.Categories.Find(id);
            if (c == null)
            {
                return NotFound(c);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            c.name = newc.name;
            c.discription = newc.discription;
            _Mdb.SaveChanges();
            return Ok(c);
        }

        


    }
}
