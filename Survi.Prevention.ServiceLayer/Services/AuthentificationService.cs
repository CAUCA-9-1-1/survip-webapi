using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class AuthentificationService : BaseService
	{
		public AuthentificationService(ManagementContext context) : base(context)
		{
		}

		public (AccessToken token, Webuser user) Login(string username, string password, string applicationName, string issuer, string secretKey)
		{
			var encodedPassword = new PasswordGenerator().EncodePassword(password, applicationName);
			var userFound = Context.Webusers
				.Include(user => user.Attributes)
				.SingleOrDefault(user => user.Username == username && user.Password == encodedPassword && user.IsActive);
			if (userFound != null)
			{
				var token = GenerateJwtToken(userFound, applicationName, issuer, secretKey);
				var handler = new JwtSecurityTokenHandler();
				var tokenString = handler.WriteToken(token);
				var accessToken = new AccessToken {TokenForAccess = tokenString, ExpiresIn = 600000, IdWebuser = userFound.Id};
				Context.Add(accessToken);
				Context.SaveChanges();
				return (accessToken, userFound);
			}

			return (null, null);
		}
		
		protected JwtSecurityToken GenerateJwtToken(Webuser userLoggedIn, string applicationName, string issuer, string secretKey)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, userLoggedIn.Username),
				new Claim(JwtRegisteredClaimNames.Sid, userLoggedIn.Id.ToString()),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(issuer,
				applicationName,
				claims,
				expires: DateTime.UtcNow.AddMinutes(60),
				signingCredentials: creds);
			return token;
		}
	}
}
