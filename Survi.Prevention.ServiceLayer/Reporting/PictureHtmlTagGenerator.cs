namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class PictureHtmlTagGenerator
	{
		public static string GetTag(object value)
		{
			return "<img style=\"margin: 20px 20px\" src=\"" + value +
			       "\" height=\"400\" />";
		}
	}
}