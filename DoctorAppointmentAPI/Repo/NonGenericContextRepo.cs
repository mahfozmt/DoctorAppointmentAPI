using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Repo
{
    public class NonGenericContextRepo : INonGenirecRepo
    {
        public readonly AppoinmentDbContext _context;
        public NonGenericContextRepo(AppoinmentDbContext context)
        {
            _context = context;
        }
        public List<Serial> GetSerial()
        {
            return _context.Serials.Include("RoasterOfDoctor").Include("Pateint").ToList();
        }

        public void AddSerial(Serial serial)
        {
            serial.BookingDate = DateTime.Now;
            int preSerial = _context.Serials.Where(x => x.RoasterOfDoctorId == serial.RoasterOfDoctorId).Count();
            var esPat1 = _context.RoasterOfDoctors.FirstOrDefault(x => x.RoasterOfDoctorId == serial.RoasterOfDoctorId);
            int esPatNumber = esPat1.EstimatedPateintNumber;
            if (preSerial < esPatNumber)
            {
                serial.SerialNumber = preSerial + 1;
                _context.Add(serial);
                _context.SaveChanges();
            }


        }

        public List<Doctor> GetDoctorsBySpId(int spId)
        {
            return _context.Doctors.Include("Gender").Include("Speacialization").Where(x => x.SpeacializationId == spId).ToList();
        }

        public List<DoctorVM> GetDoctors(int spId)
        {
            List<Doctor> doctors = _context.Doctors.Include("Gender").Include("Speacialization").Where(x => x.SpeacializationId == spId).ToList();
            List<DoctorVM> doctors1 = new List<DoctorVM>();

            foreach (var item in doctors)
            {
                DoctorVM vM = new DoctorVM
                {
                    DoctorId = item.DoctorId,
                    AboutDetails = item.AboutDetails,
                    BMDCNumber = item.BMDCNumber,
                    Email = item.Email,
                    FullName = item.FullName,
                    Gender = item.Gender.GenderName,
                    PhoneNumber = item.PhoneNumber,
                    Photo = item.Photo,
                    Speacialization = item.Speacialization.SpeacializationDepartment
                };
                doctors1.Add(vM);
            }
            return doctors1;
        }

        public async Task<List<DetailedRoasterVM>> DoctorRoaster(int doctorid)
        {
            Doctor doctor = _context.Doctors.Find(doctorid);
            List<RoasterOfDoctor> roasterOfDoctors = await _context.RoasterOfDoctors.Include("Chamber").Where(x => x.Chamber.Doctor.DoctorId == doctorid && x.Date >= DateTime.Now.Date).ToListAsync();
            List<DetailedRoasterVM> detailedRoasterVMs = new List<DetailedRoasterVM>();
            foreach (var item in roasterOfDoctors)
            {
                DetailedRoasterVM vM = new DetailedRoasterVM
                {
                    DoctorName = doctor.FullName,
                    ChamberAddress = item.Chamber.Address,
                    Date = item.Date,
                    EstimatedPateintNumber = item.EstimatedPateintNumber,
                    RoasterOfDoctorId = item.RoasterOfDoctorId,
                    TimeStart = item.TimeStart,
                    TimeEnd = item.TimeEnd
                };

                detailedRoasterVMs.Add(vM);
            }
            return detailedRoasterVMs;
        }

        public async Task<List<DetailedSerialVM>> DetailedSerials(int doctorid, DateTime date)
        {
            var DetailedSerial = await (from serial in _context.Serials
                                        join pateint in _context.Pateints on serial.PateintId equals pateint.PateintId
                                        join roaster in _context.RoasterOfDoctors on serial.RoasterOfDoctorId equals              roaster.RoasterOfDoctorId
                                        join chamber in _context.Chambers on roaster.ChamberId equals chamber.ChamberId
                                        join doctor in _context.Doctors on chamber.DoctorId equals doctor.DoctorId
                                        where doctor.DoctorId == doctorid && roaster.Date == date

                                        select new DetailedSerialVM
                                        {
                                            BookingDate = serial.BookingDate,
                                            ChamberAdress = chamber.Address,
                                            PateintMobileNumber = pateint.MobileNumber,
                                            PateintName = pateint.Name,
                                            SerialNumber = serial.SerialNumber
                                        }).ToListAsync();
            return DetailedSerial;
        }

        public List<Chamber> GetDoctorChambers(int doctorId)
        {
            return _context.Chambers.Include("Doctor").Where(x => x.DoctorId == doctorId).ToList();
        }
    }
}
