using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using WebbShopManager.Repositry;

namespace WebbShopManager.Views.UIController
{
    public class DeleteLogic
    {
        public static void UIDeleteAdvertisement()
        {
            AdvertisementRepo advertisementRepo = new AdvertisementRepo();
            Advertisement advertisement = new Advertisement();

            bool validID = false;
            while (!validID)
            {
                Console.WriteLine("Enter the ID of the advertisment you want to delete: ");
                string inputID = Console.ReadLine();
            }
            bool validId = false;
            while (!validId)
            {
                Console.WriteLine("Enter Price: ");
                string priceInput = Console.ReadLine();

                if (int.TryParse(priceInput, out int id))
                {
                    advertisement.Price = id;
                    validId = true;
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid numeric value.");
                }
            }
        }       
    }
}
