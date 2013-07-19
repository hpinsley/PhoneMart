using System.Collections.Generic;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PhonesController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public PhonesController(ICodeCamperUow db) {
            _db = db;
        }

// GET api/phones
        public IEnumerable<Phone> Get() {
            return _db.Phones.GetAllWithPlans();
        }

        // GET api/phones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/phones
        public void Post(Phone newPhone) {
            System.Diagnostics.Trace.WriteLine(string.Format("Adding {0}", newPhone));
            _db.Phones.Add(newPhone);
            _db.Commit();
            System.Diagnostics.Trace.WriteLine(string.Format("Added {0}", newPhone));
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
