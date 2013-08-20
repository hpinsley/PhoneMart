using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {
        public PhoneDb()
            : base(GetConnectionString()) {

            //Note that setting the lazy loading feature here
            //is not effective as the UOW sets it in its CreateDbContext call.
            //this.Configuration.LazyLoadingEnabled = false;
        }

        private static string GetConnectionString() {
            const string key = "phones";
            var connection = ConfigurationManager.ConnectionStrings[key];
            if (connection != null) {
                return connection.ConnectionString;
            }
            throw new Exception(string.Format("Unable to location connection string '{0}'", key));
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PhoneInstance> PhoneInstances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Manufacturer>()
                        .Property(m=>m.ManufacturerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Manufacturer>()
                        .HasMany(m => m.Phones)
                        .WithRequired(p => p.Manufacturer);

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

            modelBuilder.Entity<Person>()
                        .Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Person>()
                        .Property(p => p.FullName).IsRequired();

            /*
             *         public int PhoneInstanceId { get; set; }
        public Phone Phone { get; set; }
        public string SerialNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Plan PhonePlan { get; set; }*/

            modelBuilder.Entity<PhoneInstance>()
                        .Property(pi => pi.PhoneInstanceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PhoneInstance>()
                        .Property(pi => pi.SerialNumber).IsRequired();

            /*
             *  public int AccountId { get; set; }
        public Person AccountHolder { get; set; }
        public List<PhoneInstance> Phones { get; set; }*/

            modelBuilder.Entity<Account>()
                .Property(ac => ac.AccountId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Account>().HasRequired(ac => ac.AccountHolder);
            modelBuilder.Entity<Account>().HasMany(ac => ac.Phones);
                        


            base.OnModelCreating(modelBuilder);
        }


    }
}
