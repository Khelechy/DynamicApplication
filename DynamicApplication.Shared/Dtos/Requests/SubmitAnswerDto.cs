using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Dtos.Requests
{
    public class SubmitAnswerDto
    {
        public List<AnswerDto> Answers { get; set; }
    }

    public class AnswerDto
    {
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public dynamic QuestionAnswer { get; set; }
    }
}
