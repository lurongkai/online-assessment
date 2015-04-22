using System;
using System.Collections.Generic;
using System.Linq;
using Oas.Domain;

namespace Oas.Models.Subject
{
    public class SubjectViewModel
    {
        private Domain.Subject[] _subjects;

        public SubjectViewModel(IEnumerable<Domain.Subject> subjects) {
            this._subjects = subjects.ToArray();

            InitializeSubjectItems();
        }

        private void InitializeSubjectItems() {
            var subjects = new List<SubjectViewModelItem>();
            foreach (var subject in _subjects) {
                subjects.Add(new SubjectViewModelItem(subject.SubjectId, subject.Name, subject.SubjectType));
            }

            Subjects = subjects;
        }

        public IEnumerable<SubjectViewModelItem> Subjects { get; private set; }
    }

    public class SubjectViewModelItem
    {
        public SubjectViewModelItem(Guid subjectId, string subjectName, SubjectType subjectType) {
            SubjectId = subjectId;
            Name = subjectName;
            SubjectType = subjectType;
        }

        public Guid SubjectId { get; private set; }
        public string Name { get; private set; }
        public SubjectType SubjectType { get; private set; }
    }
}