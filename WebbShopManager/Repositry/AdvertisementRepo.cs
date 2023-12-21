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
        public static List<Advertisement> GetAllAdvertisements2()
        {
            using IDbConnection db = new SqlConnection(_connString);
            return db.Query<Advertisement>("ShowALLAdvertisements2",
                commandType: CommandType.StoredProcedure).ToList();
        }



        //public static List<Advertisement> SearchForAdvertisement(Advertisement ad)
        //{
        //    using IDbConnection db = new SqlConnection(_connString);
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@Title", ad.Title);

        //    var result = db.Query<Advertisement>("SearchForAdvertisementByName",
        //        parameters,
        //        commandType: CommandType.StoredProcedure).ToList();

        //    return result;
        //}

        public static List<Advertisement> SearchForAdvertisement(string search)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SearchCondition", search);

            var model = db.Query<Advertisement>("SearchForAdvertisementByName", parameters,
                commandType: CommandType.StoredProcedure).ToList();

            return model;
        }

        public static List<Advertisement> SearchAdvertisementsByCategoryName(string search)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryName", search);

            var model = db.Query<Advertisement>("SearchAdvertisementsByCategoryName", parameters,
                commandType: CommandType.StoredProcedure).ToList();

            return model;
        }


        public static List<Advertisement> SearchFor(string search)
        {
            using IDbConnection db = new SqlConnection(_connString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SearchCondition", search);

            var model = db.Query<Advertisement>("SearchForAdvertisementByName", parameters,
                commandType: CommandType.StoredProcedure).ToList();

            return model;
        }



        //public static List<Advertisement> GetCustomers()
        //{
        //    Console.Write("Ange ett sökvillkor för kunden:");
        //    string condition = Console.ReadLine();

        //    using (IDbConnection db = new SqlConnection(_connString))
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@SearchCondition", condition);

        //        //En SP anropas med parameters och man behöver ange commandType
        //        var model = db.Query<Advertisement>("SearchForAdvertisementByName", parameters,
        //           commandType: CommandType.StoredProcedure).ToList();

        //        return model;

        //    }
        //}
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
        public static int GetIDs()
        {
            using IDbConnection db = new SqlConnection(_connString);

            var result = db.Query<int>("CountIDs", commandType: CommandType.StoredProcedure).SingleOrDefault();
            return result;
        }
        public static int GetCategoryIDs()
        {
            using IDbConnection db = new SqlConnection(_connString);

            var result = db.Query<int>("CountCategoryIDs", commandType: CommandType.StoredProcedure).SingleOrDefault();
            return result;
        }
        public static List<int> GetIDRange()
        {
            using IDbConnection db = new SqlConnection(_connString);

            var result = db.Query<int>("GetIDRange", commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public static List<int> GetCategoryIDRange()
        {
            using IDbConnection db = new SqlConnection(_connString);

            var result = db.Query<int>("GetCategoryIDRange", commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
