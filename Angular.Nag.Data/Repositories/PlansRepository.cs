using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class PlansRepository : EFRepository<Plan>, IPlansRepository
    {
        public PlansRepository(DbContext context) : base(context) { }
    }
}
