using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Survi.Prevention.WebApi
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.CustomSchemaIds(x=>x.FullName);
				c.OrderActionsBy(action => action.RelativePath);
				c.SwaggerDoc("v1", new Info { Title = "SURVI Prevention", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = "header",
					Type = "apiKey",
				});
			    c.CustomOperationIds(apiDesc => null);
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					{"Bearer", new string[]{}}
				});
			});
			return services;
		}

		public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "SURVI Prevention v1");
				c.RoutePrefix = "docs";
			});
			return app;
		}
	}
}