﻿using System;
using System.Collections.Generic;

namespace Oas.Models.Exam
{
    public class ExamInputModel
    {
        public ExamInputModel()
        {
            SingleQuestions = new List<SingleQuestion>();
            MultipleQuestions = new List<MultipleQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }
        public List<SingleQuestion> SingleQuestions { get; set; }
        public List<MultipleQuestion> MultipleQuestions { get; set; }
        public List<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }

    public class SingleQuestion
    {
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
        public Guid? CheckedOption { get; set; }
    }

    public class MultipleQuestion
    {
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
        public List<QuestionOption> CheckedOptions { get; set; }
    }

    public class QuestionOption
    {
        public Guid OptionId { get; set; }
        public bool Checked { get; set; }
    }

    public class SubjectiveQuestion
    {
        public Guid QuestionId { get; set; }
        public string WriteDown { get; set; }
    }
}