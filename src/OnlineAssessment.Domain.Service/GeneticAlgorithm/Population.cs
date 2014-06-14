using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.GeneticAlgorithm
{
	public class Population<T> where T: Gene
	{
		public Population(ICollection<Chromosome<T>> chromosomes)
		{
		}

		public Population(int amout, IChromesomeFactory factory)
		{
			
		}

		public void RunOnce(){
		}
	}
}

