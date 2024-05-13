using DynamicApplication.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Dtos.Requests
{
    public class EditProgramQuestionDto
    {
        public string QuestionId { get; set; }
        public ProgramQuestionDto Question { get; set; }
    }
}
