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

        public override Phone GetById(int id) {
            var phone = _phoneDb.Phones
                                .Include(p => p.Manufacturer)
                                .Include(p => p.Plans)
                                .FirstOrDefault(p => p.PhoneId == id);
            return phone;
        }
        public IEnumerable<Phone> GetAllWithPlans() {
            List<Phone> phones = _phoneDb.Phones.Include(p => p.Plans)
                .Include(p=>p.Manufacturer)
                .ToList();

            foreach (var phone in phones) {
                foreach (var plan in phone.Plans) {
                    plan.Phones = null; //clear out back references that get auto loaded
                }
            }
            return phones;
        }
    }
}
