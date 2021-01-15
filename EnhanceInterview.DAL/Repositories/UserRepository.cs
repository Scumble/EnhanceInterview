using System;
using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _context;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<User> GetUsers()
		{
			return _context.Users;
		}

		public User GetUser(string login, string password)
		{
			return _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
		}

		public void AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
	}
}