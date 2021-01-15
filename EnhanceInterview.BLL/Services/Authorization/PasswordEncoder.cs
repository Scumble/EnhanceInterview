using System;
using System.Security.Cryptography;
using System.Text;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.BLL.Interfaces.Authorization;

namespace EnhanceInterview.BLL.Services.Authorization
{
	public class PasswordEncoder : IPasswordEncoder
	{
		public string EncodePassword(string password)
		{
			var saltBytes = Encoding.ASCII.GetBytes("Qwerty");
			var passwordBytes = Encoding.UTF8.GetBytes(password);
			var hashedSaltedPassword = ComputeHMAC_SHA256(passwordBytes, saltBytes);

			return Convert.ToBase64String(hashedSaltedPassword);
		}
		private byte[] ComputeHMAC_SHA256(byte[] data, byte[] salt)
		{
			using (var hmac = new HMACSHA256(salt))
			{
				return hmac.ComputeHash(data);
			}
		}
	}
}