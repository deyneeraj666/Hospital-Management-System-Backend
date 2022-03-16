using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling_API.DTO
{
    public class AppointmentsDto
    {
        public int id { get; set; }
        [Required]
        public string p_id { get; set; }
        [Required]
        public string patientName { get; set; }

        [Required]
        public string physician { get; set; }
        [Required]
        public string meetingTitle { get; set; }
        [Required]
        public string status { get; set; }

        [Required]
        public DateTime startDateTime { get; set; }

        [Required]
        public DateTime endDateTime { get; set; }

        [Required]
        public string description { get; set; }
        [Required]
        public string physicianId { get; set; }



    }
}
