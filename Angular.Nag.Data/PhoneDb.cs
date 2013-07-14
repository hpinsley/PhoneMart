using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {
        public PhoneDb()
            : base(@"Data Source=PINSLEYLAPTOP\SQLEXPRESS;Initial Catalog=Angular.Nag;Integrated Security=True") {

            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Phone>()
                        .HasKey(p => p.Model)
                        .HasMany(phone => phone.Plans)
                        .WithMany(plan => plan.Phones);

            base.OnModelCreating(modelBuilder);
        }


    }
}
