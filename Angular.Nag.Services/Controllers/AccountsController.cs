using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;
using Angular.Nag.Services.Models;

namespace Angular.Nag.Services.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public AccountsController(ICodeCamperUow db) {
            _db = db;
        }

        // GET api/accounts
        public IEnumerable<Account> Get() {
            //IQueryable<Account> accounts = _db.Accounts.GetAllWithChildData();

            List<Account> accounts = GetAccounts();
            return accounts;
        }

        /// <summary>
        /// This is inefficient but demonstrates how to do
        /// explicit loading when you are doing code first.
        /// </summary>
        /// <returns></returns>
        private List<Account> GetAccounts() {
            List<Account> accounts;
            accounts = _db.Accounts.GetAll().ToList();

            foreach (var account in accounts) {
                DbEntityEntry<Account> accountEntry = _db.PhoneDb.Entry(account);
                accountEntry.Reference(ac => ac.AccountHolder).Load();
                accountEntry.Collection(ac => ac.Phones).Load();

                foreach (PhoneInstance phoneInstance in account.Phones) {
                    DbEntityEntry<PhoneInstance> piEntry = _db.PhoneDb.Entry(phoneInstance);
                    piEntry.Reference(pi => pi.Phone).Load();
                    piEntry.Reference(pi => pi.PhonePlan).Load();
                }

                System.Diagnostics.Trace.WriteLine(string.Format("Account Id: {0} Holder: {1} with {2} phones.",
                                                                 account.AccountId, account.AccountHolder, account.Phones.Count));
            }
            return accounts;
        }

        // GET api/accounts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/accounts
        public int Post(NewAccount newAccount)
        {
            Account account = new Account();
            Person accountHolder = new Person();

            accountHolder.FullName = newAccount.FullName;
            accountHolder.ContactPhoneNumber = newAccount.ContactPhoneNumber;
            accountHolder.EmailAddress = newAccount.EmailAddress;

            account.AccountHolder = accountHolder;

            _db.Accounts.Add(account);
            _db.Commit();

            return account.AccountId;
        }

        // PUT api/accounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/accounts/5
        public void Delete(int id)
        {
        }
    }
}
