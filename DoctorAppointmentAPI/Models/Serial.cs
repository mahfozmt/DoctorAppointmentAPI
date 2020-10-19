using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class Serial
    {
        public int SerialId { get; set; }
        [ForeignKey("RoasterOfDoctor")]
        [Required]
        public int RoasterOfDoctorId { get; set; }
        [ForeignKey("Pateint")]
        public int PateintId { get; set; }
        [Display(Name ="Serial Number")]
        public int SerialNumber { get; set; }
        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        //Nav
        public virtual RoasterOfDoctor RoasterOfDoctor{ get; set; }
        public virtual Pateint  Pateint{ get; set; }

    }
}
