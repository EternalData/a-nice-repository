using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Atomic.Atomic
{
	// Token: 0x02000027 RID: 39
	internal class runtime
	{
		// Token: 0x060000BD RID: 189 RVA: 0x00009D3C File Offset: 0x00007F3C
		public static double Encrypt(string value, uint num)
		{
			bool flag = Assembly.GetCallingAssembly() == Assembly.GetExecutingAssembly();
			double result;
			if (flag)
			{
				bool flag2 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag2)
				{
					Environment.Exit(0);
				}
				bool flag3 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag3)
				{
					Environment.Exit(0);
				}
				bool flag4 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag4)
				{
					Environment.Exit(0);
				}
				bool flag5 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag5)
				{
					Environment.Exit(0);
				}
				MethodBase currentMethod = MethodBase.GetCurrentMethod();
				bool flag6 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag6)
				{
					Environment.Exit(0);
				}
				bool flag7 = currentMethod.Name != "Encrypt";
				if (flag7)
				{
					Environment.Exit(0);
				}
				bool flag8 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag8)
				{
					Environment.Exit(0);
				}
				int num2 = 0;
				bool flag9 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag9)
				{
					Environment.Exit(0);
				}
				bool flag10 = num2 == 0;
				if (flag10)
				{
					result = double.Parse(value);
				}
				else
				{
					result = 69.0;
				}
			}
			else
			{
				result = 69.0;
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00009E94 File Offset: 0x00008094
		public static string Season(string value, uint num)
		{
			bool flag = Assembly.GetCallingAssembly() == Assembly.GetExecutingAssembly();
			string result;
			if (flag)
			{
				bool flag2 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag2)
				{
					Environment.Exit(0);
				}
				bool flag3 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag3)
				{
					Environment.Exit(0);
				}
				bool flag4 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag4)
				{
					Environment.Exit(0);
				}
				bool flag5 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag5)
				{
					Environment.Exit(0);
				}
				MethodBase currentMethod = MethodBase.GetCurrentMethod();
				bool flag6 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag6)
				{
					Environment.Exit(0);
				}
				bool flag7 = currentMethod.Name != "Season";
				if (flag7)
				{
					Environment.Exit(0);
				}
				bool flag8 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag8)
				{
					Environment.Exit(0);
				}
				int num2 = 0;
				bool flag9 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag9)
				{
					Environment.Exit(0);
				}
				bool flag10 = num2 == 0;
				if (flag10)
				{
					result = runtime.d4v7654745(value, (int)num);
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00009FE4 File Offset: 0x000081E4
		public static string d4v7654745(string szPlainText, int szEncryptionKey)
		{
			szPlainText = szPlainText.ToString().Replace("                                                                                                                                       ", "");
			bool flag = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
			if (flag)
			{
				Environment.Exit(0);
			}
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			bool flag2 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
			if (flag2)
			{
				Environment.Exit(0);
			}
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			bool flag3 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
			if (flag3)
			{
				Environment.Exit(0);
			}
			bool flag4 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
			if (flag4)
			{
				Environment.Exit(0);
			}
			for (int i = 0; i < szPlainText.Length; i++)
			{
				bool flag5 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag5)
				{
					Environment.Exit(0);
				}
				char c = stringBuilder[i];
				bool flag6 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag6)
				{
					Environment.Exit(0);
				}
				c = (char)((int)c ^ szEncryptionKey);
				bool flag7 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag7)
				{
					Environment.Exit(0);
				}
				stringBuilder2.Append(c);
				bool flag8 = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
				if (flag8)
				{
					Environment.Exit(0);
				}
			}
			return stringBuilder2.ToString();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000A150 File Offset: 0x00008350
		public static IntPtr ResolveToken(int token)
		{
			return typeof(runtime).Module.ResolveMethod(token).MethodHandle.GetFunctionPointer();
		}

		// Token: 0x060000C1 RID: 193
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x060000C2 RID: 194 RVA: 0x0000A184 File Offset: 0x00008384
		private unsafe static void Initialize()
		{
			bool flag = Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly();
			if (flag)
			{
				Environment.Exit(0);
			}
			Module module = typeof(runtime).Module;
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
			runtime.VirtualProtect(ptr2 - 16, 8, 64U, out num3);
			*(int*)(ptr2 - 12) = 0;
			byte* ptr4 = ptr + *(uint*)(ptr2 - 16);
			*(int*)(ptr2 - 16) = 0;
			runtime.VirtualProtect(ptr4, 72, 64U, out num3);
			byte* ptr5 = ptr + *(uint*)(ptr4 + 8);
			*(int*)ptr4 = 0;
			*(int*)(ptr4 + 4) = 0;
			*(int*)(ptr4 + (IntPtr)2 * 4) = 0;
			*(int*)(ptr4 + (IntPtr)3 * 4) = 0;
			runtime.VirtualProtect(ptr5, 4, 64U, out num3);
			*(int*)ptr5 = 0;
			for (int i = 0; i < (int)num; i++)
			{
				runtime.VirtualProtect(ptr2, 8, 64U, out num3);
				Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
				ptr2 += 40;
			}
		}
	}
}
