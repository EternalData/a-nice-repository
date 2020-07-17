namespace AtomicObfuscator
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00003794 File Offset: 0x00001994
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000037CC File Offset: 0x000019CC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AtomicObfuscator.Form1));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.button6 = new global::System.Windows.Forms.Button();
			this.checkBox7 = new global::System.Windows.Forms.CheckBox();
			this.checkBox6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.button7 = new global::System.Windows.Forms.Button();
			this.checkBox8 = new global::System.Windows.Forms.CheckBox();
			this.checkBox9 = new global::System.Windows.Forms.CheckBox();
			this.checkBox10 = new global::System.Windows.Forms.CheckBox();
			this.checkBox11 = new global::System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(0, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(831, 22);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label6.Location = new global::System.Drawing.Point(481, 4);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(166, 15);
			this.label6.TabIndex = 37;
			this.label6.Text = "Click to join Discord For Help";
			this.label6.Click += new global::System.EventHandler(this.label6_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label4.Location = new global::System.Drawing.Point(318, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(84, 15);
			this.label4.TabIndex = 23;
			this.label4.Text = "Current User: ";
			this.label4.Paint += new global::System.Windows.Forms.PaintEventHandler(this.label4_Paint);
			this.label4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label3.Location = new global::System.Drawing.Point(164, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(132, 15);
			this.label3.TabIndex = 22;
			this.label3.Text = "Build Date: 06.06.2020";
			this.label3.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.FromArgb(14, 14, 14);
			this.label2.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Red;
			this.label2.Location = new global::System.Drawing.Point(774, 4);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(14, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "X";
			this.label2.Click += new global::System.EventHandler(this.label2_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label1.Location = new global::System.Drawing.Point(20, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(104, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "AtomicObfuscator";
			this.label1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			this.button1.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(311, 218);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(181, 36);
			this.button1.TabIndex = 1;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = global::System.Drawing.Color.White;
			this.textBox1.Location = new global::System.Drawing.Point(286, 189);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(253, 13);
			this.textBox1.TabIndex = 2;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label7.Location = new global::System.Drawing.Point(240, 166);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(304, 240);
			this.label7.TabIndex = 21;
			this.label7.Text = "Thank you for purchasing AtomicObfuscator!\r\n\r\nUpdates:\r\n\r\nJune 7th\r\n- Updated UI\r\n- Added Packer\r\n- Fixed bugs\r\nMay 29th\r\n- Control Flow Updated\r\n- Mutation\r\n- Number Protect Update";
			this.label7.Visible = false;
			this.label7.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label7_MouseDown);
			this.button2.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(12, 51);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(181, 36);
			this.button2.TabIndex = 22;
			this.button2.Text = "Dashboard";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Visible = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button2.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.button2_KeyDown);
			this.button3.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(210, 51);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(181, 36);
			this.button3.TabIndex = 23;
			this.button3.Text = "Obfuscate";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Visible = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button3.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
			this.button4.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(409, 51);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(181, 36);
			this.button4.TabIndex = 24;
			this.button4.Text = "Options";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Visible = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.button4_MouseDown);
			this.button5.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(606, 51);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(181, 36);
			this.button5.TabIndex = 25;
			this.button5.Text = "Save Options";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Visible = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button5.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label5.Location = new global::System.Drawing.Point(334, 266);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(125, 20);
			this.label5.TabIndex = 26;
			this.label5.Text = "Last Saved: Never";
			this.label5.Visible = false;
			this.label5.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label5_MouseDown);
			this.button6.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button6.ForeColor = global::System.Drawing.Color.White;
			this.button6.Location = new global::System.Drawing.Point(311, 217);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(181, 36);
			this.button6.TabIndex = 27;
			this.button6.Text = "Save Options";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Visible = false;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.checkBox7.AutoSize = true;
			this.checkBox7.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox7.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox7.Location = new global::System.Drawing.Point(463, 266);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new global::System.Drawing.Size(100, 24);
			this.checkBox7.TabIndex = 34;
			this.checkBox7.Text = "Anti Dump";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.Visible = false;
			this.checkBox7.CheckedChanged += new global::System.EventHandler(this.checkBox7_CheckedChanged);
			this.checkBox7.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox7_MouseDown);
			this.checkBox6.AutoSize = true;
			this.checkBox6.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox6.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox6.Location = new global::System.Drawing.Point(210, 208);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new global::System.Drawing.Size(139, 24);
			this.checkBox6.TabIndex = 33;
			this.checkBox6.Text = "String Protection";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.Visible = false;
			this.checkBox6.CheckedChanged += new global::System.EventHandler(this.checkBox6_CheckedChanged);
			this.checkBox6.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox6_MouseDown);
			this.checkBox5.AutoSize = true;
			this.checkBox5.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox5.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox5.Location = new global::System.Drawing.Point(210, 238);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new global::System.Drawing.Size(112, 24);
			this.checkBox5.TabIndex = 32;
			this.checkBox5.Text = "Control Flow";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.Visible = false;
			this.checkBox5.CheckedChanged += new global::System.EventHandler(this.checkBox5_CheckedChanged);
			this.checkBox5.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox5_MouseDown);
			this.checkBox4.AutoSize = true;
			this.checkBox4.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox4.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox4.Location = new global::System.Drawing.Point(464, 188);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(87, 24);
			this.checkBox4.TabIndex = 31;
			this.checkBox4.Text = "Renamer";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.Visible = false;
			this.checkBox4.CheckedChanged += new global::System.EventHandler(this.checkBox4_CheckedChanged);
			this.checkBox4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox4_MouseDown);
			this.checkBox3.AutoSize = true;
			this.checkBox3.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox3.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox3.Location = new global::System.Drawing.Point(463, 213);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(88, 24);
			this.checkBox3.TabIndex = 30;
			this.checkBox3.Text = "Mutation";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.Visible = false;
			this.checkBox3.CheckedChanged += new global::System.EventHandler(this.checkBox3_CheckedChanged);
			this.checkBox3.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox3_MouseDown);
			this.checkBox2.AutoSize = true;
			this.checkBox2.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox2.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox2.Location = new global::System.Drawing.Point(210, 178);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(154, 24);
			this.checkBox2.TabIndex = 29;
			this.checkBox2.Text = "Number Protection";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.Visible = false;
			this.checkBox2.CheckedChanged += new global::System.EventHandler(this.checkBox2_CheckedChanged);
			this.checkBox2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox2_MouseDown);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox1.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox1.Location = new global::System.Drawing.Point(464, 238);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(70, 24);
			this.checkBox1.TabIndex = 28;
			this.checkBox1.Text = "Packer";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			this.checkBox1.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseDown);
			this.textBox2.AllowDrop = true;
			this.textBox2.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.textBox2.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox2.ForeColor = global::System.Drawing.Color.White;
			this.textBox2.Location = new global::System.Drawing.Point(286, 189);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(253, 13);
			this.textBox2.TabIndex = 35;
			this.textBox2.Visible = false;
			this.textBox2.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.textBox2_DragDrop);
			this.textBox2.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.textBox2_DragEnter);
			this.button7.BackColor = global::System.Drawing.Color.FromArgb(41, 74, 122);
			this.button7.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button7.ForeColor = global::System.Drawing.Color.White;
			this.button7.Location = new global::System.Drawing.Point(311, 217);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(181, 36);
			this.button7.TabIndex = 36;
			this.button7.Text = "Obfuscate";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Visible = false;
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.checkBox8.AutoSize = true;
			this.checkBox8.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox8.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox8.Location = new global::System.Drawing.Point(210, 268);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new global::System.Drawing.Size(57, 24);
			this.checkBox8.TabIndex = 37;
			this.checkBox8.Text = "Calli";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox8.Visible = false;
			this.checkBox8.CheckedChanged += new global::System.EventHandler(this.checkBox8_CheckedChanged);
			this.checkBox9.AutoSize = true;
			this.checkBox9.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox9.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox9.Location = new global::System.Drawing.Point(210, 299);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new global::System.Drawing.Size(144, 24);
			this.checkBox9.TabIndex = 38;
			this.checkBox9.Text = "Hide All Methods";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.Visible = false;
			this.checkBox9.CheckedChanged += new global::System.EventHandler(this.checkBox9_CheckedChanged);
			this.checkBox10.AutoSize = true;
			this.checkBox10.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox10.ForeColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.checkBox10.Location = new global::System.Drawing.Point(464, 296);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new global::System.Drawing.Size(156, 24);
			this.checkBox10.TabIndex = 39;
			this.checkBox10.Text = "Resource Spammer";
			this.checkBox10.UseVisualStyleBackColor = true;
			this.checkBox10.Visible = false;
			this.checkBox10.CheckedChanged += new global::System.EventHandler(this.checkBox10_CheckedChanged);
			this.checkBox11.AutoSize = true;
			this.checkBox11.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox11.ForeColor = global::System.Drawing.Color.Lime;
			this.checkBox11.Location = new global::System.Drawing.Point(210, 332);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new global::System.Drawing.Size(108, 24);
			this.checkBox11.TabIndex = 40;
			this.checkBox11.Text = "Virtulization";
			this.checkBox11.UseVisualStyleBackColor = true;
			this.checkBox11.Visible = false;
			this.checkBox11.CheckedChanged += new global::System.EventHandler(this.checkBox11_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(14, 14, 14);
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.checkBox11);
			base.Controls.Add(this.checkBox10);
			base.Controls.Add(this.checkBox9);
			base.Controls.Add(this.checkBox8);
			base.Controls.Add(this.button7);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.checkBox7);
			base.Controls.Add(this.checkBox6);
			base.Controls.Add(this.checkBox5);
			base.Controls.Add(this.checkBox4);
			base.Controls.Add(this.checkBox3);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.button5);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			this.Text = "AtomicObfuscator";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000014 RID: 20
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Button button3;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Button button4;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Button button5;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Button button6;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.CheckBox checkBox7;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.CheckBox checkBox6;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.CheckBox checkBox5;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.CheckBox checkBox4;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.CheckBox checkBox3;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.TextBox textBox2;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Button button7;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.CheckBox checkBox8;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.CheckBox checkBox9;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.CheckBox checkBox10;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.CheckBox checkBox11;
	}
}
