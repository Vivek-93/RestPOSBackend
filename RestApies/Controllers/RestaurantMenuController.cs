using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApies.ViewModel;
using RestApies.Models.Database;
using System.Web;

namespace RestApies.Controllers
{
    public class RestaurantMenuController : ApiController
    {
        //restaurantmenu category api
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            List<RestaurantMenuEntity> userData = new List<RestaurantMenuEntity>();
            try
            {

                // check for null paramter

                //get data from database
                userData = RestaurantMenuProcCall.RestaurantMenuCategory();
                response = Request.CreateResponse(HttpStatusCode.OK, userData);

            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Server error occured while processing request");
            }
            return response;
        }

        public HttpResponseMessage SubCategory(subMenuModel _SubCategory)
        {
            HttpResponseMessage response;
            List<RestaurantMenuEntity> userData = new List<RestaurantMenuEntity>();
            try
            {
                if ( string.IsNullOrEmpty(_SubCategory.category))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Category can not be zero or null!");
                }
                else
                {
                    userData = RestaurantMenuProcCall.RestaurantMenusubCategory(_SubCategory);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public HttpResponseMessage ItemDetail(ItemDetail _SubCategory)
        {
            HttpResponseMessage response;
            List<RestaurantMenuEntity> userData = new List<RestaurantMenuEntity>();
            try
            {
                if (string.IsNullOrEmpty(_SubCategory.subcategory))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Sub Category can not be zero or null!");
                }
                else
                {
                    userData = RestaurantMenuProcCall.RestaurantMenuItemDetail(_SubCategory);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }


        public HttpResponseMessage ItemList(RestaurantMenuEntity _SubCategory)
        {
            HttpResponseMessage response;
            List<RestaurantMenuEntity> userData = new List<RestaurantMenuEntity>();
            try
            {
                if (_SubCategory == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "id can not be zero or null!");
                }
                else
                {
                    userData = RestaurantMenuProcCall.RestaurantMenuItemList(_SubCategory);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }
     
        
        // GET api/restaurantmenu
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/restaurantmenu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/restaurantmenu
        public void Post([FromBody]string value)
        {
        }

        // PUT api/restaurantmenu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/restaurantmenu/5
        public void Delete(int id)
        {
        }
    }
}
