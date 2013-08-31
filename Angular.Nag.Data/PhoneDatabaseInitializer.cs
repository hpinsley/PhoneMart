using System.Collections.Generic;
using System.Data.Entity;
using Angular.Nag.Models;
using Devtalk.EF.CodeFirst;

namespace Angular.Nag.Data {
    public class PhoneDatabaseInitializer : CreateDatabaseIfNotExists<PhoneDb> {

        protected override void Seed(PhoneDb context) {
            Seeder.Seed(context);
        }
         
    }
}