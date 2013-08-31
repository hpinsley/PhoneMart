using System.Data.Entity;

namespace Angular.Nag.Data {
    public class NoDropInitializer : IDatabaseInitializer<PhoneDb> {
        public void InitializeDatabase(PhoneDb context) {
            Seeder.Seed(context);
        }
    }
}