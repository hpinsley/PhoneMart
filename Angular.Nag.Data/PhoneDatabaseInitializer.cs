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

            var phone1 = new Phone { Manufacturer = nokia, Model = "Global 1000", Price = 25.0m, Description = @"Capture more of the moment with a 41 megapixel camera sensor, Full HD video and Nokia Rich Recording for incredible sound quality.", ImageFile = "phone01.jpg" };
            var phone2 = new Phone { Manufacturer = google, Model = "Android 200", Price = 75.0m, Description = @"Your home screen. Your world. With HTC BlinkFeed™ on your phone, you’re never out of touch with your world. All your favorite content is streamed live onto one screen. If it’s happening now, you’ll find it on your home screen.  Awesome camera. Awesome imaging tools.Awesome camera. Awesome imaging tools. Get perfect images with one-press continuous shooting, VideoPic, and a camera that captures 300% more light.Slim phone. Fat sound.  Slim phone. Dual frontal stereo speakers are teamed with powerful amplifiers, so everyone can hear what you’re hearing. Share music, share videos, share games—and share them loudly.", ImageFile = "phone02.jpg" };
            var phone3 = new Phone { Manufacturer = apple, Model = "iPhone 4", Price = 175.0m, Description = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", ImageFile = "phone03.png" };
            var phone4 = new Phone { Manufacturer = apple, Model = "iPhone 5",Price = 50.0m,Description = @"Apples's new top offering.  The iPhone 5 comes with Siri and a wealth of productivity apps making it the choice of todays savvy consumer.",ImageFile = "phone04.png"};

            context.Phones.Add(phone1);
            context.Phones.Add(phone2);
            context.Phones.Add(phone3);
            context.Phones.Add(phone4);

            context.SaveChanges();

            var plan1 = new Plan { PlanName = "Family Text and Talk", MonthlyCost = 100.0m, DataMinutes = 1000, VoiceMinutes = 500, Phones = new List<Phone> { phone1, phone3 } };
            var plan2 = new Plan { PlanName = "Yappers and Texters", MonthlyCost = 50.0m, DataMinutes = 500, VoiceMinutes = 250, Phones = new List<Phone> { phone1, phone3, phone4 } };
            var plan3 = new Plan { PlanName = "Teenage Text Special", MonthlyCost = 50.0m, DataMinutes = 500, VoiceMinutes = 250, Phones = new List<Phone> { phone2, phone3, phone4 } };
            var plan4 = new Plan { PlanName = "Frugal Family", MonthlyCost = 50.0m, DataMinutes = 500, VoiceMinutes = 250, Phones = new List<Phone> { phone1, phone3 } };

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

            var howardPhone1 = new PhoneInstance { Phone = phone1, PhonePlan = plan1, SerialNumber = "1XGY765-FDRFG-34JFKEK", PhoneNumber = "111-424-0430" };
            var howardPhone2 = new PhoneInstance { Phone = phone2, PhonePlan = plan2, SerialNumber = "2XGY765-FDRFG-34JFKEK", PhoneNumber = "222-424-0430" };
            var davidPhone1 = new PhoneInstance { Phone = phone3, PhonePlan = plan3, SerialNumber = "3XGY765-FDRFG-34JFKEK", PhoneNumber = "333-424-0430" };
            var davidPhone2 = new PhoneInstance { Phone = phone4, PhonePlan = plan4, SerialNumber = "4XGY765-FDRFG-34JFKEK", PhoneNumber = "444-424-0430" };

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