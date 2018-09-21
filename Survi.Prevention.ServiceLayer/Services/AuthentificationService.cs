using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
				var accessToken = GenerateAccessToken(userFound, applicationName, issuer, secretKey);
				var refreshToken = GenerateRefreshToken();				
				var token = new AccessToken {TokenForAccess = accessToken, RefreshToken = refreshToken, ExpiresIn = (int)(TimeSpan.FromHours(9).TotalSeconds), IdWebuser = userFound.Id};
				Context.Add(token);
				Context.SaveChanges();
				return (token, userFound);
			}

			return (null, null);
		}

		public string Refresh(string token, string refreshToken, string applicationName, string issuer, string secretKey)
		{
			var webuserId = GetCallDispatcherIdFromExpiredToken(token, issuer, applicationName, secretKey);
			var webuserToken = GetAccessTokenFromRefreshToken(refreshToken, webuserId);

			if (webuserToken == null)
				throw new SecurityTokenException("Invalid token.");

			if (webuserToken.RefreshToken != refreshToken)
				throw new SecurityTokenValidationException("Invalid token.");

			if (webuserToken.CreatedOn.AddHours(webuserToken.ExpiresIn) < DateTime.Now)
				throw new SecurityTokenExpiredException("Token expired.");

			var newAccessToken = GenerateAccessToken(webuserToken.User, applicationName, issuer, secretKey);
			webuserToken.TokenForAccess = newAccessToken;
			Context.SaveChanges();

			return newAccessToken;
		}

		public AccessToken GetAccessTokenFromRefreshToken(string refreshToken, Guid webuserId)
		{
			var webuserToken = Context.AccessTokens.Include(t => t.User)
				.FirstOrDefault(t => t.IdWebuser == webuserId && t.RefreshToken == refreshToken);
			return webuserToken;
		}

		public AccessToken GetAccessTokenFromAccessToken(string accessToken, Guid webuserId)
		{
			var webuserToken = Context.AccessTokens.Include(t => t.User)
				.FirstOrDefault(t => t.IdWebuser == webuserId && t.TokenForAccess == accessToken);
			return webuserToken;
		}

		private Guid GetCallDispatcherIdFromExpiredToken(string token, string issuer, string appName, string secretKey)
		{
			var principal = GetPrincipalFromExpiredToken(token, issuer, appName, secretKey);
			var id = principal.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value;
			if (Guid.TryParse(id, out Guid callDispatcherId))
				return callDispatcherId;
			return Guid.Empty;
		}

		private ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string issuer, string appName, string secretKey)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
				ValidateIssuer = true,
				ValidIssuer = issuer,
				ValidateAudience = true,
				ValidAudience = appName,
				ValidateLifetime = false,
				ClockSkew = TimeSpan.Zero
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
			if (!(securityToken is JwtSecurityToken jwtSecurityToken)
			    || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException("Invalid token");

			return principal;
		}

		protected string GenerateAccessToken(Webuser userLoggedIn, string applicationName, string issuer, string secretKey)
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

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		public bool IsMobileVersionValid(string mobileVersion, string minimalVersion)
		{
			var mobile = new Version(mobileVersion);
			var minVersion = new Version(minimalVersion);

			if (mobile.CompareTo(minVersion) < 0)
				return false;
			return true;
		}
	}
}
