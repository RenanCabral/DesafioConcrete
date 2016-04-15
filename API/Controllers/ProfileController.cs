using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProfileController : ApiController
    {
        // GET: api/Profile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
