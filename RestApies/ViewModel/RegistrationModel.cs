using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApies.ViewModel
{
    public class RegistrationEntity
    {

        public int id { get; set; }
        public string name { get; set; }
        public int contactnumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string fathername { get; set; }
        public int addharnumber { get; set; }
        public string pannumber { get; set; }
        public string selectRole { get; set; }
    }

    public class LoginModel
    {

        public string email { get; set; }
        public string Password { get; set; }
    }

    public class RestaurantEntity
    {
        public int id { get; set; }
        public int tablenumber { get; set; }
        public int headcount { get; set; }
        public string guestname { get; set; }
        public int phonenumber { get; set; }
        public string bookitems { get; set; }
        public int quantity { get; set; }
        public string prince { get; set; }
    }

    public class TableModel
    {
      public int id { get; set; }
    }
    //for guest add
    public class GestDetail
    {
        public int tablenumber { get; set; }
        public int headcount { get; set; }
        public string guestname { get; set; }
        public int phonenumber { get; set; }
    }

}