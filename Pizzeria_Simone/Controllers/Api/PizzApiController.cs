using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_Simone.Data;
using Pizzeria_Simone.Models;

namespace Pizzeria_Simone.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Pizza> listapizza = new List<Pizza>();

            using (BlogContext databPizza = new BlogContext())
            {
                listapizza = databPizza.Pizzaset.ToList<Pizza>();
            }
            return Ok(listapizza);
        }
      
        [HttpPost]
        public IActionResult FavouritesController ()
        {
            List<Pizza> listapizza = new List<Pizza>();



            return Ok(listapizza);
        }
    }
}
