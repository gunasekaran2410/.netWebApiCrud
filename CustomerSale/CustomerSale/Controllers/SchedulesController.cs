using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerSale.Data;
using CustomerSale.Models;

namespace CustomerSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public SchedulesController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> GetScheduleModel()
        {
          if (_context.ScheduleModel == null)
          {
              return NotFound();
          }
            return await _context.ScheduleModel.ToListAsync();
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleModel>> GetScheduleModel(string id)
        {
          if (_context.ScheduleModel == null)
          {
              return NotFound();
          }
            var scheduleModel = await _context.ScheduleModel.FindAsync(id);

            if (scheduleModel == null)
            {
                return NotFound();
            }

            return scheduleModel;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleModel(string id, ScheduleModel scheduleModel)
        {
            if (id != scheduleModel.ScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(scheduleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleModelExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleModel>> PostScheduleModel(ScheduleModel scheduleModel)
        {
          if (_context.ScheduleModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.ScheduleModel'  is null.");
          }
            _context.ScheduleModel.Add(scheduleModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScheduleModelExists(scheduleModel.ScheduleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScheduleModel", new { id = scheduleModel.ScheduleId }, scheduleModel);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleModel(string id)
        {
            if (_context.ScheduleModel == null)
            {
                return NotFound();
            }
            var scheduleModel = await _context.ScheduleModel.FindAsync(id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            _context.ScheduleModel.Remove(scheduleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleModelExists(string id)
        {
            return (_context.ScheduleModel?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
