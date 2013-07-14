using System.Collections.Generic;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PlansController : ApiController
    {
        private readonly IPhoneRepository _phoneRepository;

        public PlansController(IPhoneRepository phoneRepository) {
            _phoneRepository = phoneRepository;
        }

        // GET api/plans
        public IEnumerable<Plan> Get() {
            var db = _phoneRepository.GetDatabase();
            return db.Plans;
        }

        // GET api/plans/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/plans
        public void Post([FromBody]string value)
        {
        }

        // PUT api/plans/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/plans/5
        public void Delete(int id)
        {
        }
    }
}
