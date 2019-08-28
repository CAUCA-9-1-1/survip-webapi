using System;
using System.Collections.Generic;
using System.Text;
using Cause.Core.DataLayerExtensions.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Security;

namespace Survi.Prevention.DataLayer.Mapping.SecurityManagement
{
	public class UserFireSafetyDepartmentMapping : EntityMappingConfiguration<UserFireSafetyDepartment>
	{
		public override void Map(EntityTypeBuilder<UserFireSafetyDepartment> entity)
		{
			entity.ToTable("tbl_user_fire_safety_department");
			entity.HasKey(m => m.Id);
			entity.Property(m => m.Id).HasColumnName("id");
			entity.Property(m => m.FireSafetyDepartmentId).HasColumnName("fire_safety_department_id");
			entity.Property(m => m.UserId).HasColumnName("user_id");
		}
	}
}
