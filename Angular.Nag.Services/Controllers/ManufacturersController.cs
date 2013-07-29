using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class ManufacturersController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public ManufacturersController(ICodeCamperUow db) {
            _db = db;
        }

        // GET api/manufacturers
        public IEnumerable<Manufacturer> Get()
        {
            return _db.Manufacturers.GetAll().OrderBy(m => m.ManufacturerName).ToList();
        }

        // GET api/manufacturers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/manufacturers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/manufacturers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/manufacturers/5
        public void Delete(int id)
        {
        }
    }
}
