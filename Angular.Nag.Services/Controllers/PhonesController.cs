using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Angular.Nag.Data.Repositories;
using Angular.Nag.Models;
using Angular.Nag.Services.Models;

namespace Angular.Nag.Services.Controllers
{
    public class PhonesController : ApiController
    {
        private readonly ICodeCamperUow _db;

        public PhonesController(ICodeCamperUow db) {
            _db = db;
        }

// GET api/phones
        public IEnumerable<Phone> Get() {
            return _db.Phones.GetAllWithChildren();
        }

        // GET api/phones/5
        public Phone Get(int id) {
            var phone = _db.Phones.GetById(id);
            if (phone == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return phone;
        }

        // POST api/phones
        public void Post(NewPhone newPhone) {

            System.Diagnostics.Trace.WriteLine(string.Format("Adding {0}", newPhone));

            Manufacturer manufacturer = _db.Manufacturers.GetById(newPhone.ManufacturerId);
            if (manufacturer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Phone phone = new Phone {
                Manufacturer = manufacturer,
                Model = newPhone.Model,
                Description = newPhone.Description,
                Price = newPhone.Price,
                ImageFile = newPhone.ImageFile
            };

            var plans = _db.Plans.GetAll();
            foreach (Plan plan in plans) {
                if (newPhone.PlanIds.Contains(plan.PlanId)) {
                    phone.Plans.Add(plan);
                }
            }
            _db.Phones.Add(phone);
            _db.Commit();

            System.Diagnostics.Trace.WriteLine(string.Format("Added {0}", phone));
        }

        // PUT api/phones/5
        public void Put(int id, NewPhone phoneData) {
            var phone = _db.Phones.GetById(id);
            if (phone == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var manufacturer = _db.Manufacturers.GetById(phoneData.ManufacturerId);
            if (manufacturer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            phone.Manufacturer = manufacturer;
            phone.Model = phoneData.Model;
            phone.Description = phoneData.Description;
            phone.Price = phoneData.Price;

            phone.Plans.Clear();

            var plans = _db.Plans.GetAll();
            foreach (Plan plan in plans) {
                if (phoneData.PlanIds.Contains(plan.PlanId)) {
                    phone.Plans.Add(plan);
                }
            }

            phone.Apps.Clear();
            var apps = _db.Apps.GetAll();
            foreach (App app in apps) {
                if (phoneData.AppIds.Contains(app.AppId)) {
                    phone.Apps.Add(app);
                }
            }
            _db.Commit();
        }

        // DELETE api/phones/5
        public void Delete(int id) {
            _db.Phones.Delete(id);
            _db.Commit();
        }
    }
}
