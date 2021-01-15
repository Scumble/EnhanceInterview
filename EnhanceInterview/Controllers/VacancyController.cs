using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class VacancyController : ControllerBase
	{
		private readonly IVacancyService _vacancyService;

		public VacancyController(IVacancyService vacancyService)
		{
			_vacancyService = vacancyService;
		}

		[HttpGet("vacancies/company/{companyId}")]
		public IActionResult GetCreatedVacanciesByUserId(int companyId, string searchString = "")
		{
			return Ok(_vacancyService.GetVacanciesByCompanyId(companyId, searchString));
		}

		[HttpGet("vacancies/{vacancyId}")]
		public IActionResult GetVacancyById(int vacancyId)
		{
			return Ok(_vacancyService.GetVacancyById(vacancyId));
		}

		[HttpGet("vacancies/applicant/{applicantId}")]
		public IActionResult GetVacancies(int applicantId, string searchString = "")
		{
			return Ok(_vacancyService.GetVacanciesForApplicant(applicantId, searchString));
		}

		[HttpPost("vacancies")]
		public IActionResult CreateVacancy([FromBody]VacancyDto vacancy)
		{
			if (ModelState.IsValid)
			{
				_vacancyService.AddVacancy(vacancy);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("vacancies")]
		public IActionResult UpdateVacancy([FromBody]VacancyDto vacancy)
		{
			if (ModelState.IsValid)
			{
				_vacancyService.UpdateVacancy(vacancy);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}

		[HttpDelete("vacancies/{vacancyId}")]
		public IActionResult DeleteVacancy(int vacancyId)
		{
			_vacancyService.DeleteVacancy(vacancyId);
			return Ok();
		}
	}
}