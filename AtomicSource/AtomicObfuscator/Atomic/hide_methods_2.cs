using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicObfuscator.Atomic
{
	// Token: 0x02000008 RID: 8
	internal class hide_methods_2
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000056B8 File Offset: 0x000038B8
		public static void Execute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.Body.HasExceptionHandlers;
						if (flag)
						{
							int num = 0;
							if (num < methodDef.Body.Instructions.Count - 2)
							{
								Instruction target = methodDef.Body.Instructions[num + 1];
								methodDef.Body.Instructions.Insert(num + 1, Instruction.Create(OpCodes.Unaligned, byte.MaxValue));
								methodDef.Body.Instructions.Insert(num + 1, Instruction.Create(OpCodes.Br_S, target));
								num += 2;
							}
						}
					}
				}
			}
		}
	}
}
