using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Domain
{
    [Flags]
    public enum CourseLevel
    {
        CoursewareDesignerLevel1 = 0x0001,
        CoursewareDesignerLevel2 = 0x0010,
        CoursewareDesignerLevel3 = 0x0100
    }
}
