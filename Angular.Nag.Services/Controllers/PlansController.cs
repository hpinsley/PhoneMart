using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Angular.Nag.Data;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PlansController : ApiController
    {
        private readonly ICodeCamperUow _uow;

        public PlansController(ICodeCamperUow uow) {
            _uow = uow;
        }

        // GET api/plans
        public IEnumerable<Plan> Get() {
            return _uow.Plans.GetAll();
        }

        // GET api/plans/5
        public Plan Get(int id) {
            Plan plan = _uow.Plans.GetById(id);
            if (plan != null) {
                DbEntityEntry<Plan> planEntry = _uow.PhoneDb.Entry(plan);
                System.Diagnostics.Trace.WriteLine(string.Format("Before Phone plans load status is {0}", planEntry.Collection(pl => pl.Phones).IsLoaded));
                planEntry.Collection(pl => pl.Phones).Load();
                System.Diagnostics.Trace.WriteLine(string.Format("After Phone plans load status is {0}", planEntry.Collection(pl => pl.Phones).IsLoaded));


            }
            return plan;
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
