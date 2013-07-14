using System.Collections.Generic;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PhonesController : ApiController
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhonesController(IPhoneRepository phoneRepository) {
            _phoneRepository = phoneRepository;
        }

// GET api/phones
        public IEnumerable<Phone> Get() {
            var db = _phoneRepository.GetDatabase();
            return db.Phones; //.Include("plans");
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
