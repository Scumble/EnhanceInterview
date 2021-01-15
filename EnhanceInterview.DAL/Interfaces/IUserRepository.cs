using System.Collections.Generic;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers();

		void AddUser(User user);

		User GetUser(string login, string password);
	}
}