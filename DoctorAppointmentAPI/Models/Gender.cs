using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        [Display(Name ="Gender")]
        public string GenderName { get; set; }

        //NAV
        public virtual List<Pateint> Pateints  { get; set; }
        public virtual List<Doctor> Doctors  { get; set; }
    }
}
