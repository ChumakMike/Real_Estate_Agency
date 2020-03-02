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
    internal class AnnouncmentRepository : IAnnouncmentRepository {

        private EFApplicatonContext EFApplicatonContext;

        public AnnouncmentRepository(EFApplicatonContext ApplicatonContext) 
            => this.EFApplicatonContext = ApplicatonContext;

        public void Create(Announcment announcment) {
            EFApplicatonContext.Announcments.Add(announcment);
        }

        public IEnumerable<Announcment> GetAll() {
            return EFApplicatonContext.Announcments;
        }

        public Announcment GetById(int id) {
            return EFApplicatonContext.Announcments.Find(id);
        }

        public IEnumerable<Announcment> GetByUserId(string id) {
            return EFApplicatonContext.Announcments.Where(x => x.UserId == id);
        }

        public void Remove(Announcment announcment) {
            var local = EFApplicatonContext.Set<Announcment>()
                         .Local
                         .FirstOrDefault(x => x.AnnouncmentId == announcment.AnnouncmentId);
            if (local != null) {
                EFApplicatonContext.Entry(local).State = EntityState.Detached;
            }
            EFApplicatonContext.Announcments.Attach(announcment);
            EFApplicatonContext.Entry(announcment).State = EntityState.Deleted;
            EFApplicatonContext.Announcments.Remove(announcment);
        }

        public void Update(Announcment announcment) {
            var local = EFApplicatonContext.Set<Announcment>()
                        .Local
                        .FirstOrDefault(x => x.AnnouncmentId == announcment.AnnouncmentId);
            if (local != null) {
                EFApplicatonContext.Entry(local).State = EntityState.Detached;
            }
            EFApplicatonContext.Entry(announcment).State = EntityState.Modified;
        }

        public void Dispose() {
            EFApplicatonContext.Dispose();
        }

    }
}
