using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Teacher : SystemUser
    {
        public Subject ResponsibleSubject { get; set; }
    }
}
