using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class PhoneInstance {
        public int PhoneInstanceId { get; set; }
        public Phone Phone { get; set; }
        public string SerialNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Plan PhonePlan { get; set; }

        public List<App> Apps { get; set; }

        public PhoneInstance() {
            Apps = new List<App>();
        }
    }
}