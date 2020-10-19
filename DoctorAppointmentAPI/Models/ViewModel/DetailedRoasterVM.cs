using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models.ViewModel
{
    public class DetailedRoasterVM
    {
        public int RoasterOfDoctorId { get; set; }
        public string DoctorName { get; set; }
        public string ChamberAddress { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public int EstimatedPateintNumber { get; set; }
         
    }
}
