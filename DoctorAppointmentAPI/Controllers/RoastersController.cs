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
    public class RoastersController : ControllerBase
    {
        private readonly IAppointRepo<RoasterOfDoctor> _repo;
        private readonly IAppointRepo<Doctor> _docRepo;
        private readonly IAppointRepo<Chamber> _chRepo;
        private readonly INonGenirecRepo _nonGenirec;

        public RoastersController(IAppointRepo<RoasterOfDoctor> repo, IAppointRepo<Doctor> docRepo, IAppointRepo<Chamber> chRepo, INonGenirecRepo nonGenirec)
        {
            _repo = repo;
            _docRepo = docRepo;
            _chRepo = chRepo;
            _nonGenirec = nonGenirec;
        }

        //GET: api/Roasters
        [HttpGet]
        public async Task<IEnumerable<RoasterOfDoctor>> GetRoasters()
        {
            var roasters = await _repo.GetT();
            foreach (var roaster in roasters)
            {

                roaster.Chamber = await _chRepo.GetTById(roaster.ChamberId);
                roaster.Chamber.RoasterOfDoctors = null;
                //roaster.Doctor = await _docRepo.GetTById(roaster.DoctorId);
                //roaster.Doctor.RoasterOfDoctors = null;
            }
            return roasters;
        }

        // GET: api/Roasters/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roaster = await _repo.GetTById(id);
            if (roaster == null)
            {
                return NotFound();
            }
            roaster.Chamber = await _chRepo.GetTById(roaster.ChamberId);
            roaster.Chamber.RoasterOfDoctors = null;
            //roaster.Doctor = await _docRepo.GetTById(roaster.DoctorId);
            //roaster.Doctor.RoasterOfDoctors = null;
            return Ok(roaster);
        }

        // POST: api/Roasters
        [HttpPost("{doctorId}")]
        //Task PostRoaster(RoasterOfDoctor roaster, int doctorId)
        public async Task<ActionResult> PostRoaster([FromRoute] int doctorId,[FromBody] RoasterOfDoctor roaster )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _nonGenirec.PostRoaster(roaster, doctorId);
             
            return CreatedAtAction("GetRoasters", new { id = roaster.RoasterOfDoctorId }, roaster);
        }

        // PUT: api/Roasters/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoaster([FromRoute] int id, [FromBody] RoasterOfDoctor roaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != roaster.RoasterOfDoctorId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(roaster);
                var save = await _repo.SaveAsync(roaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoasterExists(id))
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

        // DELETE: api/Roasters/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roaster = await _repo.GetTById(id);
            if (roaster == null)
            {
                return NotFound();
            }
            _repo.Delete(roaster);
            await _repo.SaveAsync(roaster);
            return Ok(roaster);
        }


        private bool RoasterExists(int id)
        {
            var roaster = _repo.GetTById(id);
            if (roaster == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        // GET: DoctorRoaster/1
        [Route("/DoctorRoaster/{id}")]
        [HttpGet]

        public async Task<ActionResult> DoctorRoaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roaster = await _nonGenirec.DoctorRoaster(id);
            if (roaster == null)
            {
                return NotFound();
            }
            return Ok(roaster);
        }
    }
}
