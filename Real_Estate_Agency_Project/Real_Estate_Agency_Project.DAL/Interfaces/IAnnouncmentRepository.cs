using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Models;

namespace Real_Estate_Agency_Project.DAL.Interfaces {
    interface IAnnouncmentRepository : IDisposable {
        Announcment GetById(int id);
        IEnumerable<Announcment> GetAll();
        void Create(Announcment announcment);
        void Remove(Announcment announcment);
        void Update(Announcment announcment);
        IEnumerable<Announcment> GetByUserId(string id);
    }
}
