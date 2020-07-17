using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x02000014 RID: 20
	internal class cflow
	{
		// Token: 0x0600007F RID: 127 RVA: 0x0000774C File Offset: 0x0000594C
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.Body.HasExceptionHandlers;
					if (flag)
					{
						for (int j = 0; j < methodDef.Body.Instructions.Count - 2; j++)
						{
							Instruction target = methodDef.Body.Instructions[j + 1];
							methodDef.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Ldstr, "Atomic"));
							methodDef.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Br_S, target));
							j += 2;
						}
					}
				}
			}
		}
	}
}
