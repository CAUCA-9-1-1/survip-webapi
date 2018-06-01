using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
			var encodedPassword = EncodePassword(password, applicationName);
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

		private string EncodePassword(string password, string applicationName)
		{
			var secret = Encoding.UTF8.GetBytes(applicationName);
			var bytePassword = Encoding.UTF8.GetBytes(password);

			var hmac = new HMACSHA256(secret);

			var hmacPassword = hmac.ComputeHash(bytePassword);
			return ByteToString(hmacPassword);
		}

		private string ByteToString(byte[] buff)
		{
			string sbinary = "";

			for (int i = 0; i < buff.Length; i++)
				sbinary += buff[i].ToString("X2"); // hex format

			return sbinary;
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
