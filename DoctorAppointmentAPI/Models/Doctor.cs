using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
   
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The Full Name field is required.")]
        [StringLength(50), Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "The Phone Number field is required.")]
        [StringLength(50), Display(Name = "Phone Number")] 
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Full Name field is required.")]
        [StringLength(100), Display(Name = "BMDC Registration Number")]
        public string BMDCNumber { get; set; }
        [Required(ErrorMessage = "The Gender field is required.")]
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
      
        [ForeignKey("Speacialization")]
        public int SpeacializationId { get; set; }
        [Display(Name ="About Details")]
        public string AboutDetails { get; set; }


        //Nav
        public virtual Gender Gender { get; set; }
        public virtual Speacialization Speacialization { get; set; }
        public virtual List<RoasterOfDoctor> RoasterOfDoctors { get; set; }
        public virtual List<Chamber> Chambers { get; set; }
    

    }
}
