using System;
using System.Collections.Generic;
using System.Linq;

namespace AtomicProtector.Atomic.cflow
{
	// Token: 0x02000031 RID: 49
	public class Blocks
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000D910 File Offset: 0x0000BB10
		public Block getBlock(int id)
		{
			return this.blocks.Single((Block block) => block.ID == id);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000D948 File Offset: 0x0000BB48
		public void Scramble(out Blocks incGroups)
		{
			Blocks blocks = new Blocks();
			foreach (Block item in this.blocks)
			{
				blocks.blocks.Insert(this.generator.Next(1, blocks.blocks.Count), item);
			}
			incGroups = blocks;
		}

		// Token: 0x04000072 RID: 114
		public List<Block> blocks = new List<Block>();

		// Token: 0x04000073 RID: 115
		private Random generator = new Random();
	}
}
