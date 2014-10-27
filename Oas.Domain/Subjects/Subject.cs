using System;
namespace Oas.Domain
{
    public class Subject: IAggregateRoot<Subject>
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }

        public virtual Course BelongTo { get; set; }
    }
}