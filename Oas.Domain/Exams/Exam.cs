﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        public string Description { get; set; }

        public Paper Paper { get; set; }
        public ExamSchedule Schedule { get; set; }
    }
}
