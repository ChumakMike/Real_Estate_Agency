using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Identity;
using Real_Estate_Agency_Project.DAL.Interfaces;
using Real_Estate_Agency_Project.DAL.Repositories;
using Real_Estate_Agency_Project.DAL.DBContext;
using Real_Estate_Agency_Project.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Real_Estate_Agency_Project.DAL.UOW {

    internal class UnitOfWork : IUnitOfWork {

        private readonly EFApplicatonContext ApplicatonContext;
        private UserRepository userRepository;
        private AnnouncmentRepository announcmentRepository;
        private ApplicationRoleManager roleManager;
        private ApplicationUserManager userManager;

        public UnitOfWork() {
            ApplicatonContext = new EFApplicatonContext();
            userRepository = new UserRepository(ApplicatonContext);
            announcmentRepository = new AnnouncmentRepository(ApplicatonContext);
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(ApplicatonContext));
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ApplicatonContext));
        }

        public UnitOfWork(EFApplicatonContext ApplicatonContext) => this.ApplicatonContext = ApplicatonContext;

        public IUserRepository UserRepository => userRepository;

        public IAnnouncmentRepository AnnouncmentRepository => announcmentRepository;

        public ApplicationUserManager UserManager => userManager;

        public ApplicationRoleManager RoleManager => roleManager;

        private bool disposed = false;

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    AnnouncmentRepository?.Dispose();
                    UserRepository?.Dispose();
                }
                this.disposed = true;
            }
        }

        public void SaveChanges() {
            ApplicatonContext.SaveChanges();
        }

        public async Task SaveChangesAsync() {
            await ApplicatonContext.SaveChangesAsync();
        }
    }
}
