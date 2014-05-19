using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain
{
    public enum QuestionCategory
    {
        UnitTesting,                    // 单元测试
        ComprehensiveTesting,           // 综合题测试
        SimulationTesting,              // 模拟考试
        ModularizedTheoryExam,          // 模块化考试-理论模块
        ModularizedSkillExam,           // 模块化考试-技能模块
        ModularizedSkillExtensionExam   // 模块化考试-拓展技能模块
    }
}
