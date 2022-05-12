using Microsoft.AspNetCore.Mvc;
using Pizzeria_Simone.Models;
using Pizzeria_Simone.Utils;

namespace Pizzeria_Simone.Controllers
{

    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizza = PizzaData.GetPizza();
            return View("HomePage", pizza);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Pizza pizzaFound = GetPizzaById(id);

            if (pizzaFound != null)
            {
                return View("Details", pizzaFound);
            }
            else
            {
                return NotFound("la pizza con id" + id + " non è stato trovato");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizza", nuovaPizza);
            }

            Pizza pizza = new Pizza(PizzaData.GetPizza().Count, nuovaPizza.Title, nuovaPizza.Description, nuovaPizza.Image, nuovaPizza.Price);
            // il mio modello è corretto

            PizzaData.GetPizza().Add(nuovaPizza);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizza PizzaToEdit = GetPizzaById(id);

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
            Pizza pizzaOriginal = GetPizzaById(id);

            if (pizzaOriginal != null)
            {
                pizzaOriginal.Title = model.Title;
                pizzaOriginal.Description = model.Description;
                pizzaOriginal.Image = model.Image;

                return RedirectToAction("Index");
            } else
            {
                return NotFound();
            }
        }
        private Pizza GetPizzaById(int id)
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
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            int PizzaIndexToRemove = -1;

            List<Pizza> pizzaList = PizzaData.GetPizza();

            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Id == id)
                {
                    PizzaIndexToRemove = i;
                }  
            }

            if (PizzaIndexToRemove >= 0)
            {
                PizzaData.GetPizza().RemoveAt(PizzaIndexToRemove);

                return RedirectToAction("Index");
            }else
            {
                return NotFound();
            }
        }
    }

}
            