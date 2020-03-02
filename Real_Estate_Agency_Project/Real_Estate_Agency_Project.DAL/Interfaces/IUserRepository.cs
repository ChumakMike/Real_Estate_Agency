using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Models;

namespace Real_Estate_Agency_Project.DAL.Interfaces {
    interface IUserRepository : IDisposable {
        UserProfile GetById(string id);
        IEnumerable<UserProfile> GetAll();
        void Create(UserProfile UserProfile);
        void Remove(UserProfile UserProfile);
        void Update(UserProfile UserProfile);
    }
}
