﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {
        public PhoneDb(string connectionString)
            : base(connectionString) {

            //Note that setting the lazy loading feature here
            //is not effective as the UOW sets it in its CreateDbContext call.
            //this.Configuration.LazyLoadingEnabled = false;
        }

        //Default constructor used for code migrations
        public PhoneDb() { 

        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PhoneInstance> PhoneInstances { get; set; }
        public DbSet<App> Apps { get; set; }
        //public DbSet<PhoneCase> PhoneCases { get; set; }
        //public DbSet<PhoneCharger> PhoneChargers { get; set; }
        public DbSet<Accessory> Accessories { get; set; }

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
                        .HasMany(phone => phone.Apps)
                        .WithMany(app => app.Phones);

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


            modelBuilder.Entity<PhoneInstance>()
                        .Property(pi => pi.PhoneInstanceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PhoneInstance>()
                        .Property(pi => pi.SerialNumber).IsRequired();

            modelBuilder.Entity<PhoneInstance>()
                        .HasMany(pi => pi.Apps)
                        .WithMany(app => app.PhoneInstances);

            modelBuilder.Entity<Account>()
                .Property(ac => ac.AccountId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Account>().HasRequired(ac => ac.AccountHolder);
            modelBuilder.Entity<Account>().HasMany(ac => ac.Phones);

            modelBuilder.Entity<Accessory>()
                .ToTable("Accessories");

            //Note that the descriminator column should not actually exist in the model at all.
            modelBuilder.Entity<Accessory>()
                .Map<PhoneCharger>(m => m.Requires("Category").HasValue("Charger"))
                .Map<PhoneCase>(m => m.Requires("Category").HasValue("Case"));

            base.OnModelCreating(modelBuilder);
        }


    }
}
