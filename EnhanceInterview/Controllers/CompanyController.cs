using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[AuthorizeRoles(Roles.ADMIN)]
		[HttpGet("companies")]
		public IActionResult GetCompanies(string searchString = "")
		{
			return Ok(_companyService.GetCompanies(searchString));
		}

		[AuthorizeRoles(Roles.HR, Roles.APPLICANT, Roles.TEAM_LEAD, Roles.DEVELOPER, Roles.PSYCHOLOGIST, Roles.RECRUITER, Roles.ADMIN )]
		[HttpGet("companies/{id}")]
		public IActionResult GetCompaniesById(int id)
		{
			return Ok(_companyService.GetCompanyById(id));
		}

		[HttpGet("companies/name/{companyName}")]
		public IActionResult GetCompaniesByName(string companyName)
		{
			return Ok(_companyService.GetCompanyByName(companyName));
		}

		[AuthorizeRoles(Roles.ADMIN)]
		[HttpPost("companies")]
		public IActionResult AddCompany([FromBody]CompanyDto company)
		{
			if (ModelState.IsValid)
			{
				_companyService.AddCompany(company);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[AuthorizeRoles(Roles.HR, Roles.APPLICANT, Roles.TEAM_LEAD, Roles.DEVELOPER, Roles.PSYCHOLOGIST, Roles.RECRUITER, Roles.ADMIN )]
		[HttpPut("companies")]
		public IActionResult UpdateCompany([FromBody]CompanyDto company)
		{
			if (ModelState.IsValid)
			{
				_companyService.UpdateCompany(company);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}

		[AuthorizeRoles(Roles.ADMIN)]
		[HttpDelete("companies/{companyId}")]
		public IActionResult DeleteCompany(int companyId)
		{
			_companyService.DeleteCompany(companyId);
			return Ok();
		}
	}
}