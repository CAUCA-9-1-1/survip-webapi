using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Survi.Prevention.ServiceLayer.Localization.Base
{
	public class EnumItem//<TEnum> where TEnum : Enum
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}

	public static class EnumLocalizationExtensions
	{
		public static string GetDisplayName(this Enum value)
		{
			var converter = TypeDescriptor.GetConverter(value);
			return converter.ConvertToString(value);
		}

		public static string GetDisplayName(this Enum value, string languageCode)
		{
			var keyName = value.GetType().Name + "_" + value;
			var localizedName = EnumResource.ResourceManager.GetString(keyName, CultureInfo.GetCultureInfo("fr"));
			return localizedName;
		}

		/// <summary>
		/// Returns a dictionary of elements mapped to the int value and display string of each members of the given Enum type.
		/// </summary>
		/// <param name="enumType"></param>
		/// <returns></returns>
		public static List<EnumItem> ToList(this Type enumType)
		{
			if (!typeof(Enum).IsAssignableFrom(enumType))
				throw new ArgumentException("enumType must a enum!", "enumType");
			else
			{
				return Enum.GetValues(enumType)
					.Cast<Enum>()
					.Select(e => new EnumItem { Id = (int)(object)e, Description = e.GetDisplayName() })
					.OrderBy(e => e.Description)
					.ToList();
			}
		}

		public static List<EnumItem> ToList(this Type enumType, string languageCode)
		{
			if (!typeof(Enum).IsAssignableFrom(enumType))
				throw new ArgumentException("enumType must a enum!", "enumType");
			else
			{
				return Enum.GetValues(enumType)
					.Cast<Enum>()
					.Select(e => new EnumItem { Id = (int)(object)e, Description = e.GetDisplayName(languageCode) })
					.OrderBy(e => e.Description)
					.ToList();
			}
		}
	}

	public class EnumLocalizer<TResource> : TypeConverter
	{
		private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(TResource));

		public static void Localize<TEnum>()
		{
			TypeDescriptor.AddAttributes(typeof(TEnum), new TypeConverterAttribute(typeof(EnumLocalizer<TResource>)));
		}
		/// <summary>
		/// Returns whether this converter can convert the object to the specified type.
		/// </summary>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
		{
			return destType.IsEnum || base.CanConvertTo(context, destType);
		}

		/// <summary>
		/// Converts the given value to the type of this converter.
		/// </summary>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
				return ResourceManager.GetString(value.GetType().Name + "_" + value, culture) ?? value.ToString();
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public string GetString(CultureInfo culture, object value)
		{
			return ResourceManager.GetString(value.GetType().Name + "_" + value, culture) ?? value.ToString();
		}
	}
}
