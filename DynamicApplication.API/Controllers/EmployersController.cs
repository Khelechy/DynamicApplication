using DynamicApplication.Core.Interfaces;
using DynamicApplication.Core.Services;
using DynamicApplication.Shared.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly IApplicationProgramService _applicationProgramService;
        private readonly IQuestionService _questionService;

        public EmployersController(IApplicationProgramService applicationProgramService, IQuestionService questionService)
        {
            _applicationProgramService = applicationProgramService;
            _questionService = questionService;
        }

        [HttpPost("program")]
        public async Task<IActionResult> CreateProgramAndQuestions([FromBody] CreateProgramDto createProgramDto)
        {
            var (isSuccess, mesaage) = await _applicationProgramService.CreateProgramAndQuestions(createProgramDto);
            if (!isSuccess)
            {
                return BadRequest(mesaage);
            }
            return Ok(mesaage);
        }

        [HttpPut("program/question")]
        public async Task<IActionResult> UpdateProgramQuestion([FromBody] EditProgramQuestionDto editProgramQuestionDto)
        {
            var(isSuccess, mesaage) = await _applicationProgramService.EditProgramQuestion(editProgramQuestionDto);
            if (!isSuccess)
            {
                return BadRequest(mesaage);
            }
            return Ok();
        }

        [HttpGet("program/question/{id}")]
        public async Task<IActionResult> GetProgramQuestion(string id)
        {
            var question = await _questionService.GetProgramQuestion(id);
            if(question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
    }
}
