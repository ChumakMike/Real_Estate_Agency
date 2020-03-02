using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Real_Estate_Agency_Project.DAL.Models;

namespace Real_Estate_Agency_Project.DAL.DBContext {
    internal class EFApplicatonContext : IdentityDbContext<ApplicationUser> {

        public EFApplicatonContext() : base("ApplicationContext", throwIfV1Schema : false) { }
        public EFApplicatonContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Announcment> Announcments { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(u => new { u.RoleId, u.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
