using System;
using System.Windows.Forms;

namespace AtomicObfuscator
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000044 RID: 68 RVA: 0x000021F1 File Offset: 0x000003F1
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
