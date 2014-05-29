using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithmTest
{
    internal class GeneticAlgorithmRunner
    {
        private readonly double _difficulty;
        private readonly double _kpcoverage;

        public GeneticAlgorithmRunner(double kpcoverage, double difficulty) {
            _kpcoverage = kpcoverage;
            _difficulty = difficulty;
        }

        /// <summary>
        ///     初始种群
        /// </summary>
        /// <param name="count">个体数量</param>
        /// <param name="paper">期望试卷</param>
        /// <param name="problemList">题库</param>
        /// <returns>初始种群</returns>
        public List<Unit> CSZQ(int count, Paper paper, List<Problem> problemList) {
            var unitList = new List<Unit>();
            var eachTypeCount = paper.EachTypeCount;
            Unit unit;
            var rand = new Random();
            for (var i = 0; i < count; i++) {
                unit = new Unit();
                unit.ID = i + 1;
                unit.AdaptationDegree = 0.00;

                //总分限制
                while (paper.TotalScore != unit.SumScore) {
                    unit.ProblemList.Clear();

                    //各题型题目数量限制
                    for (var j = 0; j < eachTypeCount.Length; j++) {
                        var oneTypeProblem = problemList
                            .Where(o => o.Type == (j + 1))
                            .Where(p => IsContain(paper, p))
                            .ToList();
                        var temp = new Problem();
                        for (var k = 0; k < eachTypeCount[j]; k++) {
                            //选择不重复的题目
                            var index = rand.Next(0, oneTypeProblem.Count - k);
                            unit.ProblemList.Add(oneTypeProblem[index]);
                            temp = oneTypeProblem[oneTypeProblem.Count - 1 - k];
                            oneTypeProblem[oneTypeProblem.Count - 1 - k] = oneTypeProblem[index];
                            oneTypeProblem[index] = temp;
                        }
                    }
                }
                unitList.Add(unit);
            }

            //计算知识点覆盖率及适应度
            unitList = GetKPCoverage(unitList, paper);
            unitList = GetAdaptationDegree(unitList, paper, _kpcoverage, _difficulty);

            return unitList;
        }

        /// <summary>
        ///     计算知识点覆盖率
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="paper">期望试卷</param>
        /// <returns>List</returns>
        public List<Unit> GetKPCoverage(List<Unit> unitList, Paper paper) {
            List<int> kp;
            for (var i = 0; i < unitList.Count; i++) {
                kp = new List<int>();
                unitList[i].ProblemList.ForEach(delegate(Problem p) { kp.AddRange(p.Points); });

                //个体所有题目知识点并集跟期望试卷知识点交集
                var common = kp.Intersect(paper.Points);
                unitList[i].KPCoverage = common.Count()*1.00/paper.Points.Count;
            }
            return unitList;
        }

        /// <summary>
        ///     计算种群适应度
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="paper">期望试卷</param>
        /// <param name="KPCoverage">知识点分布在适应度计算中所占权重</param>
        /// <param name="Difficulty">试卷难度系数在适应度计算中所占权重</param>
        /// <returns>List</returns>
        public List<Unit> GetAdaptationDegree(List<Unit> unitList, Paper paper, double KPCoverage, double Difficulty) {
            unitList = GetKPCoverage(unitList, paper);
            for (var i = 0; i < unitList.Count; i++) {
                unitList[i].AdaptationDegree = 1 - (1 - unitList[i].KPCoverage)*KPCoverage -
                                               Math.Abs(unitList[i].Difficulty - paper.Difficulty)*Difficulty;
            }
            return unitList;
        }

        /// <summary>
        ///     选择算子（轮盘赌选择）
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="count">选择次数</param>
        /// <returns>进入下一代的种群</returns>
        public List<Unit> Select(List<Unit> unitList, int count) {
            var selectedUnitList = new List<Unit>();

            //种群个体适应度和
            double AllAdaptationDegree = 0;
            unitList.ForEach(delegate(Unit u) { AllAdaptationDegree += u.AdaptationDegree; });

            var rand = new Random();
            while (selectedUnitList.Count != count) {
                //选择一个0—1的随机数字
                var degree = 0.00;
                var randDegree = rand.Next(1, 100)*0.01*AllAdaptationDegree;

                //选择符合要求的个体
                for (var j = 0; j < unitList.Count; j++) {
                    degree += unitList[j].AdaptationDegree;
                    if (degree >= randDegree) {
                        //不重复选择
                        if (!selectedUnitList.Contains(unitList[j])) {
                            selectedUnitList.Add(unitList[j]);
                        }
                        break;
                    }
                }
            }
            return selectedUnitList;
        }

        /// <summary>
        ///     交叉算子
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="count">交叉后产生的新种群个体数量</param>
        /// <param name="paper">期望试卷</param>
        /// <returns>List</returns>
        public List<Unit> Cross(List<Unit> unitList, int count, Paper paper) {
            var crossedUnitList = new List<Unit>();
            var rand = new Random();
            while (crossedUnitList.Count != count) {
                //随机选择两个个体
                var indexOne = rand.Next(0, unitList.Count);
                var indexTwo = rand.Next(0, unitList.Count);
                Unit unitOne;
                Unit unitTwo;
                if (indexOne != indexTwo) {
                    unitOne = unitList[indexOne];
                    unitTwo = unitList[indexTwo];

                    //随机选择一个交叉位置
                    var crossPosition = rand.Next(0, unitOne.ProblemCount - 2);

                    //保证交叉的题目分数合相同
                    double scoreOne = unitOne.ProblemList[crossPosition].Score +
                                      unitOne.ProblemList[crossPosition + 1].Score;
                    double scoreTwo = unitTwo.ProblemList[crossPosition].Score +
                                      unitTwo.ProblemList[crossPosition + 1].Score;
                    if (scoreOne == scoreTwo) {
                        //两个新个体
                        var unitNewOne = new Unit();
                        unitNewOne.ProblemList.AddRange(unitOne.ProblemList);
                        var unitNewTwo = new Unit();
                        unitNewTwo.ProblemList.AddRange(unitTwo.ProblemList);

                        //交换交叉位置后面两道题
                        for (var i = crossPosition; i < crossPosition + 2; i++) {
                            unitNewOne.ProblemList[i] = new Problem(unitTwo.ProblemList[i]);
                            unitNewTwo.ProblemList[i] = new Problem(unitOne.ProblemList[i]);
                        }

                        //添加到新种群集合中
                        unitNewOne.ID = crossedUnitList.Count;
                        unitNewTwo.ID = unitNewOne.ID + 1;
                        if (crossedUnitList.Count < count) {
                            crossedUnitList.Add(unitNewOne);
                        }
                        if (crossedUnitList.Count < count) {
                            crossedUnitList.Add(unitNewTwo);
                        }
                    }
                }

                //过滤重复个体
                crossedUnitList = crossedUnitList.Distinct(new ProblemComparer()).ToList();
            }

            //计算知识点覆盖率及适应度
            crossedUnitList = GetKPCoverage(crossedUnitList, paper);
            crossedUnitList = GetAdaptationDegree(crossedUnitList, paper, _kpcoverage, _difficulty);

            return crossedUnitList;
        }

        /// <summary>
        ///     变异算子
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="problemList">题库</param>
        /// <param name="paper">期望试卷</param>
        /// <returns>List</returns>
        public List<Unit> Change(List<Unit> unitList, List<Problem> problemList, Paper paper) {
            var rand = new Random();
            var index = 0;
            unitList.ForEach(delegate(Unit u) {
                //随机选择一道题
                index = rand.Next(0, u.ProblemList.Count);
                var temp = u.ProblemList[index];

                //得到这道题的知识点
                var problem = new Problem();
                for (var i = 0; i < temp.Points.Count; i++) {
                    if (paper.Points.Contains(temp.Points[i])) {
                        problem.Points.Add(temp.Points[i]);
                    }
                }

                //从数据库中选择包含此题有效知识点的同类型同分数不同题号试题
                var otherDB = from a in problemList
                    where a.Points.Intersect(problem.Points).Count() > 0
                    select a;

                var smallDB =
                    otherDB.Where(p => IsContain(paper, p))
                        .Where(o => o.Score == temp.Score && o.Type == temp.Type && o.ID != temp.ID)
                        .ToList();

                //从符合要求的试题中随机选一题替换
                if (smallDB.Count > 0) {
                    var changeIndex = rand.Next(0, smallDB.Count);
                    u.ProblemList[index] = smallDB[changeIndex];
                }
            });

            //计算知识点覆盖率跟适应度
            unitList = GetKPCoverage(unitList, paper);
            unitList = GetAdaptationDegree(unitList, paper, _kpcoverage, _difficulty);
            return unitList;
        }


        /// <summary>
        ///     调用示例
        /// </summary>
        public void Show() {
            //题库
            var db = new DB();

            //期望试卷
            var paper = new Paper {
                ID = 1,
                TotalScore = 100,
                Difficulty = 0.72,
                Points =
                    new List<int> {
                        1,
                        3,
                        5,
                        7,
                        9,
                        11,
                        13,
                        15,
                        17,
                        19,
                        21,
                        23,
                        25,
                        27,
                        29,
                        31,
                        33,
                        35,
                        37,
                        39,
                        41,
                        43,
                        45,
                        47,
                        49,
                        51,
                        53,
                        55,
                        57,
                        59,
                        61,
                        63,
                        65,
                        67,
                        69,
                        71,
                        73,
                        75,
                        77,
                        79,
                        81
                    },
                EachTypeCount = new[] {20, 5, 10, 7, 5}
            };

            //迭代次数计数器
            var count = 1;

            //适应度期望值
            var expand = 0.98;

            //最大迭代次数
            var runCount = 500;

            //初始化种群
            var unitList = CSZQ(20, paper, db.ProblemDB);
            Console.WriteLine("\n\n      -------遗传算法组卷系统(http://www.cnblogs.com/durongjian/)---------\n\n");
            Console.WriteLine("初始种群：");
            //ShowUnit(unitList);
            Console.WriteLine("-----------------------迭代开始------------------------");

            //开始迭代
            while (!IsEnd(unitList, expand)) {
                Console.WriteLine("在第 " + (count++) + " 代未得到结果");
                if (count > runCount) {
                    Console.WriteLine("计算 " + runCount + " 代仍没有结果，请重新设计条件！");
                    break;
                }

                //选择
                unitList = Select(unitList, 10);

                //交叉
                unitList = Cross(unitList, 20, paper);

                //是否可以结束（有符合要求试卷即可结束）
                if (IsEnd(unitList, expand)) {
                    break;
                }

                //变异
                unitList = Change(unitList, db.ProblemDB, paper);
            }
            if (count <= runCount) {
                Console.WriteLine("在第 " + count + " 代得到结果，结果为：\n");
                Console.WriteLine("期望试卷难度：" + paper.Difficulty + "\n");
                ShowResult(unitList, expand);
            }
        }

        #region 是否达到目标

        /// <summary>
        ///     是否达到目标
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="endcondition">结束条件（适应度要求）</param>
        /// <returns>bool</returns>
        public bool IsEnd(List<Unit> unitList, double endcondition) {
            if (unitList.Count > 0) {
                for (var i = 0; i < unitList.Count; i++) {
                    if (unitList[i].AdaptationDegree >= endcondition) {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 显示结果

        /// <summary>
        ///     显示结果
        /// </summary>
        /// <param name="unitList">种群</param>
        /// <param name="expand">期望适应度</param>
        public void ShowResult(List<Unit> unitList, double expand) {
            unitList.OrderBy(o => o.ID).ToList().ForEach(delegate(Unit u) {
                if (u.AdaptationDegree >= expand) {
                    Console.WriteLine("第" + u.ID + "套：");
                    Console.WriteLine("题目数量\t知识点分布\t难度系数\t适应度");
                    Console.WriteLine(u.ProblemCount + "\t\t" + u.KPCoverage.ToString("f2") + "\t\t" +
                                      u.Difficulty.ToString("f2") + "\t\t" + u.AdaptationDegree.ToString("f2") + "\n\n");
                }
            });
        }

        #endregion

        #region 显示种群个体题目编号

        /// <summary>
        ///     显示种群个体题目编号
        /// </summary>
        /// <param name="u">种群个体</param>
        public void ShowUnit(Unit u) {
            Console.WriteLine("编号\t知识点分布\t难度系数");
            Console.WriteLine(u.ID + "\t" + u.KPCoverage.ToString("f2") + "\t\t" + u.Difficulty.ToString("f2"));
            u.ProblemList.ForEach(delegate(Problem p) { Console.Write(p.ID + "\t"); });
            Console.WriteLine();
        }

        #endregion

        #region 题目知识点是否符合试卷要求

        /// <summary>
        ///     题目知识点是否符合试卷要求
        /// </summary>
        /// <param name="paper">期望试卷</param>
        /// <param name="problem">一首试题</param>
        /// <returns>bool</returns>
        private bool IsContain(Paper paper, Problem problem) {
            for (var i = 0; i < problem.Points.Count; i++) {
                if (paper.Points.Contains(problem.Points[i])) {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}