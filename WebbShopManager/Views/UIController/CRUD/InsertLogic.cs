﻿using Dapper;
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
using WebbShopManager.Views.UI;

namespace WebbShopManager.Views.UIController.CRUD
{
    public static class InsertLogic
    {
        public static void InsertAdvertisementLogic()
        {
            try
            {
                Advertisement advertisement = new Advertisement();

                while (string.IsNullOrEmpty(advertisement.Title))
                {
                    EnterX.EnterTitel();
                    var tinput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(tinput);
                    advertisement.Title = tinput;
                }

                while (string.IsNullOrEmpty(advertisement.DescriptionColumn))
                {
                    EnterX.EnterDescription();
                    var dinput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(dinput);
                    advertisement.DescriptionColumn = dinput;
                }

                bool validPrice = false;
                while (!validPrice)
                {
                    EnterX.EnterPrice();
                    var pinput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(pinput);
                    string priceInput = pinput;

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
                bool validID = false;
                do
                {
                    foreach (var category in CategoryRepo.ShowAllCategories())
                    {
                        Console.WriteLine(category.CategoryID + " " + category.CategoryName);
                    }
                    EnterX.EnterCategotyID();
                    string idInput = Console.ReadLine();
                    Exit.Do_You_Want_To_Exit_To_Main_Menu(idInput);

                    if (int.TryParse(idInput, out int id) && AdvertisementRepo.GetCategoryIDs() >= id)
                    {
                        advertisement.CategoryID = id;
                        validID = true;
                    }
                    else
                    {
                        InvalidX.InvalidID();
                        Console.ReadLine();
                        Console.Clear();    
                        validID = false;
                    }
                } while (!validID);
                
                AdvertisementRepo.InsertAdvertisement(advertisement);
                Console.Clear();
                MenuControllerLogic.MenuPlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
