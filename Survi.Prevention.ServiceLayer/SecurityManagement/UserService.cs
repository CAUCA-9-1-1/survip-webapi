using Cause.SecurityManagement;
using Cause.SecurityManagement.Services;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SecurityManagement
{
	public class UserService : UserManagementService<User>
	{
		private IManagementContext context;

		public UserService(IManagementContext context, ISecurityContext<User> securityContext) : base(securityContext)
		{
			this.context = context;
		}

		public List<User> GetAllUsersWithInfo()
		{
			return SecurityContext.Users.Where(c => c.IsActive)
				.Include(u => u.UserFireSafetyDepartments)
				.Include(u => u.Groups)
				.Include(u => u.Permissions)
				.ToList();
		}

		public string GetUserName(Guid userId)
		{
			return SecurityContext.Users.First(c => c.Id == userId)?.UserName;
		}

		public void UpdateUserFireSafetyDepartment(List<UserFireSafetyDepartment> userFireSafetyDepartments, Guid userId)
		{
			if (userFireSafetyDepartments == null)
				return;

			var dbUserFireSafetyDepartments = context.UserFireSafetyDepartments.AsNoTracking().Where(uf => uf.UserId == userId).ToList();

			RemoveCurrentFireSafetyDepartments(userFireSafetyDepartments, dbUserFireSafetyDepartments);
			AddNewUserFireSafetyDepartments(userFireSafetyDepartments);

			context.SaveChanges();
		}

		public List<Guid> GetUserFireSafetyDepartments(Guid currentUserId)
		{
			return context.UserFireSafetyDepartments.Where(c => c.UserId == currentUserId)
				.Select(c => Guid.Parse(c.FireSafetyDepartmentId)).ToList();
		}

		public List<WebuserForWeb> GetWebUsersByAllowedFireSafetyDepartments(Guid currentUserId)
		{
			var allowedDepartments = GetUserFireSafetyDepartments(currentUserId);
			var usersForDepartment = context.UserFireSafetyDepartments
				.Where(c => allowedDepartments.Contains(Guid.Parse(c.FireSafetyDepartmentId))).Select(c => c.UserId).ToList();
			return SecurityContext.Users.Where(c => usersForDepartment.Contains(c.Id)).Select(c => new WebuserForWeb()
			{
				Id = c.Id,
				Name = (c.FirstName ?? "") + " " + (c.LastName ?? "")
			}).ToList();
		}

		private void AddNewUserFireSafetyDepartments(List<UserFireSafetyDepartment> userFireSafetyDepartments)
		{
			userFireSafetyDepartments.ForEach(userFireSafetyDepartment =>
			{
				var isExistRecord = context.UserFireSafetyDepartments.AsNoTracking().Any(u => u.Id == userFireSafetyDepartment.Id);

				if (!isExistRecord)
					context.UserFireSafetyDepartments.Add(userFireSafetyDepartment);
			});
		}

		private void RemoveCurrentFireSafetyDepartments(List<UserFireSafetyDepartment> userFireSafetyDepartments, List<UserFireSafetyDepartment> dbUserFireSafetyDepartments)
		{
			dbUserFireSafetyDepartments.ForEach(userFireSafetyDepartment =>
			{
				if (userFireSafetyDepartments.All(u => u.Id != userFireSafetyDepartment.Id))
					context.UserFireSafetyDepartments.Remove(userFireSafetyDepartment);
			});
		}
	}
}
