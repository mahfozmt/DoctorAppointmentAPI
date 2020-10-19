using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models.ViewModel
{
    public class DoctorVM
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }       
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BMDCNumber { get; set; }
        public string Gender { get; set; }
        public string Speacialization { get; set; }       
        public string AboutDetails { get; set; }

    }
}
