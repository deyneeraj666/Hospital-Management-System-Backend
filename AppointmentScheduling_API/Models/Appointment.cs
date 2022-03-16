using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AppointmentScheduling_API.Models
{
    [Table("tblAppointmentDetails")]
    public class Appointment
    {
        public int id { get; set; }
        public string p_id { get; set; }
        public string patientName { get; set; }

        public string physician { get; set; }
        public string meetingTitle { get; set; }
        public string status { get; set; }

        public DateTime startDateTime { get; set; }

        public DateTime endDateTime { get; set; }

        public string description { get; set; }
        public string physicianId { get; set; }
    }
}
