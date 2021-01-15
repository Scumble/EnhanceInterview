using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class AnswerController : ControllerBase
	{
		private readonly IAnswerService _answerService;
		private readonly IRatingService _ratingService;

		public AnswerController(IAnswerService answerService, IRatingService ratingService)
		{
			_answerService = answerService;
			_ratingService = ratingService;
		}

		[HttpGet("rating/applicant/{applicantId}")]
		public IActionResult GetInterviewRatings(int applicantId)
		{
			return Ok(_ratingService.GetInterviewRatings(applicantId));
		}

		[HttpGet("rating/vacancy/{vacancyId}")]
		public IActionResult GetVacancyRatings(int vacancyId)
		{
			return Ok(_ratingService.GetVacancyRating(vacancyId));
		}

		[HttpGet("answers/interview/{interviewId}")]
		public IActionResult GetInterviewResultsByInterviewId(int interviewId, string searchString = "", string category = "")
		{
			return Ok(_answerService.GetInterviewResultsByInterviewId(interviewId, searchString, category));
		}

		[HttpPost("answers")]
		public IActionResult AddAnswer([FromBody]AnswerDto answerDto)
		{
			if (ModelState.IsValid)
			{
				_answerService.AddAnswer(answerDto);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("answers")]
		public IActionResult UpdateAnswer([FromBody]AnswerDto answerDto)
		{
			if (ModelState.IsValid)
			{
				_answerService.UpdateAnswer(answerDto);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}

		[HttpDelete("answers/{answerId}")]
		public IActionResult DeleteAnswer(int answerId)
		{
			_answerService.DeleteAnswer(answerId);
			return Ok();
		}
	}
}