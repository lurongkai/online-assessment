﻿using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Infrastructure.Mapping
{
	public class ExaminationMapping : EntityTypeConfiguration<Examination>
	{
		public ExaminationMapping()
		{
			HasKey(m => m.ExaminationId);

			Property(m => m.BeginDate).IsOptional();
			Property(m => m.DueDate).IsOptional();
			Property(m => m.Duration).IsRequired();
			Property(m => m.State).IsRequired();

			HasRequired(m => m.Paper).WithOptional();
		}
	}

	public class ExaminationPaperMapping : EntityTypeConfiguration<ExaminationPaper>
	{
		public ExaminationPaperMapping()
		{
			HasKey(m => m.ExaminationPaperId);
			HasMany(m => m.Questions).WithRequired().WillCascadeOnDelete(true);

			Property(m => m.Title).IsRequired();
			Property(m => m.Description).IsOptional();

			HasRequired(m => m.Subject).WithOptional();
            
			Ignore(m => m.TotalScore);
		}
	}

	public class PaperQuestionMapping : EntityTypeConfiguration<PaperQuestion>
	{
		public PaperQuestionMapping()
		{
			HasKey(m => m.PaperQuestionId);
			HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);

			Property(m => m.QuestionIndex).IsRequired();
			Property(m => m.Score).IsRequired();
			Property(m => m.QuestionForm).IsRequired();
			Property(m => m.QuestionBody).IsRequired();
			Property(m => m.ReferenceRightAnswer).IsOptional();
		}
	}

	public class PaperQuestionOptionMapping : EntityTypeConfiguration<PaperQuestionOption>
	{
		public PaperQuestionOptionMapping()
		{
			HasKey(m => m.ExaminationQuestionOptionId);

			Property(m => m.OptionIndex).IsRequired();
			Property(m => m.Description).IsRequired();
			Property(m => m.IsRightAnswer).IsRequired();
		}
	}
}
