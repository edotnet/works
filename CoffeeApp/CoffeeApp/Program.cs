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
                    Console.WriteLine("\nPlease enter money or coffee index.\n");
                    input = -1;
                }
                if (input > 0 && input <= 10)
                {
                    machine.MakeCoffee(input);
                }
                else if (input > 10)
                {
                    Purse.Add(input);
                    Console.WriteLine($"\nYour balance {Purse.Balance}\n");
                }
                else if (input == 0)
                {
                    Console.WriteLine("\nThank you.");
                    Console.WriteLine($"Get back - {Purse.Balance}");
                    Purse.Remove(Purse.Balance);
                    Thread.Sleep(1500);
                }

            } while (input != 0);
        }
    }
}
