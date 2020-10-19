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
    public class ChambersController : ControllerBase
    {
        private readonly IAppointRepo<Chamber> _repo;
        private readonly IAppointRepo<Doctor> doc_Repo;
        private readonly INonGenirecRepo _nonGenirecRepo;

        public ChambersController(IAppointRepo<Chamber> repo, IAppointRepo<Doctor> doc_repo, INonGenirecRepo nonGenirecRepo)
        {
            _repo = repo;
            doc_Repo = doc_repo;
            _nonGenirecRepo = nonGenirecRepo;
        }

        //GET: api/Chambers
        [HttpGet]
        public async Task<IEnumerable<Chamber>> GetChambers()
        {
            var chambers = await _repo.GetT();
            foreach (var chamber in chambers)
            {
                chamber.Doctor = await doc_Repo.GetTById(chamber.DoctorId);
                chamber.Doctor.Chambers = null;
            }
            return chambers;
        }

        // GET: api/Chambers/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetChambers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chamber = await _repo.GetTById(id);
            if (chamber == null)
            {
                return NotFound();
            }
            chamber.Doctor = await doc_Repo.GetTById(chamber.DoctorId);
            chamber.Doctor.Chambers = null;
            return Ok(chamber);
        }

        // POST: api/Chambers
        [HttpPost]
        public async Task<ActionResult> PostPateint([FromBody] Chamber chamber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(chamber);
            var save = await _repo.SaveAsync(chamber);
            return CreatedAtAction("GetChambers", new { id = chamber.ChamberId }, chamber);
        }

        // PUT: api/Chambers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPateint([FromRoute] int id, [FromBody] Chamber chamber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != chamber.ChamberId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(chamber);
                var save = await _repo.SaveAsync(chamber);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChamberExists(id))
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

        // DELETE: api/Chambers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChambers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chamber = await _repo.GetTById(id);
            if (chamber == null)
            {
                return NotFound();
            }
            _repo.Delete(chamber);
            await _repo.SaveAsync(chamber);
            return Ok(chamber);
        }

        private bool ChamberExists(int id)
        {
            var chamber = _repo.GetTById(id);
            if (chamber == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        [Route("DoctorChambers/{doctorId}")]
        [HttpGet]
        public List<Chamber> GetDoctorChambers ([FromRoute] int doctorId)
        {
            return _nonGenirecRepo.GetDoctorChambers(doctorId);

        }


    }
}
