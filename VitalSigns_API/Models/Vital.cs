using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VitalSigns_API.Models
{
    public class Vital
    {
        [Key]
        public int Id { get; set; }
        public string PatientId { get; set; }
        public int AppointmentId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Temperature { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int RespiratoryRate { get; set; }

    }
}
