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
                        } while (!CheckNumberValidity.IntcheckerOneToTwo(smInput, out resultSearch));

                        int smNumberInput = resultSearch;
                        switch (smNumberInput)
                        {
                            case 1:
                                {
                                    foreach (var advertisement in AdvertisementRepo.GetAllAdvertisements())
                                    {
                                        Console.WriteLine(advertisement.AdvertisementID.ToString() + " " + advertisement.Title + " " + advertisement.DescriptionColumn + " " + advertisement.Price);
                                    }
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
                                        Console.WriteLine(advertisement.AdvertisementID.ToString() + " " + advertisement.Title + " " + advertisement.DescriptionColumn + " " + advertisement.Price);
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

