using System.Collections.Generic;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data {
    public class PhoneDatabaseInitializer : DropCreateDatabaseAlways<PhoneDb> {

        protected override void Seed(PhoneDb context) {
            System.Diagnostics.Trace.WriteLine("Seeding phone values");
            var phone1 = new phone {model = "Nokia 1000", price = 25.0m, description = "Nokia's top offering", imageFile = "phone01.png"};
            var phone2 = new phone {model = "Android 200",price = 75.0m,description = "Androids's top offering",imageFile = "phone02.jpg"};
            var phone3 = new phone {model = "iPhone 4",price = 175.0m,description = "Apples's old top offering",imageFile = "phone03.jpg"};
            var phone4 = new phone {model = "iPhone 5",price = 50.0m,description = "Apples's new top offering",imageFile = "phone04.jpg"};

            context.Phones.Add(phone1);
            context.Phones.Add(phone2);
            context.Phones.Add(phone3);
            context.Phones.Add(phone4);

            context.SaveChanges();

            var plan1 = new Plan { PlanId = 1, PlanName = "Plan One", MonthlyCost = 100.0m, DataMinutes = 1000, VoiceMinutes = 500, Phones = new List<phone>() { phone1, phone3 } };
            var plan2 = new Plan { PlanId = 2, PlanName = "Plan Two", MonthlyCost = 50.0m, DataMinutes = 500, VoiceMinutes = 250, Phones = new List<phone>() { phone2, phone3, phone4 } };

            context.Plans.Add(plan1);
            context.Plans.Add(plan2);

            context.SaveChanges();
            System.Diagnostics.Trace.WriteLine("Seeded phone values");
        }
         
    }
}