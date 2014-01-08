using System.Data.Entity;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class AccessoriesRepository : EFRepository<Accessory>, IAccessoriesRepository
    {
        private PhoneDb _phoneDb;

        public AccessoriesRepository(DbContext context) : base(context) {
            _phoneDb = (PhoneDb)context;
        }

        public override Accessory GetById(int id) {
            return _phoneDb.Accessories
                           .Include("Phones.Manufacturer")
                           .FirstOrDefault(accessory => accessory.AccessoryId == id);

        }
    }
}
