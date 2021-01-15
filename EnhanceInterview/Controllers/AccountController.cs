using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Exceptions;
using EnhanceInterview.BLL.Interfaces.Authorization;
using EnhanceInterview.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult Login([FromBody]AccountViewModel model)
		{
			var user = _accountService.AuthenticateUser(model.Login, model.Password);

			if (user == null)
			{
				return BadRequest(new
				{
					message = "Username or password is incorrect"
				});
			}

			return Ok(user);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]RegistrationModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_accountService.RegisterUser(model);
					return StatusCode(StatusCodes.Status201Created);
				}
				catch (RegistrationException)
				{
					return BadRequest(new
					{
						message = "User with the same login already exists"
					});
				}
			}

			return BadRequest();
		}
	}
}