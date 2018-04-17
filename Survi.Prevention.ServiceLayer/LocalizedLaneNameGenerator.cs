namespace Survi.Prevention.ServiceLayer
{
	public class LocalizedLaneNameGenerator
	{
		public string GenerateLaneName(string name, string genericDescription, string publicDescription, bool addWhiteSpaceAfterGeneric)
		{
			var laneName = AddGenericPart(genericDescription, addWhiteSpaceAfterGeneric, name);
			laneName = AddPublicPart(publicDescription, laneName);
			return laneName;
		}

		private static string AddGenericPart(string genericDescription, bool addWhiteSpaceAfterGeneric, string laneName)
		{
			if (!string.IsNullOrWhiteSpace(genericDescription))
				laneName = $"{genericDescription}{(addWhiteSpaceAfterGeneric ? " " : string.Empty)}{laneName}";
			return laneName;
		}

		private static string AddPublicPart(string publicDescription, string laneName)
		{
			if (!string.IsNullOrWhiteSpace(publicDescription))
				laneName = $"{publicDescription} {laneName}";
			return laneName;
		}
	}
}