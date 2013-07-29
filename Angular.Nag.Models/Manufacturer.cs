using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class Manufacturer {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public List<Phone> Phones { get; set; }

        public Manufacturer() {
            Phones = new List<Phone>();
        }
    }
}