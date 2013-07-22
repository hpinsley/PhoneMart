using System.Collections.Generic;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories {
    public interface IAccountsRepository : IRepository<Account> {
        IQueryable<Account> GetAllWithChildData();
    }
}