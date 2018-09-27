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
		    var permissionSystem = new PermissionSystem {Description = "SURVI-Prevention", Id = Guid.Parse("4c0b5365-c308-4bb6-b412-36b22eea59a4") };

		    var urlInspetionDashboard = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), Description = "Accès au tableau de bord", FeatureName = "url-inspection-dashboard", DefaultValue = true};
		    var urlStatistics = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("4b920789-e3bf-4b8c-a1fe-a09128e30843"), Description = "Accès aux statistiques", FeatureName = "url-statistics" };
		    var urlReportConfiguration = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), Description = "Accès à la gestion des rapports", FeatureName = "url-report-configuration" };
		    var urlManagementSystem = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), Description = "Accès à la gestion système", FeatureName = "url-management-system" };
		    var urlManagementSystemType = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("05d57316-7b0a-4195-bfdb-796262d4128a"), Description = "Accès à la gestion des types du système", FeatureName = "url-management-typesystem" };
		    var urlManagementSurvey = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("1f350fa7-60a5-4b8c-9696-d2331545012d"), Description = "Accès à la gestion des questionnaires", FeatureName = "url-management-survey" };
		    var urlManagementAddress = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), Description = "Accès à la gestion des villes", FeatureName = "url-management-address" };
		    var urlManagementDepartment = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("b104208c-f7a9-4f70-b414-5352b55fb7c4"), Description = "Accès à la gestion du SSI", FeatureName = "url-management-department" };
		    var rightMobile = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), Description = "Accès au mobile", FeatureName = "RightMobile", DefaultValue = true};
		    var rightApproveInspection = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("aa163670-487c-461e-8112-9bf98070f5b3"), Description = "Acception des inspections", FeatureName = "RightApproveInspection" };
		    var rightBatchManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("c4237a41-fbf3-481b-aa18-a7e469331c43"), Description = "Gestion des lots", FeatureName = "RightBatchManagement" };
		    var rightFireStationManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), Description = "Gestion des casernes", FeatureName = "RightFireStationManagement" };
		    var rightLaneManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("0615bbba-ae42-472b-b768-227b80efd4f1"), Description = "Gestion des voies", FeatureName = "RightLaneManagement" };
		    var rightBuildingManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("98075263-e986-4823-aa11-cfca837adcbc"), Description = "Gestion des bâtiments", FeatureName = "RightBuildingManagement" };
		    var rightPermissionManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), Description = "Gestion des permissions", FeatureName = "RightPermissionManagement" };
		    var rightUserManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("89dbc380-186b-440c-a069-bd42d0664ed8"), Description = "Gestion des utilisateurs", FeatureName = "RightUserManagement" };
		    var rightFireHydrantTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("314b0c77-b8e7-411c-9002-3a56a54f6749"), Description = "Gestion des types de borne", FeatureName = "RightFireHydrantTypeManagement" };
		    var rightConnectionTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("1864a414-64a3-4f67-9556-059ad9c5a672"), Description = "Gestion des types de connexion", FeatureName = "RightConnectionTypeManagement" };
		    var rightOperatorManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("b38a094f-b0a6-494b-9104-009d30199cbf"), Description = "Gestion des opérateurs", FeatureName = "RightOperatorManagement" };
		    var rightUnitManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("78b19b2a-f31b-4027-8b92-105a0ac44282"), Description = "Gestion des unités de mesure", FeatureName = "RightUnitManagement" };
		    var rightCountyManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("d68c1911-e063-4b22-a635-413004d3bd60"), Description = "Gestion des comtés", FeatureName = "RightCountyManagement" };
		    var rightRegionManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("62982bdc-2ae9-407b-9396-01bfb3c50d23"), Description = "Gestion des régions", FeatureName = "RightRegionManagement" };
		    var rightStateManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("193ab58d-0a0f-48d5-bb65-6a2d67db58c4"), Description = "Gestion des provinces/états", FeatureName = "RightStateManagement" };
		    var rightCountryManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("08dfbdb1-6cf4-449b-85e3-8134de4ed052"), Description = "Gestion des pays", FeatureName = "RightCountryManagement" };
		    var rightCityTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("8a9896a5-0ab5-4c33-a01f-7e97742c9570"), Description = "Gestion des types de ville", FeatureName = "RightCityTypeManagement" };
		    var rightCityManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd"), Description = "Gestion des villes", FeatureName = "RightCityManagement" };
		    var rightRiskLevelManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("2dfaae63-39a2-471c-9a42-705cba52c565"), Description = "Gestion des niveaux de risque", FeatureName = "RightRiskLevelManagement" };
		    var rightUtilisationCodeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("4e5be439-7249-4f7c-b9c1-e0a448046c57"), Description = "Gestion des codes d'utilisation", FeatureName = "RightUtilisationCodeManagement" };
		    var rightRpaTypeManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("6da8395e-4057-415c-9710-ea098fdf2e9e"), Description = "Gestion des types de PNAPs", FeatureName = "RightRPATypeManagement" };
		    var rightHazardousMaterialManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("e8c4cc98-7e17-450b-8333-9d87cd8f695a"), Description = "Gestion des matières dangereuses", FeatureName = "RightHazardousMaterialManagement" };
		    var rightDepartmentRiskLevel = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("9898d805-e8ef-4595-a0d2-66d1b022ea86"), Description = "Gestion des niveaux de risque par SSI", FeatureName = "RightDepartmentRiskLevel" };
		    var rightDepartmentManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("26d14cda-d321-4db2-a604-6daaff0483e9"), Description = "Gestion des SSI", FeatureName = "RightDepartmentManagement" };
		    var rightFireHydrantManagement = new PermissionSystemFeature { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), Description = "Gestion des bornes", FeatureName = "RightFireHydrantManagement" };

		    var adminObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("98db62c4-51b1-492e-b616-cfbd3ff53875"), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Administration" };
			var firemanObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), ObjectTable = "group", GenericId = "", IsGroup = true, GroupName = "Pompier" };
			var webuserObject = new PermissionObject { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("e325886d-e950-4067-ad8f-847de181dcd0"), ObjectTable = "webuser", GenericId = adminUserId.ToString(), IsGroup = false, GroupName = "", IdPermissionObjectParent = adminObject.Id };

		    var permission1 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("d2794eb1-aba7-4326-98a8-a1ec1385790f"), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlStatistics.Id, Access = true};
		    var permission2 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("88bbb9fc-0ec9-43b1-a3fd-3ab40efd3122"), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlReportConfiguration.Id, Access = true };
		    var permission3 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("100f6d6e-3320-4b8e-b314-aab14c61d41f"), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSystem.Id, Access = true };
		    var permission4 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("8002ec95-24ba-4c0a-984d-3262031669f6"), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSystemType.Id, Access = true };
		    var permission5 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("7db5bb12-37d0-4587-b8fe-e10c64e22fd8"), CreatedOn = Now, IdPermissionObject = adminObject.Id, IdPermissionSystemFeature = urlManagementSurvey.Id, Access = true };
		      
		    var adminP01 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("1cc19dbd-6cf3-47cb-b718-07340e8cd0b6"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature =urlInspetionDashboard.Id		    		};   		   		    
		    var adminP02 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("b78e99ed-b653-4192-80f4-f1e9d3c6b454"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature =urlManagementAddress.Id				};
			var adminP03 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("66a210e8-4ad6-42e8-96b5-1f54ef91d6f4"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = urlManagementDepartment.Id			};
			var adminP04 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("e0341e26-d2a1-4adb-a2b3-5425dc0c4937"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightMobile.Id						};
			var adminP05 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("3d46a013-93b7-4094-be7a-8c1810ccb7ae"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightApproveInspection.Id				};
			var adminP06 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("e7aa95d5-8ec2-4e2c-972a-a2a903c74c77"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightBatchManagement.Id				};
			var adminP07 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("f11ccda4-779c-4231-8517-815f4938992b"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightFireStationManagement.Id			};
			var adminP08 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("17a95e77-6763-481a-b53d-c4372cb1db62"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightLaneManagement.Id				};
			var adminP09 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("de5c78f3-4123-4807-938a-99e623a55851"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightBuildingManagement.Id			};
			var adminP10 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("54af869b-e07f-4845-b5f9-d12683a9ccf6"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightPermissionManagement.Id			};
			var adminP11 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("7da38ff6-de80-4754-b9f6-aff4d7d89d18"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightUserManagement.Id				};
			var adminP12 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("7f2eea9e-c182-4ea1-996d-97ce53f39254"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightFireHydrantTypeManagement.Id		};
			var adminP13 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("e9ed4961-ed94-4121-b0d5-8de86f708236"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightConnectionTypeManagement.Id		};
			var adminP14 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("f3878fca-4056-453f-80d3-6a2f8004c9a1"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightOperatorManagement.Id			};
			var adminP15 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("f4ec1514-3298-4fd2-b2ed-042d79272ccc"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightUnitManagement.Id				};
			var adminP16 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("35f99f12-af9f-460b-8b27-63be4a326699"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightCountyManagement.Id				};
			var adminP17 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("cb28d006-1d03-4db9-836e-205876d5ba48"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightRegionManagement.Id				};
			var adminP18 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("b35943a3-3b7c-4cc4-af82-8a5c7271f611"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightStateManagement.Id				};
			var adminP19 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("5fe3c4f5-6b71-4c11-97ea-7264ed5c37ee"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightCountryManagement.Id				};
			var adminP20 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("40d5f714-f0cd-4ebd-813d-96c79c724517"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightCityTypeManagement.Id			};
			var adminP21 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("a9fc0734-99ad-4f95-8c49-760ddcba6e62"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightCityManagement.Id				};
			var adminP22 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("53560ea6-e0bd-46d9-bc06-66823d5091f6"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightRiskLevelManagement.Id			};
			var adminP23 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("86f8f414-30fc-4972-9006-37b051117aa2"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightUtilisationCodeManagement.Id		};
			var adminP24 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("8a7ea586-c5ad-4881-869a-90ef73804f8f"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightRpaTypeManagement.Id				};
			var adminP25 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("243272d7-e069-4cef-a377-25e8e7d02e4e"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightHazardousMaterialManagement.Id	};
			var adminP26 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("f131976a-07cd-42bc-8a2c-ee7c8f20e5a9"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightDepartmentRiskLevel.Id			};
			var adminP27 = new Permission { IdPermissionSystem = permissionSystem.Id,Id = Guid.Parse("ce91dc37-a08e-4f4f-863b-f793fc992092"), CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true, IdPermissionSystemFeature = rightDepartmentManagement.Id          };
			var adminP28 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("aee63ddd-b33e-4904-b453-9dde916fce6d"),CreatedOn = Now, IdPermissionObject = adminObject.Id, Access = true,  IdPermissionSystemFeature = rightFireHydrantManagement.Id };

			var permission6 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("82f426ea-9488-4f5e-bab4-0b1e2e43cbff"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = urlManagementAddress.Id, Access = true };
		    var permission7 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("c643389a-3e12-445d-813e-19b0451bdda9"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = urlManagementDepartment.Id, Access = true };
		    var permission8 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("5d5011ec-048a-4ea7-8588-ca7287dbd137"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightApproveInspection.Id, Access = true };
		    var permission9 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("bcbdce89-ab74-44ef-82ca-6e57728fa696"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightBatchManagement.Id, Access = true };
		    var permission11 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("1309a734-a7a2-4b82-a80c-c07b6b7850e5"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightLaneManagement.Id, Access = true };
		    var permission12 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("651a2ccd-10a7-47a6-9d0a-91b81ac19e16"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightBuildingManagement.Id, Access = true };
		    var permission31 = new Permission { IdPermissionSystem = permissionSystem.Id, Id = Guid.Parse("e7441fbb-77e0-424c-bd79-c7e04cd83f34"), CreatedOn = Now, IdPermissionObject = firemanObject.Id, IdPermissionSystemFeature = rightFireHydrantManagement.Id, Access = true };
		
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
					permission1, permission2, permission3, permission4, permission5, permission6, permission7, permission8, permission9, permission11, permission12, permission31,
				adminP01, adminP02, adminP03, adminP04, adminP05, adminP06, adminP07, adminP08, adminP09, adminP10,	adminP11, adminP12, adminP13, adminP14, adminP15,
				adminP16, adminP17, adminP18, adminP19, adminP20, adminP21, adminP22, adminP23, adminP24, adminP25, adminP26, adminP27, adminP28
			    );
	    }
    }
}
