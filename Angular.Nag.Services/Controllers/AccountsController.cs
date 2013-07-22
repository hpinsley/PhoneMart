using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

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
            IQueryable<Account> accounts = _db.Accounts.GetAllWithChildData();
            foreach (var account in accounts) {
                System.Diagnostics.Trace.WriteLine(string.Format("Account Id: {0} Holder: {1} with {2} phones.", account.AccountId, account.AccountHolder, account.Phones.Count));
            }

            return accounts;
        }

        // GET api/accounts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/accounts
        public void Post([FromBody]string value)
        {
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
