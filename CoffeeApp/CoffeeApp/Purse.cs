using System;

namespace CoffeeApp
{
    public static class Purse
    {
        public static decimal Balance { get; private set; } = 0;

        public static void Add(decimal cnt)
        {
            if (cnt != 50 && cnt != 100 && cnt != 200 && cnt != 500)
            {
                Console.WriteLine("\nThe number to be entered must be one of 50 10 200 500.");
                return;
            }

            Balance += cnt;
        }

        public static void Remove(decimal cnt)
        {
            Balance -= cnt;
        }
    }
}
