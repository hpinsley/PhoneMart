namespace Angular.Nag.Models {
    public class PhoneInstance {
        public int PhoneInstanceId { get; set; }
        public Phone Phone { get; set; }
        public string SerialNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Plan PhonePlan { get; set; }
    }
}