﻿using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping() {
            HasMany(m => m.AnswerSheets);

            Property(m => m.JobTitle).IsOptional();
            Property(m => m.Company).IsOptional();
            Property(m => m.StudingCourseLevel).IsRequired();
        }
    }
}
