using System.Collections.Generic;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;

namespace Angular.Nag.Services.Controllers
{
    public class AccessoriesController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public AccessoriesController(ICodeCamperUow db) {
            _db = db;
        }

        // GET api/Accessories
        public IEnumerable<Accessory> Get() {
            return _db.Accessories.GetAll();
        }

        // GET api/Accessories/5
        public Accessory Get(int id) {
            Accessory accessory = _db.Accessories.GetById(id);
            return accessory;
        }

    }
}
