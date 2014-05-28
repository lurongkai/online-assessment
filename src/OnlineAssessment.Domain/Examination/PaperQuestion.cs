﻿using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class PaperQuestion
    {
        public PaperQuestion()
        {
            PaperQuestionId = Guid.NewGuid();
            QuestionOptions = new List<PaperQuestionOption>();
        }

        public Guid PaperQuestionId { get; set; }
        public int QuestionIndex { get; set; }
        public int Score { get; set; }
        public float QuestionDegree { get; set; }
        public QuestionForm QuestionForm { get; set; }
        public string QuestionBody { get; set; }
        public string ReferenceRightAnswer { get; set; }
        public virtual ICollection<PaperQuestionOption> QuestionOptions { get; set; }

        public float AvarageDegree
        {
            get { return QuestionDegree*Score; }
        }
    }
}