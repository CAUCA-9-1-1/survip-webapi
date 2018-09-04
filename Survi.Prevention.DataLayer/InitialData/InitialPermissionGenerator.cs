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

		    var urlInspetionDashboard = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès au tableau de bord", FeatureName = "url-inspection-dashboard", DefaultValue = true};
		    var urlStatistics = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès aux statistiques", FeatureName = "url-statistics" };
		    var urlReportConfiguration = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion des rapports", FeatureName = "url-report-configuration" };
		    var urlManagementSystem = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion système", FeatureName = "url-management-system" };
		    var urlManagementSystemType = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion des types du système", FeatureName = "url-management-typesystem" };
		    var urlManagementSurvey = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion des questionnaires", FeatureName = "url-management-survey" };
		    var urlManagementAddress = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion des villes", FeatureName = "url-management-address" };
		    var urlManagementDepartment = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès à la gestion du SSI", FeatureName = "url-management-department" };
		    var rightMobile = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Accès au mobile", FeatureName = "RightMobile", DefaultValue = true};
		    var rightApproveInspection = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Acception des inspections", FeatureName = "RightApproveInspection" };
		    var rightBatchManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des lots", FeatureName = "RightBatchManagement" };
		    var rightFireStationManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des casernes", FeatureName = "RightFireStationManagement" };
		    var rightLaneManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des voies", FeatureName = "RightLaneManagement" };
		    var rightBuildingManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des bâtiments", FeatureName = "RightBuildingManagement" };
		    var rightPermissionManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des permissions", FeatureName = "RightPermissionManagement" };
		    var rightUserManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des utilisateurs", FeatureName = "RightUserManagement" };
		    var rightFireHydrantTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des types de borne", FeatureName = "RightFireHydrantTypeManagement" };
		    var rightConnectionTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des types de connexion", FeatureName = "RightConnectionTypeManagement" };
		    var rightOperatorManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des opérateurs", FeatureName = "RightOperatorManagement" };
		    var rightUnitManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des unités de mesure", FeatureName = "RightUnitManagement" };
		    var rightCountyManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des comtés", FeatureName = "RightCountyManagement" };
		    var rightRegionManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des régions", FeatureName = "RightRegionManagement" };
		    var rightStateManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des provinces/états", FeatureName = "RightStateManagement" };
		    var rightCountryManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des pays", FeatureName = "RightCountryManagement" };
		    var rightCityTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des types de ville", FeatureName = "RightCityTypeManagement" };
		    var rightCityManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des villes", FeatureName = "RightCityManagement" };
		    var rightRiskLevelManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des niveaux de risque", FeatureName = "RightRiskLevelManagement" };
		    var rightUtilisationCodeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des codes d'utilisation", FeatureName = "RightUtilisationCodeManagement" };
		    var rightRpaTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des types de PNAPs", FeatureName = "RightRPATypeManagement" };
		    var rightHazardousMaterialManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des matières dangereuses", FeatureName = "RightHazardousMaterialManagement" };
		    var rightDepartmentRiskLevel = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des niveaux de risque par SSI", FeatureName = "RightDepartmentRiskLevel" };
		    var rightDepartmentManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des SSI", FeatureName = "RightDepartmentManagement" };
		    var rightFireHydrantManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), Description = "Gestion des bornes", FeatureName = "RightFireHydrantManagement" };

		    var adminObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Administration" };
			var firemanObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Pompier" };
			var webuserObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), ObjectTable = "webuser", GenericId = adminUserId.ToString(), IsGroup = false, GroupName = "", IdPermissionObjectParent = adminObject.Id };

		    var permission1 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlStatistics.Id, Access = true};
		    var permission2 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlReportConfiguration.Id, Access = true };
		    var permission3 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSystem.Id, Access = true };
		    var permission4 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSystemType.Id, Access = true };
		    var permission5 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSurvey.Id, Access = true };
		    var permission6 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = urlManagementAddress.Id, Access = true };
		    var permission7 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = urlManagementDepartment.Id, Access = true };
		    var permission8 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightApproveInspection.Id, Access = true };
		    var permission9 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightBatchManagement.Id, Access = true };
		    var permission10 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightFireStationManagement.Id, Access = true };
		    var permission11 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightLaneManagement.Id, Access = true };
		    var permission12 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightBuildingManagement.Id, Access = true };
		    var permission13 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightPermissionManagement.Id, Access = true };
		    var permission14 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightUserManagement.Id, Access = true };
		    var permission15 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightFireHydrantTypeManagement.Id, Access = true };
		    var permission16 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightConnectionTypeManagement.Id, Access = true };
		    var permission17 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightOperatorManagement.Id, Access = true };
		    var permission18 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightUnitManagement.Id, Access = true };
		    var permission19 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightCountyManagement.Id, Access = true };
		    var permission20 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightRegionManagement.Id, Access = true };
		    var permission21 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightStateManagement.Id, Access = true };
		    var permission22 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightCountryManagement.Id, Access = true };
		    var permission23 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightCityTypeManagement.Id, Access = true };
		    var permission24 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightCityManagement.Id, Access = true };
		    var permission25 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightRiskLevelManagement.Id, Access = true };
		    var permission26 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightUtilisationCodeManagement.Id, Access = true };
		    var permission27 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightRpaTypeManagement.Id, Access = true };
		    var permission28 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightHazardousMaterialManagement.Id, Access = true };
		    var permission29 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightDepartmentRiskLevel.Id, Access = true };
		    var permission30 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightDepartmentManagement.Id, Access = true };
		    var permission31 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightFireHydrantManagement.Id, Access = true };

		    builder.Entity<PermissionSystem>().HasData(permissionSystem);
		    builder.Entity<PermissionSystemFeature>().HasData(
					urlInspetionDashboard, urlStatistics, urlReportConfiguration, urlManagementSystem, urlManagementSystemType, urlManagementSurvey, urlManagementAddress, urlManagementDepartment, rightMobile,
					rightApproveInspection, rightBatchManagement, rightFireStationManagement, rightLaneManagement, rightBuildingManagement, rightPermissionManagement, rightUserManagement, rightFireHydrantTypeManagement,
					rightConnectionTypeManagement, rightOperatorManagement, rightUnitManagement, rightCountyManagement, rightRegionManagement, rightStateManagement, rightCountryManagement, rightCityTypeManagement,
					rightCityManagement, rightRiskLevelManagement, rightUtilisationCodeManagement, rightRpaTypeManagement, rightHazardousMaterialManagement, rightDepartmentRiskLevel, rightDepartmentManagement,
					rightFireHydrantManagement
			    );
		    builder.Entity<PermissionObject>().HasData(adminObject, firemanObject, webuserObject);
		    builder.Entity<Permission>().HasData(
					permission1, permission2, permission3, permission4, permission5, permission6, permission7, permission8, permission9, permission10, permission11, permission12, permission13, permission14, permission15,
					permission16, permission17, permission18, permission19, permission20, permission21, permission22, permission23, permission24, permission25, permission26, permission27, permission28, permission29,
					permission30, permission31
			    );
	    }
    }
}
