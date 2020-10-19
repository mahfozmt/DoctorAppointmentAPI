using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class Chamber
    {
        public int ChamberId { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The address field is required.")]
        [StringLength(300), Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The Room Number field is required.")]
        [StringLength(300), Display(Name = "Room Number")]
        public string RoomNumber { get; set; }
        //Nav
        public virtual Doctor Doctor { get; set; }
        public List<RoasterOfDoctor> RoasterOfDoctors  { get; set; }

    }
}
