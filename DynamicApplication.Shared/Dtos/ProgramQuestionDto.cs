using DynamicApplication.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Dtos
{
    public class ProgramQuestionDto
    {
        public string? QuestionText { get; set; }
        public QuestionTypeEnum? QuestionType { get; set; }
        public List<string>? Options { get; set; } // Save Multichoice and dropdown options
    }
}
