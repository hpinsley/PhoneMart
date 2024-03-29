﻿using System.Collections.Generic;

namespace Angular.Nag.Models {
    public class Plan {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal MonthlyCost { get; set; }
        public int VoiceMinutes { get; set; }
        public int DataMegabytes { get; set; }

        public List<Phone> Phones { get; set; }

        public Plan() {
            Phones = new List<Phone>();
        }
    }
}