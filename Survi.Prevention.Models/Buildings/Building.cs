using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
  public class Building : BaseModel
  {
    public string CivicNumber { get; set; }
    public string CivicLetter { get; set; }
    public string CivicSupp { get; set; }
    public string CivicLetterSupp { get; set; }
    public string AppartmentNumber { get; set; }
    public string Floor { get; set; }
    public int NumberOfFloor { get; set; }
    public int NumberOfAppartment { get; set; }
    public int NumberOfBuilding { get; set; }
    public bool VacantLand { get; set; }
    public int YearOfConstruction { get; set; }
    public decimal BuildingValue { get; set; }
    public string PostalCode { get; set; }
    public int Suite { get; set; }
    public string Source { get; set; }
    public bool IsParent { get; set; }
    public string UtilisationDescription { get; set; }
    public bool ShowInResources { get; set; }
    public string Matricule { get; set; }
    public object Coordinates { get; set; }
    public string CoordinatesSource { get; set; }
    public string Details { get; set; }

    public Guid IdLane { get; set; }
    public Guid IdUtilisationCode { get; set; }
    public Guid IdSector { get; set; }
    public Guid IdMutualAidSector { get; set; }
    public Guid IdJawsExtricationSector { get; set; }
    public Guid IdSledSector { get; set; }
    public Guid IdRiskLevel { get; set; }
    public Guid IdResourceCategory { get; set; }
    public Guid IdAssociationBuilding { get; set; }
    public Guid IdAssociationType { get; set; }
    public Guid IdUnitType { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
