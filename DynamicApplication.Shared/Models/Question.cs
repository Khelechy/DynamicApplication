using DynamicApplication.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public string ProgramId { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
        public List<string> Options { get; set; } = new List<string>(); // Save Multichoice and dropdown options
    }
}
