using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;
using Angular.Nag.Services.Models;

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
        public void Post(NewPhone newPhone) {

            System.Diagnostics.Trace.WriteLine(string.Format("Adding {0}", newPhone));

            Phone phone = new Phone {
                Model = newPhone.Model,
                Description = newPhone.Description,
                Price = newPhone.Price,
                ImageFile = newPhone.ImageFile
            };

            var plans = _db.Plans.GetAll();
            foreach (Plan plan in plans) {
                if (newPhone.PlanIds.Contains(plan.PlanId)) {
                    phone.Plans.Add(plan);
                }
            }
            _db.Phones.Add(phone);
            _db.Commit();

            System.Diagnostics.Trace.WriteLine(string.Format("Added {0}", phone));
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
