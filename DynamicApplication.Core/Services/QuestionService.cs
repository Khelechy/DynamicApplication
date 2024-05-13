using DynamicApplication.Core.Data;
using DynamicApplication.Core.Interfaces;
using DynamicApplication.Core.Mappers;
using DynamicApplication.Shared.Dtos;
using DynamicApplication.Shared.Enums;
using DynamicApplication.Shared.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;
        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProgramQuestions(Guid programId, List<ProgramQuestionDto> pogramQuestions)
        {
            var questions = pogramQuestions.Select(x => x.ToQuestion(programId)).ToList();
            await _context.Questions.AddRangeAsync(questions);
            await _context.SaveChangesAsync();
        }

        public async Task<Question> GetProgramQuestion(string id)
        {
            return await _context.Questions.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<IEnumerable<Question>> GetMultipleAsync(string programId, QuestionTypeEnum? questionType)
        {
            var results = await _context.Questions.Where(x => x.ProgramId == programId && (questionType == null || questionType.HasValue && x.QuestionType == questionType.Value)).ToListAsync();
            return results;
        }

        public async Task UpdateProgramQuestion(Question question)
        {
             _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}
