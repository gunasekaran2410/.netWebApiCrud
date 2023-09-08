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
    public class EnrollmentsController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public EnrollmentsController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentModel>>> GetEnrollmentModel()
        {
          if (_context.EnrollmentModel == null)
          {
              return NotFound();
          }
            return await _context.EnrollmentModel.ToListAsync();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentModel>> GetEnrollmentModel(string id)
        {
          if (_context.EnrollmentModel == null)
          {
              return NotFound();
          }
            var enrollmentModel = await _context.EnrollmentModel.FindAsync(id);

            if (enrollmentModel == null)
            {
                return NotFound();
            }

            return enrollmentModel;
        }

        // PUT: api/Enrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollmentModel(string id, EnrollmentModel enrollmentModel)
        {
            if (id != enrollmentModel.EnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(enrollmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentModelExists(id))
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

        // POST: api/Enrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnrollmentModel>> PostEnrollmentModel(EnrollmentModel enrollmentModel)
        {
          if (_context.EnrollmentModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.EnrollmentModel'  is null.");
          }
            _context.EnrollmentModel.Add(enrollmentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnrollmentModelExists(enrollmentModel.EnrollmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnrollmentModel", new { id = enrollmentModel.EnrollmentId }, enrollmentModel);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollmentModel(string id)
        {
            if (_context.EnrollmentModel == null)
            {
                return NotFound();
            }
            var enrollmentModel = await _context.EnrollmentModel.FindAsync(id);
            if (enrollmentModel == null)
            {
                return NotFound();
            }

            _context.EnrollmentModel.Remove(enrollmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrollmentModelExists(string id)
        {
            return (_context.EnrollmentModel?.Any(e => e.EnrollmentId == id)).GetValueOrDefault();
        }
    }
}
