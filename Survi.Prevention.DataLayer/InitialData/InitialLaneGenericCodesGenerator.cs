using System;
using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialLaneGenericCodesGenerator
	{
		private static readonly DateTime Now = new DateTime(2018, 6, 1);
		internal static IEnumerable<LaneGenericCode> GetInitialData()
		{
			yield return new LaneGenericCode { Id = Guid.Parse("fe0216da-9b06-4f8d-b38f-4d91796ad4b3"), CreatedOn = Now, Code = "A", Description = "", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = Guid.Parse("17a0d69b-6a5f-423c-8a2b-c93c96ddd91a"), CreatedOn = Now, Code = "B", Description = "À", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("96830639-fc48-4673-b2ee-a2c6bdd9acfc"), CreatedOn = Now, Code = "C", Description = "À L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = Guid.Parse("0f05e403-e9be-4f45-93f3-ef6dda52e0ae"), CreatedOn = Now, Code = "D", Description = "À LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("3d905da2-e08d-4e55-b024-2402e2572089"), CreatedOn = Now, Code = "E", Description = "AU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("0bd9e144-1b09-41e6-88bd-fd454fad8342"), CreatedOn = Now, Code = "F", Description = "AUX", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("5f4750a2-e4be-48b3-b427-e299947ac2c7"), CreatedOn = Now, Code = "G", Description = "CHEZ", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("2364ddf8-e5a6-4f3f-91ec-b1d55a1c523f"), CreatedOn = Now, Code = "H", Description = "D'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = Guid.Parse("089d9146-c67d-48de-b2c1-ffb00bfc2a99"), CreatedOn = Now, Code = "I", Description = "DE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("c27d8877-7b9f-4462-b20b-e71e2c2f963f"), CreatedOn = Now, Code = "J", Description = "DE L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = Guid.Parse("fc846456-2091-445d-bc85-da22069771d6"), CreatedOn = Now, Code = "K", Description = "DE LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("15375891-f145-4ceb-9978-d9ff84ea1822"), CreatedOn = Now, Code = "L", Description = "DES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("395e7d3b-e747-4faf-af42-936960ae513f"), CreatedOn = Now, Code = "M", Description = "DU", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("4eba70e7-1656-41d8-abaa-8f596bda3d85"), CreatedOn = Now, Code = "N", Description = "L'", AddWhiteSpaceAfter = false };
			yield return new LaneGenericCode { Id = Guid.Parse("c54c1bcf-8e0e-4132-8de7-3a926f0d59d9"), CreatedOn = Now, Code = "O", Description = "LA", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("a60472cc-a8ef-42c5-9a72-1baa46c1b96e"), CreatedOn = Now, Code = "P", Description = "LE", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("dd5d2540-df8d-4e42-81a1-dd09face8308"), CreatedOn = Now, Code = "Q", Description = "LES", AddWhiteSpaceAfter = true };
			yield return new LaneGenericCode { Id = Guid.Parse("99e6098d-2de5-4dc7-811c-e324f1d5dd4b"), CreatedOn = Now, Code = "R", Description = "THE", AddWhiteSpaceAfter = true };	
		}
	}
}