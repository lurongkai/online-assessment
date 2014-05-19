using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain
{
    public class News
    {
        public News() {
            NewsId = Guid.NewGuid();
        }

        public Guid NewsId { get; set; }

        public string Content { get; set; }
    }
}
