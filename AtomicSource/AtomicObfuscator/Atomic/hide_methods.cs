using System;
using Atomic.Atomic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace AtomicObfuscator.Atomic
{
	// Token: 0x02000009 RID: 9
	internal class hide_methods
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00005834 File Offset: 0x00003A34
		public static void Execute(ModuleDef asm)
		{
			asm.Mvid = null;
			asm.Name = Renamer.Generator.GenerateString();
			asm.Import(new FieldDefUser(Renamer.Generator.GenerateString()));
			foreach (TypeDef typeDef in asm.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = methodDef.Body == null;
					if (!flag)
					{
						methodDef.Body.SimplifyBranches();
						bool flag2 = methodDef.ReturnType.FullName != "System.Void" || !methodDef.HasBody || methodDef.Body.Instructions.Count == 0;
						if (!flag2)
						{
							TypeSig typeSig = asm.Import(typeof(int)).ToTypeSig();
							Local local = new Local(typeSig);
							TypeSig typeSig2 = asm.Import(typeof(bool)).ToTypeSig();
							Local local2 = new Local(typeSig2);
							methodDef.Body.Variables.Add(local);
							methodDef.Body.Variables.Add(local2);
							Instruction operand = methodDef.Body.Instructions[methodDef.Body.Instructions.Count - 1];
							Instruction item = new Instruction(OpCodes.Ret);
							Instruction instruction = new Instruction(OpCodes.Ldc_I4_1);
							methodDef.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4_0));
							methodDef.Body.Instructions.Insert(1, new Instruction(OpCodes.Stloc, local));
							methodDef.Body.Instructions.Insert(2, new Instruction(OpCodes.Br, instruction));
							Instruction instruction2 = new Instruction(OpCodes.Ldloc, local);
							methodDef.Body.Instructions.Insert(3, instruction2);
							methodDef.Body.Instructions.Insert(4, new Instruction(OpCodes.Ldc_I4_0));
							methodDef.Body.Instructions.Insert(5, new Instruction(OpCodes.Ceq));
							methodDef.Body.Instructions.Insert(6, new Instruction(OpCodes.Ldc_I4_1));
							methodDef.Body.Instructions.Insert(7, new Instruction(OpCodes.Ceq));
							methodDef.Body.Instructions.Insert(8, new Instruction(OpCodes.Stloc, local2));
							methodDef.Body.Instructions.Insert(9, new Instruction(OpCodes.Ldloc, local2));
							methodDef.Body.Instructions.Insert(10, new Instruction(OpCodes.Brtrue, methodDef.Body.Instructions[10]));
							methodDef.Body.Instructions.Insert(11, new Instruction(OpCodes.Ret));
							methodDef.Body.Instructions.Insert(12, new Instruction(OpCodes.Calli));
							methodDef.Body.Instructions.Insert(13, new Instruction(OpCodes.Sizeof, operand));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction);
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Stloc, local2));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Br, instruction2));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, item);
							ExceptionHandler item2 = new ExceptionHandler(ExceptionHandlerType.Finally)
							{
								HandlerStart = methodDef.Body.Instructions[10],
								HandlerEnd = methodDef.Body.Instructions[11],
								TryEnd = methodDef.Body.Instructions[14],
								TryStart = methodDef.Body.Instructions[12]
							};
							bool flag3 = !methodDef.Body.HasExceptionHandlers;
							if (flag3)
							{
								methodDef.Body.ExceptionHandlers.Add(item2);
							}
							methodDef.Body.OptimizeBranches();
							methodDef.Body.OptimizeMacros();
						}
					}
				}
			}
		}
	}
}
