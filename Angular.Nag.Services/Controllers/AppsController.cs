using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class AppsController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public AppsController(ICodeCamperUow db) {
            _db = db;
        }

        // GET api/plans
        public IEnumerable<App> Get() {
            return _db.Apps.GetAll();
        }

        // GET api/apps/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/apps
        public void Post([FromBody]string value)
        {
        }

        // PUT api/apps/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/apps/5
        public void Delete(int id)
        {
        }
    }
}
