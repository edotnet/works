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

                Console.WriteLine($"Product is ready");
                Console.WriteLine($"Your balance - {Purse.Balance}");
                Console.WriteLine("Choose another coffee or add money or enter 0 for take money.\n");

                unitOfWork.SaveChanges();
            }
            else if (Purse.Balance < cof.Price)
            {
                Console.WriteLine("You have not enought money.\n");
            }
            else
            {
                Console.WriteLine("We are sorry but we have not enought ingredients.\n");
            }
        }
    }
}
