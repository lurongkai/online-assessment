﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Teacher : SystemUser
    {
        public virtual Subject ResponsibleSubject { get; set; }
    }
}
