using System.Data.Entity;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class AccountsRepository : EFRepository<Account>, IAccountsRepository {
        private PhoneDb _phoneDb;
        public AccountsRepository(DbContext context) : base(context) {
            _phoneDb = (PhoneDb) context;
        }

        public IQueryable<Account> GetAllWithChildData() {

            System.Diagnostics.Trace.WriteLine(string.Format("Lazy: {0}, Proxy: {1}", _phoneDb.Configuration.LazyLoadingEnabled, _phoneDb.Configuration.ProxyCreationEnabled));

            var accounts = _phoneDb.Accounts
                                   .Include("Phones.Phone")
                                   .Include("Phones.PhonePlan")
                                   .Include(ac => ac.AccountHolder);
                                   

            return accounts;
        }
    }
}
