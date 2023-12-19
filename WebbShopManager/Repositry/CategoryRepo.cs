using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopManager.Entities;

namespace WebbShopManager.Repositry
{
    public static class CategoryRepo
    {
        public static string _connString = "Data Source=DESKTOP-F2QGBSH\\SQLEXPRESS;Initial Catalog=WebbShopAdvertisements;Integrated Security=true;trustservercertificate=true";
    
    
        public static List<Category> ShowAllCategories()
        {
            using IDbConnection db = new SqlConnection(_connString);
            return db.Query<Category>("ShowCategories",
                commandType: CommandType.StoredProcedure).ToList();
        }   
    
    }
}
