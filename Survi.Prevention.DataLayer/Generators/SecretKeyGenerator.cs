using System;
using System.Security.Cryptography;
using System.Text;

namespace Survi.Prevention.DataLayer.Generators
{
  public class SecretKeyGenerator
  {
    public static (string randomKey, string secretKey) GenerateSecretKey(string packageName)
    {
      var randomKey = GenerateRandomKey();
      var secretKey = $"{packageName}-{randomKey}";
      return (randomKey, GetSecretKey(secretKey));
    }

    private static string GenerateRandomKey()
    {
      var rand = new Random();
      var b = new byte[256 / 8];
      rand.NextBytes(b);

      return string.Concat(b);
    }

    private static string GetSecretKey(string secretKey)
    {
      return sha256_hash(secretKey);
    }

    private static string sha256_hash(string value)
    {
      var sb = new StringBuilder();

      using (var hash = SHA256.Create())
      {
        var encoding = Encoding.UTF8;
        var result = hash.ComputeHash(encoding.GetBytes(value));

        foreach (var b in result)
          sb.Append(b.ToString("x2"));
      }
      return sb.ToString();
    }
  }
}
