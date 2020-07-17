using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x02000016 RID: 22
	internal class fields
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00007994 File Offset: 0x00005B94
		public static void ProcessMethod(MethodDef method, ModuleDef modulee)
		{
			bool isConstructor = method.IsConstructor;
			if (!isConstructor)
			{
				bool flag = !method.HasBody;
				if (!flag)
				{
					bool flag2 = !method.Body.HasInstructions;
					if (!flag2)
					{
						method.Body.SimplifyMacros(method.Parameters);
						for (int i = 0; i < method.Body.Instructions.Count; i++)
						{
							Local local = method.Body.Instructions[i].Operand as Local;
							bool flag3 = local != null;
							if (flag3)
							{
								bool flag4 = !fields.convertedLocals.ContainsKey(local);
								FieldDef fieldDef;
								if (flag4)
								{
									fieldDef = new FieldDefUser("\ud83c\udf47 ⋆ \ud83c\udf6a  \ud83c\udf80  \ud835\udcb6\ud835\udcc9\ud83c\udf38\ud835\udcc2\ud835\udcbe\ud835\udcb8  \ud83c\udf80  \ud83c\udf6a ⋆ \ud83c\udf47", new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
									method.Module.GlobalType.Fields.Add(fieldDef);
									fields.convertedLocals.Add(local, fieldDef);
								}
								else
								{
									fieldDef = fields.convertedLocals[local];
								}
								OpCode opCode = null;
								Code code = method.Body.Instructions[i].OpCode.Code;
								Code code2 = code;
								switch (code2)
								{
								case Code.Ldloc_0:
								case Code.Ldloc_1:
								case Code.Ldloc_2:
								case Code.Ldloc_3:
								case Code.Ldloc_S:
									goto IL_1A9;
								case Code.Stloc_0:
								case Code.Stloc_1:
								case Code.Stloc_2:
								case Code.Stloc_3:
								case Code.Stloc_S:
									goto IL_1BB;
								case Code.Ldarg_S:
								case Code.Ldarga_S:
								case Code.Starg_S:
									break;
								case Code.Ldloca_S:
									goto IL_1B2;
								default:
									switch (code2)
									{
									case Code.Ldloc:
										goto IL_1A9;
									case Code.Ldloca:
										goto IL_1B2;
									case Code.Stloc:
										goto IL_1BB;
									}
									break;
								}
								IL_1C4:
								method.Body.Instructions[i].OpCode = opCode;
								method.Body.Instructions[i].Operand = fieldDef;
								goto IL_201;
								IL_1A9:
								opCode = OpCodes.Ldsfld;
								goto IL_1C4;
								IL_1B2:
								opCode = OpCodes.Ldsflda;
								goto IL_1C4;
								IL_1BB:
								opCode = OpCodes.Stsfld;
								goto IL_1C4;
							}
							IL_201:;
						}
						fields.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
						{
							method.Body.Variables.Remove(x.Key);
						});
						fields.convertedLocals = new Dictionary<Local, FieldDef>();
					}
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00007BF4 File Offset: 0x00005DF4
		public static void protect(ModuleDef md)
		{
			IEnumerable<TypeDef> types = md.Types;
			Func<TypeDef, bool> <>9__0;
			Func<TypeDef, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((TypeDef x) => x != md.GlobalType));
			}
			foreach (TypeDef typeDef in types.Where(predicate))
			{
				foreach (MethodDef method in from x in typeDef.Methods
				where x.HasBody && x.Body.HasInstructions && !x.IsConstructor
				select x)
				{
					fields.convertedLocals = new Dictionary<Local, FieldDef>();
					fields.ProcessMethod(method, md);
				}
			}
		}

		// Token: 0x04000050 RID: 80
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
