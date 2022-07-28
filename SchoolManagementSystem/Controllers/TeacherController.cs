using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.UnitOfWork;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(ILogger<TeacherController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Teachers.Add(teacher);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetTeacher", new { teacher.ID }, teacher);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher=await _unitOfWork.Teachers.GetById(id);
            if(teacher==null)
                return NotFound(); //404
            return Ok(teacher);
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, Teacher teacher)
        {
            if(id!=teacher.ID)
                return BadRequest();

            await _unitOfWork.Teachers.Update(teacher);
            await _unitOfWork.CompleteAsync();  

            return CreatedAtAction("GetTeacher",new {id},teacher);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetById(id);
            if (teacher == null)
                return BadRequest();

            await _unitOfWork.Teachers.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok("Teacher Deleted Successfully");
        }
    }
}
