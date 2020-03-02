using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Identity;
using Real_Estate_Agency_Project.DAL.Interfaces;
using Real_Estate_Agency_Project.DAL.Repositories;
using Real_Estate_Agency_Project.DAL.DBContext;

namespace Real_Estate_Agency_Project.DAL.UOW {

    internal class UnitOfWork : IUnitOfWork {

        private readonly EFApplicatonContext ApplicatonContext;
        private UserRepository userRepository;
        private AnnouncmentRepository announcmentRepository;
        private ApplicationRoleManager roleManager;
        private ApplicationUserManager userManager;

        public UnitOfWork() => ApplicatonContext = new EFApplicatonContext();
        public UnitOfWork(EFApplicatonContext ApplicatonContext) => this.ApplicatonContext = ApplicatonContext;

       // public IUserRepository UserRepository => userRepository ??= new UserRepository(ApplicatonContext);

        public IAnnouncmentRepository AnnouncmentRepository => throw new NotImplementedException();

        public ApplicationUserManager UserManager => throw new NotImplementedException();

        public ApplicationRoleManager RoleManager => throw new NotImplementedException();

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
