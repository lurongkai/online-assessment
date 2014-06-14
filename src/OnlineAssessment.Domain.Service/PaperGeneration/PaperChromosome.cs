using System;
using System.Linq;
using OnlineAssessment.Domain.Service.GeneticAlgorithm;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
	public class PaperChromosome
	{
		private double _expectedDegree;

		public List<QuestionCharacter> GeneSeries { get; private set; }

		// 试卷期望难度系数
		public PaperChromosome(double expectedDegree)
		{
			_expectedDegree = expectedDegree;
		}

		public int TotalScore {
			get { return GeneSeries.Sum(q => q.Score); }
		}

		public double Degree {
			get { return GeneSeries.Sum(q => q.Score * q.QuestionDegree) / TotalScore; }
		}

		public double Fitness {
			get {
				return GeneSeries.Count == 0
						? 0.00
						: 1.00 - Math.Abs(Degree - _expectedDegree);
			}
		}

		public void ClearAllGenes()
		{
			GeneSeries.Clear();
		}

		public void AddGenes(IEnumerable<QuestionCharacter> questions)
		{
			GeneSeries.AddRange(questions);
		}
	}
}

