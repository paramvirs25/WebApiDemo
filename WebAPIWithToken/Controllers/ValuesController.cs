using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIWithToken.Models;

namespace WebAPIWithToken.Controllers
{

    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            List<LoginResponse> users = new List<LoginResponse>();
            users.Add(new LoginResponse() { id = 1, firstName = "qq" });
            users.Add(new LoginResponse() { id = 2, firstName = "ll" });

            return Ok(users);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
