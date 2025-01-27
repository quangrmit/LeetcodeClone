using BusinessObjects;
using DataAccess;
using k8s.Models;
using k8s;
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


    }
}
