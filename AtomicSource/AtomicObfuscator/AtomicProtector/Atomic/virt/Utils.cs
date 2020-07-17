using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using dnlib.DotNet.Emit;

namespace AtomicProtector.Atomic.virt
{
	// Token: 0x0200002E RID: 46
	internal class Utils
	{
		// Token: 0x060000DB RID: 219 RVA: 0x0000D698 File Offset: 0x0000B898
		public static OpCode ConvertOpCode(OpCode opcode)
		{
			bool flag = Utils.dnlibToReflection.TryGetValue(opcode, out Utils.ropcode);
			OpCode nop;
			if (flag)
			{
				nop = Utils.ropcode;
			}
			else
			{
				nop = OpCodes.Nop;
			}
			return nop;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000D6CC File Offset: 0x0000B8CC
		public static void LoadOpCodes()
		{
			Dictionary<short, OpCode> dictionary = new Dictionary<short, OpCode>(256);
			foreach (FieldInfo fieldInfo in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				bool flag = fieldInfo.FieldType != typeof(OpCode);
				if (!flag)
				{
					OpCode value = (OpCode)fieldInfo.GetValue(null);
					dictionary[value.Value] = value;
				}
			}
			foreach (FieldInfo fieldInfo2 in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				bool flag2 = fieldInfo2.FieldType != typeof(OpCode);
				if (!flag2)
				{
					OpCode opCode = (OpCode)fieldInfo2.GetValue(null);
					bool flag3 = !dictionary.TryGetValue(opCode.Value, out Utils.ropcode);
					if (!flag3)
					{
						Utils.dnlibToReflection[opCode] = Utils.ropcode;
					}
				}
			}
		}

		// Token: 0x0400006B RID: 107
		private static Dictionary<OpCode, OpCode> dnlibToReflection = new Dictionary<OpCode, OpCode>();

		// Token: 0x0400006C RID: 108
		private static OpCode ropcode;
	}
}
