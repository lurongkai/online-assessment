using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.GeneticAlgorithm
{
	public class Chromosome<T> where T: Gene
	{
		public Chromosome()
		{
		}

		public IList<T> GeneSeries { get; private set; }

		public virtual double Fitness { get; protected set; }
	}
}

