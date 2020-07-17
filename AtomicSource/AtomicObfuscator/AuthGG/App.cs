using System;
using System.Collections.Generic;

namespace AuthGG
{
	// Token: 0x02000036 RID: 54
	internal class App
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x0000E054 File Offset: 0x0000C254
		public static string GrabVariable(string name)
		{
			string result;
			try
			{
				bool flag = User.ID != null || User.HWID != null || User.IP != null || !Constants.Breached;
				if (flag)
				{
					result = App.Variables[name];
				}
				else
				{
					Constants.Breached = true;
					result = "User is not logged in, possible breach detected!";
				}
			}
			catch
			{
				result = "N/A";
			}
			return result;
		}

		// Token: 0x04000078 RID: 120
		public static string Error = null;

		// Token: 0x04000079 RID: 121
		public static Dictionary<string, string> Variables = new Dictionary<string, string>();
	}
}
