using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmTest
{
    public class Unit
    {
        public Unit()
        {
            ID = 0;
            AdaptationDegree = 0.00;
            KPCoverage = 0.00;
            ProblemList = new List<Problem>();
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 适应度
        /// </summary>
        public double AdaptationDegree { get; set; }

        /// <summary>
        /// 难度系数（本试卷所有题目分数*难度系数/总分）
        /// </summary>
        public double Difficulty
        {
            get
            {
                double diff = 0.00;
                ProblemList.ForEach(delegate(Problem p)
                {
                    diff += p.Difficulty * p.Score;
                });
                return diff / SumScore;
            }
        }

        /// <summary>
        /// 题目数量
        /// </summary>
        public int ProblemCount
        {
            get
            {
                return ProblemList.Count;
            }
        }

        /// <summary>
        /// 总分
        /// </summary>
        public int SumScore
        {
            get
            {
                int sum = 0;
                ProblemList.ForEach(delegate(Problem p)
                {
                    sum += p.Score;
                });
                return sum;
            }
        }

        /// <summary>
        /// 知识点分布
        /// </summary>
        public double KPCoverage { get; set; }

        /// <summary>
        /// 题目
        /// </summary>
        public List<Problem> ProblemList { get; set; }
    }
}
