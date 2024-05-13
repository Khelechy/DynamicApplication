using DynamicApplication.Shared.Dtos;
using DynamicApplication.Shared.Enums;
using DynamicApplication.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Interfaces
{
    public interface IQuestionService
    {
        Task AddProgramQuestions(Guid programId, List<ProgramQuestionDto> pogramQuestions);
        Task<Question> GetProgramQuestion(string id);
        Task<IEnumerable<Question>> GetMultipleAsync(string programId, QuestionTypeEnum? questionType);

        Task UpdateProgramQuestion(Question question);

    }
}
