using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Atomic.Atomic;
using Atomic.packer;
using AtomicObfuscator.Atomic;
using AtomicObfuscator.Atomic.cflow;
using AtomicProtector.Atomic.cflow;
using AtomicProtector.Atomic.virt;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace AtomicObfuscator
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000002 RID: 2
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
		// (set) Token: 0x06000004 RID: 4 RVA: 0x0000206C File Offset: 0x0000026C
		public int Radius { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002075 File Offset: 0x00000275
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207D File Offset: 0x0000027D
		public Color BorderColor { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002086 File Offset: 0x00000286
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208E File Offset: 0x0000028E
		public Color FillColor { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002097 File Offset: 0x00000297
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209F File Offset: 0x0000029F
		public bool Fill { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A8 File Offset: 0x000002A8
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020B0 File Offset: 0x000002B0
		public bool AntiAlias { get; set; }

		// Token: 0x0600000D RID: 13
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x0600000E RID: 14 RVA: 0x0000281C File Offset: 0x00000A1C
		public Form1()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000028B8 File Offset: 0x00000AB8
		private void Form1_Load(object sender, EventArgs e)
		{
			if (true && true)
			{
				this.textBox1.Visible = false;
				this.button1.Visible = false;
				this.label7.Visible = true;
				this.button1.Visible = false;
				this.textBox1.Visible = false;
				this.button2.Visible = true;
				this.button3.Visible = true;
				this.button4.Visible = true;
				this.button5.Visible = true;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020B9 File Offset: 0x000002B9
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020B9 File Offset: 0x000002B9
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020BC File Offset: 0x000002BC
		private void label2_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002938 File Offset: 0x00000B38
		private void button1_Click(object sender, EventArgs e)
		{
			string contents = this.textBox1.Text.Replace(" ", "");
			if (true)
			{
				this.textBox1.Visible = false;
				this.button1.Visible = false;
				this.label7.Visible = true;
				this.button2.Visible = true;
				this.button3.Visible = true;
				this.button4.Visible = true;
				this.button5.Visible = true;
				File.WriteAllText("C:\\ProgramData\\atomicobfuscatorkeysave.txt", contents);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000029C4 File Offset: 0x00000BC4
		private void button6_Click(object sender, EventArgs e)
		{
			this.label5.Text = "Updating..";
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			bool @checked = this.checkBox2.Checked;
			if (@checked)
			{
				text = "numberprotect";
			}
			bool checked2 = this.checkBox6.Checked;
			if (checked2)
			{
				text2 = "stringenc";
			}
			bool checked3 = this.checkBox5.Checked;
			if (checked3)
			{
				text3 = "cflow";
			}
			bool checked4 = this.checkBox4.Checked;
			if (checked4)
			{
				text4 = "renamer";
			}
			bool checked5 = this.checkBox3.Checked;
			if (checked5)
			{
				text5 = "mutation";
			}
			bool checked6 = this.checkBox1.Checked;
			if (checked6)
			{
				text6 = "packer";
			}
			bool checked7 = this.checkBox7.Checked;
			if (checked7)
			{
				text7 = "antidump";
			}
			bool checked8 = this.checkBox8.Checked;
			if (checked8)
			{
				text8 = "calli";
			}
			bool checked9 = this.checkBox9.Checked;
			if (checked9)
			{
				text9 = "hideallmethods";
			}
			bool checked10 = this.checkBox10.Checked;
			if (checked10)
			{
				text10 = "resourcespammer";
			}
			string[] contents = new string[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6,
				text7,
				text8,
				text9,
				text10
			};
			File.WriteAllLines("C:\\ProgramData\\atomicconfigg.txt", contents);
			FileInfo fileInfo = new FileInfo("C:\\ProgramData\\atomicconfigg.txt");
			DateTime lastWriteTime = fileInfo.LastWriteTime;
			this.label5.Text = "Last saved: " + lastWriteTime.ToString();
			MessageBox.Show("Config Updated!", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002BB0 File Offset: 0x00000DB0
		public static bool Simplify(MethodDef methodDef)
		{
			bool flag = methodDef.Parameters == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				methodDef.Body.SimplifyMacros(methodDef.Parameters);
				result = true;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public static bool Optimize(MethodDef methodDef)
		{
			bool flag = methodDef.Body == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				methodDef.Body.OptimizeMacros();
				methodDef.Body.OptimizeBranches();
				result = true;
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002C24 File Offset: 0x00000E24
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Form1.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002C70 File Offset: 0x00000E70
		private void button7_Click(object sender, EventArgs e)
		{
			ModuleDef moduleDef = ModuleDefMD.Load(this.textBox2.Text);
			bool virtualization = this.Virtualization;
			if (virtualization)
			{
				foreach (TypeDef typeDef in moduleDef.Types.ToArray<TypeDef>())
				{
					foreach (MethodDef method in typeDef.Methods.ToArray<MethodDef>())
					{
						virtualization.ConvertToDynamic(method, moduleDef);
					}
				}
			}
			bool calli = this.Calli;
			if (calli)
			{
				bool flag = !this.Virtualization;
				if (flag)
				{
					calli.Execute(moduleDef);
				}
			}
			foreach (TypeDef typeDef2 in moduleDef.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef2.Methods.ToArray<MethodDef>())
				{
					bool flag2 = methodDef.HasBody && methodDef.Body.Instructions.Count > 0 && !methodDef.IsConstructor;
					if (flag2)
					{
						bool cflow = this.Cflow;
						if (cflow)
						{
							bool flag3 = !cfhelper.HasUnsafeInstructions(methodDef);
							if (flag3)
							{
								bool flag4 = Form1.Simplify(methodDef);
								if (flag4)
								{
									Blocks blocks = cfhelper.GetBlocks(methodDef);
									bool flag5 = blocks.blocks.Count != 1;
									if (flag5)
									{
										control_flow.toDoBody(methodDef, blocks);
										break;
									}
								}
								Form1.Optimize(methodDef);
							}
						}
					}
				}
			}
			bool cflow2 = this.Cflow;
			if (cflow2)
			{
				Ctrl_Flow.Brs(moduleDef);
				after_stage.AfterStage(moduleDef);
			}
			bool strings = this.Strings;
			if (strings)
			{
				numbers.InjectClass1(moduleDef);
				numbers.String(moduleDef);
			}
			bool mutation = this.Mutation;
			if (mutation)
			{
				mutatio.Booleanisator(moduleDef);
			}
			bool renamer = this.Renamer;
			if (renamer)
			{
				Renamer.Renamer3.Rename(moduleDef);
			}
			bool numbers = this.Numbers;
			if (numbers)
			{
				numbers.InjectClass(moduleDef);
			}
			foreach (TypeDef typeDef3 in moduleDef.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef2 in typeDef3.Methods.ToArray<MethodDef>())
				{
					bool flag6 = methodDef2.HasBody && methodDef2.Body.Instructions.Count != 0;
					if (flag6)
					{
						bool numbers2 = this.Numbers;
						if (numbers2)
						{
							array.Array(methodDef2);
						}
					}
				}
			}
			bool cflow3 = this.Cflow;
			if (cflow3)
			{
				cflow.Execute(moduleDef);
			}
			bool antiDumper = this.AntiDumper;
			if (antiDumper)
			{
				antidump.Execute(moduleDef);
			}
			bool numbers3 = this.Numbers;
			if (numbers3)
			{
				numbers.InjectClass(moduleDef);
				numbers.encrypt(moduleDef);
				numbers.encrypt(moduleDef);
			}
			bool strings2 = this.Strings;
			if (strings2)
			{
				numbers.String(moduleDef);
			}
			bool mutation2 = this.Mutation;
			if (mutation2)
			{
				foreach (TypeDef typeDef4 in moduleDef.Types.ToArray<TypeDef>())
				{
					foreach (MethodDef methodDef3 in typeDef4.Methods.ToArray<MethodDef>())
					{
						bool flag7 = methodDef3.HasBody && methodDef3.Body.Instructions.Count != 0;
						if (flag7)
						{
							mutatio.Mutate1(methodDef3);
						}
					}
				}
			}
			bool numbers4 = this.Numbers;
			if (numbers4)
			{
				numbers.encrypt(moduleDef);
			}
			bool hideAllMethods = this.HideAllMethods;
			if (hideAllMethods)
			{
				hide_methods_2.Execute(moduleDef);
				hide_methods.Execute(moduleDef);
			}
			bool resourceSpammer = this.ResourceSpammer;
			if (resourceSpammer)
			{
				string s = "AtomicObfuscator";
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				for (int num3 = 0; num3 < 150; num3++)
				{
					EmbeddedResource item = new EmbeddedResource(new UTF8String(Form1.RandomString(10)), bytes, ManifestResourceAttributes.Public);
					moduleDef.Resources.Add(item);
				}
			}
			Directory.CreateDirectory(".\\AtomicProtected\\");
			moduleDef.Write(".\\AtomicProtected\\" + Path.GetFileName(this.textBox2.Text), new ModuleWriterOptions(moduleDef)
			{
				Logger = DummyLogger.NoThrowInstance
			});
			bool packer = this.Packer;
			if (packer)
			{
				context.LoadModule(".\\AtomicProtected\\" + Path.GetFileName(this.textBox2.Text));
				context.PackerPhase();
				context.SaveModule();
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003120 File Offset: 0x00001320
		private void button2_Click(object sender, EventArgs e)
		{
			this.label7.Visible = true;
			this.textBox2.Visible = false;
			this.button7.Visible = false;
			this.label5.Visible = false;
			this.button6.Visible = false;
			this.checkBox2.Visible = false;
			this.checkBox6.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox4.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox3.Visible = false;
			this.checkBox1.Visible = false;
			this.checkBox7.Visible = false;
			this.checkBox8.Visible = false;
			this.checkBox9.Visible = false;
			this.checkBox10.Visible = false;
			this.checkBox11.Visible = false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000320C File Offset: 0x0000140C
		private void button3_Click(object sender, EventArgs e)
		{
			this.label7.Visible = false;
			this.textBox2.Visible = true;
			this.button7.Visible = true;
			this.label5.Visible = false;
			this.button6.Visible = false;
			this.checkBox2.Visible = false;
			this.checkBox6.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox4.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox3.Visible = false;
			this.checkBox1.Visible = false;
			this.checkBox7.Visible = false;
			this.checkBox8.Visible = false;
			this.checkBox9.Visible = false;
			this.checkBox10.Visible = false;
			this.checkBox11.Visible = false;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000032F8 File Offset: 0x000014F8
		private void button4_Click(object sender, EventArgs e)
		{
			this.label7.Visible = false;
			this.textBox2.Visible = false;
			this.button7.Visible = false;
			this.label5.Visible = false;
			this.button6.Visible = false;
			this.checkBox2.Visible = true;
			this.checkBox6.Visible = true;
			this.checkBox5.Visible = true;
			this.checkBox4.Visible = true;
			this.checkBox5.Visible = true;
			this.checkBox3.Visible = true;
			this.checkBox1.Visible = true;
			this.checkBox7.Visible = true;
			this.checkBox8.Visible = true;
			this.checkBox9.Visible = true;
			this.checkBox10.Visible = true;
			this.checkBox11.Visible = true;
			bool flag = File.Exists("C:\\ProgramData\\atomicconfigg.txt");
			if (flag)
			{
				string text = File.ReadAllText("C:\\ProgramData\\atomicconfigg.txt");
				bool flag2 = text.Contains("numberprotect");
				if (flag2)
				{
					this.checkBox2.Checked = true;
				}
				bool flag3 = text.Contains("stringenc");
				if (flag3)
				{
					this.checkBox6.Checked = true;
				}
				bool flag4 = text.Contains("cflow");
				if (flag4)
				{
					this.checkBox5.Checked = true;
				}
				bool flag5 = text.Contains("renamer");
				if (flag5)
				{
					this.checkBox4.Checked = true;
				}
				bool flag6 = text.Contains("mutation");
				if (flag6)
				{
					this.checkBox3.Checked = true;
				}
				bool flag7 = text.Contains("packer");
				if (flag7)
				{
					this.checkBox1.Checked = true;
				}
				bool flag8 = text.Contains("antidump");
				if (flag8)
				{
					this.checkBox7.Checked = true;
				}
				bool flag9 = text.Contains("calli");
				if (flag9)
				{
					this.checkBox8.Checked = true;
				}
				bool flag10 = text.Contains("hideallmethods");
				if (flag10)
				{
					this.checkBox9.Checked = true;
				}
				bool flag11 = text.Contains("resourcespammer");
				if (flag11)
				{
					this.checkBox10.Checked = true;
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003540 File Offset: 0x00001740
		private void button5_Click(object sender, EventArgs e)
		{
			this.label7.Visible = false;
			this.textBox2.Visible = false;
			this.button7.Visible = false;
			this.label5.Visible = true;
			this.button6.Visible = true;
			this.checkBox2.Visible = false;
			this.checkBox6.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox4.Visible = false;
			this.checkBox5.Visible = false;
			this.checkBox3.Visible = false;
			this.checkBox1.Visible = false;
			this.checkBox7.Visible = false;
			this.checkBox8.Visible = false;
			this.checkBox9.Visible = false;
			this.checkBox10.Visible = false;
			this.checkBox11.Visible = false;
			bool flag = File.Exists("C:\\ProgramData\\atomicconfigg.txt");
			if (flag)
			{
				FileInfo fileInfo = new FileInfo("C:\\ProgramData\\atomicconfigg.txt");
				DateTime lastWriteTime = fileInfo.LastWriteTime;
				this.label5.Text = "Status: Last saved: " + lastWriteTime.ToString();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000366C File Offset: 0x0000186C
		private void textBox2_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				bool flag = array != null;
				if (flag)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					bool flag2 = num != -1;
					if (flag2)
					{
						string a = text.Substring(num).ToLower();
						bool flag3 = a == ".exe" || a == ".dll";
						if (flag3)
						{
							base.Activate();
							this.textBox2.Text = text;
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003724 File Offset: 0x00001924
		private void textBox2_DragEnter(object sender, DragEventArgs e)
		{
			bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
			if (dataPresent)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003758 File Offset: 0x00001958
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003758 File Offset: 0x00001958
		private void label3_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003758 File Offset: 0x00001958
		private void label4_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003758 File Offset: 0x00001958
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003758 File Offset: 0x00001958
		private void label7_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000020B9 File Offset: 0x000002B9
		private void button3_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000020B9 File Offset: 0x000002B9
		private void button4_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000020B9 File Offset: 0x000002B9
		private void button5_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000020B9 File Offset: 0x000002B9
		private void button2_KeyDown(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox2_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox6_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox5_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox4_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox3_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000020C6 File Offset: 0x000002C6
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			this.AntiDumper = !this.AntiDumper;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox7_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000020B9 File Offset: 0x000002B9
		private void checkBox1_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003758 File Offset: 0x00001958
		private void label5_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003758 File Offset: 0x00001958
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000020D8 File Offset: 0x000002D8
		private void label6_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/Bwk5c8R");
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000020E6 File Offset: 0x000002E6
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			this.Numbers = !this.Numbers;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000020F8 File Offset: 0x000002F8
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			this.Strings = !this.Strings;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000210A File Offset: 0x0000030A
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			this.Cflow = !this.Cflow;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000211C File Offset: 0x0000031C
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			this.Renamer = !this.Renamer;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000212E File Offset: 0x0000032E
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			this.Mutation = !this.Mutation;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002140 File Offset: 0x00000340
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.Packer = !this.Packer;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002152 File Offset: 0x00000352
		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			this.Calli = !this.Calli;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002164 File Offset: 0x00000364
		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			this.HideAllMethods = !this.HideAllMethods;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002176 File Offset: 0x00000376
		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			this.ResourceSpammer = !this.ResourceSpammer;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002188 File Offset: 0x00000388
		private void checkBox11_CheckedChanged(object sender, EventArgs e)
		{
			this.Virtualization = !this.Virtualization;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000219A File Offset: 0x0000039A
		private void label4_Paint(object sender, PaintEventArgs e)
		{
			this.label4.Text = "Current User: " + Environment.UserName;
		}

		// Token: 0x04000001 RID: 1
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000002 RID: 2
		public const int HT_CAPTION = 2;

		// Token: 0x04000008 RID: 8
		private bool Strings = false;

		// Token: 0x04000009 RID: 9
		private bool Numbers = false;

		// Token: 0x0400000A RID: 10
		private bool Cflow = false;

		// Token: 0x0400000B RID: 11
		private bool Renamer = false;

		// Token: 0x0400000C RID: 12
		private bool Mutation = false;

		// Token: 0x0400000D RID: 13
		private bool Packer = false;

		// Token: 0x0400000E RID: 14
		private bool AntiDumper = false;

		// Token: 0x0400000F RID: 15
		private bool Calli = false;

		// Token: 0x04000010 RID: 16
		private bool HideAllMethods = false;

		// Token: 0x04000011 RID: 17
		private bool ResourceSpammer = false;

		// Token: 0x04000012 RID: 18
		private bool Virtualization = false;

		// Token: 0x04000013 RID: 19
		private static Random random = new Random();
	}
}
