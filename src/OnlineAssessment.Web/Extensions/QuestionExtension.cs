using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessment.Web.Extensions
{
    public static class QuestionExtension
    {
        public static string GetString(this QuestionType questionType) {
            switch (questionType) {
                case QuestionType.SingleSelection: return "单选题";
                case QuestionType.MultipleSelection: return "多选题";
                case QuestionType.Subjective: return "主观题";
                default: return "Unknown";
            }
        }
    }
}