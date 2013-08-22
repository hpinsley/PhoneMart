using System.Data.Entity;
using System.Linq;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    public class AppsRepository : EFRepository<App>, IAppsRepository
    {
        private PhoneDb _phoneDb;

        public AppsRepository(DbContext context) : base(context) {
            _phoneDb = (PhoneDb)context;
        }

        public override App GetById(int id) {
            return _phoneDb.Apps
                           .Include("Phones.Manufacturer")
                           .FirstOrDefault(app => app.AppId == id);
        }
    }
}
