using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class AuthentificationService : BaseService
	{
		private readonly string issuer = "http://cauca.ca";
		private readonly string secretKey = "SURVI-Prevention-API";

		public AuthentificationService(ManagementContext context) : base(context)
		{
		}

		public (AccessToken token, Webuser user) Login(string username, string password)
		{
			var encodedPassword = EncodePassword(password);
			var userFound = Context.Webusers.FirstOrDefault(user => user.Username == username && user.Password == encodedPassword && user.IsActive);
			if (userFound != null)
			{
				var token = GenerateJwtToken(userFound);
				var handler = new JwtSecurityTokenHandler();
				var tokenString = handler.WriteToken(token);
				var accessToken = new AccessToken {TokenForAccess = tokenString, CreatedOn = DateTime.Now, ExpiresIn = 60, IdWebuser = userFound.Id};
				Context.Add(accessToken);
				Context.SaveChanges();
				return (accessToken, userFound);
			}

			return (null, null);
		}

		private string EncodePassword(string password)
		{
			var secret = Encoding.UTF8.GetBytes(secretKey);
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

		public (bool isAuthorized, Guid idUser) GetAuthorizedUser(string token)
		{
#if DEBUG
			// backdoor!
			if (token == "T")
				return (true, Guid.Parse(""));
#endif

			var handler = new JwtSecurityTokenHandler();
			if (!handler.CanReadToken(token))
			{
				//LogInvalidTokenRequest(token, "Le token reçu n'est pas d'un format valide.");
				return (false, Guid.Empty);
			}

			try
			{
				TokenValidationParameters validationParameters = GetTokenValidationParameters();
				handler.ValidateToken(token, validationParameters, out var securityToken);
				return ClaimsAreValid(securityToken);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				//LogInvalidTokenRequest(token, ex.Message);
				return (false, Guid.Empty);
			}
		}

		private TokenValidationParameters GetTokenValidationParameters()
		{
			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
				ValidAudience = issuer,
				ValidIssuer = issuer
			};

			return validationParameters;
		}

		/*private void LogInvalidTokenRequest(string token, string message)
		{
		  loggingService.LogWebApiCallWithInvalidToken(token, message);
		}*/

		private (bool isAuthorized, Guid idUser) ClaimsAreValid(SecurityToken securityToken)
		{
			if (securityToken is JwtSecurityToken jwtToken)
			{
				var securityTokenClaims = jwtToken.Claims.ToList();
				var idUserFromClaim = Guid.Parse(securityTokenClaims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
				var usernameFromClaim = securityTokenClaims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
				var userHasBeenFound = Context.Webusers.Any(user => user.Id == idUserFromClaim && user.Username == usernameFromClaim && user.IsActive);

				if (userHasBeenFound)
					return (true, idUserFromClaim);
			}

			return (false, Guid.Empty);
		}

		protected JwtSecurityToken GenerateJwtToken(Webuser userLoggedIn)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, userLoggedIn.Username),
				new Claim(JwtRegisteredClaimNames.Sid, userLoggedIn.Id.ToString()),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(issuer,
				issuer,
				claims,
				expires: DateTime.UtcNow.AddMinutes(60),
				signingCredentials: creds);
			return token;
		}
	}
}
