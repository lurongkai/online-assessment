using System;

namespace Oas.Domain
{
    public class SubjectPin
    {
        public int SubjectPinId { get; set; }
        public Guid SubjectId { get; set; }
        public string PinName { get; set; }
    }
}