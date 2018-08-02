using System;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialUserGenerator
	{
		internal static void SeedInitialData(ModelBuilder builder, Guid idUser)
		{
			var user = new Webuser
			{
				Id = idUser,
				Username = "admin",
				Password = "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247",
				CreatedOn = DateTime.Now,
			};

			var attributes = new []
			{
				new WebuserAttributes {Id = GuidExtensions.GetGuid(), IdWebuser = user.Id, AttributeName = "last_name", AttributeValue = "Cauca"},
				new WebuserAttributes {Id = GuidExtensions.GetGuid(), IdWebuser = user.Id,AttributeName = "reset_password", AttributeValue = "false"},
				new WebuserAttributes {Id = GuidExtensions.GetGuid(), IdWebuser = user.Id,AttributeName = "first_name", AttributeValue = "Admin"},
			};

			builder.Entity<Webuser>().HasData(user);
			builder.Entity<WebuserAttributes>().HasData(attributes);
		}
	}
}