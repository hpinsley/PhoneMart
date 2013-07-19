using System.Collections.Generic;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories {
    public interface IPhonesRepository : IRepository<Phone> {
        IEnumerable<Phone> GetAllWithPlans();
    }
}