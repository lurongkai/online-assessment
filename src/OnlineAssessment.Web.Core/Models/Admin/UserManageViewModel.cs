using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Web.Core.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }

        public bool IsTeacher { get; set; }
    }

    public class UserManageViewModel
    {
       public IEnumerable<UserViewModel> Users { get; set; } 
    }
}
