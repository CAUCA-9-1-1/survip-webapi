using System;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.InitialData
{
    internal class InitialPermissionGenerator
    {
	    private static readonly DateTime Now = new DateTime(2018, 6, 1);
	    internal static void SeedInitialData(ModelBuilder builder, Guid adminUserId)
	    {
		    var permissionSystem = new PermissionSystem {Description = "SURVI-Prevention", Id = GuidExtensions.GetGuid()};

			var surveyFeature = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Voir la section questionnaire du site", FeatureName = "RightSectionSurvey" };
		    var managementFeature = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Voir la section gestion du site", FeatureName = "RightSectionManagement" };
		    var inspectionFeature = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Voir la section inspection du site", FeatureName = "RightSectionInspection" };
		    var adminFeature = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès en administration", FeatureName = "RightAdmin" };
		    var tpiFeature = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès pour un TPI", FeatureName = "RightTPI" };

		    var adminObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Administration" };
		    var tpiObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "TPI" };
			var firemanObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Pompier" };
			var webuserObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "webuser", GenericId = adminUserId.ToString(), IsGroup = false, GroupName = "", IdPermissionObjectParent = adminObject.Id };

		    var permission1 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = inspectionFeature.Id, Access = true};
		    var permission2 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = surveyFeature.Id, Access = true };
		    var permission3 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = adminFeature.Id, Access = true };
		    var permission4 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = managementFeature.Id, Access = true };
		    var permission5 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = tpiFeature.Id, Access = true };
		    var permission6 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = tpiObject.Id, IdPermissionSystemFeature = inspectionFeature.Id, Access = true };
		    var permission7 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = tpiObject.Id, IdPermissionSystemFeature = surveyFeature.Id, Access = true };
		    var permission8 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = inspectionFeature.Id, Access = true };

		    builder.Entity<PermissionSystem>().HasData(permissionSystem);
		    builder.Entity<PermissionSystemFeature>().HasData(surveyFeature, managementFeature, inspectionFeature, adminFeature, tpiFeature);
		    builder.Entity<PermissionObject>().HasData(adminObject, tpiObject, firemanObject, webuserObject);
		    builder.Entity<Permission>().HasData(permission1, permission2, permission3, permission4, permission5, permission6, permission7, permission8);
	    }
    }
}
