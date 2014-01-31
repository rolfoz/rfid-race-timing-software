/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 28/01/2013
 * Time: 3:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinformsTiming
	

{
	
	

	
	partial class TimingCode
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.EnterEPC = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBoxAll = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.CausesValidation = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(21, 56);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(1137, 276);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellContentClick);
			// 
			// numericUpDownMinutes
			// 
			this.numericUpDownMinutes.Location = new System.Drawing.Point(68, 30);
			this.numericUpDownMinutes.Maximum = new decimal(new int[] {
									60000,
									0,
									0,
									0});
			this.numericUpDownMinutes.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numericUpDownMinutes.Name = "numericUpDownMinutes";
			this.numericUpDownMinutes.Size = new System.Drawing.Size(72, 20);
			this.numericUpDownMinutes.TabIndex = 12;
			this.numericUpDownMinutes.Value = new decimal(new int[] {
									60,
									0,
									0,
									0});
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(211, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Search";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// EnterEPC
			// 
			this.EnterEPC.Location = new System.Drawing.Point(68, 6);
			this.EnterEPC.Name = "EnterEPC";
			this.EnterEPC.Size = new System.Drawing.Size(100, 20);
			this.EnterEPC.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 14);
			this.label4.TabIndex = 14;
			this.label4.Text = "Last";
			// 
			// checkBoxAll
			// 
			this.checkBoxAll.Location = new System.Drawing.Point(174, 4);
			this.checkBoxAll.Name = "checkBoxAll";
			this.checkBoxAll.Size = new System.Drawing.Size(46, 24);
			this.checkBoxAll.TabIndex = 1;
			this.checkBoxAll.Text = "All";
			this.checkBoxAll.UseVisualStyleBackColor = true;
			this.checkBoxAll.CheckedChanged += new System.EventHandler(this.CheckBoxAllCheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(156, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Minutes";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(481, 9);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "Print View";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(606, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 19);
			this.label2.TabIndex = 9;
			this.label2.Text = "Delete Tags Between";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(726, 3);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Show Only";
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(726, 32);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2.TabIndex = 15;
			// 
			// TimingCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 343);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDownMinutes);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.EnterEPC);
			this.Controls.Add(this.checkBoxAll);
			this.Name = "TimingCode";
			this.Text = "TimingCode";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.CheckBox checkBoxAll;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox EnterEPC;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		//private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
