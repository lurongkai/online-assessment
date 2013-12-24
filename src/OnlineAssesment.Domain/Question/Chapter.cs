using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Domain
{
    public class Chapter : ICanMigrate
    {
        public Guid ChapterId { get; set; }
        public string Title { get; set; }
    }
}
