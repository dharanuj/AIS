using AIS.BL;
using AIS.Entity;
using System;
using System.Web.Http;

namespace AIS.UI.Service_API
{
    public class UserController : ApiController
    {
        private readonly UserValidation _user = new UserValidation();

        [HttpGet]
        [Route("api/users/")]
        public IHttpActionResult ValidateUser([FromUri] string username, string password)
        {
            try
            {
                return Ok(_user.ValidateUser(username, password));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }

        [HttpPost]
        [Route("api/users/")]
        public IHttpActionResult CreateUser([FromBody] User user)
        {
            try
            {
                return Ok(_user.CreateUser(user));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
    }
}