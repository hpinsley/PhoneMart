using System;
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
                                .Include(p => p.Apps)
                                .Include(p => p.Accessories)
                                .FirstOrDefault(p => p.PhoneId == id);
            return phone;
        }
        public IEnumerable<Phone> GetAllWithChildren() {
            List<Phone> phones = _phoneDb.Phones
                .Include(p => p.Plans)
                .Include(p => p.Apps)
                .Include(p=>p.Manufacturer)
                .Include(p=>p.Accessories)
                .ToList();

            foreach (var phone in phones) {
                foreach (var plan in phone.Plans) {
                    plan.Phones = null; //clear out back references that get auto loaded
                }
                foreach (var app in phone.Apps) {
                    app.Phones = null; //clear out back references that get auto loaded
                }
                foreach (var accessory in phone.Accessories) {
                    accessory.Phones = null;
                }
            }
            return phones;
        }

        public override void Delete(int id) {
            Phone phone = _phoneDb.Phones.FirstOrDefault(p => p.PhoneId == id);
            if (phone == null)
                throw new Exception(string.Format("No such phone with id {0}", id));

            var instances = _phoneDb.PhoneInstances.Where(pi => pi.Phone.PhoneId == phone.PhoneId).ToList();
            instances.ForEach(pi => _phoneDb.PhoneInstances.Remove(pi));
            _phoneDb.Phones.Remove(phone);
        }
    }
}
