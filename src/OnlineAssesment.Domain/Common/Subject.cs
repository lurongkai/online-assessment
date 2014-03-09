using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Domain
{
    public class Subject : ICanMigrate
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
    }
}
