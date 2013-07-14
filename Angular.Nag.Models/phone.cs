using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class Phone {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }

        public virtual List<Plan> Plans { get; set; }
    }
}