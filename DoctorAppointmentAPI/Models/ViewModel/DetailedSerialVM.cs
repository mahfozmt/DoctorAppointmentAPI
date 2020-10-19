using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models.ViewModel
{
    public class DetailedSerialVM
    {
        public string ChamberAdress { get; set; }
        public string PateintName { get; set; }
        public string PateintMobileNumber { get; set; }
        public int SerialNumber { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
