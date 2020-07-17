using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace AtomicProtector.Atomic
{
	// Token: 0x0200002B RID: 43
	internal class md5_runtime
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000A4D4 File Offset: 0x000086D4
		private static void AtomicOnGod()
		{
			string location = Assembly.GetExecutingAssembly().Location;
			Stream baseStream = new StreamReader(location).BaseStream;
			BinaryReader binaryReader = new BinaryReader(baseStream);
			string a = BitConverter.ToString(MD5.Create().ComputeHash(binaryReader.ReadBytes(File.ReadAllBytes(location).Length - 16)));
			baseStream.Seek(-16L, SeekOrigin.End);
			string b = BitConverter.ToString(binaryReader.ReadBytes(16));
			bool flag = a != b;
			if (flag)
			{
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
