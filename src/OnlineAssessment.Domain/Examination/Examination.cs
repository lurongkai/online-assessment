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

using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain
{
    public class Examination
    {
        public Examination() {
            ExaminationId = Guid.NewGuid();
        }

        public Guid ExaminationId { get; set; }
        public string Title { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double Duration { get; set; }

        public virtual ExaminationPaper Paper { get; set; }
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }

        public ExaminationState State { get; set; }
        public ExaminationType ExaminationType { get; set; }

        public bool HasStudentAnswerSheet(Student student) {
            return AnswerSheets.Any(a => a.Student.Id == student.Id);
        }
    }
}