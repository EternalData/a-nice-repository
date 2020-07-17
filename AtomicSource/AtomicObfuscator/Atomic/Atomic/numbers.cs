using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x0200001B RID: 27
	internal class numbers
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00008638 File Offset: 0x00006838
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			numbers.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Encrypt");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00008720 File Offset: 0x00006920
		public static void InjectClass1(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			numbers.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Season");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00008808 File Offset: 0x00006A08
		public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
		{
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			for (int i = 0; i < szPlainText.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)((int)c ^ szEncryptionKey);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00008864 File Offset: 0x00006A64
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("1234567890", length)
			select s[numbers.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000088B0 File Offset: 0x00006AB0
		public static void String(ModuleDef module)
		{
			numbers.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = !methodDef.HasBody;
						if (!flag)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									string s = numbers.Random(5);
									string szPlainText = (string)instructions[i].Operand;
									string text = numbers.EncryptDecrypt(szPlainText, int.Parse(s));
									text += "                                                                                                                                       ";
									instructions[i].Operand = text;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldc_I4, int.Parse(s)));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, numbers.init1));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00008A5C File Offset: 0x00006C5C
		public static double RandomDouble(double min, double max)
		{
			return numbers.rnd.NextDouble() * (max - min) + min;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00008A80 File Offset: 0x00006C80
		public static void InlineInteger(MethodDef method, int i)
		{
			bool isGlobalModuleType = method.DeclaringType.IsGlobalModuleType;
			if (!isGlobalModuleType)
			{
				IList<Instruction> instructions = method.Body.Instructions;
				try
				{
					bool flag = instructions[i - 1].OpCode == OpCodes.Callvirt;
					if (flag)
					{
						bool flag2 = instructions[i + 1].OpCode == OpCodes.Call;
						if (flag2)
						{
							return;
						}
					}
					bool flag3 = instructions[i + 4].IsBr();
					if (!flag3)
					{
						bool flag4 = true;
						int num = numbers.random.Next(0, 2);
						int num2 = num;
						if (num2 != 0)
						{
							if (num2 == 1)
							{
								flag4 = false;
							}
						}
						else
						{
							flag4 = true;
						}
						Local local = new Local(method.Module.CorLibTypes.String);
						method.Body.Variables.Add(local);
						Local local2 = new Local(method.Module.CorLibTypes.Int32);
						method.Body.Variables.Add(local2);
						int ldcI4Value = instructions[i].GetLdcI4Value();
						string s = Renamer.Generator.GenerateString();
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local2));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local2));
						bool flag5 = flag4;
						if (flag5)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
						}
						instructions.Insert(i, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(string).GetMethod("op_Equality", new Type[]
						{
							typeof(string),
							typeof(string)
						}))));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local));
						bool flag6 = flag4;
						if (flag6)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, Renamer.Generator.GenerateString()));
						}
						instructions.Insert(i + 5, Instruction.Create(OpCodes.Brtrue_S, instructions[i + 6]));
						instructions.Insert(i + 7, Instruction.Create(OpCodes.Br_S, instructions[i + 8]));
						instructions.RemoveAt(i + 10);
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00008D4C File Offset: 0x00006F4C
		public static void encrypt(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = !methodDef.HasBody;
					if (!flag)
					{
						bool flag2 = !methodDef.Body.HasInstructions;
						if (!flag2)
						{
							bool flag3 = methodDef.DeclaringType == md.GlobalType;
							if (!flag3)
							{
								for (int k = 0; k < methodDef.Body.Instructions.Count; k++)
								{
									bool flag4 = methodDef.Body.Instructions[k].OpCode == OpCodes.Ldc_I4;
									if (flag4)
									{
										int ldcI4Value = methodDef.Body.Instructions[k].GetLdcI4Value();
										double value = numbers.RandomDouble(1.0, 1000.0);
										string s = Convert.ToString(value);
										double num = double.Parse(s);
										int num2 = ldcI4Value - (int)num;
										methodDef.Body.Instructions[k].Operand = num2;
										methodDef.Body.Instructions[k].OpCode = OpCodes.Ldc_I4;
										methodDef.Body.Instructions.Insert(k + 1, Instruction.Create(OpCodes.Ldstr, s));
										methodDef.Body.Instructions.Insert(k + 2, Instruction.Create(OpCodes.Ldc_I4, numbers.rnd.Next(1, 10000)));
										methodDef.Body.Instructions.Insert(k + 3, Instruction.Create(OpCodes.Call, numbers.init));
										methodDef.Body.Instructions.Insert(k + 4, OpCodes.Conv_I4.ToInstruction());
										methodDef.Body.Instructions.Insert(k + 5, Instruction.Create(OpCodes.Add));
										k += 5;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000056 RID: 86
		public static MethodDef init;

		// Token: 0x04000057 RID: 87
		public static MethodDef init1;

		// Token: 0x04000058 RID: 88
		public static Random rnd = new Random();

		// Token: 0x04000059 RID: 89
		public static Random random = new Random();
	}
}
