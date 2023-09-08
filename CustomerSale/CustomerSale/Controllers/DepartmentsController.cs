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
    public class DepartmentsController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public DepartmentsController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartmentModel()
        {
          if (_context.DepartmentModel == null)
          {
              return NotFound();
          }
            return await _context.DepartmentModel.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(string id)
        {
          if (_context.DepartmentModel == null)
          {
              return NotFound();
          }
            var departmentModel = await _context.DepartmentModel.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            return departmentModel;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(string id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(departmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentModelExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
          if (_context.DepartmentModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.DepartmentModel'  is null.");
          }
            _context.DepartmentModel.Add(departmentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentModelExists(departmentModel.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartmentModel", new { id = departmentModel.DepartmentId }, departmentModel);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentModel(string id)
        {
            if (_context.DepartmentModel == null)
            {
                return NotFound();
            }
            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            _context.DepartmentModel.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentModelExists(string id)
        {
            return (_context.DepartmentModel?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
