using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace AtomicObfuscator.Properties
{
	// Token: 0x02000006 RID: 6
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000053A8 File Offset: 0x000035A8
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000035 RID: 53
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
