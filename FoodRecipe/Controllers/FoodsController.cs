using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Model;


using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using FoodRecipe.DAL;

namespace FoodRecipe.Controllers
{


    
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
       
        private readonly FoodContext _context;
        private IFoodRepository foodRepository;
        private readonly IMapper _mapper;

        public FoodsController(FoodContext context)
        {
            _context = context;
            
           
        }


        // GET: api/Foods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFood()
        {
            var result = from food in _context.Food
                         join restaurant in _context.Restaurant on food.FoodId equals restaurant.Restaurant1
                         select new
                         {
                             id = food.FoodId,
                             name = food.Title,
                             restaurantName = restaurant.Names
                         };



            return await _context.Food.ToListAsync();
        }

        // GET: api/Foods/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var food = await _context.Food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

      

        // PUT: api/Foods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

      

        // POST: api/Foods
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Food.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new { id = food.FoodId }, food);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        
        public async Task<ActionResult<Food>> DeleteFood(int id)
        {
            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Food.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        [HttpGet("SearchByVideoName/{searchString}")]

        public async Task<List<Food>> SearchVideo(string searchString)

        {

            var recipeTitles = from m in _context.Food

                              select m; //get all the videos

            if (!String.IsNullOrEmpty(searchString))

            {

                recipeTitles = recipeTitles.Where(s => s.Title.Contains(searchString));

            }

            var returned = await recipeTitles.ToListAsync();



            return returned;

        }

        private bool FoodExists(int id)
        {
            return _context.Food.Any(e => e.FoodId == id);
        }
    }
}
