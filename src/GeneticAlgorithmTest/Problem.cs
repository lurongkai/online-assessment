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
    public class Problem
    {
        public Problem() {
            ID = 0;
            Type = 0;
            Score = 0;
            Difficulty = 0.00;
            Points = new List<int>();
        }

        public Problem(Problem p) {
            ID = p.ID;
            Type = p.Type;
            Score = p.Score;
            Difficulty = p.Difficulty;
            Points = p.Points;
        }

        /// <summary>
        ///     编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     题型（1、2、3、4、5对应单选，多选，判断，填空，问答）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        ///     难度系数
        /// </summary>
        public double Difficulty { get; set; }

        /// <summary>
        ///     知识点
        /// </summary>
        public List<int> Points { get; set; }
    }
}