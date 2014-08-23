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

using System.Data.Entity.ModelConfiguration;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class ExaminationMapping : EntityTypeConfiguration<Examination>
    {
        public ExaminationMapping() {
            HasKey(m => m.ExaminationId);

            Property(m => m.Title).IsRequired();
            Property(m => m.BeginDate).IsOptional();
            Property(m => m.DueDate).IsOptional();
            Property(m => m.Duration).IsRequired();
            Property(m => m.State).IsRequired();

            HasRequired(m => m.Paper);
            HasMany(m => m.AnswerSheets);
        }
    }

    public class ExaminationPaperMapping : EntityTypeConfiguration<ExaminationPaper>
    {
        public ExaminationPaperMapping() {
            HasKey(m => m.ExaminationPaperId);
            HasMany(m => m.Questions).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.Title).IsRequired();
            Property(m => m.Description).IsOptional();
            Property(m => m.Degree).IsRequired();
            Property(m => m.TotalScore).IsRequired();

            HasMany(m => m.Examinations);
            HasMany(m => m.Questions).WithRequired();
        }
    }

    public class PaperQuestionMapping : EntityTypeConfiguration<PaperQuestion>
    {
        public PaperQuestionMapping() {
            HasKey(m => m.PaperQuestionId);

            Property(m => m.QuestionIndex).IsRequired();
            Property(m => m.Score).IsRequired();
            Property(m => m.Degree).IsRequired();
            Property(m => m.QuestionForm).IsRequired();
            Property(m => m.QuestionBody).IsRequired();
            Property(m => m.ReferenceRightAnswer).IsOptional();

            HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);
        }
    }

    public class PaperQuestionOptionMapping : EntityTypeConfiguration<PaperQuestionOption>
    {
        public PaperQuestionOptionMapping() {
            HasKey(m => m.ExaminationQuestionOptionId);

            Property(m => m.OptionIndex).IsRequired();
            Property(m => m.Description).IsRequired();
            Property(m => m.IsRightAnswer).IsRequired();
        }
    }
}