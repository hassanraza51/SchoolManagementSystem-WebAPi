using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.UnitOfWork;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(ILogger<StudentController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWork.Students.Add(student);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetStudent", new { student.ID }, student);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student=await _unitOfWork.Students.GetById(id);
            if(student==null)
                return NotFound();
            return Ok(student);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.Students.GetAll();
            return Ok(students);
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudent(int id,Student student)
        {
            if(id!=student.ID)
                return BadRequest();
            
            await _unitOfWork.Students.Update(student);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetStudent", new {id},student);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student= await _unitOfWork.Students.GetById(id);

            if (student == null)
                return BadRequest();

            await _unitOfWork.Students.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok("Student Deleted Successfully");
        }
    }
}
