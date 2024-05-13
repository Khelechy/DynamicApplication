using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Dtos.Requests
{
    public class CreateProgramDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProgramQuestionDto> programQuestions { get; set; }    
    }
}
