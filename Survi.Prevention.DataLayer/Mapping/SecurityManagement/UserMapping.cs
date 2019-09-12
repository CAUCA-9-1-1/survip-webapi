using Cause.SecurityManagement.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Security;

namespace Survi.Prevention.DataLayer.Mapping.SecurityManagement
{
	public class UserMapping : UserMapping<User>
	{
		public override void Map(EntityTypeBuilder<User> model)
		{
			base.Map(model);
			model.HasMany(m => m.UserFireSafetyDepartments)
				.WithOne()
				.HasForeignKey(m => m.UserId);

			model.HasMany(m => m.Groups)
				.WithOne()
				.HasForeignKey(m => m.IdUser);
		}
	}
}
