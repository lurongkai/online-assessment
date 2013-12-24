using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Infrastructure
{
    public class OnlineAssessmentContextInitializer : DropCreateDatabaseIfModelChanges<OnlineAssessmentContext>
    {
        protected override void Seed(OnlineAssessmentContext context) {
                
        }
    }
}
