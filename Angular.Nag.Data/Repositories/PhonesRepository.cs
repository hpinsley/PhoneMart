using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class PhonesRepository : EFRepository<Phone>, IPhonesRepository {
        private PhoneDb _phoneDb;
        public PhonesRepository(DbContext context) : base(context) {
            _phoneDb = (PhoneDb) context;
        }

        public IEnumerable<Phone> GetAllWithPlans() {
            List<Phone> phones = _phoneDb.Phones.Include(p => p.Plans).ToList();

            foreach (var phone in phones) {
                foreach (var plan in phone.Plans) {
                    plan.Phones = null; //clear out back references that get auto loaded
                }
            }
            return phones;
        }
    }
}
