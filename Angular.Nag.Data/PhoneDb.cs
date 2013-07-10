using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular.Nag.Models;

namespace Angular.Nag.Data
{
    public class PhoneDb : DbContext
    {

        public DbSet<phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<phone>().HasKey(p => p.model);

            base.OnModelCreating(modelBuilder);
        }
    }
}
