using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AtomicProtector.Atomic
{
	// Token: 0x02000028 RID: 40
	internal class anti_dump_runtime
	{
		// Token: 0x060000C4 RID: 196
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x060000C5 RID: 197 RVA: 0x0000A2A4 File Offset: 0x000084A4
		private unsafe static void Initialize()
		{
			Module module = typeof(anti_dump_runtime).Module;
			byte* ptr = (byte*)((void*)Marshal.GetHINSTANCE(module));
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + *(uint*)ptr2;
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + num2;
			byte* ptr3 = stackalloc byte[(UIntPtr)11];
			uint num3;
			anti_dump_runtime.VirtualProtect(ptr2 - 16, 8, 64U, out num3);
			*(int*)(ptr2 - 12) = 0;
			byte* ptr4 = ptr + *(uint*)(ptr2 - 16);
			*(int*)(ptr2 - 16) = 0;
			anti_dump_runtime.VirtualProtect(ptr4, 72, 64U, out num3);
			byte* ptr5 = ptr + *(uint*)(ptr4 + 8);
			*(int*)ptr4 = 0;
			*(int*)(ptr4 + 4) = 0;
			*(int*)(ptr4 + (IntPtr)2 * 4) = 0;
			*(int*)(ptr4 + (IntPtr)3 * 4) = 0;
			anti_dump_runtime.VirtualProtect(ptr5, 4, 64U, out num3);
			*(int*)ptr5 = 0;
			for (int i = 0; i < (int)num; i++)
			{
				anti_dump_runtime.VirtualProtect(ptr2, 8, 64U, out num3);
				Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
				ptr2 += 40;
			}
		}
	}
}
