using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Views.UI;

namespace WebbShopManager.Views.UIController
{
    public static class MenuControllerLogic
    {
        public static void MenuPlayer()
        {
            UserInterface.ViewMainMenu();

            string mmInput;
            int result;

            do
            {
                UserInterface.ViewInputField();
                mmInput = Console.ReadLine();
            } while (!CheckNumberValidity.IntcheckerOneToFour(mmInput, out result));

            int mmNumberInput = result;
            switch (mmNumberInput)
            {
                case 1:
                    {
                        UserInterface.ViewSearchMenu();

                        string smInput;
                        int resultSearch;

                        do
                        {
                            UserInterface.ViewInputField();
                            smInput = Console.ReadLine();
                        } while (!CheckNumberValidity.IntcheckerOneToTwo(smInput, out resultSearch));

                        int smNumberInput = resultSearch;
                        switch (smNumberInput)
                        {
                            case 1 :
                                {

                                }
                        }
                    }
            }
        }
    }
}

