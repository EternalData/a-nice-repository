using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using dnlib.DotNet.Emit;

namespace AtomicProtector.Atomic.virt
{
	// Token: 0x0200002F RID: 47
	internal class Utils2
	{
		// Token: 0x060000DF RID: 223 RVA: 0x0000D7D4 File Offset: 0x0000B9D4
		public static OpCode ConvertOpCode(OpCode ropcode)
		{
			bool flag = Utils2.reflectionToDnlib.TryGetValue(ropcode, out Utils2.Opcode);
			OpCode result;
			if (flag)
			{
				result = Utils2.Opcode;
			}
			else
			{
				result = OpCodes.Nop;
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000D808 File Offset: 0x0000BA08
		public static void LoadOpCodes()
		{
			Dictionary<short, OpCode> dictionary = new Dictionary<short, OpCode>(256);
			foreach (FieldInfo fieldInfo in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				bool flag = fieldInfo.FieldType != typeof(OpCode);
				if (!flag)
				{
					OpCode opCode = (OpCode)fieldInfo.GetValue(null);
					dictionary[opCode.Value] = opCode;
				}
			}
			foreach (FieldInfo fieldInfo2 in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				bool flag2 = fieldInfo2.FieldType != typeof(OpCode);
				if (!flag2)
				{
					OpCode key = (OpCode)fieldInfo2.GetValue(null);
					bool flag3 = !dictionary.TryGetValue(key.Value, out Utils2.Opcode);
					if (!flag3)
					{
						Utils2.reflectionToDnlib[key] = Utils2.Opcode;
					}
				}
			}
		}

		// Token: 0x0400006D RID: 109
		private static Dictionary<OpCode, OpCode> reflectionToDnlib = new Dictionary<OpCode, OpCode>();

		// Token: 0x0400006E RID: 110
		private static OpCode Opcode;
	}
}
