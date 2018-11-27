namespace Survi.Prevention.ApiClient.Configurations
{
    public class LoginResult
    {
        public string AuthorizationType { get; set; }
        public string TokenForAccess { get; set; }
        public string RefreshToken { get; set; }
        /*public string IdWeb
        token.ExpiresIn,
        AccessToken = token.TokenForAccess,
        token.RefreshToken,
        IdWebuser = user.Id,
        LastName = user.Attributes.Where(a => a.AttributeName=="last_name").Select(a => a.AttributeValue).FirstOrDefault() ?? "",
        FirstName = user.Attributes.Where(a => a.AttributeName == "first_name").Select(a => a.AttributeValue).FirstOrDefault() ?? "",*/
    }
}
