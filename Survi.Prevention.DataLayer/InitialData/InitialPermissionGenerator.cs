using System;
using System.Collections.Generic;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.InitialData
{
    internal class InitialPermissionGenerator
    {
	    internal static IEnumerable<PermissionSystem> GetInitialData(Guid adminUserId)
	    {		    
			var surveyFeature = new PermissionSystemFeature { Description = "Voir la section questionnaire du site", FeatureName = "RightSectionSurvey" };
		    var managementFeature = new PermissionSystemFeature { Description = "Voir la section gestion du site", FeatureName = "RightSectionManagement" };
		    var inspectionFeature = new PermissionSystemFeature { Description = "Voir la section inspection du site", FeatureName = "RightSectionInspection" };
		    var adminFeature = new PermissionSystemFeature { Description = "Accès en administration", FeatureName = "RightAdmin" };
		    var tpiFeature = new PermissionSystemFeature { Description = "Accès pour un TPI", FeatureName = "RightTPI" };

		    var adminObject = new PermissionObject { ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Administration" };
		    var tpiObject = new PermissionObject { ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "TPI" };
			var firemanObject = new PermissionObject { ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Pompier" };
			var webuserObject = new PermissionObject { ObjectTable = "webuser", GenericId = adminUserId.ToString(), IsGroup = false, GroupName = "", Parent = adminObject };

		    var permission1 = new Permission {PermissionObject = adminObject, Feature = inspectionFeature, Access = true};
		    var permission2 = new Permission { PermissionObject = adminObject, Feature = surveyFeature, Access = true };
		    var permission3 = new Permission { PermissionObject = adminObject, Feature = adminFeature, Access = true };
		    var permission4 = new Permission { PermissionObject = adminObject, Feature = managementFeature, Access = true };
		    var permission5 = new Permission { PermissionObject = adminObject, Feature = tpiFeature, Access = true };
		    var permission6 = new Permission { PermissionObject = tpiObject, Feature = inspectionFeature, Access = true };
		    var permission7 = new Permission { PermissionObject = tpiObject, Feature = surveyFeature, Access = true };
		    var permission8 = new Permission { PermissionObject = firemanObject, Feature = inspectionFeature, Access = true };

		    yield return new PermissionSystem {
			    Description = "SURVI-Prevention",
				Features = new List<PermissionSystemFeature> { surveyFeature, managementFeature, inspectionFeature, adminFeature, tpiFeature },
				Objects = new List<PermissionObject> { adminObject, tpiObject, firemanObject, webuserObject },
				Permissions = new List<Permission> { permission1, permission2, permission3, permission4, permission5, permission6, permission7, permission8 }
		    };
		}
    }
}
