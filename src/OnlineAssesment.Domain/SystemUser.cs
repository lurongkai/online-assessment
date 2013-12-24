using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class SystemUser : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
