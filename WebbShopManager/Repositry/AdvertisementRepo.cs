using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WebbShopManager.Repositry
{
    public static class AdvertisementRepo
    {
        private static string _connString = "Data Source=DESKTOP-F2QGBSH\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=true;trustservercertificate=true";

        public static List<Advertisement> GetAllAdvertisements()
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                return db.Query<Advertisement>("ShowAllAdvertisements",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
