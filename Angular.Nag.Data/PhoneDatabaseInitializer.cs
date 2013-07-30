using System.Collections.Generic;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data {
    public class PhoneDatabaseInitializer : DropCreateDatabaseAlways<PhoneDb> {

        protected override void Seed(PhoneDb context) {
            System.Diagnostics.Trace.WriteLine("Seeding phone values");

            var apple = new Manufacturer {ManufacturerName = "Apple"};
            var samsung = new Manufacturer {ManufacturerName = "Samsung"};
            var lg = new Manufacturer { ManufacturerName = "LG" };
            var casio = new Manufacturer { ManufacturerName = "Casio" };
            var google = new Manufacturer { ManufacturerName = "Google" };
            var microsoft = new Manufacturer { ManufacturerName = "Microsoft" };
            var nokia = new Manufacturer { ManufacturerName = "Nokia" };

            context.Manufacturers.Add(apple);
            context.Manufacturers.Add(samsung);
            context.Manufacturers.Add(lg);
            context.Manufacturers.Add(casio);
            context.Manufacturers.Add(google);
            context.Manufacturers.Add(microsoft);

            var global1000 = new Phone { Manufacturer = nokia, Model = "Global 1000", Price = 25.0m, Description = @"Capture more of the moment with a 41 megapixel camera sensor, Full HD video and Nokia Rich Recording for incredible sound quality.", ImageFile = "phone01.jpg" };
            var android200 = new Phone { Manufacturer = google, Model = "Android 200", Price = 75.0m, Description = @"Your home screen. Your world. With HTC BlinkFeed on your phone, you’re never out of touch with your world. All your favorite content is streamed live onto one screen. If it’s happening now, you’ll find it on your home screen.", ImageFile = "phone02.jpg" };
            var iPhone4 = new Phone { Manufacturer = apple, Model = "iPhone 4", Price = 175.0m, Description = @"The iPhone 4 is Apple's upgrade on the revolutionary iPhone.  It features the touch-screen user interface that has set the standard in consumer smart phones.", ImageFile = "phone03.png" };
            var iPhone5 = new Phone { Manufacturer = apple, Model = "iPhone 5", Price = 50.0m, Description = @"Apples's new top offering.  The iPhone 5 comes with Siri and a wealth of productivity apps making it the choice of todays savvy consumer.", ImageFile = "phone04.png" };
            var galaxy = new Phone { Manufacturer = samsung, Model = "Galaxy", Price = 150.0m, Description = @"The wildly popular Galaxy features its iconic large screen and a wealth of apps from the legions of Android developers", ImageFile = "phone02.jpg" };
            var win8 = new Phone { Manufacturer = microsoft, Model = "Win 8", Price = 125.0m, Description = @"Microsoft's Win 8 phone is its first entry into the smart phone market that is based on its new Metro-style user interface", ImageFile = "phone01.jpg" };
            var lgSlim = new Phone { Manufacturer = lg, Model = "Slimline", Price = 75.0m, Description = @"The original flip phone with its simple-to-use interface.", ImageFile = "phone01.jpg" };
            var starLight = new Phone { Manufacturer = casio, Model = "Star Light", Price = 175.0m, Description = @"Casio's top of the line phone.", ImageFile = "phone02.jpg" };

            context.Phones.Add(global1000);
            context.Phones.Add(android200);
            context.Phones.Add(iPhone4);
            context.Phones.Add(iPhone5);
            context.Phones.Add(galaxy);
            context.Phones.Add(win8);
            context.Phones.Add(lgSlim);
            context.Phones.Add(starLight);

            context.SaveChanges();

            var plan1 = new Plan { PlanName = "Family Text and Talk", MonthlyCost = 100.0m, DataMegabytes = 1000, VoiceMinutes = 500, Phones = new List<Phone> { global1000, iPhone4, galaxy, win8 } };
            var plan2 = new Plan { PlanName = "Yappers and Texters", MonthlyCost = 50.0m, DataMegabytes = 500, VoiceMinutes = 250, Phones = new List<Phone> { global1000, iPhone4, iPhone5, starLight } };
            var plan3 = new Plan { PlanName = "Teenage Text Special", MonthlyCost = 50.0m, DataMegabytes = 1000, VoiceMinutes = 150, Phones = new List<Phone> { android200, iPhone4, iPhone5, galaxy, starLight } };
            var plan4 = new Plan { PlanName = "Frugal Family", MonthlyCost = 25.0m, DataMegabytes = 250, VoiceMinutes = 250, Phones = new List<Phone> { global1000, iPhone4, win8, lgSlim } };

            context.Plans.Add(plan1);
            context.Plans.Add(plan2);
            context.Plans.Add(plan3);
            context.Plans.Add(plan4);

            context.SaveChanges();

            var howard = new Person { FullName = "Pinsley, Howard", ContactPhoneNumber = "914-424-0430", EmailAddress = "hpinsley@gmail.com" };
            var david = new Person { FullName = "Pinsley, David", ContactPhoneNumber = "914-424-0431", EmailAddress = "luckypilar@gmail.com" };

            context.People.Add(howard);
            context.People.Add(david);

            context.SaveChanges();

            var howardPhone1 = new PhoneInstance { Phone = global1000, PhonePlan = plan1, SerialNumber = "1XGY765-FDRFG-34JFKEK", PhoneNumber = "111-424-0430" };
            var howardPhone2 = new PhoneInstance { Phone = android200, PhonePlan = plan2, SerialNumber = "2XGY765-FDRFG-34JFKEK", PhoneNumber = "222-424-0430" };
            var davidPhone1 = new PhoneInstance { Phone = iPhone4, PhonePlan = plan3, SerialNumber = "3XGY765-FDRFG-34JFKEK", PhoneNumber = "333-424-0430" };
            var davidPhone2 = new PhoneInstance { Phone = iPhone5, PhonePlan = plan4, SerialNumber = "4XGY765-FDRFG-34JFKEK", PhoneNumber = "444-424-0430" };

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