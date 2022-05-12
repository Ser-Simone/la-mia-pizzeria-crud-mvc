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

            List<Pizza> Nuovapizza = new List<Pizza>();

            for (int i = 0; i < 5; i++)
            {
                Pizza pizza = new Pizza(i, "Titolo post: " +i , "Lorem Ipsum...." , "0 ", 5);
                Nuovapizza.Add(pizza);
            }
            PizzaData.pizzas = Nuovapizza;
            return PizzaData.pizzas;
        }
        
    }
}
