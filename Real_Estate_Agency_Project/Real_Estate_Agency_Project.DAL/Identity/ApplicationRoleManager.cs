using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Real_Estate_Agency_Project.DAL.Models;


namespace Real_Estate_Agency_Project.DAL.Identity {
    internal class ApplicationRoleManager : RoleManager<ApplicationRole> {

        public ApplicationRoleManager(IRoleStore<ApplicationRole> store) : base(store) { }

        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store) { }
    }
}
