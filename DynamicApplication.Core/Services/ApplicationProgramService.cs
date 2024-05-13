using DynamicApplication.Core.Data;
using DynamicApplication.Core.Interfaces;
using DynamicApplication.Shared.Dtos.Requests;
using DynamicApplication.Shared.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Services
{
    public class ApplicationProgramService : IApplicationProgramService
    {
        private readonly IQuestionService _questionService;
        private readonly AppDbContext _context;

        public ApplicationProgramService(AppDbContext context, IQuestionService questionService)
        {
            _context = context;
            _questionService = questionService;
        }

        public async Task<(bool, string)> CreateProgramAndQuestions(CreateProgramDto createProgramDto)
        {
            // Validate Multichoice and Dropdwon has option values

            var dropdownOrMultichoice = createProgramDto.programQuestions.Where(x => x.QuestionType.Value == Shared.Enums.QuestionTypeEnum.Dropdown || x.QuestionType.Value == Shared.Enums.QuestionTypeEnum.Multichoice).ToList();  
            if(dropdownOrMultichoice.Any(x => x.Options == null || x.Options.Count <= 0))
            {
                return new(false, "One or more questions dont have options");

            }

            var appProgram = new ApplicationProgram
            {
                Description = createProgramDto.Description,
                Name = createProgramDto.Name
            };

            var newProgram = await _context.ApplicationPrograms.AddAsync(appProgram);
            await _context.SaveChangesAsync();  

            await _questionService.AddProgramQuestions(newProgram.Entity.Id, createProgramDto.programQuestions);

            return new(true, newProgram.Entity.Id.ToString());
        }

        public async Task<(bool, string)> EditProgramQuestion(EditProgramQuestionDto editProgramQuestionDto)
        {
            var question = await _questionService.GetProgramQuestion(editProgramQuestionDto.QuestionId);
            if(question == null)
            {
                return new(false, "Question not found");
            }
            question.QuestionText = string.IsNullOrEmpty(editProgramQuestionDto.Question.QuestionText) ? question.QuestionText : editProgramQuestionDto.Question.QuestionText;
            question.QuestionType = editProgramQuestionDto.Question.QuestionType.HasValue ? editProgramQuestionDto.Question.QuestionType.Value : question.QuestionType;
            question.Options = editProgramQuestionDto.Question.Options != null ? editProgramQuestionDto.Question.Options : question.Options;


            await _questionService.UpdateProgramQuestion(question);
            return new(true, "");
        }
    }
}
