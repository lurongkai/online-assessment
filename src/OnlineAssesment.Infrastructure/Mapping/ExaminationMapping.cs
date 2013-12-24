﻿using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class ExaminationMapping : EntityTypeConfiguration<Examination>
    {
        public ExaminationMapping() {
            HasKey(m => m.ExaminationId);
            HasMany(m => m.Questions).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.Description).IsOptional();
            Property(m => m.CourseLevel).IsRequired();
            Property(m => m.BeginDate).IsOptional();
            Property(m => m.DueDate).IsOptional();
            Property(m => m.Duration).IsRequired();
            Property(m => m.State).IsRequired();
            
            Ignore(m => m.TotalScore);
        }
    }

    public class ExaminationQuestionMapping : EntityTypeConfiguration<ExaminationQuestion>
    {
        public ExaminationQuestionMapping() {
            HasKey(m => m.ExaminationQuestionId);
            HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.QuestionId).IsRequired();
            Property(m => m.QuestionIndex).IsRequired();
            Property(m => m.Score).IsRequired();
            Property(m => m.QuestionBody).IsRequired();
            Property(m => m.ReferenceRightAnswer).IsOptional();
        }
    }

    public class ExaminationQuestionOptionMapping : EntityTypeConfiguration<ExaminationQuestionOption>
    {
        public ExaminationQuestionOptionMapping() {
            HasKey(m => m.ExaminationQuestionOptionId);

            Property(m => m.OptionIndex).IsRequired();
            Property(m => m.Description).IsRequired();
            Property(m => m.IsRightAnswer).IsRequired();
        }
    }
}