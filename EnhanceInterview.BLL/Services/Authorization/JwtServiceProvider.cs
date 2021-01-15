using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.BLL.Interfaces.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EnhanceInterview.BLL.Services.Authorization
{
	public class JwtServiceProvider : IJwtServiceProvider
	{
		private readonly AppSettings _appSettings;

		public JwtServiceProvider(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public string GenerateJwtToken(string userId, string role)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] 
				{
					new Claim(ClaimTypes.Name, userId),
					new Claim(ClaimTypes.Role, role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}