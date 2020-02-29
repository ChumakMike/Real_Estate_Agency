﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Real_Estate_Agency_Project.DAL.Models {
    internal class ApplicationUser : IdentityUser {
        public virtual UserProfile UserProfile { get; set; }
    }
}
