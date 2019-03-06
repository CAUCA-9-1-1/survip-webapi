using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using BuildingContact = Survi.Prevention.Models.Buildings.BuildingContact;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class BuildingContactService : BaseCrudServiceWithImportation<BuildingContact, ApiClient.DataTransferObjects.BuildingContact>
    {
        public BuildingContactService(
            IManagementContext context,
            IEntityConverter<ApiClient.DataTransferObjects.BuildingContact, BuildingContact> converter)
            : base(context, converter)
        {
        }

        public override BuildingContact Get(Guid id)
        {
            return Context.BuildingContacts.AsNoTracking()
                .FirstOrDefault(contact => contact.Id == id);
        }

        public List<BuildingContact> GetBuildingContactList(Guid idBuilding)
        {
            var result = Context.BuildingContacts
                .Where(c => c.IdBuilding == idBuilding)
                .ToList();

            return result;
        }

        public List<ApiClient.DataTransferObjects.BuildingContact> Export(List<string> idBuildings)
        {
            var query = (
                from buildingcontact in Context.BuildingContacts.AsNoTracking()
                    .IgnoreQueryFilters()
                where buildingcontact.HasBeenModified &&
                      idBuildings.Contains(buildingcontact.IdBuilding.ToString())
                select new ApiClient.DataTransferObjects.BuildingContact
                {
                    Id = buildingcontact.IdExtern ?? buildingcontact.Id.ToString(),
                    IdBuilding = buildingcontact.Building.IdExtern,
                    CallPriority = buildingcontact.CallPriority,
                    CellphoneNumber = buildingcontact.CellphoneNumber,
                    FirstName = buildingcontact.FirstName,
                    IsOwner = buildingcontact.IsOwner,
                    LastName = buildingcontact.LastName,
                    OtherNumber = buildingcontact.OtherNumber,
                    OtherNumberExtension = buildingcontact.OtherNumberExtension,
                    PagerCode = buildingcontact.PagerCode,
                    PagerNumber = buildingcontact.PagerNumber,
                    PhoneNumber = buildingcontact.PhoneNumber,
                    PhoneNumberExtension = buildingcontact.PhoneNumberExtension,
                    IsActive = buildingcontact.IsActive,
                    LastEditedOn = buildingcontact.LastModifiedOn
                });
            return query.ToList();
        }

        public bool UpdateExternalIds(List<TransferIdCorrespondence> correspondenceIds)
        {
            try
            {
                List<string> ids = correspondenceIds.Select(ci => ci.Id).ToList();
                var query = from buildingContact in Context.BuildingContacts.AsNoTracking().IgnoreQueryFilters()
                            where ids.Contains(buildingContact.Id.ToString()) && buildingContact.IdExtern == ""
                            select new BuildingContact();

                query.ToList().ForEach(bc =>
                    {
                        bc.IdExtern = correspondenceIds.SingleOrDefault(ci => ci.Id == bc.Id.ToString())?.IdExtern;
                    });
                Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SetEntityAsTransferedToCad(List<string> ids)
        {
            try
            {
                Context.IsInImportationMode = true;
                var buildingContacts = Context.BuildingContacts.Where(b => ids.Contains(b.Id.ToString())).ToList();

                buildingContacts.ForEach(b =>
                {
                    b.HasBeenModified = false;
                });
                Context.SaveChanges();
                Context.IsInImportationMode = false;
                return true;
            }
            catch (Exception)
            {
                Context.IsInImportationMode = false;
                return false;
            }
        }
    }
}