using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using WebbShopManager.Repositry;
using WebbShopManager.Views.UI;

namespace WebbShopManager.Views.UIController.CRUD
{
    public static class UpdateLogic
    {
        public static void UpdateAdvertisementLogic()
        {
            try
            {
                Advertisement advertisement = new Advertisement();

                bool validID = false;
                do
                {
                    EnterX.EnterID();
                    string idInput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(idInput);

                    if (int.TryParse(idInput, out int id) && AdvertisementRepo.GetIDRange().Contains(id))
                    {
                        advertisement.AdvertisementID = id;
                        validID = true;
                    }
                    else
                    {
                        InvalidX.InvalidID();
                        validID = false;
                    }
                } while (!validID);
                
                while (string.IsNullOrEmpty(advertisement.Title))
                {
                    EnterX.EnterTitel();
                    string titleinput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(titleinput);
                    advertisement.Title = titleinput;
                }

                while (string.IsNullOrEmpty(advertisement.DescriptionColumn))
                {
                    EnterX.EnterDescription();
                    string descriptioninput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(descriptioninput);
                    advertisement.DescriptionColumn = descriptioninput;
                }

                bool validPrice = false;
                while (!validPrice)
                {
                    EnterX.EnterPrice();
                    string priceInput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(priceInput);


                    if (decimal.TryParse(priceInput, out decimal price))
                    {
                        advertisement.Price = price;
                        validPrice = true;
                    }
                    else
                    {
                        InvalidX.InvalidPrice();
                    }
                }
                bool validCategoryID = false;
                do
                {
                    foreach (var category in CategoryRepo.ShowAllCategories())
                    {
                        Console.WriteLine(category.CategoryID + " " + category.CategoryName);
                    }
                    EnterX.EnterCategotyID();
                    string idInput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(idInput);

                    if (int.TryParse(idInput, out int categoryID) && AdvertisementRepo.GetCategoryIDRange().Contains(categoryID))
                    {
                        advertisement.CategoryID = categoryID;
                        validCategoryID = true;
                    }
                    else
                    {
                        InvalidX.InvalidNumber();
                        validID = false;
                    }
                } while (!validCategoryID);
                AdvertisementRepo.Update(advertisement);
                Console.Clear();
                MenuControllerLogic.MenuPlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.Clear();
            }
        }
    }
}
