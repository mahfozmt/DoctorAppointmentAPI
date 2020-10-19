using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Models.ViewModel;
using DoctorAppointmentAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialsController : ControllerBase
    {
        private readonly INonGenirecRepo _repo;

        public SerialsController(INonGenirecRepo repo)
        {
            _repo = repo;
        }

        // POST: api/Serials
        [HttpPost]
        public void AddSerial(Serial serial)
        {
            _repo.AddSerial(serial);

        }

        //GET: api/Serials
        [HttpGet]
        public List<Serial> GetSerial()
        {
            return _repo.GetSerial();
        }

        // GET: DetailedSerials/1/10-10-2020
        [Route("/DetailedSerials/{doctorid}/{date}")]
        [HttpGet]
        public Task<List<DetailedSerialVM>> DetailedSerials(int doctorid, DateTime date)
        {
            return _repo.DetailedSerials(doctorid, date);
        }

    }
}
