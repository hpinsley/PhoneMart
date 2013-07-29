using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class Phone {
        public int PhoneId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }

        public List<Plan> Plans { get; set; }
        

        public override string ToString() {
            return string.Format("Phone Model: {0}; Description: {1}; Price: {2}; PhoneId: {3}",
                                 Model, Description, Price, PhoneId);
        }

        public Phone() {
            Plans = new List<Plan>();
        }
    }
}