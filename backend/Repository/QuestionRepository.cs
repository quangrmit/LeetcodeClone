using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class QuestionRepository
    {
        public QuestionRepository() { }

        public List<ListQuestionResponseDTO> listAllQuestions() {
           return QuestionDAO.getAllQuestions();
        }

        public Question findQuestionById(int id)
        {

            // Attach testcase in response
            return QuestionDAO.getQuestionById(id);
        }

        public List<bool> answerQuestion(AnswerQuestionRequestDTO answer)
        {
            //String testcases = TestcaseDAO.getTestcasesById(answer.QuestionId);
            return [];
        }
    }
}
