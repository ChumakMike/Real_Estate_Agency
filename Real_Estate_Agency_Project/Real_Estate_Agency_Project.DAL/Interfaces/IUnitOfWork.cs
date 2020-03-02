using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_Estate_Agency_Project.DAL.Interfaces;
using Real_Estate_Agency_Project.DAL.Identity;


namespace Real_Estate_Agency_Project.DAL.Interfaces {
    interface IUnitOfWork : IDisposable {
        IUserRepository UserRepository { get; }
        IAnnouncmentRepository AnnouncmentRepository { get; }
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
