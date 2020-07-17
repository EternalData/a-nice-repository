using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace Atomic.packer
{
	// Token: 0x0200000F RID: 15
	internal class context
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00006AB0 File Offset: 0x00004CB0
		public static void LoadModule(string filename)
		{
			try
			{
				context.FileName = filename;
				byte[] data = File.ReadAllBytes(filename);
				ModuleContext context = ModuleDef.CreateModuleContext();
				context.module = ModuleDefMD.Load(data, context);
				foreach (AssemblyRef assemblyRef in context.module.GetAssemblyRefs())
				{
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006B34 File Offset: 0x00004D34
		public static void SaveModule()
		{
			try
			{
				string filename = string.Concat(new string[]
				{
					Path.GetDirectoryName(context.FileName),
					"\\",
					Path.GetFileNameWithoutExtension(context.FileName),
					"_Packed",
					Path.GetExtension(context.FileName)
				});
				bool isILOnly = context.module.IsILOnly;
				if (isILOnly)
				{
					ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(context.module);
					moduleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
					moduleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
					context.module.Write(filename, moduleWriterOptions);
				}
				else
				{
					NativeModuleWriterOptions nativeModuleWriterOptions = new NativeModuleWriterOptions(context.module);
					nativeModuleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
					nativeModuleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
					context.module.NativeWrite(filename, nativeModuleWriterOptions);
				}
			}
			catch (ModuleWriterException ex)
			{
			}
			Console.ReadLine();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00006C24 File Offset: 0x00004E24
		public static byte[] Compress(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal))
			{
				deflateStream.Write(data, 0, data.Length);
			}
			return memoryStream.ToArray();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006C78 File Offset: 0x00004E78
		public static void PackerPhase()
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Atomic.exe");
			moduleDefMD.Characteristics = context.module.Characteristics;
			moduleDefMD.Cor20HeaderFlags = context.module.Cor20HeaderFlags;
			moduleDefMD.Cor20HeaderRuntimeVersion = context.module.Cor20HeaderRuntimeVersion;
			moduleDefMD.DllCharacteristics = context.module.DllCharacteristics;
			moduleDefMD.EncBaseId = context.module.EncBaseId;
			moduleDefMD.EncId = context.module.EncId;
			moduleDefMD.Generation = context.module.Generation;
			moduleDefMD.Kind = context.module.Kind;
			moduleDefMD.Machine = context.module.Machine;
			moduleDefMD.RuntimeVersion = context.module.RuntimeVersion;
			moduleDefMD.TablesHeaderVersion = context.module.TablesHeaderVersion;
			moduleDefMD.Win32Resources = context.module.Win32Resources;
			MethodDef entryPoint = moduleDefMD.EntryPoint;
			string text = context.RandomString(20);
			Instruction instruction = (from op in entryPoint.Body.Instructions
			where op.OpCode == OpCodes.Ldc_I4 && op.GetLdcI4Value() == 123456789
			select op).First<Instruction>();
			Instruction instruction2 = (from op in entryPoint.Body.Instructions
			where op.OpCode == OpCodes.Ldstr && op.Operand.ToString().Equals("Name_Resource")
			select op).First<Instruction>();
			instruction.Operand = entryPoint.MDToken.ToInt32();
			instruction2.Operand = text;
			byte[] ilasByteArray = Assembly.Load(context.GetCurrentModule(moduleDefMD)).ManifestModule.ResolveMethod(entryPoint.MDToken.ToInt32()).GetMethodBody().GetILAsByteArray();
			moduleDefMD.Resources.Add(new EmbeddedResource(text, context.Encrypt(context.GetCurrentModule(context.module), ilasByteArray)));
			context.module = moduleDefMD;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00006E6C File Offset: 0x0000506C
		public static byte[] GetCurrentModule(ModuleDefMD module)
		{
			MemoryStream memoryStream = new MemoryStream();
			bool isILOnly = module.IsILOnly;
			if (isILOnly)
			{
				module.Write(memoryStream, new ModuleWriterOptions(module)
				{
					MetaDataOptions = 
					{
						Flags = MetaDataFlags.PreserveAll
					},
					MetaDataLogger = DummyLogger.NoThrowInstance
				});
			}
			else
			{
				module.NativeWrite(memoryStream, new NativeModuleWriterOptions(module)
				{
					MetaDataOptions = 
					{
						Flags = MetaDataFlags.PreserveAll
					},
					MetaDataLogger = DummyLogger.NoThrowInstance
				});
			}
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			return array;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00006F1C File Offset: 0x0000511C
		public static byte[] Encrypt(byte[] plain, byte[] Key)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < plain.Length; j++)
				{
					plain[j] ^= Key[j % Key.Length];
					for (int k = 0; k < Key.Length; k++)
					{
						plain[j] = (byte)((int)plain[j] ^ ((int)Key[k] << i ^ k) + j);
					}
				}
			}
			return plain;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006F94 File Offset: 0x00005194
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[context.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0400003C RID: 60
		private static Random random = new Random();

		// Token: 0x0400003D RID: 61
		public static ModuleDefMD module = null;

		// Token: 0x0400003E RID: 62
		public static string FileName = null;
	}
}
