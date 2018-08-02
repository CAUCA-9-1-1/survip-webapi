using System;

namespace Survi.Prevention.DataLayer.InitialData
{
	public static class GuidExtensions
	{
		private static Guid last;

		private static readonly int[] GuidByteOrder =
			new[] {15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3};

		private static Guid Increment(Guid guid)
		{
			var bytes = guid.ToByteArray();
			bool carry = true;
			for (int i = 0; i < GuidByteOrder.Length && carry; i++)
			{
				int index = GuidByteOrder[i];
				byte oldValue = bytes[index]++;
				carry = oldValue > bytes[index];
			}

			return new Guid(bytes);
		}

		public static Guid GetGuid()
		{
			last = last == Guid.Empty ? Guid.Parse("f13400a9-70b8-4325-b732-7fe7db72176b") : Increment(last);
			return last;
		}
	}
}