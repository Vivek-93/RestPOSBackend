using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApies.ViewModel;
using RestApies.Models.Database;

namespace RestApies.Controllers
{
    public class RestaurantController : ApiController
    {
        public HttpResponseMessage tableDetail(TableModel _Table)
        {
            HttpResponseMessage response;
            List<RestaurantEntity> userData = new List<RestaurantEntity>();
            try
            {
            
               // check for null paramter
              
                    //get data from database
                userData = RegistrationProcCall.usp_user_restauranttableget(_Table);
                response = Request.CreateResponse(HttpStatusCode.OK, userData);
                
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Server error occured while processing request");
            }
            return response;
        }

        public HttpResponseMessage RestaurantAdd(GestDetail _ListAdd)
        {
            HttpResponseMessage response;
            try
            {
                if (string.IsNullOrWhiteSpace(_ListAdd.guestname))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Name can not be blank!");
                }
                else
                {
                   
                    int new_user_id = RegistrationProcCall.usp_user_restaurantadd(_ListAdd);
                    response = Request.CreateResponse(HttpStatusCode.OK, new_user_id);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public HttpResponseMessage GuestDetail(TableModel _EntityID)
        {
            HttpResponseMessage response;
            RestaurantEntity userData = new RestaurantEntity();
            try
            {
                if (_EntityID == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "UserID can not be zero!");
                }
                else
                {
                    userData = RegistrationProcCall.usp_user_restaurantgestDetail(_EntityID);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }



        public HttpResponseMessage BookedOrder(bookOrder _ListAdd)
        {
            HttpResponseMessage response;
            try
            {
                if (string.IsNullOrWhiteSpace(_ListAdd.bookitems))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "items can not be blank!");
                }
                else
                {

                    int new_user_id = RegistrationProcCall.usp_user_restaurantBookedOrder(_ListAdd);

                    response = Request.CreateResponse(HttpStatusCode.OK, new_user_id);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }



        public HttpResponseMessage BookOrderDetail(RestaurantEntity _Table)
        {
            HttpResponseMessage response;
            List<RestaurantEntity> userData = new List<RestaurantEntity>();
            try
            {
                if (_Table == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "tablenumber can not be blank!");
                }
                else { 
                // check for null paramter

                //get data from database
                userData = RegistrationProcCall.usp_user_restaurantBookedOrderDetail(_Table);
                response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }

            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Server error occured while processing request");
            }
            return response;
        }



        public HttpResponseMessage QuantityUpdate(RestaurantquantityUpdate _Update)
        {
            HttpResponseMessage response;
            RestaurantEntity userData = new RestaurantEntity();
            try
            {
                if (_Update == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Update can not be null!");
                }
                else
                {
                    userData = RegistrationProcCall.usp_user_restaurantquantityUpdate(_Update);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }
        // GET api/restaurant
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/restaurant/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/restaurant
        public void Post([FromBody]string value)
        {
        }

        // PUT api/restaurant/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/restaurant/5
        public void Delete(int id)
        {
        }
    }
}
