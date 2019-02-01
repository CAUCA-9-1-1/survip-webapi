using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public enum ParticularRiskType
	{
		Foundation,
		Floor,
		Wall,
		Roof
	}

    public abstract class BaseBuildingParticularRisk<TBuilding, TRiskPicture, TPicture> : BaseImportedModel
	    where TBuilding : IBaseBuilding
        where TPicture : BasePicture
		where TRiskPicture : BaseBuildingParticularRiskPicture<TPicture>
	{
		public Guid IdBuilding { get; set; }
	    public bool IsWeakened { get; set; }
		public bool HasOpening { get; set; }
	    public string Comments { get; set; } = "";
		public string Wall { get; set; }
		public string Sector { get; set; }
	    public string Dimension { get; set; } = "";

		public TBuilding Building { get; set; }
		public ICollection<TRiskPicture> Pictures { get; set; }
    }
}
