namespace Angular.Nag.Services.Models {
    public class NewPhone {
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public int[] PlanIds { get; set; }
        public int[] AppIds { get; set; }

        public override string ToString() {
            return string.Format("Phone Model: {0}; Description: {1}; Price: {2}",
                                 Model, Description, Price);
        }

    }
}