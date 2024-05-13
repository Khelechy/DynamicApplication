using DynamicApplication.Shared.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Interfaces
{
    public interface IApplicationProgramService
    {
        Task<(bool, string)> CreateProgramAndQuestions(CreateProgramDto createProgramDto);
        Task<(bool, string)> EditProgramQuestion(EditProgramQuestionDto editProgramQuestionDto);
    }
}
