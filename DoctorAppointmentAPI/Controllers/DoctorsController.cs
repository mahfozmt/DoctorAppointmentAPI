using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IAppointRepo<Doctor> _repo;
        private readonly IAppointRepo<Speacialization> sp_Repo;
        private readonly IAppointRepo<Gender> gn_Repo;

        public DoctorsController(IAppointRepo<Doctor> repo , IAppointRepo<Speacialization> sp_repo, IAppointRepo<Gender> gn_repo)
        {
            _repo = repo;
            sp_Repo = sp_repo;
            gn_Repo = gn_repo;
        }

        //GET: api/Doctors
        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors= await _repo.GetT();
            foreach (var doctor in doctors)
            {
                doctor.Speacialization = await sp_Repo.GetTById(doctor.SpeacializationId);
                doctor.Speacialization.Doctors = null;
                doctor.Gender = await gn_Repo.GetTById(doctor.GenderId);
                doctor.Gender.Doctors = null;
            }
            return doctors;
        }

        // GET: api/Doctors/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDoctors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var doctor = await _repo.GetTById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            doctor.Speacialization= await sp_Repo.GetTById(doctor.SpeacializationId);
            doctor.Speacialization.Doctors = null;
            doctor.Gender = await gn_Repo.GetTById(doctor.GenderId);
            doctor.Gender.Doctors = null;
            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult> PostDoctors([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(doctor);
            var save = await _repo.SaveAsync(doctor);
            return CreatedAtAction("GetDoctors", new { id = doctor.DoctorId }, doctor);
        }

        // PUT: api/Doctors/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor([FromRoute] int id, [FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(doctor);
                var save = await _repo.SaveAsync(doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Doctors/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var doctor = await _repo.GetTById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _repo.Delete(doctor);
            await _repo.SaveAsync(doctor);
            return Ok(doctor);
        }


        private bool DoctorsExists(int id)
        {
            var doctor = _repo.GetTById(id);
            if (doctor == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
