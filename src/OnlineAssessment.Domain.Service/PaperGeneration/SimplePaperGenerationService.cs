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
// 
// Source code hosted on: https://github.com/lurongkai/online-assessment

using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
    public class SimplePaperGenerationService
    {
        private readonly IEnumerable<QuestionCharacter> _questions;

        public SimplePaperGenerationService(IEnumerable<QuestionCharacter> allQuestion) {
            _questions = allQuestion;
        }

        public PaperChromosome GenerateExaminationPaper(PaperConstraint paperConstraint) {
            var papers = InitializeQuestionPopulation(paperConstraint);
            var top = papers.OrderByDescending(p => p.Fitness).First();
            return top;
        }

        private IEnumerable<PaperChromosome> InitializeQuestionPopulation(PaperConstraint paperConstraint) {
            for (var i = 0; i < 50; i++) {
                var paper = new PaperChromosome(paperConstraint.ExpectedDegree);

                var counter = 500;
                while (paperConstraint.TotalScore != paper.TotalScore) {
                    paper.ClearAllGenes();
                    foreach (var quota in paperConstraint.QuestionQuota) {
                        var questionForm = quota.Key;
                        var questionAmount = quota.Value;
                        var candidateQuestions = _questions.Where(q => q.QuestionForm == questionForm).ToList();

                        paper.AddGenes(TakeRandomAmountQuestions(candidateQuestions, questionAmount));
                    }
                    counter--;
                    if (counter == 0) { throw new InvalidOperationException("question database not large enough to generate population."); }
                }

                yield return paper;
            }
        }

        private IEnumerable<QuestionCharacter> TakeRandomAmountQuestions(List<QuestionCharacter> candidateQuestions, int questionAmount) {
            if (candidateQuestions.Count < questionAmount) { throw new InvalidOperationException("specfied question form do not have enough questions."); }

            var r = new Random();
            for (var questionIndex = 0; questionIndex < questionAmount; questionIndex++) {
                var rLocation = r.Next(0, candidateQuestions.Count - questionIndex);
                yield return candidateQuestions[rLocation];

                var temp = candidateQuestions[candidateQuestions.Count - 1 - questionIndex];
                candidateQuestions[candidateQuestions.Count - 1 - questionIndex] = candidateQuestions[rLocation];
                candidateQuestions[rLocation] = temp;
            }
        }
    }
}