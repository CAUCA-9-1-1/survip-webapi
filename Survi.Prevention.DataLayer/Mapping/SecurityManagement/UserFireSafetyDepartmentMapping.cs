using Cause.Core.DataLayerExtensions.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Security;

namespace Survi.Prevention.DataLayer.Mapping.SecurityManagement
{
	public class UserFireSafetyDepartmentMapping : EntityMappingConfiguration<UserFireSafetyDepartment>
	{
		public override void Map(EntityTypeBuilder<UserFireSafetyDepartment> entity)
		{
            entity.HasKey(m => m.Id);
		}
	}
}
