using System;
using System.Linq;
using OnlineAssessment.Domain.Service.GeneticAlgorithm;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
	public class PaperChromosome : Chromosome<QuestionGene>
	{
		private double _convergency;

		// 试卷期望难度系数
		public PaperChromosome(double convergency)
		{
			_convergency = convergency;
		}

		public int TotalScore {
			get { return GeneSeries.Sum(q => q.QuestionScore); }
		}

		public double Degree {
			get { return GeneSeries.Sum(q => q.QuestionScore * q.QuestionDegree) / TotalScore; }
		}

		public override double Fitness {
			get {
				return GeneSeries.Count == 0
						? 0.00
						: 1.00 - Math.Abs(Degree - _convergency);
			}
		}
	}
}

