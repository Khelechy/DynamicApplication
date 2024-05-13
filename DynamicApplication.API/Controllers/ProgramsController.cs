using DynamicApplication.Core.Interfaces;
using DynamicApplication.Shared.Dtos.Requests;
using DynamicApplication.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public ProgramsController(IQuestionService questionService)
        {
           _questionService = questionService; 
        }

        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetProgramQuestions(string id, [FromQuery] QuestionTypeEnum? questionType)
        {
            var response = await _questionService.GetMultipleAsync(id, questionType);
            return Ok(response);
        }

        [HttpPost("questions/answer")]
        public async Task<IActionResult> SubmitQuestionAnswer( [FromBody] SubmitAnswerDto answerDto)
        {
            var (isSuccess, mesaage) = await _questionService.SubmitProgramAnswers(answerDto);
            if (!isSuccess)
            {
                return BadRequest(mesaage);
            }
            return Ok(mesaage);
        }
    }
}
