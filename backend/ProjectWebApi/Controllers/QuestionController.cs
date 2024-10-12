using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {   
        private QuestionRepository questionRepository = new QuestionRepository();

        public QuestionController() { }
        [HttpGet]
        public ActionResult<IEnumerable<ListQuestionResponseDTO>> getQuestions() => questionRepository.listAllQuestions();

        [HttpGet("{id:int}")]
        public ActionResult<Question> getQuestionById(int id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Id not provided" });
            }
            try
            {
                return questionRepository.findQuestionById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Question not found" });
            }
        }

        //[HttpPost]
        //public IActionResult answerQuestion(AnswerQuestionRequestDTO answer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        List<bool> testResult = questionRepository.answerQuestion(answer);
        //        return Ok(testResult);
        //    }
        //    return BadRequest(new { message = "Invalid answer format" });
        //}
    }
}
