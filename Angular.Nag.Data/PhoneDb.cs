using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {
        public PhoneDb()
            : base(@"Data Source=PINSLEYLAPTOP\SQLEXPRESS;Initial Catalog=Angular.Nag;Integrated Security=True") {

            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<phone> Phones { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<phone>()
                        .HasKey(p => p.model)
                        .HasMany(phone => phone.plans)
                        .WithMany(plan => plan.Phones);

            base.OnModelCreating(modelBuilder);
        }


    }
}
