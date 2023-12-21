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
            bool validID = false;
            do
            {
                EnterX.EnterID();
                string idInput = Console.ReadLine();
                Exit.Do_You_Want_To_Exit_To_Main_Menu(idInput);

                if (int.TryParse(idInput, out int id) && AdvertisementRepo.GetIDRange().Contains(id))
                {
                    validID = true;
                    AdvertisementRepo.Delete(id);
                }
                else
                {
                    InvalidX.InvalidID();
                    validID = false;
                }
            } while (!validID);
        }
    }
}
