using System.Collections.Generic;

namespace Angular.Nag.Models {

    public abstract class Accessory {
        public int AccessoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Phone> Phones { get; set; }

        public Accessory() {
            Phones = new List<Phone>();
        }
    }

    public enum ChargerType {
        Wall = 1,
        Car = 2
    }

    public class PhoneCharger : Accessory {
        public ChargerType ChargerType { get; set;}
        public int CordLength { get; set; }
    }

    public class PhoneCase : Accessory {
        public string Color { get; set; }
    }
}