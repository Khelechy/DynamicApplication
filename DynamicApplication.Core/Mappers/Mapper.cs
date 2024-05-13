using DynamicApplication.Shared.Dtos;
using DynamicApplication.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Mappers
{
    public static class Mapper
    {
        public static Question ToQuestion(this ProgramQuestionDto programQuestionDto, Guid programId)
        {
            if (programQuestionDto == null) return null;
            return new Question
            {
                ProgramId = programId.ToString(),
                QuestionText = programQuestionDto.QuestionText,
                QuestionType = programQuestionDto.QuestionType.Value,
                Options = programQuestionDto.QuestionType.Value == Shared.Enums.QuestionTypeEnum.Dropdown || programQuestionDto.QuestionType.Value == Shared.Enums.QuestionTypeEnum.Multichoice ? programQuestionDto.Options : new List<string>(),
            };
        }
    }
}
