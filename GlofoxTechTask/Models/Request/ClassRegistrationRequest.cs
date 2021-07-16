using System;
using System.ComponentModel.DataAnnotations;

namespace GlofoxTechTask.Models.Request
{
    public class ClassRegistrationRequest
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string ClassName { get; set; }
    }
}
