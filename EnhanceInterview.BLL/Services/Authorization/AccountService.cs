using System;
using System.Linq;
using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Exceptions;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.BLL.Interfaces.Authorization;

namespace EnhanceInterview.BLL.Services.Authorization
{
	public class AccountService : IAccountService
	{
		private readonly IRoleService _roleService;
		private readonly IUserService _userService;
		private readonly IJwtServiceProvider _jwtServiceProvider;
		private readonly IPasswordEncoder _passwordEncoder;

		public AccountService(
			IJwtServiceProvider jwtServiceProvider,
			IRoleService roleService,
			IUserService userService,
			IPasswordEncoder passwordEncoder)
		{
			_jwtServiceProvider = jwtServiceProvider;
			_roleService = roleService;
			_userService = userService;
			_passwordEncoder = passwordEncoder;
		}

		public LoginModel AuthenticateUser(string login, string password)
		{
			var encodedPassword = _passwordEncoder.EncodePassword(password);
			var user = _userService.GetUser(login, encodedPassword);

			if (user == null)
			{
				return null;
			}

			var userModel = _roleService.GetUserByRole(user.UserId, user.Role);
			userModel.Token = _jwtServiceProvider.GenerateJwtToken(user.UserId, user.Role);
			userModel.Login = login;
			userModel.Role = user.Role;

			return userModel;
		}

		public void RegisterUser(RegistrationModel registrationModel)
		{
			if (!ValidateNewUserLogin(registrationModel.Login))
			{
				throw new RegistrationException("User with the same login already exists");
			}

			var userId = Guid.NewGuid().ToString();
			var encodedPassword = _passwordEncoder.EncodePassword(registrationModel.Password);

			if (string.IsNullOrEmpty(registrationModel.Role))
			{
				registrationModel.Role = Roles.APPLICANT;
			}

			var userDto = new UserDto
			{
				UserId = userId,
				Login = registrationModel.Login,
				Password = encodedPassword,
				Role = registrationModel.Role
			};

			_userService.AddUser(userDto);
			registrationModel.UserId = userId;
			_roleService.CreateUserByRole(registrationModel);
		}

		private bool ValidateNewUserLogin(string login)
		{
			var users = _userService.GetUsers();
			return users.FirstOrDefault(x => x.Login == login) == null;
		}
	}
}