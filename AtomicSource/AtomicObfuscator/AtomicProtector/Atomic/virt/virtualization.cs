using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicProtector.Atomic.virt
{
	// Token: 0x0200002C RID: 44
	internal class virtualization
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0000A55C File Offset: 0x0000875C
		public static void ConvertToDynamic(MethodDef method, ModuleDef module)
		{
			AssemblyDef assembly = module.Assembly;
			Utils.LoadOpCodes();
			Utils2.LoadOpCodes();
			TypeDef declaringType = method.DeclaringType;
			bool flag = !method.HasBody;
			if (!flag)
			{
				bool flag2 = !method.Body.HasInstructions;
				if (!flag2)
				{
					bool flag3 = method.ReturnType.TypeName != "Void";
					if (!flag3)
					{
						bool flag4 = declaringType.Namespace == "";
						if (!flag4)
						{
							bool flag5 = declaringType.Namespace.Contains(".Properties");
							if (!flag5)
							{
								bool flag6 = declaringType.IsGlobalModuleType && method.Name == ".cctor";
								if (!flag6)
								{
									Instruction[] oldInstructions = method.Body.Instructions.ToArray<Instruction>();
									Instruction[] array = null;
									Local local = new Local(assembly.ManifestModule.Import(typeof(List<Type>)).ToTypeSig());
									Local local2 = new Local(assembly.ManifestModule.Import(typeof(DynamicMethod)).ToTypeSig());
									Local local3 = new Local(assembly.ManifestModule.Import(typeof(ILGenerator)).ToTypeSig());
									Local local4 = new Local(assembly.ManifestModule.Import(typeof(Label[])).ToTypeSig());
									TypeSig returnType = method.ReturnType;
									Local[] oldLocals = method.Body.Variables.ToArray<Local>();
									List<Local> list = new List<Local>();
									bool flag7 = method.Name != ".ctor";
									if (flag7)
									{
										bool hasParamDefs = method.HasParamDefs;
										if (hasParamDefs)
										{
											array = virtualization.BuildInstruction(method.Body.Instructions.ToArray<Instruction>(), declaringType, method, method.ParamDefs[0].DeclaringMethod.MethodSig.Params, method.ReturnType.ToTypeDefOrRef(), method.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, oldLocals, oldInstructions, assembly, false, out list, returnType);
										}
										else
										{
											array = virtualization.BuildInstruction(method.Body.Instructions.ToArray<Instruction>(), declaringType, method, null, method.ReturnType.ToTypeDefOrRef(), method.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, oldLocals, oldInstructions, assembly, false, out list, returnType);
										}
									}
									else
									{
										bool hasParamDefs2 = method.HasParamDefs;
										if (hasParamDefs2)
										{
											array = virtualization.BuildInstruction(method.Body.Instructions.ToArray<Instruction>(), declaringType, method, method.ParamDefs[0].DeclaringMethod.MethodSig.Params, method.ReturnType.ToTypeDefOrRef(), method.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, oldLocals, oldInstructions, assembly, true, out list, returnType);
										}
										else
										{
											array = virtualization.BuildInstruction(method.Body.Instructions.ToArray<Instruction>(), declaringType, method, null, method.ReturnType.ToTypeDefOrRef(), method.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, oldLocals, oldInstructions, assembly, true, out list, returnType);
										}
									}
									method.Body.Instructions.Clear();
									method.Body.Variables.Add(local);
									method.Body.Variables.Add(local2);
									method.Body.Variables.Add(local3);
									method.Body.Variables.Add(local4);
									foreach (Local local5 in list)
									{
										method.Body.Variables.Add(local5);
									}
									foreach (Instruction item in array)
									{
										method.Body.Instructions.Add(item);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000A93C File Offset: 0x00008B3C
		public static Instruction[] BuildInstruction(Instruction[] toBuild, TypeDef typeDef, MethodDef method, IList<TypeSig> Param, ITypeDefOrRef type, IList<Parameter> pp, TypeDef typeM, Local local, Local local2, Local local3, Local local4, Local[] oldLocals, Instruction[] oldInstructions, AssemblyDef ctx, bool ISConstructorMethod, out List<Local> outLocals, TypeSig returnType)
		{
			List<Instruction> list = new List<Instruction>();
			List<Local> list2 = new List<Local>();
			list.Add(OpCodes.Nop.ToInstruction());
			list.Add(OpCodes.Ldc_I4.ToInstruction(9999));
			list.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Label))));
			list.Add(OpCodes.Stloc_S.ToInstruction(local4));
			list.Add(OpCodes.Newobj.ToInstruction(ctx.ManifestModule.Import(typeof(List<Type>).GetConstructor(new Type[0]))));
			list.Add(OpCodes.Stloc_S.ToInstruction(local));
			bool flag = pp.ToArray<Parameter>().Count<Parameter>() != 0;
			if (flag)
			{
				bool flag2 = pp[0] != null;
				if (flag2)
				{
					list.Add(OpCodes.Ldloc_S.ToInstruction(local));
					list.Add(OpCodes.Ldtoken.ToInstruction(pp[0].Type.ToTypeDefOrRef()));
					list.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
					{
						typeof(RuntimeTypeHandle)
					}))));
					list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[]
					{
						typeof(Type)
					}))));
				}
			}
			bool flag3 = Param != null;
			if (flag3)
			{
				foreach (TypeSig sig in Param)
				{
					list.Add(OpCodes.Ldloc_S.ToInstruction(local));
					list.Add(OpCodes.Ldtoken.ToInstruction(sig.ToTypeDefOrRef()));
					list.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
					{
						typeof(RuntimeTypeHandle)
					}))));
					list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[]
					{
						typeof(Type)
					}))));
				}
			}
			list.Add(OpCodes.Ldstr.ToInstruction("AtomicObfuscator"));
			list.Add(OpCodes.Ldtoken.ToInstruction(type));
			list.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
			{
				typeof(RuntimeTypeHandle)
			}))));
			list.Add(OpCodes.Ldloc_S.ToInstruction(local));
			list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(List<Type>).GetMethod("ToArray", new Type[0]))));
			list.Add(OpCodes.Ldtoken.ToInstruction(typeM));
			list.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
			{
				typeof(RuntimeTypeHandle)
			}))));
			list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("get_Module"))));
			list.Add(OpCodes.Ldc_I4_1.ToInstruction());
			list.Add(OpCodes.Newobj.ToInstruction(ctx.ManifestModule.Import(typeof(DynamicMethod).GetConstructor(new Type[]
			{
				typeof(string),
				typeof(Type),
				typeof(Type[]),
				typeof(Module),
				typeof(bool)
			}))));
			list.Add(OpCodes.Stloc_S.ToInstruction(local2));
			list.Add(OpCodes.Ldloc_S.ToInstruction(local2));
			list.Add(Instruction.Create(OpCodes.Callvirt, ctx.ManifestModule.Import(typeof(DynamicMethod).GetMethod("GetILGenerator", new Type[0]))));
			list.Add(OpCodes.Stloc_S.ToInstruction(local3));
			if (ISConstructorMethod)
			{
				virtualization.addLocal(new Local(ctx.ManifestModule.Import(typeDef).ToTypeSig()), local3, ref list, ctx, ref list2);
			}
			bool flag4 = oldLocals.Count<Local>() != 0;
			if (flag4)
			{
				foreach (Local local5 in oldLocals)
				{
					virtualization.addLocal(local5, local3, ref list, ctx, ref list2);
				}
			}
			List<Instruction> list3 = new List<Instruction>();
			foreach (Instruction instruction in oldInstructions)
			{
				bool flag5 = instruction.OpCode.OperandType == OperandType.InlineBrTarget || instruction.OpCode.OperandType == OperandType.ShortInlineBrTarget;
				if (flag5)
				{
					list3.Add(instruction);
					list.Add(OpCodes.Ldloc_S.ToInstruction(local4));
					list.Add(OpCodes.Ldc_I4.ToInstruction((int)((Instruction)instruction.Operand).Offset));
					list.Add(OpCodes.Ldloc_S.ToInstruction(local3));
					list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("DefineLabel", new Type[0]))));
					list.Add(OpCodes.Stelem.ToInstruction(ctx.ManifestModule.Import(typeof(Label))));
				}
			}
			virtualization.LocalsCount = 0;
			foreach (Instruction instruction2 in oldInstructions)
			{
				bool flag6 = instruction2.Operand != null;
				if (flag6)
				{
					virtualization.ConvertInstructionWithOperand(instruction2, local3, ref list, list2, list3, ctx);
				}
				else
				{
					virtualization.ConvertInstruction(instruction2, local3, ref list, ctx);
				}
			}
			list.UpdateInstructionOffsets();
			List<Instruction> list4 = new List<Instruction>();
			List<Instruction> list5 = new List<Instruction>();
			List<int> list6 = new List<int>();
			List<int> list7 = new List<int>();
			foreach (Instruction instruction3 in list)
			{
				bool flag7 = instruction3.OpCode == OpCodes.Ldsfld;
				if (flag7)
				{
					list4.Add(instruction3);
				}
			}
			foreach (Instruction instruction4 in oldInstructions)
			{
				bool flag8 = instruction4.OpCode.OperandType == OperandType.InlineBrTarget || instruction4.OpCode.OperandType == OperandType.ShortInlineBrTarget;
				if (flag8)
				{
					list5.Add(instruction4);
					Instruction instruction5 = (Instruction)instruction4.Operand;
					int num = 0;
					for (int m = 0; m < oldInstructions.Count<Instruction>(); m++)
					{
						bool flag9 = oldInstructions[m].OpCode == instruction5.OpCode;
						if (flag9)
						{
							num++;
							bool flag10 = oldInstructions[m] == instruction5;
							if (flag10)
							{
								list6.Add(num);
								break;
							}
						}
					}
					instruction5 = instruction4;
					int num2 = 0;
					for (int n = 0; n < oldInstructions.Count<Instruction>(); n++)
					{
						bool flag11 = oldInstructions[n].OpCode == instruction5.OpCode;
						if (flag11)
						{
							num2++;
							bool flag12 = oldInstructions[n] == instruction5;
							if (flag12)
							{
								list7.Add(num2);
								break;
							}
						}
					}
				}
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			string a = "";
			int num6 = 0;
			for (int num7 = 0; num7 < list5.Count; num7++)
			{
				for (int num8 = 0; num8 < list.Count; num8++)
				{
					bool flag13 = list[num8].OpCode != OpCodes.Ldsfld;
					if (!flag13)
					{
						bool flag14 = num4 != 0;
						if (flag14)
						{
							num4--;
						}
						else
						{
							string text = ((Instruction)list5[num7].Operand).ToString().Substring(9).ToLower();
							string b = list[num8].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower().Replace("_", ".").Substring(16);
							bool flag15 = text == b;
							if (flag15)
							{
								bool flag16 = a != text;
								if (flag16)
								{
									num6 = 0;
								}
								num6++;
								a = text;
								bool flag17 = num6 == list6[num3];
								if (flag17)
								{
									num6 = 0;
									num5++;
									num4 = num5;
									num3++;
									int num9 = num8;
									list.Insert(num9 - 1, OpCodes.Ldloc_S.ToInstruction(local3));
									list.Insert(num9, OpCodes.Ldloc_S.ToInstruction(local4));
									list.Insert(num9 + 1, OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list5[num7].Operand).Offset));
									list.Insert(num9 + 2, OpCodes.Ldelem.ToInstruction(ctx.ManifestModule.Import(typeof(Label))));
									list.Insert(num9 + 3, OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("MarkLabel", new Type[]
									{
										typeof(Label)
									}))));
									num8 += 3;
								}
							}
							else
							{
								num4 = num5;
							}
						}
					}
				}
			}
			num3 = 0;
			num4 = 0;
			num5 = 0;
			a = "";
			num6 = 0;
			for (int num10 = 0; num10 < list5.Count; num10++)
			{
				for (int num11 = 0; num11 < list.Count; num11++)
				{
					bool flag18 = list[num11].OpCode != OpCodes.Ldsfld;
					if (!flag18)
					{
						bool flag19 = num4 != 0;
						if (flag19)
						{
							num4--;
						}
						else
						{
							string text2 = list5[num10].OpCode.ToString().ToLower();
							string b2 = list[num11].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower().Replace("_", ".").Substring(16);
							bool flag20 = text2 == b2;
							if (flag20)
							{
								bool flag21 = a != text2;
								if (flag21)
								{
									num6 = 0;
								}
								num6++;
								a = text2;
								bool flag22 = num6 == list7[num3];
								if (flag22)
								{
									num6 = 0;
									num5++;
									num4 = num5;
									num3++;
									int num12 = num11;
									list.Insert(num12 + 1, OpCodes.Ldloc_S.ToInstruction(local4));
									list.Insert(num12 + 2, OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list5[num10].Operand).Offset));
									list.Insert(num12 + 3, OpCodes.Ldelem.ToInstruction(ctx.ManifestModule.Import(typeof(Label))));
									list.Insert(num12 + 4, OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
									{
										typeof(OpCode),
										typeof(Label)
									}))));
									num11 += 3;
								}
							}
							else
							{
								num4 = num5;
							}
						}
					}
				}
			}
			list.Add(OpCodes.Ldloc_S.ToInstruction(local2));
			list.Add(OpCodes.Ldnull.ToInstruction());
			bool flag23 = Param != null;
			if (flag23)
			{
				list.Add(OpCodes.Ldc_I4.ToInstruction(Param.Count + 1));
			}
			else
			{
				bool flag24 = pp.ToArray<Parameter>().Count<Parameter>() != 0;
				if (flag24)
				{
					list.Add(OpCodes.Ldc_I4.ToInstruction(pp.ToArray<Parameter>().Count<Parameter>()));
				}
				else
				{
					list.Add(OpCodes.Ldc_I4.ToInstruction(0));
				}
			}
			list.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(object))));
			bool flag25 = Param != null;
			if (flag25)
			{
				int num13 = 0;
				list.Add(OpCodes.Dup.ToInstruction());
				foreach (Parameter parameter in pp)
				{
					list.Add(OpCodes.Ldc_I4.ToInstruction(num13));
					list.Add(OpCodes.Ldarg_S.ToInstruction(parameter));
					list.Add(OpCodes.Stelem_Ref.ToInstruction());
					list.Add(OpCodes.Dup.ToInstruction());
					num13++;
				}
				list.RemoveAt(list.Count - 1);
			}
			else
			{
				bool flag26 = pp.ToArray<Parameter>().Count<Parameter>() != 0;
				if (flag26)
				{
					int num14 = 0;
					list.Add(OpCodes.Dup.ToInstruction());
					foreach (Parameter parameter2 in pp)
					{
						list.Add(OpCodes.Ldc_I4.ToInstruction(num14));
						list.Add(OpCodes.Ldarg_S.ToInstruction(parameter2));
						list.Add(OpCodes.Stelem_Ref.ToInstruction());
						list.Add(OpCodes.Dup.ToInstruction());
						num14++;
					}
					list.RemoveAt(list.Count - 1);
				}
			}
			list.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(MethodBase).GetMethod("Invoke", new Type[]
			{
				typeof(object),
				typeof(object[])
			}))));
			bool flag27 = returnType.TypeName != "Void";
			if (flag27)
			{
				list.Add(OpCodes.Unbox_Any.ToInstruction(returnType.ToTypeDefOrRef()));
			}
			else
			{
				list.Add(OpCodes.Pop.ToInstruction());
			}
			list.Add(OpCodes.Ret.ToInstruction());
			outLocals = list2;
			return list.ToArray();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B8D0 File Offset: 0x00009AD0
		public static void ConvertInstructionWithOperand(Instruction instruct, Local push, ref List<Instruction> lista, List<Local> variables, List<Instruction> brTargets, AssemblyDef ctx)
		{
			lista.Add(OpCodes.Ldloc_S.ToInstruction(push));
			char[] array = Utils.ConvertOpCode(instruct.OpCode).Name.ToCharArray();
			array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
			string text = new string(array);
			bool flag = text.Contains(".");
			if (flag)
			{
				string text2 = text.Substring(text.IndexOf('.')).ToUpper();
				text = text.Replace(text2.ToLower(), text2);
			}
			FieldInfo field = typeof(OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
			lista.Add(OpCodes.Ldsfld.ToInstruction(ctx.ManifestModule.Import(field)));
			object operand = instruct.Operand;
			bool flag2 = operand is ConstructorInfo;
			if (!flag2)
			{
				bool flag3 = operand is MethodDef;
				if (flag3)
				{
					bool flag4 = operand.ToString().Contains(".ctor");
					if (flag4)
					{
						lista.Add(OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
						{
							typeof(RuntimeTypeHandle)
						}))));
						lista.Add(OpCodes.Ldc_I4.ToInstruction(0));
						lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
						{
							typeof(Type[])
						}))));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(OpCode),
							typeof(ConstructorInfo)
						}))));
						return;
					}
					bool flag5 = instruct.OpCode == OpCodes.Ldftn;
					if (flag5)
					{
						lista.Add(OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
						{
							typeof(RuntimeTypeHandle)
						}))));
						lista.Add(OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
						lista.Add(OpCodes.Ldc_I4.ToInstruction(17301375));
						lista.Add(OpCodes.Ldnull.ToInstruction());
						int num = 0;
						int num2 = 0;
						foreach (TypeSig sig in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
						{
							bool flag6 = num == 0;
							if (flag6)
							{
								lista.Add(OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
								lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
								lista.Add(OpCodes.Dup.ToInstruction());
								num++;
							}
							lista.Add(OpCodes.Ldc_I4.ToInstruction(num2));
							lista.Add(OpCodes.Ldtoken.ToInstruction(sig.ToTypeDefOrRef()));
							lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							lista.Add(OpCodes.Stelem_Ref.ToInstruction());
							lista.Add(OpCodes.Dup.ToInstruction());
							num2++;
						}
						lista.RemoveAt(lista.Count - 1);
						lista.Add(OpCodes.Ldnull.ToInstruction());
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(OpCode),
							typeof(MethodInfo)
						}))));
						return;
					}
					lista.Add(OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
					lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
					{
						typeof(RuntimeTypeHandle)
					}))));
					lista.Add(OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
					lista.Add(OpCodes.Ldc_I4.ToInstruction(17301375));
					lista.Add(OpCodes.Ldnull.ToInstruction());
					int num3 = 0;
					int num4 = 0;
					bool flag7 = ((MethodBaseSig)((MethodDef)operand).Signature).Params.Count >= 1;
					if (flag7)
					{
						foreach (TypeSig sig2 in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
						{
							bool flag8 = num3 == 0;
							if (flag8)
							{
								lista.Add(OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
								lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
								lista.Add(OpCodes.Dup.ToInstruction());
								num3++;
							}
							lista.Add(OpCodes.Ldc_I4.ToInstruction(num4));
							lista.Add(OpCodes.Ldtoken.ToInstruction(sig2.ToTypeDefOrRef()));
							lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							lista.Add(OpCodes.Stelem_Ref.ToInstruction());
							lista.Add(OpCodes.Dup.ToInstruction());
							num4++;
						}
						lista.RemoveAt(lista.Count - 1);
						lista.Add(OpCodes.Ldnull.ToInstruction());
						lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(OpCode),
							typeof(MethodInfo)
						}))));
					}
					else
					{
						lista.Add(OpCodes.Ldc_I4_0.ToInstruction());
						lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
						lista.Add(OpCodes.Ldnull.ToInstruction());
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(OpCode),
							typeof(MethodInfo)
						}))));
					}
					return;
				}
				else
				{
					bool flag9 = operand is string;
					if (flag9)
					{
						lista.Add(OpCodes.Ldstr.ToInstruction(operand.ToString()));
						lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(OpCode),
							typeof(string)
						}))));
						return;
					}
					bool flag10 = operand is TypeDef;
					if (flag10)
					{
						return;
					}
					bool flag11 = operand is ConstructorInfo;
					if (!flag11)
					{
						bool flag12 = operand is int;
						if (flag12)
						{
							lista.Add(OpCodes.Ldc_I4.ToInstruction(int.Parse(operand.ToString())));
							lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(OpCode),
								typeof(int)
							}))));
							return;
						}
						bool flag13 = instruct.OpCode == OpCodes.Ldc_I4_S;
						if (flag13)
						{
							lista.Add(OpCodes.Ldc_I4_S.ToInstruction(sbyte.Parse(operand.ToString())));
							lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(OpCode),
								typeof(sbyte)
							}))));
							return;
						}
						bool flag14 = operand is double;
						if (flag14)
						{
							lista.Add(OpCodes.Ldc_R8.ToInstruction(double.Parse(operand.ToString().Replace(".", ","))));
							lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(OpCode),
								typeof(double)
							}))));
							return;
						}
						bool flag15 = operand is float;
						if (flag15)
						{
							lista.Add(OpCodes.Ldc_R4.ToInstruction(float.Parse(operand.ToString().Replace(".", ","))));
							lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(OpCode),
								typeof(float)
							}))));
							return;
						}
						bool flag16 = operand is MemberRef;
						if (flag16)
						{
							bool flag17 = instruct.OpCode == OpCodes.Ldftn;
							if (flag17)
							{
								return;
							}
							bool flag18 = operand.ToString().Contains(".ctor");
							if (flag18)
							{
								lista.Add(OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
								lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
								{
									typeof(RuntimeTypeHandle)
								}))));
								int num5 = 0;
								int num6 = 0;
								bool flag19 = ((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1;
								if (flag19)
								{
									foreach (TypeSig sig3 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
									{
										bool flag20 = num5 == 0;
										if (flag20)
										{
											lista.Add(OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
											lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
											lista.Add(OpCodes.Dup.ToInstruction());
											num5++;
										}
										lista.Add(OpCodes.Ldc_I4.ToInstruction(num6));
										lista.Add(OpCodes.Ldtoken.ToInstruction(sig3.ToTypeDefOrRef()));
										lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
										{
											typeof(RuntimeTypeHandle)
										}))));
										lista.Add(OpCodes.Stelem_Ref.ToInstruction());
										lista.Add(OpCodes.Dup.ToInstruction());
										num6++;
									}
									lista.RemoveAt(lista.Count - 1);
									lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
									{
										typeof(Type[])
									}))));
									lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
									{
										typeof(OpCode),
										typeof(ConstructorInfo)
									}))));
								}
								else
								{
									lista.Add(OpCodes.Ldc_I4.ToInstruction(0));
									lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
									lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
									{
										typeof(Type[])
									}))));
									lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
									{
										typeof(OpCode),
										typeof(ConstructorInfo)
									}))));
								}
								return;
							}
							lista.Add(OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
							lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							lista.Add(OpCodes.Ldstr.ToInstruction(((MemberRef)operand).Name));
							int num7 = 0;
							int num8 = 0;
							bool flag21 = ((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1;
							if (flag21)
							{
								foreach (TypeSig sig4 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
								{
									bool flag22 = num7 == 0;
									if (flag22)
									{
										lista.Add(OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
										lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
										lista.Add(OpCodes.Dup.ToInstruction());
										num7++;
									}
									lista.Add(OpCodes.Ldc_I4.ToInstruction(num8));
									lista.Add(OpCodes.Ldtoken.ToInstruction(sig4.ToTypeDefOrRef()));
									lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
									{
										typeof(RuntimeTypeHandle)
									}))));
									lista.Add(OpCodes.Stelem_Ref.ToInstruction());
									lista.Add(OpCodes.Dup.ToInstruction());
									num8++;
								}
								lista.RemoveAt(lista.Count - 1);
								lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
								{
									typeof(string),
									typeof(Type[])
								}))));
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(OpCode),
									typeof(MethodInfo)
								}))));
							}
							else
							{
								lista.Add(OpCodes.Ldc_I4.ToInstruction(17301375));
								lista.Add(OpCodes.Ldnull.ToInstruction());
								lista.Add(OpCodes.Ldc_I4_0.ToInstruction());
								lista.Add(OpCodes.Newarr.ToInstruction(ctx.ManifestModule.Import(typeof(Type))));
								lista.Add(OpCodes.Ldnull.ToInstruction());
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
								{
									typeof(string),
									typeof(BindingFlags),
									typeof(Binder),
									typeof(Type[]),
									typeof(ParameterModifier[])
								}))));
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(OpCode),
									typeof(MethodInfo)
								}))));
							}
							return;
						}
						else
						{
							bool flag23 = operand is FieldDef;
							if (flag23)
							{
								lista.Add(OpCodes.Ldtoken.ToInstruction(((FieldDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
								lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
								{
									typeof(RuntimeTypeHandle)
								}))));
								lista.Add(OpCodes.Ldstr.ToInstruction(((FieldDef)operand).Name));
								lista.Add(OpCodes.Ldc_I4.ToInstruction(17301375));
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetField", new Type[]
								{
									typeof(string),
									typeof(BindingFlags)
								}))));
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(OpCode),
									typeof(FieldInfo)
								}))));
								return;
							}
							bool flag24 = operand is TypeRef;
							if (flag24)
							{
								lista.Add(OpCodes.Ldtoken.ToInstruction(((TypeRef)operand).ToTypeSig().ToTypeDefOrRef()));
								lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
								{
									typeof(RuntimeTypeHandle)
								}))));
								lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(OpCode),
									typeof(Type)
								}))));
								return;
							}
							bool flag25 = operand is Local;
							if (flag25)
							{
								try
								{
									Dictionary<Local, Local> dictionary = variables.ToDictionary((Local x) => x, (Local x) => x);
									Local local;
									dictionary.TryGetValue(variables[int.Parse(((Local)operand).ToString().Replace("V_", ""))], out local);
									lista.Add(OpCodes.Ldloc_S.ToInstruction(local));
									lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
									{
										typeof(OpCode),
										typeof(LocalBuilder)
									}))));
									return;
								}
								catch (Exception ex)
								{
									Console.WriteLine(string.Format("{0}::{1} msg: {2}", instruct.OpCode, operand, ex.Message));
								}
							}
							else
							{
								bool flag26 = instruct.OpCode.OperandType == OperandType.InlineBrTarget || instruct.OpCode.OperandType == OperandType.ShortInlineBrTarget;
								if (flag26)
								{
									return;
								}
								bool flag27 = instruct.OpCode == OpCodes.Nop;
								if (flag27)
								{
									return;
								}
							}
						}
					}
				}
			}
			lista.RemoveAt(lista.Count - 1);
			lista.RemoveAt(lista.Count - 1);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
		public static void ConvertInstruction(Instruction instruct, Local push, ref List<Instruction> lista, AssemblyDef ctx)
		{
			lista.Add(OpCodes.Ldloc_S.ToInstruction(push));
			char[] array = Utils.ConvertOpCode(instruct.OpCode).Name.ToCharArray();
			array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
			string text = new string(array);
			bool flag = text.Contains(".");
			if (flag)
			{
				string text2 = text.Substring(text.IndexOf('.')).ToUpper();
				text = text.Replace(text2.ToLower(), text2);
			}
			FieldInfo field = typeof(OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
			bool flag2 = field == null;
			if (flag2)
			{
				Console.WriteLine(text);
			}
			lista.Add(OpCodes.Ldsfld.ToInstruction(ctx.ManifestModule.Import(field)));
			lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
			{
				typeof(OpCode)
			}))));
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000D334 File Offset: 0x0000B534
		public static void addLocal(Local local, Local push, ref List<Instruction> lista, AssemblyDef ctx, ref List<Local> list)
		{
			lista.Add(OpCodes.Ldloc_S.ToInstruction(push));
			lista.Add(OpCodes.Ldtoken.ToInstruction(local.Type.ToTypeDefOrRef()));
			lista.Add(OpCodes.Call.ToInstruction(ctx.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
			{
				typeof(RuntimeTypeHandle)
			}))));
			lista.Add(OpCodes.Callvirt.ToInstruction(ctx.ManifestModule.Import(typeof(ILGenerator).GetMethod("DeclareLocal", new Type[]
			{
				typeof(Type)
			}))));
			list.Add(new Local(ctx.ManifestModule.Import(typeof(LocalBuilder)).ToTypeSig()));
			lista.Add(OpCodes.Stloc_S.ToInstruction(list[list.Count - 1]));
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000D448 File Offset: 0x0000B648
		public static int Emulate(Instruction[] code, AssemblyDef ctx)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("AtomicObfuscator", typeof(void), null);
			ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
			foreach (Instruction instruction in code)
			{
				bool flag = instruction.Operand != null;
				if (flag)
				{
					bool flag2 = instruction.OpCode == OpCodes.Ldc_I4;
					if (flag2)
					{
						ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode), Convert.ToInt32(instruction.Operand));
					}
					else
					{
						bool flag3 = instruction.OpCode == OpCodes.Ldstr;
						if (flag3)
						{
							ilgenerator.Emit(Utils.ConvertOpCode(OpCodes.Ldstr), Convert.ToString(instruction.Operand));
						}
						else
						{
							bool flag4 = instruction.OpCode.OperandType == OperandType.InlineTok || instruction.OpCode.OperandType == OperandType.InlineType || instruction.OpCode.OperandType == OperandType.InlineMethod || instruction.OpCode.OperandType == OperandType.InlineField;
							if (flag4)
							{
								Type type = Assembly.LoadWithPartialName("AssemblyData").GetType("AssemblyData.methodsrewriter.Resolver");
								MethodInfo method = type.GetMethod("GetRtObject", new Type[]
								{
									typeof(ITokenOperand)
								});
								object obj = method.Invoke("", new object[]
								{
									(ITokenOperand)instruction.Operand
								});
								bool flag5 = obj is ConstructorInfo;
								if (flag5)
								{
									ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode), (ConstructorInfo)obj);
								}
								else
								{
									bool flag6 = obj is MethodInfo;
									if (flag6)
									{
										ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode), (MethodInfo)obj);
									}
									else
									{
										bool flag7 = obj is FieldInfo;
										if (flag7)
										{
											ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode), (FieldInfo)obj);
										}
										else
										{
											bool flag8 = obj is Type;
											if (flag8)
											{
												ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode), (Type)obj);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					ilgenerator.Emit(Utils.ConvertOpCode(instruction.OpCode));
				}
			}
			dynamicMethod.Invoke(null, new object[0]);
			return 0;
		}

		// Token: 0x04000066 RID: 102
		private static Dictionary<int, int> counterList = new Dictionary<int, int>();

		// Token: 0x04000067 RID: 103
		private static int LocalsCount = 0;
	}
}
