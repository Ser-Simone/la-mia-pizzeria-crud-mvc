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
        public IActionResult Get(string? search)
        {
            List<Pizza> listapizza = new List<Pizza>();

            using (BlogContext databPizza = new BlogContext())
            {
                if( search != null && search != "" )
                {
                    listapizza = databPizza.Pizzaset.Where(Pizza => Pizza.Title.Contains(search) || Pizza.Description.Contains(search)).ToList<Pizza>();
                }
                else
                {
                    listapizza = databPizza.Pizzaset.ToList<Pizza>();
                }
                
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
