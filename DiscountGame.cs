using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Games
{
    public class DiscountGame
    {
        public void HandleDiscount(string action, string gameName)
        {
            if (action == "Apply Discount")
            {
                Console.WriteLine($"Discount applied to {gameName}!");
            }
            else if (action == "No Discount")
            {
                Console.WriteLine($"No discount for {gameName}.");
            }
            else
            {
                throw new InvalidOperationException("Unknown action");
            }
        }
    }
}
