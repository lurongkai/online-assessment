using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Domain
{
    [Flags]
    public enum CourseLevel
    {
        Level1 = 0x0001,
        Level2 = 0x0010,
        Level3 = 0x0100
    }
}
