using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.UnitOfWork;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public SchoolController(ILogger<SchoolController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSchool(School school)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.School.Add(school);
                await _unitOfWork.CompleteAsync();

                return Ok(school);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSchool()
        {
            var school = await _unitOfWork.School.GetAll();
            return Ok(school);
        }
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateSchool(string id,School school)
        {
            if(id!=school.RegistrationID)
                return BadRequest();
            await _unitOfWork.School.Update(school);
            await _unitOfWork.CompleteAsync();
            return Ok(school);
        }
    }
}
