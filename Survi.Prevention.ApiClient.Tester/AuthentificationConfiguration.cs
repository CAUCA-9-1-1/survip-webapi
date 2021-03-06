﻿using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Tester
{
	public class AuthentificationConfiguration: IConfiguration
	{
		public string ApiBaseUrl { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string AuthorizationType { get; set; }
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	    public int RequestTimeoutInSeconds { get; set; } = 300;
	    public int RequestBatchSize { get; set; } 
	}
}
