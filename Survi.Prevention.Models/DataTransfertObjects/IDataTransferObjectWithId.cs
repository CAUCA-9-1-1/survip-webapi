using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public interface IDataTransferObjectWithId
    {
		Guid Id { get; set; }
    }
}
