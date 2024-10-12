﻿using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private SubmissionRepository submissionRepository = new SubmissionRepository();
        private QuestionRepository questionRepository = new QuestionRepository();
        public SubmissionController() { }
        [HttpPost]
        public async Task<IActionResult> submitAnswer(AnswerQuestionRequestDTO answer)
        {
            try
            {
                Question question = questionRepository.findQuestionById(answer.QuestionId);
                Testcase testcase = question.Testcases.FirstOrDefault();
                String ans = answer.Answer;

                String res = await Task.Run(() => submissionRepository.answerQuestion(testcase, ans));
                if (res == "")
                {
                    return BadRequest(new { message = "Can't run testcases" });
                }
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        
    }
}
