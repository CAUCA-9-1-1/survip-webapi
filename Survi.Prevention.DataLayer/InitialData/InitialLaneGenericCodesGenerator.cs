using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialLaneGenericCodesGenerator
	{
		internal static IEnumerable<LaneGenericCode> GetInitialData()
		{
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "A", Description = "", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "B", Description = "À", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "C", Description = "À L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "D", Description = "À LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "E", Description = "AU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "F", Description = "AUX", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "G", Description = "CHEZ", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "H", Description = "D'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "I", Description = "DE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "J", Description = "DE L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "K", Description = "DE LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "L", Description = "DES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "M", Description = "DU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "N", Description = "L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "O", Description = "LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "P", Description = "LE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "Q", Description = "LES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = GuidExtensions.GetGuid(), Code = "R", Description = "THE", AddWhiteSpaceAfter = true };
		}
	}
}