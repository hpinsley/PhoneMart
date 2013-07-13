using System.Collections.Generic;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data {
    public class PhoneDatabaseInitializer : DropCreateDatabaseAlways<PhoneDb> {

        protected override void Seed(PhoneDb context) {
            System.Diagnostics.Trace.WriteLine("Seeding phone values");
            var phone = new phone() {model = "Nokia 1000", price = 25.0m, description = "Nokia's top offering", imageFile = "phone01.png"};
            context.Phones.Add(phone);
            context.Phones.Add(new phone() { model = "Android 200", price = 75.0m, description = "Androids's top offering", imageFile = "phone02.jpg"});
            context.Phones.Add(new phone() { model = "iPhone 4", price = 175.0m, description = "Apples's old top offering", imageFile = "phone03.jpg"});
            context.Phones.Add(new phone() { model = "iPhone 5", price = 50.0m, description = "Apples's new top offering", imageFile = "phone04.jpg"});
            context.SaveChanges();

            var plan = new Plan() {
                PlanId = 1,
                PlanName = "Plan One",
                MonthlyCost = 100.0m,
                DataMinutes = 1000,
                VoiceMinutes = 500,
                Phones = new List<phone>(){phone}
            };

            context.Plans.Add(plan);
            context.SaveChanges();
            System.Diagnostics.Trace.WriteLine("Seeded phone values");
        }
         
    }
}