namespace Angular.Nag.Data {
    public class PhoneRepository : IPhoneRepository {
        public PhoneDb GetDatabase() {
            return new PhoneDb();
        }
    }
}