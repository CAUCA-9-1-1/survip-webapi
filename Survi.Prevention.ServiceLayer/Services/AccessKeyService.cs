using System;
using Survi.Prevention.DataLayer;
using Survi.Prevention.DataLayer.Generators;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
  public class AccessKeyService : BaseService
  {
    private readonly string packageName;

    public AccessKeyService(ManagementContext context, string packageName)
     : base(context)
    {
      this.packageName = packageName;
    }

    public AccessSecretKey CreateNewSecretKey(Guid webuserId)
    {
      var secretKey = GenerateAccessSecretKey();
      Context.AccessSecretKeys.Add(secretKey);
      Context.SaveChanges();
      return secretKey;
    }

    private AccessSecretKey GenerateAccessSecretKey()
    {
      var key = SecretKeyGenerator.GenerateSecretKey(packageName);
      return new AccessSecretKey
      {
        ApplicationName = packageName,
        RandomKey = key.randomKey,
        SecretKey = key.secretKey
      };
    }    
  }
}
