using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class Account {
        public int AccountId { get; set; }
        public virtual Person AccountHolder { get; set; }
        public virtual List<PhoneInstance> Phones { get; set; }

        public Account() {
            Phones = new List<PhoneInstance>();
        }
    }
}