using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmTest
{
    public class Problem
    {
        public Problem()
        {
            ID = 0;
            Type = 0;
            Score = 0;
            Difficulty = 0.00;
            Points = new List<int>();
        }

        public Problem(Problem p)
        {
            this.ID = p.ID;
            this.Type = p.Type;
            this.Score = p.Score;
            this.Difficulty = p.Difficulty;
            this.Points = p.Points;
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 题型（1、2、3、4、5对应单选，多选，判断，填空，问答）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 难度系数
        /// </summary>
        public double Difficulty { get; set; }

        /// <summary>
        /// 知识点
        /// </summary>
        public List<int> Points { get; set; }
    } 
}
