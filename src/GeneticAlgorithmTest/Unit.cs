// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Collections.Generic;

namespace GeneticAlgorithmTest
{
    public class Unit
    {
        public Unit() {
            ID = 0;
            AdaptationDegree = 0.00;
            KPCoverage = 0.00;
            ProblemList = new List<Problem>();
        }

        /// <summary>
        ///     编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     适应度
        /// </summary>
        public double AdaptationDegree { get; set; }

        /// <summary>
        ///     难度系数（本试卷所有题目分数*难度系数/总分）
        /// </summary>
        public double Difficulty {
            get {
                var diff = 0.00;
                ProblemList.ForEach(delegate(Problem p) { diff += p.Difficulty*p.Score; });
                return diff/SumScore;
            }
        }

        /// <summary>
        ///     题目数量
        /// </summary>
        public int ProblemCount {
            get { return ProblemList.Count; }
        }

        /// <summary>
        ///     总分
        /// </summary>
        public int SumScore {
            get {
                var sum = 0;
                ProblemList.ForEach(delegate(Problem p) { sum += p.Score; });
                return sum;
            }
        }

        /// <summary>
        ///     知识点分布
        /// </summary>
        public double KPCoverage { get; set; }

        /// <summary>
        ///     题目
        /// </summary>
        public List<Problem> ProblemList { get; set; }
    }
}