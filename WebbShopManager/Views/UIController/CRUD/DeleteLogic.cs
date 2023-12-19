using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using WebbShopManager.Repositry;
using WebbShopManager.Views.UI;

namespace WebbShopManager.Views.UIController.CRUD
{
    public class DeleteLogic
    {
        public static void DeleteAdvertisement()
        {
            if (AdvertisementRepo.GetIDs() <= 0)
            {
                Errors.NoAds();
                return;
            }
            bool validID = false;
            do
            {
                EnterX.EnterID();
                string idInput = Console.ReadLine();

                if (int.TryParse(idInput, out int id) && AdvertisementRepo.GetIDs() <= id)
                {
                    validID = true;
                }
                else
                {
                    InvalidX.InvalidNumber();
                    validID = false;
                }
            } while (!validID);
        }
    }
}
