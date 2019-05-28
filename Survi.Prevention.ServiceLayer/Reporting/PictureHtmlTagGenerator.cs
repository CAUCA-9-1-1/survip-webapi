using System;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Reporting
{
    public enum PictureType
    {
        Tag,
        Logo
    }

	public class PictureHtmlTagGenerator
	{
		public static string GetTag(object value, string height)
		{
			return "<img style=\"margin: 20px 20px\" src=\"" + value +
			       $"\" height=\"{height}\" width=\"auto\" />";
		}

	    public static string GetTagForLogo(object value, string height)
	    {
	        return "<img style=\"margin: 5px 5px\" src=\"" + value +
	               $"\" height=\"{height}\" width=\"auto\" />";
	    }

        public static string GetFilledTemplateWithPicture(string filledTemplate, string group, string placeholder, string dataUri, PictureType type)
        {
            var placeholderPosition = filledTemplate.IndexOf($"@{group}.{placeholder}", StringComparison.Ordinal);
            var countForEnd = GetCountToUntilAtSign(filledTemplate, placeholderPosition, placeholder.Length, group);

            if (dataUri == null)
            {
                if (CheckIfHeightIsEntered(placeholderPosition, filledTemplate, placeholder.Length, group))
                {
                    var holderSplit = filledTemplate.Substring(placeholderPosition, countForEnd).Split('.');
                    var height = holderSplit[2].Replace("@", "");
                    filledTemplate = filledTemplate.Replace($"@{group}.{placeholder}.{height}@", "");
                }
                else
                {
                    filledTemplate = filledTemplate.Replace($"@{group}.{placeholder}@", "");
                }
            }
            else
            {
                var holderSplit = filledTemplate.Substring(placeholderPosition, countForEnd).Split('.');

                var height = String.Empty;
                if (holderSplit.Length == 3)
                    height = holderSplit[2].Replace("@", "");

                if (type == PictureType.Tag)
                {
                    filledTemplate = !String.IsNullOrEmpty(height)
                        ? filledTemplate.Replace($"@{group}.{placeholder}.{height}@", GetTag(dataUri, height))
                        : filledTemplate.Replace($"@{group}.{placeholder}@", GetTag(dataUri, "400"));
                }
                else
                {
                    filledTemplate = !String.IsNullOrEmpty(height)
                        ? filledTemplate.Replace($"@{group}.{placeholder}.{height}@", GetTagForLogo(dataUri, height))
                        : filledTemplate.Replace($"@{group}.{placeholder}@", GetTagForLogo(dataUri, "100"));
                }
            }

            return filledTemplate;
        }

	    private static bool CheckIfHeightIsEntered(int placeholderPosition, string filledTemplate, int placeholderLength, string group)
	    {
	        var height = false;

	        var countForEnd = GetCountToUntilAtSign(filledTemplate, placeholderPosition, placeholderLength, group);
	        var holderSplit = filledTemplate.Substring(placeholderPosition, countForEnd).Split('.');

	        if (holderSplit.Length == 3)
	            height = true;

	        return height;
	    }

	    private static int GetCountToUntilAtSign(string filledTemplate, int placeholderPosition, int placeholderLength, string group)
	    {
	        bool canStop = false;

	        int countForEnd = (group.Length + placeholderLength + 2);
	        do
	        {
	            var stringToCheck = filledTemplate.Substring(placeholderPosition, countForEnd);

	            if (!stringToCheck.EndsWith("@"))
	                countForEnd++;
	            else
	                canStop = true;
	        } while (canStop == false);
	        return countForEnd;
	    }
    }
}