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
        public static string _connString = "Data Source=DESKTOP-F2QGBSH\\SQLEXPRESS;Initial Catalog=WebbShopAdvertisements;Integrated Security=true;trustservercertificate=true";

        public static List<Advertisement> GetAllAdvertisements()
        {
            using IDbConnection db = new SqlConnection(_connString);
            return db.Query<Advertisement>("ShowAllAdvertisements",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public static List<Advertisement> SearchForAdvertisement(Advertisement ad)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", ad.Title);

            var result = db.Query<Advertisement>("SearchForAdvertisementByName",
                parameters,
                commandType: CommandType.StoredProcedure).ToList();

            return result;
        }

        public static void InsertAdvertisement(Advertisement ad)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", ad.Title);
            parameters.Add("@DescriptionColumn", ad.DescriptionColumn);
            parameters.Add("@Price", ad.Price);
            parameters.Add("@CategoryID", ad.CategoryID);

            db.Execute("InsertAdvertisement", parameters,
                commandType: CommandType.StoredProcedure);
        }

        public static void Delete(int advertisementID)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AdvertisementID", advertisementID);

            db.Execute("DeleteAdvertisement", parameters,
                commandType: CommandType.StoredProcedure);
        }

        public static void Update(Advertisement ad)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@AdvertisementID", ad.AdvertisementID);
            parameters.Add("@Title", ad.Title);
            parameters.Add("@DescriptionColumn", ad.DescriptionColumn);
            parameters.Add("@Price", ad.Price);
            parameters.Add("@CategoryID", ad.CategoryID);

            db.Execute("UpdateAdvertisement", parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
