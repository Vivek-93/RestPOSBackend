using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApies.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace RestApies.Models.Database
{
    public class RestaurantMenuProcCall
    {
        public static List<RestaurantMenuEntity> RestaurantMenuCategory()
        {

            List<RestaurantMenuEntity> _UserEntity = new List<RestaurantMenuEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "RestaurantMenuCategory ";
                _UserEntity = connection.Query<RestaurantMenuEntity>(sqlQuery, new { }).ToList<RestaurantMenuEntity>();
            }
            return _UserEntity;
        }

        public static List<RestaurantMenuEntity> RestaurantMenusubCategory(subMenuModel _SubCategory)
        {
            List<RestaurantMenuEntity> _ListingEntity = new List<RestaurantMenuEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "RestaurantMenusubCategory @category";
                _ListingEntity = connection.Query<RestaurantMenuEntity>(sqlQuery, new { category = _SubCategory.category }).ToList<RestaurantMenuEntity>();
            }
            return _ListingEntity;
        }
    }
}