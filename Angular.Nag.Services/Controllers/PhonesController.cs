using System.Collections.Generic;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PhonesController : ApiController
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly ICodeCamperUow _db;

        public PhonesController(IPhoneRepository phoneRepository, ICodeCamperUow db) {
            _phoneRepository = phoneRepository;
            _db = db;
        }

// GET api/phones
        public IEnumerable<Phone> Get() {
            //var db = _phoneRepository.GetDatabase();
            //return db.Phones; //.Include("plans");
            return _db.Phones.GetAll();
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
