using System;
using System.Collections.Generic;

namespace Oas.Domain
{
    public class Subject : IAggregateRoot<Subject>
    {
        public Subject() {
            SubjectId = Guid.NewGuid();
        }

        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public SubjectType SubjectType { get; set; }

        public virtual Course BelongTo { get; set; }
    }
}