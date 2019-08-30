using System;
using System.Collections.Generic;
using System.Text;
using Cause.SecurityManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Survi.Prevention.DataLayer.Mapping.SecurityManagement
{
	public class GroupMapping : Cause.SecurityManagement.Mapping.GroupMapping
	{
		public override void Map(EntityTypeBuilder<Group> model)
		{
			base.Map(model);
			model.HasMany(m => m.Permissions)
				.WithOne(m => m.Group)
				.HasForeignKey(m => m.IdGroup);
		}
	}
}
