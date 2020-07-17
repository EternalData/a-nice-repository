using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicObfuscator.Atomic
{
	// Token: 0x02000007 RID: 7
	internal class calli
	{
		// Token: 0x0600004C RID: 76 RVA: 0x000053C0 File Offset: 0x000035C0
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef typeDef in module.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = !methodDef.HasBody;
					if (!flag)
					{
						bool flag2 = !methodDef.Body.HasInstructions;
						if (!flag2)
						{
							bool flag3 = methodDef.FullName.Contains("My.");
							if (!flag3)
							{
								bool flag4 = methodDef.FullName.Contains(".My");
								if (!flag4)
								{
									bool isConstructor = methodDef.IsConstructor;
									if (!isConstructor)
									{
										bool isGlobalModuleType = methodDef.DeclaringType.IsGlobalModuleType;
										if (!isGlobalModuleType)
										{
											int k = 0;
											while (k < methodDef.Body.Instructions.Count - 1)
											{
												try
												{
													bool flag5 = methodDef.Body.Instructions[k].ToString().Contains("ISupportInitialize");
													if (!flag5)
													{
														bool flag6 = methodDef.Body.Instructions[k].OpCode != OpCodes.Call && methodDef.Body.Instructions[k].OpCode != OpCodes.Callvirt && methodDef.Body.Instructions[k].OpCode != OpCodes.Ldloc_S;
														if (!flag6)
														{
															try
															{
																MemberRef memberRef = (MemberRef)methodDef.Body.Instructions[k].Operand;
																methodDef.Body.Instructions[k].OpCode = OpCodes.Calli;
																methodDef.Body.Instructions[k].Operand = memberRef.MethodSig;
																methodDef.Body.Instructions.Insert(k, Instruction.Create(OpCodes.Ldftn, memberRef));
															}
															catch (Exception)
															{
															}
														}
													}
												}
												catch (Exception)
												{
												}
												IL_1F9:
												k++;
												continue;
												goto IL_1F9;
											}
										}
									}
								}
							}
						}
					}
				}
				foreach (MethodDef methodDef2 in module.GlobalType.Methods)
				{
					bool flag7 = methodDef2.Name != ".ctor";
					if (!flag7)
					{
						module.GlobalType.Remove(methodDef2);
						break;
					}
				}
			}
		}
	}
}
