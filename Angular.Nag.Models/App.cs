
using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class App {
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Phone> Phones { get; set; }
        public List<PhoneInstance> PhoneInstances { get; set; }

        public override string ToString() {
            return string.Format("App: Id: {0}, Name: {1}", AppId, Name);
        }

        public App() {
            Phones = new List<Phone>();
            PhoneInstances = new List<PhoneInstance>();
        }
    }
}