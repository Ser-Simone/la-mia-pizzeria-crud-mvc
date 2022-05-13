using Pizzeria_Simone.Models;

namespace Pizzeria_Simone.Utils
{
    public static class PizzaData
    {
        private static List<Pizza> pizzas;

        public static List<Pizza> GetPizza()
        {
            if (PizzaData.pizzas != null)
            {
                return PizzaData.pizzas;
            }

            List<Pizza> nuovaPizza = new List<Pizza>();

         
                //Pizza pizza = new Pizza(0, "Titolo post: " , "Lorem Ipsum...."," ", 5);
                //Nuovapizza.Add(pizza);
            
            PizzaData.pizzas = nuovaPizza;
            return PizzaData.pizzas;
        }
        
    }
}
