using System.Threading.Tasks;
using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class InterviewController : ControllerBase
	{
		private readonly IInterviewService _interviewService;
		private readonly IHubContext<NotificationHub> _hubContext;

		public InterviewController(IInterviewService interviewService, IHubContext<NotificationHub> hubContext)
		{
			_interviewService = interviewService;
			_hubContext = hubContext;
		}

		[HttpGet("interviews/company/{companyId}")]
		public IActionResult GetInterviewsByCompanyId(int companyId, string searchString = "", string status = "")
		{
			return Ok(_interviewService.GetInterviewsByCompanyId(companyId, searchString, status));
		}

		[HttpGet("interviews/applicant/{applicantId}")]
		public IActionResult GetAppliedInterviews(int applicantId, string searchString = "", string status = "")
		{
			return Ok(_interviewService.GetAppliedInterviews(applicantId, searchString, status));
		}

		[HttpGet("interview/{interviewId}")]
		public IActionResult GetInterviewById(int interviewId)
		{
			return Ok(_interviewService.GetInterviewById(interviewId));
		}

		[HttpGet("interview/vacancy/{vacancyId}")]
		public IActionResult GetInterviewByVacancyId(int vacancyId)
		{
			return Ok(_interviewService.GetInterviewByVacancyId(vacancyId));
		}

		[HttpGet("interview/applicant/{applicantId}/vacancy/{vacancyId}")]
		public IActionResult GetInterviewByApplicantId(int applicantId, int vacancyId)
		{
			return Ok(_interviewService.GetInterviewByApplicantId(applicantId, vacancyId));
		}

		[HttpPost("interview")]
		public async Task<IActionResult> ApplyToVacancy([FromBody]InterviewDto interviewDto)
		{
			if (ModelState.IsValid)
			{
				var interview = _interviewService.AddInterview(interviewDto);
				await _hubContext.Clients.All.SendAsync("AppliedToVacancy", interview);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("interview")]
		public async Task<IActionResult> UpdateInterview([FromBody]InterviewDto interviewDto)
		{
			if (ModelState.IsValid)
			{
				_interviewService.UpdateInterview(interviewDto);
				await _hubContext.Clients.All.SendAsync("InterviewUpdated", string.Empty);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}
	}
}