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
    public class RegistrationProcCall
    {

        public static RegistrationEntity usp_user_registrationlogin(LoginModel _RegisterLogin)
        {

            RegistrationEntity _UserEntity = new RegistrationEntity();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_registrationlogin @email,@Password";
                _UserEntity = connection.Query<RegistrationEntity>(sqlQuery, new { email = _RegisterLogin.email, Password = _RegisterLogin.Password }).FirstOrDefault();
            }
            return _UserEntity;
        }

        public static int usp_user_registrationAdd(RegistrationEntity _RegisterAdd)
        {
            int userid = 0;
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                //string sqlQuery = "usp_user_registrationAdd @name,@contactnumber,@email,@password,@address,@fathername,@addharnumber,@pannumber,@selectRole";

                //userid = connection.Query<int>(sqlQuery, new
                //{
                   
                //    name = _RegisterAdd.name,
                //    contactnumber = _RegisterAdd.contactnumber,
                //    email = _RegisterAdd.email,
                //    password = _RegisterAdd.password,
                //    address = _RegisterAdd.address,
                //    fathername = _RegisterAdd.fathername,
                //    addharnumber = _RegisterAdd.addharnumber,
                //    pannumber = _RegisterAdd.pannumber,
                //    selectRole = _RegisterAdd.selectRole
                //}).FirstOrDefault();


                //

                // SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_user_registrationAdd";
                // cmd.Parameters.Add("@id", SqlDbType.Int).Value = _RegisterAdd.id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = _RegisterAdd.name;
                cmd.Parameters.Add("@contactnumber", SqlDbType.Int).Value = _RegisterAdd.contactnumber;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _RegisterAdd.email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = _RegisterAdd.password;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = _RegisterAdd.address;
                cmd.Parameters.Add("@fathername", SqlDbType.VarChar).Value = _RegisterAdd.fathername;
                cmd.Parameters.Add("@addharnumber", SqlDbType.Int).Value = _RegisterAdd.addharnumber;
                cmd.Parameters.Add("@pannumber", SqlDbType.VarChar).Value = _RegisterAdd.pannumber;
                cmd.Parameters.Add("@selectRole", SqlDbType.VarChar).Value = _RegisterAdd.selectRole;

                cmd.Connection = connection;
                userid = (int)cmd.ExecuteScalar();
            }
            return userid;
        }

        public static RegistrationEntity usp_user_registrationget(RegistrationEntity _UserId)
        {

            RegistrationEntity _UserEntity = new RegistrationEntity();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_registrationget @id";
                _UserEntity = connection.Query<RegistrationEntity>(sqlQuery, new { id = _UserId.id }).FirstOrDefault();
            }
            return _UserEntity;
        }

        public static RegistrationEntity usp_user_registrationupdate(RegistrationEntity _Update)
        {
            RegistrationEntity _UserEntity = new RegistrationEntity();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
            //    string sqlQuery = @"usp_user_registrationupdate @id,@name,@contactnumber,@email,@password,@address,@fathername,@addharnumber,@pannumber,@selectRole";
              //  _UserEntity = connection.Query<RegistrationEntity>(sqlQuery, new {id = _Update.id, name = _Update.name, contactnumber = _Update.contactnumber, email = _Update.email, password = _Update.password, address = _Update.address, fathername = _Update.fathername, addharnumber = _Update.addharnumber, pannumber = _Update.pannumber, selectRole = _Update.selectRole }).FirstOrDefault();


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_user_registrationupdate";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _Update.id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = _Update.name;
                cmd.Parameters.Add("@contactnumber", SqlDbType.Int).Value = _Update.contactnumber;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _Update.email;
                //cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = _Update.password;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = _Update.address;
                cmd.Parameters.Add("@fathername", SqlDbType.VarChar).Value = _Update.fathername;
                cmd.Parameters.Add("@addharnumber", SqlDbType.Int).Value = _Update.addharnumber;
                cmd.Parameters.Add("@pannumber", SqlDbType.VarChar).Value = _Update.pannumber;
                cmd.Parameters.Add("@selectRole", SqlDbType.VarChar).Value = _Update.selectRole;

                cmd.Connection = connection;
                _UserEntity = (RegistrationEntity)cmd.ExecuteScalar();
            }
            return _UserEntity;
        }

        //Restaurant Table

        public static List<RestaurantEntity> usp_user_restauranttableget(TableModel _Table)
        {

            List<RestaurantEntity> _UserEntity = new List<RestaurantEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_restauranttableget @id";
                _UserEntity = connection.Query<RestaurantEntity>(sqlQuery, new { id = _Table.id }).ToList<RestaurantEntity>();
            }
            return _UserEntity;
        }

        public static int usp_user_restaurantadd(GestDetail _ListAdd)
        {
            int userid = 0;
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_restaurantadd  @tablenumber,@headcount,@guestname,@phonenumber";
                userid = connection.Query<int>(sqlQuery, new { tablenumber =_ListAdd.tablenumber,headcount = _ListAdd.headcount, guestname = _ListAdd.guestname, phonenumber = _ListAdd.phonenumber }).FirstOrDefault();
            }
            return userid;
        }

        public static RestaurantEntity usp_user_restaurantgestDetail(TableModel _EntiyID)
        {
            RestaurantEntity _ListingEntity = new RestaurantEntity();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_restaurantgestDetail @id";
                _ListingEntity = connection.Query<RestaurantEntity>(sqlQuery, new { id = _EntiyID.id }).FirstOrDefault();
            }
            return _ListingEntity;
        }

        public static int usp_user_restaurantBookedOrder(bookOrder _Bookorder)
        {
            int userid = 0;
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_restaurantBookedOrder  @tablenumber,@bookitems,@quantity,@price";
                userid = connection.Query<int>(sqlQuery, new { tablenumber = _Bookorder.tablenumber, bookitems = _Bookorder.bookitems, quantity = _Bookorder.quantity, price = _Bookorder.price }).FirstOrDefault();
            }
            return userid;
        }

        public static List<RestaurantEntity> usp_user_restaurantBookedOrderDetail(RestaurantEntity _Table)
        {

            List<RestaurantEntity> _UserEntity = new List<RestaurantEntity>();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
                string sqlQuery = "usp_user_restaurantBookedOrderDetail @tablenumber";
                _UserEntity = connection.Query<RestaurantEntity>(sqlQuery, new { tablenumber = _Table.tablenumber }).ToList<RestaurantEntity>();
            }
            return _UserEntity;
        }

        public static RestaurantEntity usp_user_restaurantquantityUpdate(RestaurantquantityUpdate _Update)
        {
            RestaurantEntity _ListEntity = new RestaurantEntity();
            using (var connection = SQLConnection.GetOpenSQLConnection())
            {
              //  string sqlQuery = "usp_user_restaurantquantityUpdate @id,@quantity";
              //  _ListEntity = connection.Query<RestaurantEntity>(sqlQuery, new { id = _Update.id, quantity = _Update.quantity, }).FirstOrDefault();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_user_restaurantquantityUpdate";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _Update.id;
                cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = _Update.quantity;
               // cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = _Update.name;
             //   cmd.Parameters.Add("@contactnumber", SqlDbType.Int).Value = _Update.contactnumber;
               // cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _Update.email;
                //cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = _Update.password;
                //cmd.Parameters.Add("@fathername", SqlDbType.VarChar).Value = _Update.fathername;
                //cmd.Parameters.Add("@addharnumber", SqlDbType.Int).Value = _Update.addharnumber;
                //cmd.Parameters.Add("@pannumber", SqlDbType.VarChar).Value = _Update.pannumber;
                //cmd.Parameters.Add("@selectRole", SqlDbType.VarChar).Value = _Update.selectRole;

                cmd.Connection = connection;
                _ListEntity = (RestaurantEntity)cmd.ExecuteScalar();

            }
            return _ListEntity;
        }

    }
}