using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopManager.Views.UIController
{
    public static class CheckNumberValidity
    {
        public static bool IntcheckerOneToFour(string input, out int result)
        {
            string inputString = input;
            if (int.TryParse(inputString, out int outputInt) && (outputInt >= 1 && outputInt <= 4))
            {
                result = outputInt;
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }

        public static bool IntcheckerOneToTwo(string input, out int result)
        {
            string inputString = input;
            if (int.TryParse(inputString, out int outputInt) && (outputInt >= 1 && outputInt <= 2))
            {
                result = outputInt;
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }
    }
}

