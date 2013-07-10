using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers {
    public class ValuesController : ApiController {
        // GET api/values
        public IEnumerable<string> Get() {

            var db = new PhoneDb();
            DbSet<phone> phones = db.Phones;
            int count = phones.Count();
            return new string[] { "value1", "value2", count.ToString() };
        }

        // GET api/values/5
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }
    }
}