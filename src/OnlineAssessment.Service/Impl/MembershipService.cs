using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class MembershipService : IMembershipService
    {
        public SystemUser GetProfile(string userId) {
            var context = new OnlineAssessmentContext();
            var user = context.Users.Find(userId);

            return user;
        }
    }
}
