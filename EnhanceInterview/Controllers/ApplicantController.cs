using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class ApplicantController : ControllerBase
	{
		private readonly IApplicantService _applicantService;

		public ApplicantController(IApplicantService applicantService)
		{
			_applicantService = applicantService;
		}

		[HttpGet("applicant/user/{userId}")]
		public IActionResult GetApplicantByUserId(string userId)
		{
			return Ok(_applicantService.GetApplicantByUserId(userId));
		}

		[HttpGet("applicant/{id}")]
		public IActionResult GetApplicantById(int id)
		{
			return Ok(_applicantService.GetApplicantById(id));
		}

		[HttpPut("applicant")]
		public IActionResult UpdateVacancy([FromBody]ApplicantDto applicantDto)
		{
			if (ModelState.IsValid)
			{
				_applicantService.UpdateApplicant(applicantDto);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}
	}
}