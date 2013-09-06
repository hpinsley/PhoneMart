using System.Data.Entity;

namespace Angular.Nag.Data {

    //I created this initializer to use in the hosted environment
    //where I have to create an empty database manually.  The code
    //cannot drop and recreate it.  This allows me to seed an empty
    //database.  Somehow, the tables do get created.
    public class NoDropInitializer : IDatabaseInitializer<PhoneDb> {
        public void InitializeDatabase(PhoneDb context) {
            Seeder.Seed(context);
        }
    }
}