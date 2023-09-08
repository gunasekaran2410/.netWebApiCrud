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
    public class CoursesController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public CoursesController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourseModel()
        {
          if (_context.CourseModel == null)
          {
              return NotFound();
          }
            return await _context.CourseModel.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseModel(string id)
        {
          if (_context.CourseModel == null)
          {
              return NotFound();
          }
            var courseModel = await _context.CourseModel.FindAsync(id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return courseModel;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseModel(string id, CourseModel courseModel)
        {
            if (id != courseModel.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(courseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseModelExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourseModel(CourseModel courseModel)
        {
          if (_context.CourseModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.CourseModel'  is null.");
          }
            _context.CourseModel.Add(courseModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseModelExists(courseModel.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseModel", new { id = courseModel.CourseId }, courseModel);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseModel(string id)
        {
            if (_context.CourseModel == null)
            {
                return NotFound();
            }
            var courseModel = await _context.CourseModel.FindAsync(id);
            if (courseModel == null)
            {
                return NotFound();
            }

            _context.CourseModel.Remove(courseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseModelExists(string id)
        {
            return (_context.CourseModel?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
    }
}
