using System;

namespace KrunchyToMAuto
{
	// Token: 0x02000004 RID: 4
	internal static class Extensions
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002604 File Offset: 0x00000804
		internal static int ToInt(this string value)
		{
			int result = 0;
			int num;
			if (string.IsNullOrEmpty(value))
			{
				result = 0;
			}
			else if (int.TryParse(value, out num))
			{
				result = num;
			}
			return result;
		}
	}
}
