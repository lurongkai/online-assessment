using System;
using System.Collections.Generic;

namespace GeneticAlgorithmTest
{
    public class DB
    {
        /// <summary>
        ///     题库
        /// </summary>
        public List<Problem> ProblemDB;

        public DB() {
            ProblemDB = new List<Problem>();
            Problem model;
            var rand = new Random();
            List<int> Points;
            for (var i = 1; i <= 5000; i++) {
                model = new Problem();
                model.ID = i;

                //试题难度系数取0.3到1之间的随机值
                model.Difficulty = rand.Next(30, 100)*0.01;

                //单选题1分
                if (i < 1001) {
                    model.Type = 1;
                    model.Score = 1;
                }

                //单选题2分
                if (i > 1000 && i < 2001) {
                    model.Type = 2;
                    model.Score = 2;
                }

                //判断题2分
                if (i > 2000 && i < 3001) {
                    model.Type = 3;
                    model.Score = 2;
                }

                //填空题1—4分
                if (i > 3000 && i < 4001) {
                    model.Type = 4;
                    model.Score = rand.Next(1, 5);
                }

                //问答题分数为难度系数*10
                if (i > 4000 && i < 5001) {
                    model.Type = 5;
                    model.Score = model.Difficulty > 0.3 ? (int) (double.Parse(model.Difficulty.ToString("f1"))*10) : 3;
                }

                Points = new List<int>();
                //每题1到4个知识点
                var count = rand.Next(1, 5);
                for (var j = 0; j < count; j++) {
                    Points.Add(rand.Next(1, 100));
                }
                model.Points = Points;
                ProblemDB.Add(model);
            }
        }
    }
}