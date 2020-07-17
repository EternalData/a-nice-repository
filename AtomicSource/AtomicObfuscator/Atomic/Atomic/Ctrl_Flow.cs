using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x02000015 RID: 21
	internal class Ctrl_Flow
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00007898 File Offset: 0x00005A98
		public static void Brs(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = methodDef.HasBody && methodDef.Body.Instructions.Count != 0;
					if (flag)
					{
						IList<Instruction> instructions = methodDef.Body.Instructions;
						int num = 0;
						if (num < instructions.Count)
						{
							Instruction instruction = Instruction.Create(OpCodes.Nop);
							Instruction instruction2 = OpCodes.Call.ToInstruction(md.Import(typeof(string).GetMethod("IsNullOrEmpty", new Type[]
							{
								typeof(string)
							})));
						}
					}
				}
			}
		}

		// Token: 0x0400004B RID: 75
		public static List<Instruction> instr = new List<Instruction>();

		// Token: 0x0400004C RID: 76
		private static List<int> Integers = new List<int>();

		// Token: 0x0400004D RID: 77
		private static List<int> Integers_Position = new List<int>();

		// Token: 0x0400004E RID: 78
		private static int Index = 0;

		// Token: 0x0400004F RID: 79
		private static Random rnd = new Random();
	}
}
