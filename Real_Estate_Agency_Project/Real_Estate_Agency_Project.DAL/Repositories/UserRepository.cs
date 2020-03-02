using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Interfaces;
using Real_Estate_Agency_Project.DAL.Models;
using Real_Estate_Agency_Project.DAL.DBContext;
using System.Data.Entity;

namespace Real_Estate_Agency_Project.DAL.Repositories {
    internal class UserRepository : IUserRepository {

        private EFApplicatonContext EFApplicatonContext;

        public UserRepository(EFApplicatonContext ApplicatonContext) 
            => this.EFApplicatonContext = ApplicatonContext;

        public void Create(UserProfile UserProfile) {
            EFApplicatonContext.UserProfiles.Add(UserProfile);
        }

        public IEnumerable<UserProfile> GetAll() {
            return EFApplicatonContext.UserProfiles;
        }

        public UserProfile GetById(string id) {
            return EFApplicatonContext.UserProfiles.Find(id);
        }

        public void Remove(UserProfile UserProfile) {
            var local = EFApplicatonContext.Set<UserProfile>()
                         .Local
                         .FirstOrDefault(x => x.Id == UserProfile.Id);
            if (local != null) {
                EFApplicatonContext.Entry(local).State = EntityState.Detached;
            }
            EFApplicatonContext.UserProfiles.Attach(UserProfile);
            EFApplicatonContext.Entry(UserProfile).State = EntityState.Deleted;
            EFApplicatonContext.UserProfiles.Remove(UserProfile);
        }

        public void Update(UserProfile UserProfile) {
            var local = EFApplicatonContext.Set<UserProfile>()
                         .Local
                         .FirstOrDefault(x => x.Id == UserProfile.Id);
            if (local != null) {
                EFApplicatonContext.Entry(local).State = EntityState.Detached;
            }
            EFApplicatonContext.Entry(UserProfile).State = EntityState.Modified;
        }

        public void Dispose() {
            EFApplicatonContext.Dispose();
        }
    }
}
