using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Survip.DataLayer;
using Survip.Models.SecurityManagement;

namespace Survip.ServiceLayer.Services
{
  public class AuthentificationService : BaseService
  {
    private readonly string issuer;
    private readonly string secretKey;

    public AuthentificationService(ManagementContext context, string issuer, string packageName) : base(context)
    {
      this.issuer = issuer;
      secretKey = context.AccessSecretKeys.SingleOrDefault(access => access.ApplicationName == packageName)?.RandomKey;
    }

    public (AccessToken token, Webuser user) Login(string username, string password)
    {
      var userFound = Context.Webusers.FirstOrDefault(user => user.Username == username && user.Password == password && user.IsActive);
      if (userFound != null)
      {
        var token = GenerateJwtToken(userFound);
        var accessToken = new AccessToken { TokenForAccess = token.ToString(), CreatedOn = DateTime.Now, ExpiresIn = 60, IdWebuser = userFound.Id };
        Context.Add(accessToken);
        Context.SaveChanges();
        return (accessToken, userFound);
      }

      return (null, null);
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
