
namespace Survi.Prevention.ServiceLayer
{
    public class LocalizedResourceGenerator
    {
	    public string GetFireProtectionLocationDescription(string floor, string sector, string wall, string languageCode)
	    {
		    var wallDescription = "";
		    if (!string.IsNullOrWhiteSpace(wall))
			    wallDescription = $"{Localization.EnumResource.ResourceManager.GetString("wall", System.Globalization.CultureInfo.GetCultureInfo(languageCode))	}: {wall}.";
		    var sectorDescription = "";
		    if (!string.IsNullOrWhiteSpace(sector))
			    sectorDescription = $"{Localization.EnumResource.ResourceManager.GetString("sector", System.Globalization.CultureInfo.GetCultureInfo(languageCode))	}: {sector}.";
		    var floorDescription = "";
		    if (!string.IsNullOrWhiteSpace(floor))
			    floorDescription = $"{Localization.EnumResource.ResourceManager.GetString("floor", System.Globalization.CultureInfo.GetCultureInfo(languageCode))	}: {floor}.";

		    return string.Join(" ", sectorDescription, floorDescription, wallDescription);
	    }
    }
}
