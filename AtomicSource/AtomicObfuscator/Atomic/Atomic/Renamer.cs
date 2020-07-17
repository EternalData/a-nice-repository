using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x0200001D RID: 29
	internal class Renamer
	{
		// Token: 0x0200001E RID: 30
		public interface IRenaming
		{
			// Token: 0x060000A2 RID: 162
			ModuleDefMD Rename(ModuleDefMD module);
		}

		// Token: 0x0200001F RID: 31
		public static class Generator
		{
			// Token: 0x060000A3 RID: 163 RVA: 0x00008F98 File Offset: 0x00007198
			public static string GenerateString()
			{
				int num = 2;
				byte[] array = new byte[num];
				new RNGCryptoServiceProvider().GetBytes(array);
				string str = null;
				return str + Renamer.Generator.EncodeString(array, Renamer.Generator.unicodeCharset);
			}

			// Token: 0x060000A4 RID: 164 RVA: 0x00008FD4 File Offset: 0x000071D4
			private static string EncodeString(byte[] buff, char[] charset)
			{
				int i = (int)buff[0];
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 1; j < buff.Length; j++)
				{
					for (i = (i << 8) + (int)buff[j]; i >= charset.Length; i /= charset.Length)
					{
						stringBuilder.Append(charset[i % charset.Length]);
					}
				}
				bool flag = i != 0;
				if (flag)
				{
					stringBuilder.Append(charset[i % charset.Length]);
				}
				return stringBuilder.ToString();
			}

			// Token: 0x060000A5 RID: 165 RVA: 0x00009054 File Offset: 0x00007254
			public static byte[] GetBytes(int lenght)
			{
				byte[] array = new byte[lenght];
				new RNGCryptoServiceProvider().GetBytes(array);
				return array;
			}

			// Token: 0x0400005E RID: 94
			private static readonly char[] unicodeCharset = new char[0].Concat(from ord in Enumerable.Range(8203, 5)
			select (char)ord).Concat(from ord in Enumerable.Range(8233, 6)
			select (char)ord).Concat(from ord in Enumerable.Range(8298, 6)
			select (char)ord).Except(new char[]
			{
				'搷'
			}).ToArray<char>();
		}

		// Token: 0x02000021 RID: 33
		public static class Renamer3
		{
			// Token: 0x060000AC RID: 172 RVA: 0x0000911C File Offset: 0x0000731C
			public static ModuleDef Rename(ModuleDef mod)
			{
				ModuleDefMD module = (ModuleDefMD)mod;
				Renamer.IRenaming renaming = new Renamer.NamespacesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.ClassesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.MethodsRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.PropertiesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.FieldsRenaming();
				return renaming.Rename(module);
			}
		}

		// Token: 0x02000022 RID: 34
		public class FieldsRenaming : Renamer.IRenaming
		{
			// Token: 0x060000AD RID: 173 RVA: 0x0000917C File Offset: 0x0000737C
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						foreach (FieldDef fieldDef in typeDef.Fields)
						{
							string s;
							bool flag = Renamer.FieldsRenaming._names.TryGetValue(fieldDef.Name, out s);
							if (flag)
							{
								fieldDef.Name = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.FieldsRenaming._names.Add(fieldDef.Name, text);
								fieldDef.Name = text;
							}
						}
					}
				}
				return Renamer.FieldsRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x060000AE RID: 174 RVA: 0x0000928C File Offset: 0x0000748C
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							bool flag = methodDef.Name != "InitializeComponent";
							if (!flag)
							{
								IList<Instruction> instructions = methodDef.Body.Instructions;
								for (int i = 0; i < instructions.Count - 3; i++)
								{
									bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
									if (flag2)
									{
										foreach (KeyValuePair<string, string> keyValuePair in Renamer.FieldsRenaming._names)
										{
											bool flag3 = keyValuePair.Key == instructions[i].Operand.ToString();
											if (flag3)
											{
												instructions[i].Operand = keyValuePair.Value;
											}
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000060 RID: 96
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x02000023 RID: 35
		public class ClassesRenaming : Renamer.IRenaming
		{
			// Token: 0x060000B1 RID: 177 RVA: 0x00009448 File Offset: 0x00007648
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						bool flag = typeDef.Name == "GeneratedInternalTypeHelper" || typeDef.Name == "Resources" || typeDef.Name == "Settings";
						if (!flag)
						{
							string s;
							bool flag2 = Renamer.ClassesRenaming._names.TryGetValue(typeDef.Name, out s);
							if (flag2)
							{
								typeDef.Name = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.ClassesRenaming._names.Add(typeDef.Name, text);
								typeDef.Name = text;
							}
						}
					}
				}
				return Renamer.ClassesRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x00009554 File Offset: 0x00007754
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (Resource resource in module.Resources)
				{
					foreach (KeyValuePair<string, string> keyValuePair in Renamer.ClassesRenaming._names)
					{
						bool flag = resource.Name.Contains(keyValuePair.Key);
						if (flag)
						{
							resource.Name = resource.Name.Replace(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
				foreach (TypeDef typeDef in module.GetTypes())
				{
					foreach (PropertyDef propertyDef in typeDef.Properties)
					{
						bool flag2 = propertyDef.Name != "ResourceManager";
						if (!flag2)
						{
							IList<Instruction> instructions = propertyDef.GetMethod.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag3 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag3)
								{
									foreach (KeyValuePair<string, string> keyValuePair2 in Renamer.ClassesRenaming._names)
									{
										bool flag4 = instructions[i].Operand.ToString().Contains(keyValuePair2.Key);
										if (flag4)
										{
											instructions[i].Operand = instructions[i].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000061 RID: 97
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x02000024 RID: 36
		public class MethodsRenaming : Renamer.IRenaming
		{
			// Token: 0x060000B5 RID: 181 RVA: 0x000097F4 File Offset: 0x000079F4
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						bool flag = typeDef.Name == "GeneratedInternalTypeHelper";
						if (!flag)
						{
							foreach (MethodDef methodDef in typeDef.Methods)
							{
								bool flag2 = !methodDef.HasBody;
								if (!flag2)
								{
									bool flag3 = methodDef.Name == ".ctor" || methodDef.Name == ".cctor";
									if (!flag3)
									{
										methodDef.Name = Renamer.Generator.GenerateString();
									}
								}
							}
						}
					}
				}
				return module;
			}
		}

		// Token: 0x02000025 RID: 37
		public class NamespacesRenaming : Renamer.IRenaming
		{
			// Token: 0x060000B7 RID: 183 RVA: 0x0000990C File Offset: 0x00007B0C
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						bool flag = typeDef.Namespace == "";
						if (!flag)
						{
							string s;
							bool flag2 = Renamer.NamespacesRenaming._names.TryGetValue(typeDef.Namespace, out s);
							if (flag2)
							{
								typeDef.Namespace = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.NamespacesRenaming._names.Add(typeDef.Namespace, text);
								typeDef.Namespace = text;
							}
						}
					}
				}
				return Renamer.NamespacesRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x000099EC File Offset: 0x00007BEC
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (Resource resource in module.Resources)
				{
					foreach (KeyValuePair<string, string> keyValuePair in Renamer.NamespacesRenaming._names)
					{
						bool flag = resource.Name.Contains(keyValuePair.Key);
						if (flag)
						{
							resource.Name = resource.Name.Replace(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
				foreach (TypeDef typeDef in module.GetTypes())
				{
					foreach (PropertyDef propertyDef in typeDef.Properties)
					{
						bool flag2 = propertyDef.Name != "ResourceManager";
						if (!flag2)
						{
							IList<Instruction> instructions = propertyDef.GetMethod.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag3 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag3)
								{
									foreach (KeyValuePair<string, string> keyValuePair2 in Renamer.NamespacesRenaming._names)
									{
										bool flag4 = instructions[i].ToString().Contains(keyValuePair2.Key);
										if (flag4)
										{
											instructions[i].Operand = instructions[i].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000062 RID: 98
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x02000026 RID: 38
		public class PropertiesRenaming : Renamer.IRenaming
		{
			// Token: 0x060000BB RID: 187 RVA: 0x00009C88 File Offset: 0x00007E88
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					if (!isGlobalModuleType)
					{
						foreach (PropertyDef propertyDef in typeDef.Properties)
						{
							propertyDef.Name = Renamer.Generator.GenerateString();
						}
					}
				}
				return module;
			}
		}
	}
}
