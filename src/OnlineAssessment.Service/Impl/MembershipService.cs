using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class MembershipService : IMembershipService
    {
        public ApplicationUser GetProfile(string userId) {
            using (var context = new OnlineAssessmentContext()) {
                ApplicationUser user = context.Users.Find(userId);

                return user;
            }
        }
    }
}