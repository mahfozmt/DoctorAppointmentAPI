using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Repo
{
    public interface INonGenirecRepo
    {
        List<Doctor> GetDoctorsBySpId(int spId);
        void AddSerial(Serial serial);
        List<Serial> GetSerial();
        List<DoctorVM> GetDoctors(int spId);
        List<Chamber> GetDoctorChambers(int doctorId);
        Task< List<DetailedRoasterVM>> DoctorRoaster(int doctorid);
        Task< List<DetailedSerialVM>> DetailedSerials(int doctorid, DateTime date);
    }
}
 