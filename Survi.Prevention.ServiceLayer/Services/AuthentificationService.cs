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



			var inspectionId = Guid.Parse("18b4a850-25e2-41f2-93cd-087bb2951f63");
			var report = new ReportDataLoaderService(Context);
			var template = @"
[Building]
Contacts:
	[Contact]
		Nom: {{FirstName}} {{LastName}}.  Proprio? {{IsOwner}}
	[/Contact]
Sprinklers:
	[Sprinkler]
		Type: {{TypeName}}.  Étage: {{Floor}}.  Mur: {{Wall}} etc.
	[/Sprinkler]
Panneaux d'alarme:
	[AlarmPanel]
		Type: {{TypeName}}.  Étage: {{Floor}}.  Mur: {{Wall}} etc.
	[/AlarmPanel]
PNAPs:
	[PersonRequiringAssistance]
		Type: {{TypeName}}.
	[/PersonRequiringAssistance]
Bornes:
	[FireHydrant]
		{{Number}} : {{Address}}
	[/FireHydrant]
	[Course]
		Caserne: {{Description}}
		[CourseLane]
			{{Description}}
		[/CourseLane]
	[/Course]
	[HazardousMaterial]
		{{HazardousMaterialNumber}} - {{HazardousMaterialName}}
		{{QuantityDescription}}
	[/HazardousMaterial]
	[Anomaly]
		Theme: {{Theme}}
		Notes: {{Notes}}
		[AnomalyPicture]
			Photo: {{PictureData}}
		[/AnomalyPicture]
	[/Anomaly]
	[ParticularRisk]
		Type: {{TypeName}}
		Ouverture: {{HasOpening}}
		Affaibli: {{IsWeakened}}
		Commentaire: {{Comments}}
		[ParticularRiskPicture]
			Photo: {{PictureData}}
		[/ParticularRiskPicture]
	[/ParticularRisk]
[/Building]";
			var filledTemplate = report.FillTemplate(template, inspectionId, "fr");




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
			var webuserToken = Context.AccessTokens.Include(t => t.User)
				.FirstOrDefault(t => t.IdWebuser == webuserId && t.RefreshToken == refreshToken);

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
	}
}
