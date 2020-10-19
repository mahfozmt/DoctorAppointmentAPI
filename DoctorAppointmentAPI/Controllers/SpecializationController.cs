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
    public class SpecializationController : ControllerBase
    {
        private readonly IAppointRepo<Speacialization> _repo;

        public SpecializationController(IAppointRepo<Speacialization> repo)
        {
            _repo = repo;
        }

        //GET: api/Specialization
        [HttpGet]
        public async Task<IEnumerable<Speacialization>> GetSpeacializations()
        {
            return await _repo.GetT();
        }

        // GET: api/Specialization/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSpeacializations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var speacialization = await _repo.GetTById(id);
            if (speacialization == null)
            {
                return NotFound();
            }
            return Ok(speacialization);
        }

        // POST: api/Specialization
        [HttpPost]
        public async Task<ActionResult> PostSpecialization([FromBody] Speacialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(specialization);
            var save = await _repo.SaveAsync(specialization);
            return CreatedAtAction("GetSpeacializations", new { id = specialization.SpeacializationId }, specialization);
        }

        // PUT: api/Specialization/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialization([FromRoute] int id, [FromBody] Speacialization  speacialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != speacialization.SpeacializationId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(speacialization);
                var save = await _repo.SaveAsync(speacialization);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeacializationExists(id))
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

        // DELETE: api/Specialization/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecialization([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var  speacialization = await _repo.GetTById(id);
            if (speacialization == null)
            {
                return NotFound();
            }
            _repo.Delete(speacialization);
            await _repo.SaveAsync(speacialization);
            return Ok(speacialization );
        }


        private bool SpeacializationExists(int id)
        {
            var speacialization = _repo.GetTById(id);
            if (speacialization == null)
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
