using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicObfuscator.Atomic.cflow
{
	// Token: 0x0200000A RID: 10
	internal class after_stage
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00005D40 File Offset: 0x00003F40
		public static void AfterStage(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					FieldDefUser fieldDefUser = new FieldDefUser("AtomicObfuscator", new FieldSig(md.CorLibTypes.Int32), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
					typeDef.Fields.Add(fieldDefUser);
					bool flag = methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.Body.HasExceptionHandlers;
					if (flag)
					{
						Local local = new Local(md.CorLibTypes.Int32);
						methodDef.Body.Variables.Add(local);
						for (int j = 0; j < methodDef.Body.Instructions.Count - 2; j++)
						{
							methodDef.Body.Instructions.Insert(j + 1, OpCodes.Ldsfld.ToInstruction(fieldDefUser));
							methodDef.Body.Instructions.Insert(j + 2, OpCodes.Stloc.ToInstruction(local));
							j += 2;
						}
					}
				}
			}
		}
	}
}
