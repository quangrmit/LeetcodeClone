using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AnswerQuestionRequestDTO
    {
        public int QuestionId { get; set; }
        public String Answer {  get; set; }
        public String Language { get; set; }
    }
}
