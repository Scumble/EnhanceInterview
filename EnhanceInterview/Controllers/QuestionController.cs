using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		private readonly IQuestionService _questionService;

		public QuestionController(IQuestionService questionService)
		{
			_questionService = questionService;
		}

		[HttpGet("questions/vacancy/{vacancyId}")]
		public IActionResult GetQuestions(int vacancyId, string category = "", string searchString = "")
		{
			return Ok(_questionService.GetQuestionsByVacancyId(vacancyId, category, searchString));
		}

		[HttpGet("questions/{questionId}")]
		public IActionResult GetQuestionById(int questionId)
		{
			return Ok(_questionService.GetQuestionById(questionId));
		}

		[HttpPost("questions/vacancy/{vacancyId}")]
		public IActionResult CreateQuestion([FromBody]QuestionDto question, int vacancyId)
		{
			if (ModelState.IsValid)
			{
				_questionService.AddQuestion(question, vacancyId);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("questions")]
		public IActionResult UpdateQuestion([FromBody]QuestionDto question)
		{
			if (ModelState.IsValid)
			{
				_questionService.UpdateQuestion(question);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}

		[HttpDelete("questions/{questionId}/vacancy/{vacancyId}")]
		public IActionResult DeleteQuestion(int questionId, int vacancyId)
		{
			_questionService.DeleteQuestion(questionId, vacancyId);
			return Ok();
		}
	}
}