using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerSale.Data;
using CustomerSale.Models;

namespace CustomerSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly CustomerSaleContext _context;

        public AttendancesController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]

        public async Task<ActionResult<IEnumerable<AttendanceModel>>> GetAttendanceModel()
        {
            var result = await Task.Run(() =>
                (from a in _context.AttendanceModel
                 join cl in _context.StudentModel on a.StudentId equals cl.StudentId into c1j
                 from f1 in c1j.DefaultIfEmpty()

                 join cl2 in _context.SectionModel on a.SectionId equals cl2.SectionId into c2j
                 from f2 in c2j.DefaultIfEmpty()

                 orderby a.DateAttended ascending
                 select new
                 {
                     a.AttendanceId,
                     a.DateAttended,
                     a.Hours,
                     a.SectionId,
                     section_name = f2.Name,
                     a.StudentId,
                     student_name = f1.Firstname + " " + f1.LastName,
                 }).ToList());

            return new OkObjectResult(result);
        }




        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceModel>> GetAttendanceModel(string id)
        {
          if (_context.AttendanceModel == null)
          {
              return NotFound();
          }
            var attendanceModel = await _context.AttendanceModel.FindAsync(id);

            if (attendanceModel == null)
            {
                return NotFound();
            }

            return attendanceModel;
        }

        // PUT: api/Attendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceModel(string id, AttendanceModel attendanceModel)
        {
            if (id != attendanceModel.AttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(attendanceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceModelExists(id))
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

        // POST: api/Attendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttendanceModel>> PostAttendanceModel(AttendanceModel attendanceModel)
        {
          if (_context.AttendanceModel == null)
          {
              return Problem("Entity set 'CustomerSaleContext.AttendanceModel'  is null.");
          }
            _context.AttendanceModel.Add(attendanceModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceModelExists(attendanceModel.AttendanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendanceModel", new { id = attendanceModel.AttendanceId }, attendanceModel);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceModel(string id)
        {
            if (_context.AttendanceModel == null)
            {
                return NotFound();
            }
            var attendanceModel = await _context.AttendanceModel.FindAsync(id);
            if (attendanceModel == null)
            {
                return NotFound();
            }

            _context.AttendanceModel.Remove(attendanceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceModelExists(string id)
        {
            return (_context.AttendanceModel?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}
