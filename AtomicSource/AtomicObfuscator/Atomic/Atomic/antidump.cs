using System;
using System.Collections.Generic;
using System.Linq;
using AtomicProtector.Atomic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Atomic.Atomic
{
	// Token: 0x02000011 RID: 17
	internal class antidump
	{
		// Token: 0x06000075 RID: 117 RVA: 0x00006FE0 File Offset: 0x000051E0
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(anti_dump_runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(anti_dump_runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			antidump.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Initialize");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000070C8 File Offset: 0x000052C8
		public static void Execute(ModuleDef module)
		{
			antidump.InjectClass(module);
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, antidump.init));
		}

		// Token: 0x04000043 RID: 67
		public static MethodDef init;
	}
}
