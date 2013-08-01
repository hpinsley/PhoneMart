using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;
using Angular.Nag.Services.Models;

namespace Angular.Nag.Services.Controllers
{
    public class AccountPhonesController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public AccountPhonesController(ICodeCamperUow db) {
            _db = db;
        }

        //Return all the phones instances for the account
        public IEnumerable<PhoneInstance> Get(int accountId) {
            var account = _db.Accounts.GetById(accountId);
            if (account == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            LoadNavProperties(account);
            return account.Phones.ToList();
        }

        //api/accounts/2/phones/4
        public PhoneInstance Get(int accountId, int phoneInstanceId) {
            var account = _db.Accounts.GetById(accountId);
            if (account == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            LoadNavProperties(account);
            var linkedPhone = account.Phones.Where(pi => pi.PhoneInstanceId == phoneInstanceId).FirstOrDefault();
            if (linkedPhone == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return linkedPhone;
        }

        //api/accounts/2/phones/4
        public PhoneInstance Put(int accountId, int phoneInstanceId, PhoneInstanceUpdate phoneInstanceUpdate) {
            var account = _db.Accounts.GetById(accountId);
            if (account == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            LoadNavProperties(account);
            var linkedPhone = account.Phones.Where(pi => pi.PhoneInstanceId == phoneInstanceId).FirstOrDefault();
            if (linkedPhone == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var plan = _db.Plans.GetById(phoneInstanceUpdate.PhonePlanId);

            linkedPhone.SerialNumber = phoneInstanceUpdate.SerialNumber;
            linkedPhone.PhoneNumber = phoneInstanceUpdate.PhoneNumber;
            linkedPhone.PhonePlan = plan;

            _db.Commit();
            return linkedPhone;
        }

        //api/accounts/2/phones/4
        public void Delete(int accountId, int phoneInstanceId) {
            _db.Accounts.DeletePhoneInstance(accountId, phoneInstanceId);
            _db.Commit();
        }

        // POST api/accounts/2/phones
        // Add a new phone instance to the account

        public int Post(LinkedPhone linkedPhone) {
            
            var account = _db.Accounts.GetById(linkedPhone.AccountId);
            if (account == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            LoadNavProperties(account);

            var phone = _db.Phones.GetById(linkedPhone.PhoneId);
            if (phone == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var plan = _db.Plans.GetById(linkedPhone.PhonePlanId);
            if (plan == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            PhoneInstance phoneInstance = new PhoneInstance();
            phoneInstance.Phone = phone;
            phoneInstance.PhonePlan = plan;
            phoneInstance.PhoneNumber = linkedPhone.PhoneNumber;
            phoneInstance.SerialNumber = linkedPhone.SerialNumber;

            account.Phones.Add(phoneInstance);
            _db.Commit();

            return phoneInstance.PhoneInstanceId;
        }


        private void LoadNavProperties(Account account) {
            DbEntityEntry<Account> accountEntry = _db.PhoneDb.Entry(account);
            //accountEntry.Reference(ac => ac.AccountHolder).Load();
            accountEntry.Collection(ac => ac.Phones).Load();

            foreach (PhoneInstance phoneInstance in account.Phones) {
                DbEntityEntry<PhoneInstance> piEntry = _db.PhoneDb.Entry(phoneInstance);
                piEntry.Reference(pi => pi.Phone).Load();
                piEntry.Reference(pi => pi.PhonePlan).Load();

                DbEntityEntry<Phone> phoneEntry = _db.PhoneDb.Entry(phoneInstance.Phone);
                phoneEntry.Reference(p => p.Manufacturer).Load();
            }
        }

    }
}
