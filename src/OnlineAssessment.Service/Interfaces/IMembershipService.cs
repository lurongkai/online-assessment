using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IMembershipService
    {
        ApplicationUser GetProfile(string userId);
    }
}