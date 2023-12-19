using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopManager.Views.UI
{
    public static class InvalidX
    {
        public static void InvalidNumber()
        {
            Console.WriteLine("Invalid number. Please enter a valid numeric value.");
        }
        public static void InvalidPrice()
        {
            Console.WriteLine("Invalid price. Please enter a valid numeric value.");
        }     
        public static void InvalidID()
        {
            Console.WriteLine("Invalid ID. Please enter a valid ID.");
        }
    }
}
