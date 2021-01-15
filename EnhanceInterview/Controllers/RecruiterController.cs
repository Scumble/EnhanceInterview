using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class RecruiterController : ControllerBase
	{
		private readonly IRecruiterService _recruiterService;

		public RecruiterController(IRecruiterService recruiterService)
		{
			_recruiterService = recruiterService;
		}

		[AuthorizeRoles(Roles.RECRUITER)]
		[HttpGet("recruiters/user/{userId}")]
		public IActionResult GetRecruiterByUserId(string userId)
		{
			return Ok(_recruiterService.GetRecruiterByUserId(userId));
		}

		[AuthorizeRoles(Roles.RECRUITER)]
		[HttpGet("recruiters/{id}")]
		public IActionResult GetRecruiterById(int id)
		{
			return Ok(_recruiterService.GetRecruiterById(id));
		}
	}
}