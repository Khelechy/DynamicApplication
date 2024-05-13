using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Shared.Models
{
    public class QuestionAnswer
    {
        public Guid Id { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; } // Using string to hold all dynamic data
        public string UserId { get; set; }
    }
}
