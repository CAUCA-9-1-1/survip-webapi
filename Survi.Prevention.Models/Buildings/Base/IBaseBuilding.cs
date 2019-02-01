using System;
using NetTopologySuite.Geometries;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings.Base
{
    public interface IBaseBuilding : IBaseModel
    {
        string AppartmentNumber { get; set; }
        decimal BuildingValue { get; set; }
        BuildingChildType ChildType { get; set; }
        City City { get; set; }
        string CivicLetter { get; set; }
        string CivicLetterSupp { get; set; }
        string CivicNumber { get; set; }
        string CivicSupp { get; set; }
        string Coordinates { get; set; }
        string CoordinatesSource { get; set; }
        string Details { get; set; }
        string Floor { get; set; }
        Guid IdCity { get; set; }
        Guid IdLane { get; set; }
        Guid? IdLaneTransversal { get; set; }
        Guid? IdParentBuilding { get; set; }
        Guid? IdPicture { get; set; }
        Guid IdRiskLevel { get; set; }
        Guid? IdUtilisationCode { get; set; }
        Lane Lane { get; set; }
        string Matricule { get; set; }
        int NumberOfAppartment { get; set; }
        int NumberOfBuilding { get; set; }
        int NumberOfFloor { get; set; }
        Point PointCoordinates { get; set; }
        string PostalCode { get; set; }
        RiskLevel RiskLevel { get; set; }
        bool ShowInResources { get; set; }
        string Source { get; set; }
        int Suite { get; set; }
        Lane Transversal { get; set; }
        UtilisationCode UtilisationCode { get; set; }
        string UtilisationDescription { get; set; }
        bool VacantLand { get; set; }
        int YearOfConstruction { get; set; }
    }
}