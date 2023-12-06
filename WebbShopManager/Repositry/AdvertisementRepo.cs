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
        private static string _connString = "Data Source=DESKTOP-F2QGBSH\\SQLEXPRESS;Initial Catalog=WebbShopAdvertisements;Integrated Security=true;trustservercertificate=true";

        public static List<Advertisement> GetAllAdvertisements()
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                return db.Query<Advertisement>("ShowAllAdvertisements",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Advertisement> SearchForAdvertisement()
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters(); 


                return db.Query<Advertisement>("SearchForAdvertisementByName",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
