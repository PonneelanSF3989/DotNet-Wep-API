using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Models;

namespace HelloWorld.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
        {
            new Pizza { ID = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { ID = 2, Name = "Veggie", IsGlutenFree = true }
        };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int ID) => Pizzas.FirstOrDefault(p => p.ID == ID);

        public static void Add(Pizza pizza)
        {
            pizza.ID = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int ID)
        {
            var pizza = Get(ID);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.ID == pizza.ID);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}