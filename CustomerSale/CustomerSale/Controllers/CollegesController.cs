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
    public class CollegesController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public CollegesController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Colleges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeModel>>> GetCollegeModel()
        {
          if (_context.CollegeModel == null)
          {
              return NotFound();
          }
            return await _context.CollegeModel.ToListAsync();
        }

        // GET: api/Colleges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeModel>> GetCollegeModel(string id)
        {
          if (_context.CollegeModel == null)
          {
              return NotFound();
          }
            var collegeModel = await _context.CollegeModel.FindAsync(id);

            if (collegeModel == null)
            {
                return NotFound();
            }

            return collegeModel;
        }

        // PUT: api/Colleges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollegeModel(string id, CollegeModel collegeModel)
        {
            if (id != collegeModel.CollegeId)
            {
                return BadRequest();
            }

            _context.Entry(collegeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeModelExists(id))
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

        // POST: api/Colleges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollegeModel>> PostCollegeModel(CollegeModel collegeModel)
        {
          if (_context.CollegeModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.CollegeModel'  is null.");
          }
            _context.CollegeModel.Add(collegeModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CollegeModelExists(collegeModel.CollegeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCollegeModel", new { id = collegeModel.CollegeId }, collegeModel);
        }

        // DELETE: api/Colleges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollegeModel(string id)
        {
            if (_context.CollegeModel == null)
            {
                return NotFound();
            }
            var collegeModel = await _context.CollegeModel.FindAsync(id);
            if (collegeModel == null)
            {
                return NotFound();
            }

            _context.CollegeModel.Remove(collegeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollegeModelExists(string id)
        {
            return (_context.CollegeModel?.Any(e => e.CollegeId == id)).GetValueOrDefault();
        }
    }
}
