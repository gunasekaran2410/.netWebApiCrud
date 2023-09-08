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
    public class SectionsController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public SectionsController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Sections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionModel>>> GetSectionModel()
        {
          if (_context.SectionModel == null)
          {
              return NotFound();
          }
            return await _context.SectionModel.ToListAsync();
        }

        // GET: api/Sections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionModel>> GetSectionModel(string id)
        {
          if (_context.SectionModel == null)
          {
              return NotFound();
          }
            var sectionModel = await _context.SectionModel.FindAsync(id);

            if (sectionModel == null)
            {
                return NotFound();
            }

            return sectionModel;
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectionModel(string id, SectionModel sectionModel)
        {
            if (id != sectionModel.SectionId)
            {
                return BadRequest();
            }

            _context.Entry(sectionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionModelExists(id))
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

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SectionModel>> PostSectionModel(SectionModel sectionModel)
        {
          if (_context.SectionModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.SectionModel'  is null.");
          }
            _context.SectionModel.Add(sectionModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SectionModelExists(sectionModel.SectionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSectionModel", new { id = sectionModel.SectionId }, sectionModel);
        }

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionModel(string id)
        {
            if (_context.SectionModel == null)
            {
                return NotFound();
            }
            var sectionModel = await _context.SectionModel.FindAsync(id);
            if (sectionModel == null)
            {
                return NotFound();
            }

            _context.SectionModel.Remove(sectionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionModelExists(string id)
        {
            return (_context.SectionModel?.Any(e => e.SectionId == id)).GetValueOrDefault();
        }
    }
}
