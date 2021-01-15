using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public IEnumerable<UserDto> GetUsers()
		{
			return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(_userRepository.GetUsers());
		}

		public UserDto GetUser(string login, string password)
		{
			return _mapper.Map<User, UserDto>(_userRepository.GetUser(login, password));
		}

		public void AddUser(UserDto userDto)
		{
			_userRepository.AddUser(_mapper.Map<UserDto, User>(userDto));
		}
	}
}