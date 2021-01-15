using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class InterviewerController : Controller
	{
		private readonly IInterviewerService _interviewerService;

		public InterviewerController(IInterviewerService interviewerService)
		{
			_interviewerService = interviewerService;
		}

		[HttpGet("interviewer/user/{userId}")]
		public IActionResult GetInterviewerByUserId(string userId)
		{
			return Ok(_interviewerService.GetInterviewerByUserId(userId));
		}
	}
}