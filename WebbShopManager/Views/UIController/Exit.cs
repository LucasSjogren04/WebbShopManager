using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopManager.Views.UIController
{
    public static class Exit
    {
        //This is not used
        public static bool Do_You_Want_To_Exit_Question(string input) 
        {
            if (input.ToLower() == "exit")
            {
                return true;
            }
            return false;
        }
        //This is used
        public static bool Do_You_Want_To_Exit_To_Main_Menu(string input)
        {
            if (input.ToLower() == "mainmenu")
            {
                Console.Clear();
                MenuControllerLogic.MenuPlayer();
                return true;
            }
            return false;
        }
    }
}
