using System.Data.Entity;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class PlansRepository : EFRepository<Plan>, IPlansRepository
    {
        private PhoneDb _phoneDb;

        public PlansRepository(DbContext context) : base(context) {
            _phoneDb = (PhoneDb)context;
        }

        public override Plan GetById(int id) {
            return _phoneDb.Plans
                           .Include("Phones.Manufacturer")
                           .FirstOrDefault(plan => plan.PlanId == id);

        }
    }
}
