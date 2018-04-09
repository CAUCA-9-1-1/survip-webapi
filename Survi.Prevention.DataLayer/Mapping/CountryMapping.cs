using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountryMapping : EntityMappingConfiguration<Country>
	{
		public override void Map(EntityTypeBuilder<Country> b)
		{
			b.ToTable("tbl_country").HasKey(m => m.Id);

			b.Property(m => m.CodeAlpha2).HasColumnName("code_alpha2").HasMaxLength(2).IsRequired();
			b.Property(m => m.CodeAlpha3).HasColumnName("code_alpha3").HasMaxLength(3).IsRequired();
			b.Property(m => m.Id).HasColumnName("id_country");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.States).WithOne(m => m.Country).HasForeignKey(m => m.IdCountry);
		}
	}

	public class AlarmPanelTypeMapping : EntityMappingConfiguration<AlarmPanelType>
	{
		public override void Map(EntityTypeBuilder<AlarmPanelType> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}

	public class ConstructionTypeMapping : EntityMappingConfiguration<ConstructionType>
	{
		public override void Map(EntityTypeBuilder<ConstructionType> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}

	public class BatchMapping : EntityMappingConfiguration<Batch>
	{
		public override void Map(EntityTypeBuilder<Batch> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.IdWebuserCreatedBy);
			b.HasMany(m => m.Users).WithOne(m => m.Batch).HasForeignKey(m => m.IdBatch);
			b.HasMany(m => m.Inspections).WithOne(m => m.Batch).HasForeignKey(m => m.IdBatch);
		}
	}

	public class BatchUserMapping : EntityMappingConfiguration<BatchUser>
	{
		public override void Map(EntityTypeBuilder<BatchUser> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.User).WithMany().HasForeignKey(m => m.IdWebuser);
		}
	}

	public class InspectionMapping : EntityMappingConfiguration<Inspection>
	{
		public override void Map(EntityTypeBuilder<Inspection> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();

			b.HasOne(m => m.Survey).WithMany().HasForeignKey(m => m.IdSurvey);
			b.HasOne(m => m.Form).WithMany().HasForeignKey(m => m.IdInterventionForm);
			b.HasOne(m => m.InspectedBy).WithMany().HasForeignKey(m => m.IdWebuserInspectedBy);
			b.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.IdWebuserCreatedBy);
			b.HasOne(m => m.AssignedTo).WithMany().HasForeignKey(m => m.IdWebUserAssignedTo);
			b.HasMany(m => m.Answers).WithOne(m => m.Inspection).HasForeignKey(m => m.IdInspection);
		}
	}

	public class InspectionAnswerMapping : EntityMappingConfiguration<InspectionAnswer>
	{
		public override void Map(EntityTypeBuilder<InspectionAnswer> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.AnsweredBy).WithMany().HasForeignKey(m => m.IdWebuserAnsweredBy);
			b.HasMany(m => m.SurveyAnswers).WithOne(m => m.InspectionAnswer).HasForeignKey(m => m.IdInspectionAnswer);
		}
	}

	public class InspectionQuestionMappping : EntityMappingConfiguration<InspectionQuestion>
	{
		public override void Map(EntityTypeBuilder<InspectionQuestion> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Answer).HasMaxLength(200).IsRequired();
			b.HasOne(m => m.Question).WithMany().HasForeignKey(m => m.IdSurveyQuestion);
			b.HasOne(m => m.Choice).WithMany().HasForeignKey(m => m.IdSurveyQuestionChoice);
		}
	}

	public class InterventionFormMapping : EntityMappingConfiguration<BatchUser>
	{
		public override void Map(EntityTypeBuilder<BatchUser> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.User).WithMany().HasForeignKey(m => m.IdWebuser);
		}
	}

	public class InterventionFormBuildingMapping : EntityMappingConfiguration<InterventionFormBuilding>
	{
		public override void Map(EntityTypeBuilder<InterventionFormBuilding> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.AdditionalInformation).HasMaxLength(500).IsRequired();
			b.Property(m => m.SprinklerFloor).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerSector).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerType).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerWall).HasMaxLength(50).IsRequired();
			b.Property(m => m.PipelineLocation).HasMaxLength(200).IsRequired();
			b.Property(m => m.AlarmPanelFloor).HasMaxLength(50).IsRequired();
			b.Property(m => m.AlarmPanelWall).HasMaxLength(50).IsRequired();
			b.Property(m => m.AlarmPanelSector).HasMaxLength(50).IsRequired();
			b.Property(m => m.BuildingPlanNumber).HasMaxLength(50).IsRequired();

			b.HasOne(m => m.Building).WithMany().HasForeignKey(m => m.IdBuilding);
			b.HasOne(m => m.HeightUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureHeight);
			b.HasOne(m => m.EstimatedWaterFlowUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureEstimatedWaterFlow);
			b.HasOne(m => m.ConstructionType).WithMany().HasForeignKey(m => m.IdConstructionType);
			b.HasOne(m => m.JoistConstructionType).WithMany().HasForeignKey(m => m.IdConstructionTypeForJoist);
			b.HasOne(m => m.AlarmPanelType).WithMany().HasForeignKey(m => m.IdAlarmPanelType);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture);
		}
	}

	public class InterventionFormCourseMapping : EntityMappingConfiguration<InterventionFormCourse>
	{
		public override void Map(EntityTypeBuilder<InterventionFormCourse> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdInterventionFormCourse);
		}
	}

	public class InterventionFormCourseLaneMapping : EntityMappingConfiguration<InterventionFormCourseLane>
	{
		public override void Map(EntityTypeBuilder<InterventionFormCourseLane> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}

	public class InterventionFormFireHydrantMapping : EntityMappingConfiguration<InterventionFormFireHydrant>
	{
		public override void Map(EntityTypeBuilder<InterventionFormFireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}