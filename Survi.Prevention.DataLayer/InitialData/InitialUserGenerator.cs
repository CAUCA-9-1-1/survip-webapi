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
				CreatedOn = new DateTime(2018, 6, 1),
			};

			var attributes = new []
			{
				new WebuserAttributes {Id = Guid.Parse("f90d28fd-4069-4c6a-af1c-fc08f416a1fe"), IdWebuser = user.Id, AttributeName = "last_name", AttributeValue = "Cauca"},
				new WebuserAttributes {Id = Guid.Parse("aa8b3277-1717-456e-bafb-e5752dcc5e12"), IdWebuser = user.Id,AttributeName = "reset_password", AttributeValue = "false"},
				new WebuserAttributes {Id = Guid.Parse("4c55d7dd-ee76-473b-be0d-4d8ec7cb3e10"), IdWebuser = user.Id,AttributeName = "first_name", AttributeValue = "Admin"},
			};

			builder.Entity<Webuser>().HasData(user);
			builder.Entity<WebuserAttributes>().HasData(attributes);
		}
	}
}