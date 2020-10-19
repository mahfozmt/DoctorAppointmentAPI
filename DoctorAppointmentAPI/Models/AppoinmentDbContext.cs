using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class AppoinmentDbContext : DbContext
    {
        public AppoinmentDbContext(DbContextOptions<AppoinmentDbContext> options) : base(options) { }
        public DbSet<DeasisHistory> DeasisHistories { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pateint> Pateints { get; set; }
        public DbSet<Speacialization> Speacializations { get; set; }
        public DbSet<tblUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; } 
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<RoasterOfDoctor> RoasterOfDoctors { get; set; }
        public DbSet<Serial> Serials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender { GenderId = 1, GenderName = "Male" },
                                                  new Gender { GenderId = 2, GenderName = "Female" });

            modelBuilder.Entity<Speacialization>().HasData(
                new Speacialization { SpeacializationId = 1, SpeacializationDepartment = "Aerospace Medicine" },
                new Speacialization { SpeacializationId = 2, SpeacializationDepartment = "Bariatric Surgery " },
                new Speacialization { SpeacializationId = 3, SpeacializationDepartment = "Cardiology - Interventional " },
                new Speacialization { SpeacializationId = 4, SpeacializationDepartment = "Cardiology - Non Interventional " },
                new Speacialization { SpeacializationId = 5, SpeacializationDepartment = "Cardiothoracic And Vascular Surgery " },
                new Speacialization { SpeacializationId = 6, SpeacializationDepartment = "Centre For Spinal Diseases " },
                new Speacialization { SpeacializationId = 7, SpeacializationDepartment = "Clinical Haematology And BMT " },
                new Speacialization { SpeacializationId = 8, SpeacializationDepartment = "Corneal Transplant " },
                new Speacialization { SpeacializationId = 9, SpeacializationDepartment = "Critical Care Medicine " },
                new Speacialization { SpeacializationId = 10, SpeacializationDepartment = "Dermatology And Cosmetology " },
                new Speacialization { SpeacializationId = 11, SpeacializationDepartment = "Ear Nose Throat Head And Neck Surgery " },
                new Speacialization { SpeacializationId = 12, SpeacializationDepartment = "Emergency Medicine " },
                new Speacialization { SpeacializationId = 13, SpeacializationDepartment = "Endocrinology " },
                new Speacialization { SpeacializationId = 14, SpeacializationDepartment = "General Surgery " },
                new Speacialization { SpeacializationId = 15, SpeacializationDepartment = "Infectious Diseases " },
                new Speacialization { SpeacializationId = 16, SpeacializationDepartment = "Internal Medicine " },
                new Speacialization { SpeacializationId = 17, SpeacializationDepartment = "In-Vitro Fertilisation (IVF) " },
                new Speacialization { SpeacializationId = 18, SpeacializationDepartment = "Laboratory Medicine " },
                new Speacialization { SpeacializationId = 19, SpeacializationDepartment = "Liver Transplant & Hepatic Surgery " },
                new Speacialization { SpeacializationId = 20, SpeacializationDepartment = "Maxillofacial Surgery " },
                new Speacialization { SpeacializationId = 21, SpeacializationDepartment = "Medical Gastroenterology " },
                new Speacialization { SpeacializationId = 22, SpeacializationDepartment = "Medical Oncology & Clinical Hematology " },
                new Speacialization { SpeacializationId = 23, SpeacializationDepartment = "Medical Oncology " },
                new Speacialization { SpeacializationId = 24, SpeacializationDepartment = "Minimally Invasive Gynecology " },
                new Speacialization { SpeacializationId = 25, SpeacializationDepartment = "Neonatology " },
                new Speacialization { SpeacializationId = 26, SpeacializationDepartment = "Nephrology " },
                new Speacialization { SpeacializationId = 27, SpeacializationDepartment = "Neuro Modulation " },
                new Speacialization { SpeacializationId = 28, SpeacializationDepartment = "Nutrition & Dietetics " },
                new Speacialization { SpeacializationId = 29, SpeacializationDepartment = "Neurology " },
                new Speacialization { SpeacializationId = 30, SpeacializationDepartment = "Neurosurgery " },
                new Speacialization { SpeacializationId = 31, SpeacializationDepartment = "Obstetrics And Gynecology " },
                new Speacialization { SpeacializationId = 32, SpeacializationDepartment = "Ophthalmology " },
                new Speacialization { SpeacializationId = 33, SpeacializationDepartment = "Orthopedics & Joint Replacement " },
                new Speacialization { SpeacializationId = 34, SpeacializationDepartment = "Pain Management " },
                new Speacialization { SpeacializationId = 35, SpeacializationDepartment = "Pediatric Surgery " },
                new Speacialization { SpeacializationId = 36, SpeacializationDepartment = "Physiotherapy " },
                new Speacialization { SpeacializationId = 37, SpeacializationDepartment = "Plastic Surgery " },
                new Speacialization { SpeacializationId = 38, SpeacializationDepartment = "Psychiatry " },
                new Speacialization { SpeacializationId = 39, SpeacializationDepartment = "Pulmonology " },
                new Speacialization { SpeacializationId = 40, SpeacializationDepartment = "Renal Transplant " },
                new Speacialization { SpeacializationId = 41, SpeacializationDepartment = "Reproductive Medicine & IVF " },
                new Speacialization { SpeacializationId = 42, SpeacializationDepartment = "Rheumatology " },
                new Speacialization { SpeacializationId = 43, SpeacializationDepartment = "Robotic Surgery " },
                new Speacialization { SpeacializationId = 44, SpeacializationDepartment = "Surgical Gastroenterology " },
                new Speacialization { SpeacializationId = 45, SpeacializationDepartment = "Surgical Oncology " },
                new Speacialization { SpeacializationId = 46, SpeacializationDepartment = "Urology " },
                new Speacialization { SpeacializationId = 47, SpeacializationDepartment = "Vascular and endovascular surgery " },
                new Speacialization { SpeacializationId = 48, SpeacializationDepartment = "Anaesthesia" });


            modelBuilder.Entity<Pateint>().HasData(
                new Pateint { PateintId = 1 , Name = "Mahfozur Rahman", GenderId = 1, Age = 25, MobileNumber = "01758091506" },
                new Pateint { PateintId = 2 , Name = "Wahidur Rahman", GenderId = 1, Age = 42, MobileNumber = "01745632145" },
                new Pateint { PateintId = 3 , Name = "Masum Billah", GenderId = 1, Age = 27, MobileNumber = "01652147896" },
                new Pateint { PateintId = 4 , Name = "Shanta Jahan", GenderId = 2, Age = 25, MobileNumber = "01758091506" },
                new Pateint { PateintId = 5 , Name = "Moushumi Akter", GenderId = 2, Age = 21, MobileNumber = "05616515651" },
                new Pateint { PateintId = 6 , Name = "Wali Ullah", GenderId = 1, Age = 23, MobileNumber = "464864864685" },
                new Pateint { PateintId = 7 , Name = "Sadik Rahman", GenderId = 1, Age = 22, MobileNumber = "5664666155" },
                new Pateint { PateintId = 8 , Name = "Happy Rose", GenderId = 2, Age = 24, MobileNumber = "011565668466" },
                new Pateint { PateintId = 9 , Name = "Rita Sheikh", GenderId = 2, Age = 35, MobileNumber = "01475656526" },
                new Pateint { PateintId = 10, Name = "Selim Sheikh", GenderId = 1, Age = 30, MobileNumber = "019215666245" },
                new Pateint { PateintId = 11, Name = "Aleya Ferdaus", GenderId = 2, Age = 25, MobileNumber = "01754152632" }
                );




        }
        

    }


}
