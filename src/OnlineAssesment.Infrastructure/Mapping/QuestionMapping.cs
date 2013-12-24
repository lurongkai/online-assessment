﻿using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping() {
            HasKey(m => m.QuestionId);
            HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);
            HasOptional(m => m.Chapter).WithRequired();

            Property(m => m.QuestionType).IsRequired();
            Property(m => m.QuestionBody).IsRequired();
            Property(m => m.ReferenceRightAnswer).IsOptional();
            Property(m => m.CourseLevel).IsRequired();
            Property(m => m.QuestionDegree).IsRequired();
        }
    }

    public class QuestionOptionMapping : EntityTypeConfiguration<QuestionOption>
    {
        public QuestionOptionMapping() {
            HasKey(m => m.QuestionOptionId);

            Property(m => m.Description).IsRequired();
            Property(m => m.IsRightAnswer).IsRequired();
        }
    }

    public class ChapterMapping : EntityTypeConfiguration<Chapter>
    {
        public ChapterMapping() {
            HasKey(m => m.ChapterId);

            Property(m => m.Title).IsRequired();
        }
    }
}