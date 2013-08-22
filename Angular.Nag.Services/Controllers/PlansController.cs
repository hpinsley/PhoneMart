using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;
using Angular.Nag.Services.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PlansController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public PlansController(ICodeCamperUow db) {
            _db = db;
        }

        // GET api/plans
        public IEnumerable<Plan> Get() {
            return _db.Plans.GetAll();
        }

        // GET api/plans/5
        public Plan Get(int id) {
            Plan plan = _db.Plans.GetById(id);
            return plan;
        }

        // POST api/plans
        public int Post(NewPlan newPlan) {
            Plan plan = new Plan();

            plan.PlanName = newPlan.PlanName;
            plan.MonthlyCost = newPlan.MonthlyCost;
            plan.VoiceMinutes = newPlan.VoiceMinutes;
            plan.DataMegabytes = newPlan.DataMegabytes;

            _db.Plans.Add(plan);
            _db.Commit();

            return plan.PlanId;
        }

        // PUT api/plans/5
        public void Put(int id, NewPlan planData) {
            Plan plan = _db.Plans.GetById(id);
            if (plan == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            plan.PlanName = planData.PlanName;
            plan.MonthlyCost = planData.MonthlyCost;
            plan.VoiceMinutes = planData.VoiceMinutes;
            plan.DataMegabytes = planData.DataMegabytes;

            _db.Commit();
        }

        // DELETE api/plans/5
        public void Delete(int id)
        {
        }
    }
}
