using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class MembershipService : IMembershipService
    {
        public SystemUser GetProfile(string userId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                SystemUser user = context.Users.Find(userId);

                return user;
            }
        }
    }
}