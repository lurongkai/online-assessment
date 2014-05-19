using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmTest
{
    public class Paper
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 总分
        /// </summary>
        public int TotalScore { get; set; }

        /// <summary>
        /// 难度系数
        /// </summary>
        public double Difficulty { get; set; }

        /// <summary>
        /// 知识点
        /// </summary>
        public List<int> Points { get; set; }

        /// <summary>
        /// 各种题型题数
        /// </summary>
        public int[] EachTypeCount { get; set; }
    } 
}
