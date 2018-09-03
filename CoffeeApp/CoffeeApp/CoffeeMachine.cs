using CoffeeApp.Data;
using CoffeeApp.Data.Models;
using System;
using System.Linq;

namespace CoffeeApp
{
    public class CoffeeMachine
    {
        UnitOfWork unitOfWork;
        public CoffeeMachine()
        {
            unitOfWork = new UnitOfWork();
        }

        public void MakeCoffee(int index)
        {
            Coffee cof = unitOfWork.Coffee.Get(index - 1);
            var ing = unitOfWork.Ingredients.GetAll().First();

            if (Purse.Balance >= cof.Price && ing.Coffe >= cof.Coffe
                && ing.Sugar >= cof.Sugar && ing.Water >= cof.Sugar)
            {
                Purse.Remove(cof.Price);

                ing.Coffe -= cof.Coffe;
                ing.Sugar -= cof.Sugar;
                ing.Water -= cof.Water;

                Console.WriteLine($"\nProduct is ready");
                Console.WriteLine($"Your balance - {Purse.Balance}");
                Console.WriteLine("Choose another coffee or add money or you can end by pressing 0ю");

                unitOfWork.SaveChanges();
            }
            else if (Purse.Balance < cof.Price)
            {
                Console.WriteLine("\nNot enought money.");
                ShowAllCoffies();
            }
            else
            {
                Console.WriteLine("\nWe are sorry but we do not have enough ingredients.");
                ShowAllCoffies();
            }
        }

        public void ShowAllCoffies()
        {
            Console.WriteLine("\nAll Available Coffee");
            Console.WriteLine(new string('-', 20));
            int x = 0;
            var ing = unitOfWork.Ingredients.GetAll().First();
            foreach (var item in unitOfWork.Coffee.GetAll())
            {
                x++;
                if (Purse.Balance >= item.Price && ing.Coffe >= item.Coffe
                && ing.Sugar >= item.Sugar && ing.Water >= item.Sugar)
                    Console.WriteLine(x + " : " + item.Name + " : " + item.Price);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();
        }
    }
}
