using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopManager.Views.UI
{
    public static class Menus
    {
        public static void ViewMainMenu()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("*               Main Menu                  *");
            Console.WriteLine("*                                          *");
            Console.WriteLine("*  Create advertisement:      1            *");
            Console.WriteLine("*  View advertisement(s):     2            *");
            Console.WriteLine("*  Update advertisement:      3            *");
            Console.WriteLine("*  Delete advertisement(s):   4            *");
            Console.WriteLine("*                                          *");
            Console.WriteLine("*                                          *");
            Console.WriteLine("********************************************");
        }
        public static void ViewSearchMenu()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*        Advertisement Menu          *");
            Console.WriteLine("*                                    *");
            Console.WriteLine("*  View all advertisements:     1    *");
            Console.WriteLine("*  Search for an advertisement: 2    *");
            Console.WriteLine("*                                    *");
            Console.WriteLine("**************************************");
        }
    }
}
