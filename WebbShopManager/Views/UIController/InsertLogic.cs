using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using WebbShopManager.Repositry;

namespace WebbShopManager.Views.UIController
{
    public static class InsertLogic
    {
        private static void UIInsertAdvertisement()
        {
            try
            {
                AdvertisementRepo advertisementRepo = new AdvertisementRepo();
                Advertisement advertisement = new Advertisement();

                while (string.IsNullOrEmpty(advertisement.Title))
                {
                    Console.WriteLine("Enter a Title: ");
                    advertisement.Title = Console.ReadLine();
                }

                while (string.IsNullOrEmpty(advertisement.DescriptionColumn))
                {
                    Console.WriteLine("Enter Description: ");
                    advertisement.DescriptionColumn = Console.ReadLine();
                }

                bool validPrice = false;
                while (!validPrice)
                {
                    Console.WriteLine("Enter Price: ");
                    string priceInput = Console.ReadLine();

                    if (decimal.TryParse(priceInput, out decimal price))
                    {
                        advertisement.Price = price;
                        validPrice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid numeric value.");
                    }
                }
                AdvertisementRepo.InsertAdvertisement(advertisement);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
