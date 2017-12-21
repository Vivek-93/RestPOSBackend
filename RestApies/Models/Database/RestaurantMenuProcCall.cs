using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApies.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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

        public static List<RestaurantMenuEntity> RestaurantMenuItemDetail(ItemDetail _SubCategory)
        {
             List<RestaurantMenuEntity> _ListingEntity = new  List<RestaurantMenuEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "RestaurantMenuItemDetail @subcategory";
                _ListingEntity = connection.Query<RestaurantMenuEntity>(sqlQuery, new { subcategory = _SubCategory.subcategory }).ToList<RestaurantMenuEntity>();
            }
            return _ListingEntity;
        }

        public static List<RestaurantMenuEntity> RestaurantMenuItemList(RestaurantMenuEntity _SubCategory)
        {
            List<RestaurantMenuEntity> _ListingEntity = new List<RestaurantMenuEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "RestaurantMenuItemList @id";
                _ListingEntity = connection.Query<RestaurantMenuEntity>(sqlQuery, new { id = _SubCategory.id }).ToList<RestaurantMenuEntity>();
            }
            return _ListingEntity;
        }
    }
}