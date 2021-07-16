using System;

namespace GlofoxTechTask.RegisterClassDetails.Models
{
    public class ClassRegistrationDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public string ClassName { get; set; }
        public int Frequency { get; set; } = 1;
    }
}
