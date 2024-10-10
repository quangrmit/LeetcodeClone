using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QuestionDAO
    {
        public QuestionDAO() { }

        public static List<ListQuestionResponseDTO> getAllQuestions()
        {
            var res = new List<ListQuestionResponseDTO>();

            try
            {
                using (var context = new ApplicationDBContext())
                {
                    var questions = context.Questions.ToList();
                    foreach (var question in questions)
                    {
                        res.Add(new ListQuestionResponseDTO { QuestionId = question.QuestionId, QuestionTitle = question.QuestionTitle });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.ToString());
            }
            return res;
        } 

        public static Question getQuestionById(int id)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    Question q = context.Questions.Include(m => m.Testcases).IgnoreAutoIncludes().FirstOrDefault(x => x.QuestionId == id);
                    if (q != null) return q;
                    throw new Exception("Id not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception(e.ToString()); 
            }
        }
    }
}
