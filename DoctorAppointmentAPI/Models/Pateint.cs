using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{

   
    public class Pateint
    {
        public int PateintId { get; set; }
        [Required(ErrorMessage = "The Full Name field is required.")]
        [StringLength(50), Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The  Mobile Number field is required.")]
        [StringLength(50), Display(Name = " Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "The Gender field is required.")]
        [ForeignKey("Gender")]
        public int GenderId  { get; set; }
        public int Age { get; set; }
      
        //Nev
        public virtual Gender Gender { get; set; }
        public virtual List<Serial> Serials { get; set; }
        public virtual List<DeasisHistory>  DeasisHistories { get; set; }

    }
}
