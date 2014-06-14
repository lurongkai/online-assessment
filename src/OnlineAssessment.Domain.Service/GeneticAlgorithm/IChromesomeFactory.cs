using System;

namespace OnlineAssessment.Domain.Service.GeneticAlgorithm
{
	public interface IChromesomeFactory
	{
		Chromosome<T> Create<T>() where T: Gene;
	}
}

