using System;
using Oas.Domain.Subjects;
namespace Oas.Domain
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        //public SubjectType SubjectType { get; set; }

        public virtual Course BelongTo { get; set; }
    }
}