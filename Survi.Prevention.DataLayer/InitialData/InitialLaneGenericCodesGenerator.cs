using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialLaneGenericCodesGenerator
	{
		internal static IEnumerable<LaneGenericCode> GetInitialData()
		{
			yield return new LaneGenericCode { Code = "A", Description = "", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Code = "B", Description = "À", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "C", Description = "À L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Code = "D", Description = "À LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "E", Description = "AU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "F", Description = "AUX", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "G", Description = "CHEZ", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "H", Description = "D'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Code = "I", Description = "DE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "J", Description = "DE L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Code = "K", Description = "DE LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "L", Description = "DES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "M", Description = "DU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "N", Description = "L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Code = "O", Description = "LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "P", Description = "LE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "Q", Description = "LES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Code = "R", Description = "THE", AddWhiteSpaceAfter = true };
		}
	}
}