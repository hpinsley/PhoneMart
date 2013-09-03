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
        public App Get(int id) {
            return _db.Apps.GetById(id);
        }

        // POST api/apps
        public void Post([FromBody]string value)
        {
        }

        // PUT api/apps/5
        public void Put(int id, [FromBody]App appUpdate) {
            var app = _db.Apps.GetById(id);
            if (app == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            app.Name = appUpdate.Name;
            app.Description = appUpdate.Description;
            _db.Commit();
        }

        // DELETE api/apps/5
        public void Delete(int id)
        {
        }
    }
}
