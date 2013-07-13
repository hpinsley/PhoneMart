﻿using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class phone {
        public string model { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imageFile { get; set; }

        public virtual List<Plan> plans { get; set; }
    }
}