using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {
        public PhoneDb()
            : base(@"Data Source=PINSLEYLAPTOP\SQLEXPRESS;Initial Catalog=Angular.Nag;Integrated Security=True") {

            //Note that setting the lazy loading feature here
            //is not effective as the UOW sets it in its CreateDbContext call.
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Phone>()
                        .HasKey(p => p.PhoneId)
                        .HasMany(phone => phone.Plans)
                        .WithMany(plan => plan.Phones);

            modelBuilder.Entity<Phone>()
                        .Property(p => p.PhoneId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Plan>()
                        .Property(p => p.PlanId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }


    }
}
