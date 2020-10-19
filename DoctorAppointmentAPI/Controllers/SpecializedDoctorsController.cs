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
    public class SpecializedDoctorsController : ControllerBase
    {
        private readonly INonGenirecRepo _repo;

        public SpecializedDoctorsController(INonGenirecRepo repo )
        {
            _repo = repo;
        }

        // GET: api/SpecializedDoctors/1
        //[HttpGet("{id}")]
        //public List<Doctor> GetDoctors([FromRoute] int id)
        //{
        //    return _repo.GetDoctorsBySpId(id);           
        //}



        // GET: api/SpecializedDoctors/1
        [HttpGet("{id}")]
        public List<DoctorVM> GetDoctors([FromRoute] int id)
        {
            return _repo.GetDoctors(id);           
        }

    }
}
