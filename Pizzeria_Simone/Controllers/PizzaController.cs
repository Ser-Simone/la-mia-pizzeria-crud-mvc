using Microsoft.AspNetCore.Mvc;
using Pizzeria_Simone.Data;
using Pizzeria_Simone.Models;

namespace Pizzeria_Simone.Controllers
{

    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> listapizza = new List<Pizza>();
          
            using (BlogContext databPizza = new BlogContext()) 
            {
                listapizza = databPizza.Pizzaset.ToList<Pizza>();
            }
            return View("HomePage", listapizza);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (BlogContext dbPizza = new BlogContext())
            {
                try
                {
                    Pizza pizzaFound = dbPizza.Pizzaset
                        .Where(pizza => pizza.Id == id)
                        .First();

                    return View("Details", pizzaFound);
                } catch (InvalidOperationException ex)
                {
                    return NotFound("la pizza con id" + id + " non è stato trovato");
                } catch (Exception ex)
                {
                    return BadRequest();
                }
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            using(BlogContext dbPizza = new BlogContext())
            {
                List<Category> categories = dbPizza.Category.ToList();

                PizzaCategory category = new PizzaCategory();
                category.Pizza= new Pizza();
            }
            return View("FormPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategory nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                using (BlogContext dbPizza = new BlogContext())
                {
                    List<Category> categories = dbPizza.Category.ToList();
                    nuovaPizza.Categories = categories;
                }

              
                return View("FormPizza", nuovaPizza);
            }

            using (BlogContext dbPizza = new BlogContext())
            {
                Pizza pizzanuova = new Pizza();
                pizzanuova.Title = nuovaPizza.Pizza.Title;
                pizzanuova.Description = nuovaPizza.Pizza.Description;
                pizzanuova.Image = nuovaPizza.Pizza.Image;
                pizzanuova.CategoryId = nuovaPizza.Pizza.CategoryId;

                dbPizza.Pizzaset.Add(pizzanuova);
                dbPizza.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizza? PizzaToEdit = null;
            using (BlogContext dbEdit = new BlogContext())
            {
                PizzaToEdit = dbEdit.Pizzaset
                    .Where(pizza => pizza.Id == id)
                    .FirstOrDefault();
            }

            if (PizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", PizzaToEdit);
            }
        }

        [HttpPost]
        public IActionResult Update(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }
            Pizza PizzaToEdit = null;

            using (BlogContext dbEdit = new BlogContext())
            {
                PizzaToEdit = dbEdit.Pizzaset
                   .Where(pizza => pizza.Id == id)
                   .FirstOrDefault();

                if (PizzaToEdit != null)
                {
                    PizzaToEdit.Title = model.Title;
                    PizzaToEdit.Description = model.Description;
                    PizzaToEdit.Image = model.Image;
                    PizzaToEdit.Price = model.Price;

                    dbEdit.SaveChanges();

                    return RedirectToAction("Index");
                } else
                {
                    return NotFound();
                }
            }
        }
     /*   private Pizza GetPizzaById(int id)
        {
            Pizza pizzaFound = null;

            foreach (Pizza pizza in PizzaData.GetPizza())
            {
                if (pizza.Id == id)
                {
                    pizzaFound = pizza;
                    break;
                }
            }
            return pizzaFound;
        }*/

        [HttpPost]
        public IActionResult Delete(int id)
        {

                
            using (BlogContext dbDelete = new BlogContext())
            {
                Pizza PizzaToRemove = dbDelete.Pizzaset
                    .Where(pizza => pizza.Id == id)
                    .FirstOrDefault();
            
            
            if(PizzaToRemove != null)
                {
                    dbDelete.Pizzaset.Remove(PizzaToRemove);
                    dbDelete.SaveChanges();

                    return RedirectToAction("Index");
                } else
                {
                    return NotFound();
                }
            }   
            
        }
    }

}
            