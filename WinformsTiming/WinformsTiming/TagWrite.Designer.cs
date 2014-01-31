/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 1/02/2013
 * Time: 4:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinformsTiming
{
	partial class TagWrite
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewCurrentTags = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.NewEpcInput = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.epc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentTags)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewCurrentTags
			// 
			this.dataGridViewCurrentTags.AllowUserToAddRows = false;
			this.dataGridViewCurrentTags.AllowUserToDeleteRows = false;
			this.dataGridViewCurrentTags.AllowUserToOrderColumns = true;
			this.dataGridViewCurrentTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewCurrentTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewCurrentTags.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridViewCurrentTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCurrentTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.epc,
									this.ts});
			this.dataGridViewCurrentTags.DataMember = "dataGridViewCurrentTags";
			this.dataGridViewCurrentTags.Location = new System.Drawing.Point(12, 88);
			this.dataGridViewCurrentTags.MinimumSize = new System.Drawing.Size(200, 0);
			this.dataGridViewCurrentTags.Name = "dataGridViewCurrentTags";
			this.dataGridViewCurrentTags.Size = new System.Drawing.Size(756, 172);
			this.dataGridViewCurrentTags.TabIndex = 0;
			this.dataGridViewCurrentTags.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCurrentTagsCellContentClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tags Currently in View";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// NewEpcInput
			// 
			this.NewEpcInput.Location = new System.Drawing.Point(171, 16);
			this.NewEpcInput.MaxLength = 24;
			this.NewEpcInput.Name = "NewEpcInput";
			this.NewEpcInput.Size = new System.Drawing.Size(100, 20);
			this.NewEpcInput.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(65, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Enter New EPC";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(333, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(205, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Click the tag below to write it";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(288, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 24);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "Auto Increment?";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(434, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(123, 24);
			this.checkBox2.TabIndex = 7;
			this.checkBox2.Text = "Confirm Tag Writes?";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(171, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(47, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "+1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// epc
			// 
			this.epc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.epc.DataPropertyName = "epc";
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
			this.epc.DefaultCellStyle = dataGridViewCellStyle1;
			this.epc.HeaderText = "Current EPC";
			this.epc.MinimumWidth = 20;
			this.epc.Name = "epc";
			this.epc.ReadOnly = true;
			this.epc.Width = 90;
			// 
			// ts
			// 
			this.ts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.ts.DataPropertyName = "ts";
			this.ts.HeaderText = "Last Seen Time";
			this.ts.Name = "ts";
			this.ts.ReadOnly = true;
			this.ts.Width = 97;
			// 
			// TagWrite
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(821, 311);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NewEpcInput);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridViewCurrentTags);
			this.Name = "TagWrite";
			this.Text = "TagWrite";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentTags)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NewEpcInput;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ts;
		private System.Windows.Forms.DataGridViewTextBoxColumn epc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridViewCurrentTags;
	}
}
