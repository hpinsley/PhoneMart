using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data {
    public class PhoneDatabaseInitializer : DropCreateDatabaseAlways<PhoneDb> {

        protected override void Seed(PhoneDb context) {
            System.Diagnostics.Trace.WriteLine("Seeding phone values");
            context.Phones.Add(new phone() { model = "Nokia 1000", price = 25.0m, description = "Nokia's top offering" });
            context.Phones.Add(new phone() { model = "Android 200", price = 75.0m, description = "Androids's top offering" });
            context.Phones.Add(new phone() { model = "iPhone 4", price = 175.0m, description = "Apples's old top offering" });
            context.Phones.Add(new phone() { model = "iPhone 5", price = 50.0m, description = "Apples's new top offering" });
            context.SaveChanges();
            System.Diagnostics.Trace.WriteLine("Seeded phone values");
        }
         
    }
}