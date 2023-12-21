using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using WebbShopManager.Repositry;
using WebbShopManager.Views.UI;
using WebbShopManager.Views.UIController.CRUD;

namespace WebbShopManager.Views.UIController
{
    public static class MenuControllerLogic
    {
        public static void MenuPlayer()
        {
            Menus.ViewMainMenu();

            string mmInput;
            int result;

            do
            {
                EnterX.EnterDefault();
                mmInput = Console.ReadLine();
                Exit.Do_You_Want_To_Exit_To_Main_Menu(mmInput);
            } while (!CheckNumberValidity.IntcheckerOneToFour(mmInput, out result));

            int mmNumberInput = result;
            switch (mmNumberInput)
            {
                case 2:
                    {
                        Menus.ViewSearchMenu();

                        string smInput;
                        int resultSearch;

                        do
                        {
                            EnterX.EnterDefault();
                            smInput = Console.ReadLine();
                            Exit.Do_You_Want_To_Exit_To_Main_Menu(smInput);
                        } while (!CheckNumberValidity.IntcheckerOneToThree(smInput, out resultSearch));

                        int smNumberInput = resultSearch;
                        switch (smNumberInput)
                        {
                            case 1:
                                {
                                    if (AdvertisementRepo.GetIDs() == 0)
                                    {
                                        Errors.NoAds();
                                        Console.ReadLine();
                                        Console.Clear();
                                        MenuPlayer();
                                    }
                                    foreach (var advertisement in AdvertisementRepo.GetAllAdvertisements())
                                    {
                                        Console.WriteLine("ID: \"" + advertisement.AdvertisementID.ToString() + "\" Title : \"" + advertisement.Title);
                                    }
                                    EnterX.EnterIDToExpand();
                                    int selectedID;
                                    while ((!int.TryParse(Console.ReadLine(), out selectedID) || !AdvertisementRepo.GetIDRange().Contains(selectedID)))
                                    {
                                        InvalidX.InvalidNumber();
                                    }

                                    var objectsList = AdvertisementRepo.GetAllAdvertisements2();
                                    Advertisement selectedObject = objectsList.Find(obj => obj.AdvertisementID == selectedID);

                                    // Display the details of the selected object
                                    Console.WriteLine($"\nSelected Advertisement: {selectedObject.AdvertisementID}");
                                    Console.WriteLine($"Title: {selectedObject.Title + " Description: " +  selectedObject.DescriptionColumn}" + " Price: " + selectedObject.Price + " CategoryID: " + selectedObject.CategoryID);
                                    Console.ReadLine();
                                    Console.Clear();
                                    MenuPlayer();
                                    break;
                                }
                            case 2:
                                {
                                    EnterX.EnterTitel();
                                    string title = Console.ReadLine();
                                    foreach (var advertisement in AdvertisementRepo.SearchForAdvertisement(title))
                                    {
                                        Console.WriteLine("ID: \"" + advertisement.AdvertisementID.ToString() + "\" Title : \"" + advertisement.Title + "\" Description: \"" + advertisement.DescriptionColumn + "\" Price: \"" + advertisement.Price + "\"");
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                    MenuPlayer();
                                    break;
                                }
                            case 3:
                                {
                                    EnterX.EnterCategoryName();
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Search results: ");
                                    foreach (var advertisement in AdvertisementRepo.SearchAdvertisementsByCategoryName(title))
                                    {
                                        Console.WriteLine("ID: \"" + advertisement.AdvertisementID.ToString() + "\" Title : \"" + advertisement.Title + "\" Description: \"" + advertisement.DescriptionColumn + "\" Price: \"" + advertisement.Price + "\"");
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                    MenuPlayer();
                                    break;
                                }
                        }
                    }
                    break;
                case 1:
                    {
                        InsertLogic.InsertAdvertisementLogic();
                        Console.Clear();
                        MenuPlayer();
                        break;
                    }
                case 4:
                    {
                        DeleteLogic.DeleteAdvertisement();
                        Console.Clear();
                        MenuPlayer();
                        break;
                    }
                case 3:
                    {
                        UpdateLogic.UpdateAdvertisementLogic();
                        Console.Clear();
                        MenuPlayer();
                        break;
                    }
            }
        }
    }
}

