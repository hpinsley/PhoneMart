using System.Collections.Generic;
using Angular.Nag.Models;

namespace Angular.Nag.Data {
    public static class Seeder {

        public static void Seed(PhoneDb context) {
            System.Diagnostics.Trace.WriteLine("Seeding phone values");

            var mercury = new Manufacturer { ManufacturerName = "Mercury" };
            var venus = new Manufacturer { ManufacturerName = "Venus" };
            var mars = new Manufacturer { ManufacturerName = "Mars" };
            var jupiter = new Manufacturer { ManufacturerName = "Jupiter" };
            var saturn = new Manufacturer { ManufacturerName = "Saturn" };
            var uranus = new Manufacturer { ManufacturerName = "Uranus" };
            var pluto = new Manufacturer { ManufacturerName = "Pluto" };

            context.Manufacturers.Add(mercury);
            context.Manufacturers.Add(venus);
            context.Manufacturers.Add(mars);
            context.Manufacturers.Add(jupiter);
            context.Manufacturers.Add(saturn);
            context.Manufacturers.Add(uranus);

            var global1000 = new Phone { Manufacturer = pluto, Model = "Global 1000", Price = 25.0m, Description = @"Capture more of the moment with a 41 megapixel camera sensor, Full HD video and Pluto's Great Recording for incredible sound quality.", ImageFile = "phone01.jpg" };
            var android200 = new Phone { Manufacturer = saturn, Model = "Android 200", Price = 75.0m, Description = @"Saturn's Android 200 sets the gold standard among Android phones.", ImageFile = "phone02.jpg" };
            var swift4 = new Phone { Manufacturer = mercury, Model = "Swift 4", Price = 175.0m, Description = @"The Swift 4 is Mercury's upgrade on the revolutionary Swift.  It features the touch-screen user interface that has set the standard in consumer smart phones.", ImageFile = "phone03.png" };
            var swift5 = new Phone { Manufacturer = mercury, Model = "Swift 5", Price = 50.0m, Description = @"Swifts's new top offering.  The Swift 5 comes with Merlin and a wealth of productivity apps making it the choice of todays savvy consumer.", ImageFile = "phone04.png" };
            var galaxy = new Phone { Manufacturer = venus, Model = "Universe", Price = 150.0m, Description = @"The wildly popular Universe features its iconic large screen and a wealth of apps from the legions of Android developers", ImageFile = "phone02.jpg" };
            var axis8 = new Phone { Manufacturer = uranus, Model = "Axis 8", Price = 125.0m, Description = @"The Axis 8 phone is Uranus's first entry into the smart phone market that is based on its new Cosmo-style user interface", ImageFile = "phone01.jpg" };
            var lgSlim = new Phone { Manufacturer = mars, Model = "Slimline", Price = 75.0m, Description = @"The original flip phone with its simple-to-use interface.", ImageFile = "phone01.jpg" };
            var starLight = new Phone { Manufacturer = jupiter, Model = "Star Light", Price = 175.0m, Description = @"Jupiters's top of the line phone.", ImageFile = "phone02.jpg" };

            context.Phones.Add(global1000);
            context.Phones.Add(android200);
            context.Phones.Add(swift4);
            context.Phones.Add(swift5);
            context.Phones.Add(galaxy);
            context.Phones.Add(axis8);
            context.Phones.Add(lgSlim);
            context.Phones.Add(starLight);

            context.SaveChanges();

            var plan1 = new Plan { PlanName = "Family Text and Talk", MonthlyCost = 100.0m, DataMegabytes = 1000, VoiceMinutes = 500, Phones = new List<Phone> { global1000, swift4, galaxy, axis8 } };
            var plan2 = new Plan { PlanName = "Yappers and Texters", MonthlyCost = 50.0m, DataMegabytes = 500, VoiceMinutes = 250, Phones = new List<Phone> { global1000, swift4, swift5, starLight } };
            var plan3 = new Plan { PlanName = "Teenage Text Special", MonthlyCost = 50.0m, DataMegabytes = 1000, VoiceMinutes = 150, Phones = new List<Phone> { android200, swift4, swift5, galaxy, starLight } };
            var plan4 = new Plan { PlanName = "Frugal Family", MonthlyCost = 25.0m, DataMegabytes = 250, VoiceMinutes = 250, Phones = new List<Phone> { global1000, swift4, axis8, lgSlim } };

            context.Plans.Add(plan1);
            context.Plans.Add(plan2);
            context.Plans.Add(plan3);
            context.Plans.Add(plan4);

            var app1 = new App { Name = "Angry Birds", Price = 2.99m ,Description = "Get the evil pigs by launching the virtuous birds!", Phones = new List<Phone> { global1000, swift4, galaxy, axis8 } };
            var app2 = new App { Name = "Tweet Caster", Price = 1.99m, Description = "The top of the line twitter client.", Phones = new List<Phone> { global1000, starLight, galaxy, axis8 } };
            var app3 = new App { Name = "Calendar", Price = 0m, Description = "Keeps track of your appointments and more", Phones = new List<Phone> { starLight, swift4, galaxy, lgSlim } };
            var app4 = new App { Name = "Email", Price = 0m, Description = "The best smartphone email client around.", Phones = new List<Phone> { global1000, swift4, galaxy, axis8 } };

            context.Apps.Add(app1);
            context.Apps.Add(app2);
            context.Apps.Add(app3);
            context.Apps.Add(app4);

            context.SaveChanges();

            var howard = new Person { FullName = "Pinsley, Howard", ContactPhoneNumber = "914-424-0430", EmailAddress = "hpinsley@gmail.com" };
            var david = new Person { FullName = "Pinsley, David", ContactPhoneNumber = "914-424-0431", EmailAddress = "luckypilar@gmail.com" };

            context.People.Add(howard);
            context.People.Add(david);

            context.SaveChanges();

            var howardPhone1 = new PhoneInstance { Phone = global1000, PhonePlan = plan1, SerialNumber = "1XGY765-FDRFG-34JFKEK", PhoneNumber = "111-424-0430" };
            var howardPhone2 = new PhoneInstance { Phone = starLight, PhonePlan = plan2, SerialNumber = "2XGY765-FDRFG-34JFKEK", PhoneNumber = "222-424-0430" };
            var davidPhone1 = new PhoneInstance { Phone = swift4, PhonePlan = plan3, SerialNumber = "3XGY765-FDRFG-34JFKEK", PhoneNumber = "333-424-0430" };
            var davidPhone2 = new PhoneInstance { Phone = lgSlim, PhonePlan = plan4, SerialNumber = "4XGY765-FDRFG-34JFKEK", PhoneNumber = "444-424-0430" };

            context.PhoneInstances.Add(howardPhone1);
            context.PhoneInstances.Add(howardPhone2);
            context.PhoneInstances.Add(davidPhone1);
            context.PhoneInstances.Add(davidPhone2);

            context.SaveChanges();

            var howardAcct = new Account { AccountHolder = howard };
            context.Accounts.Add(howardAcct);
            howardAcct.Phones.Add(howardPhone1);
            howardAcct.Phones.Add(howardPhone2);

            var davidAcct = new Account { AccountHolder = david };
            context.Accounts.Add(davidAcct);
            davidAcct.Phones.Add(davidPhone1);
            davidAcct.Phones.Add(davidPhone2);

            context.SaveChanges();

            System.Diagnostics.Trace.WriteLine("Seeded phone values");
        }

    }
}