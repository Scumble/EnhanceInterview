using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class FeedbackController : Controller
	{
		private readonly IFeedbackService _feedbackService;

		public FeedbackController(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		[HttpGet("feedbacks/interview/{interviewId}")]
		public IActionResult GetApplicantFeedbacks(int interviewId)
		{
			return Ok(_feedbackService.GetApplicantFeedbacks(interviewId));
		}

		[HttpPost("feedbacks")]
		public IActionResult AddFeedback([FromBody]FeedbackDto feedbackDto)
		{
			if (ModelState.IsValid)
			{
				_feedbackService.AddFeedback(feedbackDto);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("feedbacks")]
		public IActionResult UpdateFeedback([FromBody]FeedbackDto feedbackDto)
		{
			if (ModelState.IsValid)
			{
				_feedbackService.UpdateFeedback(feedbackDto);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}

		[HttpDelete("feedbacks/{feedbackId}")]
		public IActionResult DeleteAnswer(int feedbackId)
		{
			_feedbackService.DeleteFeedback(feedbackId);
			return Ok();
		}
	}
}