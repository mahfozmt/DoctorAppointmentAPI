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
    public class DeasisHistoriesController : ControllerBase
    {
        private readonly IAppointRepo<DeasisHistory> _repo;
        private readonly IAppointRepo<Pateint> pat_Repo;

        public DeasisHistoriesController(IAppointRepo<DeasisHistory> repo, IAppointRepo<Pateint> pat_repo)
        {
            this._repo = repo;
            pat_Repo = pat_repo;
        }

        //GET: api/DeasisHistories
        [HttpGet]
        public async Task<IEnumerable<DeasisHistory>> GetDeasisHistories()
        {
            var deasisHistories = await _repo.GetT();
            foreach (var deasishist in deasisHistories)
            {

                deasishist.Pateint = await pat_Repo.GetTById(deasishist.PateintId);
                deasishist.Pateint.DeasisHistories = null;
            }
            return deasisHistories;
        }

        // GET: api/DeasisHistories/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeasisHistories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deasishist = await _repo.GetTById(id);
            if (deasishist == null)
            {
                return NotFound();
            }
            deasishist.Pateint = await pat_Repo.GetTById(deasishist.PateintId);
            deasishist.Pateint.DeasisHistories = null;
            return Ok(deasishist);
        }

        // POST: api/DeasisHistories
        [HttpPost]
        public async Task<ActionResult> PostDeasisHistories([FromBody] DeasisHistory deasisHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(deasisHistory);
            var save = await _repo.SaveAsync(deasisHistory);
            return CreatedAtAction("GetDeasisHistories", new { id = deasisHistory.DeasisHistoryId }, deasisHistory);
        }

        // PUT: api/DeasisHistories/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeasisHistory([FromRoute] int id, [FromBody] DeasisHistory deasisHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != deasisHistory.DeasisHistoryId)
            {
                return BadRequest();
            }
            try
            {
                _repo.Update(deasisHistory);
                var save = await _repo.SaveAsync(deasisHistory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeasisExists(id))
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

        // DELETE: api/DeasisHistories/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeasisHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deasisHistory = await _repo.GetTById(id);
            if (deasisHistory == null)
            {
                return NotFound();
            }
            _repo.Delete(deasisHistory);
            await _repo.SaveAsync(deasisHistory);
            return Ok(deasisHistory);
        }


        private bool DeasisExists(int id)
        {
            var deasisHistory = _repo.GetTById(id);
            if (deasisHistory == null)
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
