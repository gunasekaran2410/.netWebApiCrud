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
    public class StudentsController : ControllerBase
    {
        public string error_status;
        public string error_messag;

        private readonly CustomerSaleContext _context;

        public StudentsController(CustomerSaleContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
            var result = await Task.Run(() => (from a in _context.AttendanceModel
                                               join cl in _context.StudentModel on a.StudentId equals cl.StudentId into clj
                                               from c in clj.DefaultIfEmpty()
                                               join cl2 in _context.SectionModel on a.SectionId equals cl2.SectionId into clj2
                                               from c2 in clj2.DefaultIfEmpty()

                                               orderby a.DateAttended ascending
                                               select new
                                               {
                                                   a.DateAttended,
                                                   a.SectionId,
                                                   section_name = c2.Name,
                                                   a.Hours,
                                                   a.StudentId,
                                                   student_name = c.Firstname + " " + c.LastName
                                                   // StudentFullName = a.Firstname + " " + a.LastName
                                               }).ToList()); ;
            return new OkObjectResult(result);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(string id)
        {
          if (_context.StudentModel == null)
          {
              return NotFound();
          }
            var studentModel = await _context.StudentModel.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(string id, StudentModel updatedStudent)
        {

            
            if (id == null)
            {
                error_messag = "Please Send Id";
                error_status = "0";
                return new OkObjectResult(await ErrorModels.ErrorMessage(error_messag, error_status));

            }

            var existingStudent = await _context.StudentModel.FindAsync(id);

            if (existingStudent == null)
            {
                error_messag = "No Data Found";
                error_status = "0";
                return new OkObjectResult(await ErrorModels.ErrorMessage(error_messag, error_status));
            }

            // Update the properties of the existing student with the new values
            existingStudent.Firstname = updatedStudent.Firstname;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.Email = updatedStudent.Email;
            existingStudent.Contact = updatedStudent.Contact;
            existingStudent.CollegeId = updatedStudent.CollegeId;

            try
            {
                await _context.SaveChangesAsync();
                error_messag = "Successfully";
                error_status = "1";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
                {
                    error_messag = "Not Found Data";
                    error_status = "0";
                }
                else
                {
                    throw;
                }
            }

            return new OkObjectResult(ErrorModels.ErrorMessage(error_messag, error_status));
        }


        // POST: api/Studens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel a)
        {
            
            StudentModel stud = new StudentModel()
            {
                Firstname = a.Firstname,
                LastName = a.LastName,
                Email = a.Email,
                Contact = a.Contact,
                CollegeId = a.CollegeId
            };
            _context.StudentModel.Add(stud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = stud.StudentId }, stud);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModel(string id)
        {
            if (_context.StudentModel == null)
            {
                return NotFound();
            }
            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.StudentModel.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelExists(string id)
        {
            return (_context.StudentModel?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
