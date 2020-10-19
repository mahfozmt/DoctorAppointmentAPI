using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class RoasterOfDoctor
    {

        public int RoasterOfDoctorId { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Time Start")]
        public TimeSpan TimeStart { get; set; }
        [Display(Name = "Time End")]
        public TimeSpan TimeEnd { get; set; }
        public int EstimatedPateintNumber { get; set; }
        [ForeignKey("Chamber")]
        public int ChamberId { get; set; }

        //Nev
        //public virtual Doctor Doctor { get; set; }
        public virtual Chamber Chamber { get; set; }

        public virtual List<Serial> Serials { get; set; }
        //public virtual List<AppointmentSchedule> AppointmentSchedules { get; set; }

    }
}
