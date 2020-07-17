using System;
using System.Linq;
using System.Security.Principal;

namespace AuthGG
{
	// Token: 0x02000037 RID: 55
	internal class Constants
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000256D File Offset: 0x0000076D
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00002574 File Offset: 0x00000774
		public static string Token { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000257C File Offset: 0x0000077C
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00002583 File Offset: 0x00000783
		public static string Date { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000258B File Offset: 0x0000078B
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00002592 File Offset: 0x00000792
		public static string APIENCRYPTKEY { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000FC RID: 252 RVA: 0x0000259A File Offset: 0x0000079A
		// (set) Token: 0x060000FD RID: 253 RVA: 0x000025A1 File Offset: 0x000007A1
		public static string APIENCRYPTSALT { get; set; }

		// Token: 0x060000FE RID: 254 RVA: 0x0000E0C0 File Offset: 0x0000C2C0
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
			select s[Constants.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000E10C File Offset: 0x0000C30C
		public static string HWID()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}

		// Token: 0x0400007E RID: 126
		public static bool Breached = false;

		// Token: 0x0400007F RID: 127
		public static bool Started = false;

		// Token: 0x04000080 RID: 128
		public static string IV = null;

		// Token: 0x04000081 RID: 129
		public static string Key = null;

		// Token: 0x04000082 RID: 130
		public static string ApiUrl = "https://api.auth.gg/csharp/";

		// Token: 0x04000083 RID: 131
		public static bool Initialized = false;

		// Token: 0x04000084 RID: 132
		public static Random random = new Random();
	}
}
