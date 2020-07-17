using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AtomicObfuscator.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000045 RID: 69 RVA: 0x0000220C File Offset: 0x0000040C
		internal Resources()
		{
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00005348 File Offset: 0x00003548
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("AtomicObfuscator.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00005390 File Offset: 0x00003590
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002216 File Offset: 0x00000416
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000033 RID: 51
		private static ResourceManager resourceMan;

		// Token: 0x04000034 RID: 52
		private static CultureInfo resourceCulture;
	}
}
