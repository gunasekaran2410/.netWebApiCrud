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
    public class InstructorsController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public InstructorsController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorModel>>> GetInstructorModel()
        {
          if (_context.InstructorModel == null)
          {
              return NotFound();
          }
            return await _context.InstructorModel.ToListAsync();
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorModel>> GetInstructorModel(string id)
        {
          if (_context.InstructorModel == null)
          {
              return NotFound();
          }
            var instructorModel = await _context.InstructorModel.FindAsync(id);

            if (instructorModel == null)
            {
                return NotFound();
            }

            return instructorModel;
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructorModel(string id, InstructorModel instructorModel)
        {
            if (id != instructorModel.InstructorId)
            {
                return BadRequest();
            }

            _context.Entry(instructorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorModelExists(id))
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

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstructorModel>> PostInstructorModel(InstructorModel instructorModel)
        {
          if (_context.InstructorModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.InstructorModel'  is null.");
          }
            _context.InstructorModel.Add(instructorModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InstructorModelExists(instructorModel.InstructorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstructorModel", new { id = instructorModel.InstructorId }, instructorModel);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructorModel(string id)
        {
            if (_context.InstructorModel == null)
            {
                return NotFound();
            }
            var instructorModel = await _context.InstructorModel.FindAsync(id);
            if (instructorModel == null)
            {
                return NotFound();
            }

            _context.InstructorModel.Remove(instructorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructorModelExists(string id)
        {
            return (_context.InstructorModel?.Any(e => e.InstructorId == id)).GetValueOrDefault();
        }
    }
}
