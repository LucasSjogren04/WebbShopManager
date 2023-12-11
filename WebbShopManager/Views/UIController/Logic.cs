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
    public class Logic
    {
        private static void InsertAdvertisement()
        {
            AdvertisementRepo advertisementRepo = new AdvertisementRepo();
            Advertisement advertisement = new Advertisement();

            try
            {
                while (object.Equals(advertisement.Title,             default(string)) &&
                       object.Equals(advertisement.DescriptionColumn, default(string)) &&
                       object.Equals(advertisement.Price,             default(decimal)))
                { 

                }

                





                //while (advertisement.Title == null
                //    && advertisement.DescriptionColumn == null
                //    && advertisement.Price == null)
                //{

                //}

                //Console.WriteLine("Enter a Title:");
                //advertisement.Title = Console.ReadLine();

                //if (advertisement.Title.IsNullOrEmpty())
                //{
                //    Console.WriteLine("You must fill in a title");
                //}

                //Console.WriteLine("Enter Description:");
                //advertisement.DescriptionColumn = Console.ReadLine();

                //Console.WriteLine("Enter Price:");
                //advertisement.Price = decimal.Parse(Console.ReadLine());  
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value for the Price.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }




            //using IDbConnection db = new SqlConnection(AdvertisementRepo._connString);
            //string sql = $"insert into Suppliers(CompanyName,ContactName,ContactTitle) " +
            //            $"values('{advertisement.Title}',' {advertisement.DescriptionColumn}','{advertisement.Price}')";


            //db.Execute(sql);
        }
    }
}
