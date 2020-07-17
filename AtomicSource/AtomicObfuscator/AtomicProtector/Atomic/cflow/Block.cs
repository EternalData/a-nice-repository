using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace AtomicProtector.Atomic.cflow
{
	// Token: 0x02000030 RID: 48
	public class Block
	{
		// Token: 0x0400006F RID: 111
		public int ID = 0;

		// Token: 0x04000070 RID: 112
		public int nextBlock = 0;

		// Token: 0x04000071 RID: 113
		public List<Instruction> instructions = new List<Instruction>();
	}
}
