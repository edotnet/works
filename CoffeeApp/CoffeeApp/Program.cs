using System;
using System.Threading;

namespace CoffeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome\n\n");
            CoffeeMachine machine = new CoffeeMachine();
            int input = -1;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please enter money or coffee index.\n");
                    input = -1;
                }
                if (input > 0 && input <= 10)
                {
                    machine.MakeCoffee(input);
                }
                else if (input != 0)
                {
                    Purse.Add(input);
                    Console.WriteLine($"Your balance {Purse.Balance}\n");
                }
                else
                {
                    Console.WriteLine("Thank you.");
                    Console.WriteLine($"Get back - {Purse.Balance}\n");
                    Purse.Remove(Purse.Balance);
                    Thread.Sleep(1500);
                }

            } while (input != 0);
        }
    }
}
