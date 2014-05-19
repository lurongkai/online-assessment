using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IMembershipService
    {
        SystemUser GetProfile(string userId);
    }
}
