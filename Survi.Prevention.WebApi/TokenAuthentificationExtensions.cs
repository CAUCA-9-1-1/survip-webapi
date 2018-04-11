using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Survi.Prevention.WebApi
{
	public static class TokenAuthentificationExtensions
	{
		public static IServiceCollection AddTokenAuthentification(this IServiceCollection services, IConfiguration configuration)
		{
			var secretKey = configuration.GetSection("APIConfig:SecretKey").Value;
			var issuer = configuration.GetSection("APIConfig:Issuer").Value;
			var appName = configuration.GetSection("APIConfig:PackageName").Value;

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(config =>
			{
				config.RequireHttpsMetadata = false;
				config.SaveToken = true;
				config.TokenValidationParameters = GetAuthentificationParameters(secretKey, issuer, appName);				
			});
			return services;
		}

		private static TokenValidationParameters GetAuthentificationParameters(string secretKey, string issuer, string appName)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
				ValidateIssuer = true,
				ValidIssuer = issuer,
				ValidateAudience = true,
				ValidAudience = appName,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
			return tokenValidationParameters;
		}
	}
}