using AIS.BL;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AIS.UI.ServiceAPI
{
    public class ClientController : ApiController
    {
        private readonly Client _client = new Client();

        [HttpGet]
        [Route("api/client/")]
        public IHttpActionResult GetClientInfo([FromUri] int? id, string lastName)
        {
            try
            {
                return Ok(_client.GetClientInfo(id, lastName));
            }
            catch (Exception e)
            {
                return Ok(new List<Entity.ClientInfo>());
            }
        }

        [HttpPost]
        [Route("api/client/")]
        public IHttpActionResult SaveClientInfo([FromBody] Entity.ClientInfo client)
        {
            try
            {
                return Ok(_client.SaveClientInfo(client));
            }
            catch (Exception e)
            {
                return Ok(-1);
            }
        }
    }
}