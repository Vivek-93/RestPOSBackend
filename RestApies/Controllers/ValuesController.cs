using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApies.ViewModel;
using RestApies.Models.Database;
using System;

namespace RestApies.Controllers
{
    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(LoginModel _RegisterLogin)
        {
            HttpResponseMessage response;
           RegistrationEntity userdata = new RegistrationEntity();
            try
            {

                if (string.IsNullOrEmpty(_RegisterLogin.email) || String.IsNullOrEmpty(_RegisterLogin.Password))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "email and Password can not be null");
                }
                else
                {
                    userdata = RegistrationProcCall.usp_user_registrationlogin(_RegisterLogin);
                    response = Request.CreateResponse(HttpStatusCode.OK, userdata);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return response;
        }


        public HttpResponseMessage Add(RegistrationEntity _RegisterAdd)
        {
            HttpResponseMessage response;
            try
            {
                if (string.IsNullOrWhiteSpace(_RegisterAdd.name))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Name can not be blank!");
                }
                else
                {
                    //ListingEntityID _ListEntityID = new ListingEntityID();
                    int new_user_id = RegistrationProcCall.usp_user_registrationAdd(_RegisterAdd);
                    //_ListEntityID.ListID = new_user_id;
                    response = Request.CreateResponse(HttpStatusCode.OK, new_user_id);
                    //return Request.CreateErrorResponse(HttpStatusCode.OK, " Register successfully");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        // get data 
        public HttpResponseMessage UserDetail(RegistrationEntity _UserId)
        {
            HttpResponseMessage response;
            RegistrationEntity userData = new RegistrationEntity();
            try
            {
                //check for null paramter
                if (_UserId == null)
                {
                    throw new Exception("Input parameter not provided");
                }
                else if (_UserId.id == 0) //check for zero in user id
                {
                    //response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "UserID can not be zero!");
                    throw new Exception("User ID can not be zero");
                }
                else
                {
                    //get data from database
                    userData = RegistrationProcCall.usp_user_registrationget(_UserId);
                    if (userData == null)
                    {
                        //throw exception in not record found
                        throw new Exception("User Information could not be found");
                    }
                    else
                    {
                        //return user data
                        response = Request.CreateResponse(HttpStatusCode.OK, userData);
                    }
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Server error occured while processing request");
            }
            return response;
        }
        public HttpResponseMessage Update(RegistrationEntity _Update)
        {
            HttpResponseMessage response;
            RegistrationEntity userData = new RegistrationEntity();
            try
            {
                if (_Update == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Update can not be null!");
                }
                else if (string.IsNullOrWhiteSpace(_Update.name))
                {
                    response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, "update successfuly");
                }

                else
                {
                    userData = RegistrationProcCall.usp_user_registrationupdate(_Update);
                    response = Request.CreateResponse(HttpStatusCode.OK, userData);
                }
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }
        // GET api/values
         //[HttpPost]
        public IEnumerable<string> Get()
        {
            return new string[] { "value3", "value5" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string email, [FromBody]string password)
        {
            return "1,govind";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}