using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PhonesController : ApiController
    {
        // GET api/phones
        public IEnumerable<phone> Get() {
            var db = new PhoneDb();
            return db.Phones.ToArray();
        }

        // GET api/phones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/phones
        public void Post([FromBody]string value)
        {
        }

        // PUT api/phones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/phones/5
        public void Delete(int id)
        {
        }
    }
}
