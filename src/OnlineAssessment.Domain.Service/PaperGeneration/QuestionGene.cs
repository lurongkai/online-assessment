using System;
using OnlineAssessment.Domain.Service.GeneticAlgorithm;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
	public class QuestionGene : Gene
	{
		public QuestionGene()
		{
		}


		public int QuestionScore { get; set; }
		public double QuestionDegree { get; set; }
	}
}

