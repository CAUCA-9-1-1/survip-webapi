using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingParticularRiskFactory
    {
        public static Models.Buildings.Base.BuildingParticularRisk GetRisk(ParticularRiskType riskType)
        {
            switch (riskType)
            {
                case ParticularRiskType.Floor:
                    return new BuildingFloorParticularRisk();
                case ParticularRiskType.Foundation:
                    return new BuildingFoundationParticularRisk();
                case ParticularRiskType.Roof:
                    return new BuildingRoofParticularRisk();
                case ParticularRiskType.Wall:
                    return new BuildingWallParticularRisk();
                default:
                    return null;
            }
        }
    }
}