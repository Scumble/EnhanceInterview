using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class VacancyQuestionController : ControllerBase
	{
		private readonly IVacancyQuestionService _vacancyQuestionService;

		public VacancyQuestionController(IVacancyQuestionService vacancyQuestionService)
		{
			_vacancyQuestionService = vacancyQuestionService;
		}

		[HttpPost("vacancy-questions")]
		public IActionResult CreateVacancyQuestion([FromBody]VacancyQuestionDto vacancyQuestionDto)
		{
			if (ModelState.IsValid)
			{
				_vacancyQuestionService.AddVacancyQuestion(vacancyQuestionDto);
				return StatusCode(StatusCodes.Status201Created);
			}

			return BadRequest();
		}

		[HttpPut("vacancy-questions")]
		public IActionResult UpdateVacancyQuestion([FromBody]VacancyQuestionDto vacancyQuestionDto)
		{
			if (ModelState.IsValid)
			{
				_vacancyQuestionService.UpdateVacancyQuestion(vacancyQuestionDto);
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return BadRequest();
		}
	}
}