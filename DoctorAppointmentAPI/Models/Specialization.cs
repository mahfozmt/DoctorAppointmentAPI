using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class Speacialization
    {
        public int SpeacializationId { get; set; }
        [Required(ErrorMessage = "The Speacialization/Department field is required.")]
        [StringLength(50), Display(Name = "Speacialization/Department")]
        public string SpeacializationDepartment { get; set; }
        
        //Nev
        public virtual List<Doctor> Doctors { get; set; }
    }
}
