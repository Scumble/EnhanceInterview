using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserDto> GetUsers();

		UserDto GetUser(string login, string password);

		void AddUser(UserDto userDto);
	}
}