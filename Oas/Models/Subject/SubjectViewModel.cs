using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oas.Domain;

namespace Oas.Models.Subject
{
    public class SubjectViewModel
    {
        private Domain.Subject[] _subjects;
        private SubjectPin[] _pinnedSubjects;
        public SubjectViewModel(IEnumerable<Domain.Subject> subjects, IEnumerable<Domain.SubjectPin> pinnedSubjects) {
            this._subjects = subjects.ToArray();
            this._pinnedSubjects = pinnedSubjects.ToArray();

            InitializeSubjectItems();
        }

        private void InitializeSubjectItems() {
            var subjects = new List<SubjectViewModelItem>();
            var pinnedSubjectIds = _pinnedSubjects.Select(s => s.SubjectId).ToArray();
            foreach (var subject in _subjects) {
                if (pinnedSubjectIds.Contains(subject.SubjectId)) {
                    var pin = _pinnedSubjects.First(p => p.SubjectId == subject.SubjectId);
                    subjects.Add(new SubjectViewModelItem(subject.SubjectId, subject.Name, pin.PinName, true));
                } else {
                    subjects.Add(new SubjectViewModelItem(subject.SubjectId, subject.Name, "", false));
                }
            }

            Subjects = subjects;
        }

        public IEnumerable<SubjectViewModelItem> Subjects { get; private set; }
    }

    public class SubjectViewModelItem
    {
        public SubjectViewModelItem(Guid subjectId, string subjectName, string pinName, bool isPinned) {
            SubjectId = subjectId;
            IsPinned = isPinned;
            Name = subjectName;

            if (isPinned && !String.IsNullOrEmpty(pinName)) { Name += String.Format("({0})", pinName); }
        }

        public Guid SubjectId { get; private set; }
        public string Name { get; private set; }
        public bool IsPinned { get; private set; }
    }
}