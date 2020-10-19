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
    public class PateintsController : ControllerBase
    {
        private readonly IAppointRepo<Pateint> _repo;
        private readonly IAppointRepo<Gender> gn_Repo;

        public PateintsController(IAppointRepo<Pateint> repo, IAppointRepo<Gender> gn_repo)
        {
            _repo = repo;
            gn_Repo = gn_repo;
        }

        //GET: api/Pateints
        [HttpGet]
        public async Task<IEnumerable<Pateint>> GetPateints()
        {
            var pateints = await _repo.GetT();
            foreach (var pateint in pateints)
            {
                
                pateint.Gender = await gn_Repo.GetTById(pateint.GenderId);
                pateint.Gender.Doctors = null;
            }
            return pateints;
        }

        // GET: api/Pateints/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPateints([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pateint = await _repo.GetTById(id);
            if (pateint == null)
            {
                return NotFound();
            }
            pateint.Gender = await gn_Repo.GetTById(pateint.GenderId);
            pateint.Gender.Pateints = null;
            return Ok(pateint);
        }

        // POST: api/Pateints
        [HttpPost]
        public async Task<ActionResult> PostPateint([FromBody] Pateint pateint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(pateint);
            var save = await _repo.SaveAsync(pateint);
            return CreatedAtAction("GetPateints", new { id = pateint.PateintId }, pateint);
        }

        // PUT: api/Pateints/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPateint([FromRoute] int id, [FromBody] Pateint pateint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != pateint.PateintId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(pateint);
                var save = await _repo.SaveAsync(pateint);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PateintExists(id))
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

        // DELETE: api/Pateints/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePateint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pateint = await _repo.GetTById(id);
            if (pateint == null)
            {
                return NotFound();
            }
            _repo.Delete(pateint);
            await _repo.SaveAsync(pateint);
            return Ok(pateint);
        }


        private bool PateintExists(int id)
        {
            var pateint = _repo.GetTById(id);
            if (pateint == null)
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
