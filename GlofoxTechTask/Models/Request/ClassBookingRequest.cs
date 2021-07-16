using System;
using System.ComponentModel.DataAnnotations;

namespace GlofoxTechTask.Models.Request
{
    public class ClassBookingRequest
    {
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public DateTime ClassDate { get; set; }
    }
}
