/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 6/02/2013
 * Time: 10:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinformsTiming
{
	partial class ResultsPrint
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ChooseRace = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Race = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BibNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Sex = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GunStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChipStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChipEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ManualEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NettTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GunTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Laps = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OverallPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GenderPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CatPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AgeCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unique_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// ChooseRace
			// 
			this.ChooseRace.FormattingEnabled = true;
			this.ChooseRace.Location = new System.Drawing.Point(-1, 8);
			this.ChooseRace.Name = "ChooseRace";
			this.ChooseRace.Size = new System.Drawing.Size(166, 21);
			this.ChooseRace.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(171, 6);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(93, 24);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Finishers Only";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(552, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Show Runners";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(797, 5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Print Current View";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(280, 6);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 24);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "Male OR";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(366, 6);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(75, 24);
			this.checkBox3.TabIndex = 11;
			this.checkBox3.Text = "Female";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(461, 6);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(71, 24);
			this.checkBox4.TabIndex = 12;
			this.checkBox4.Text = "AgeCat";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(691, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 27);
			this.label1.TabIndex = 13;
			this.label1.Text = "Click the Column Headers to Sort";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(953, 6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(119, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "Create Html";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToOrderColumns = true;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.FName,
									this.LName,
									this.Race,
									this.BibNumber,
									this.Status,
									this.Sex,
									this.Age,
									this.GunStart,
									this.ChipStart,
									this.ChipEnd,
									this.ManualEnd,
									this.NettTotal,
									this.GunTotal,
									this.Laps,
									this.DOB,
									this.OverallPos,
									this.GenderPos,
									this.CatPos,
									this.AgeCat,
									this.EPC,
									this.unique_key});
			this.dataGridView2.GridColor = System.Drawing.SystemColors.ControlLight;
			this.dataGridView2.Location = new System.Drawing.Point(12, 36);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ShowCellErrors = false;
			this.dataGridView2.ShowRowErrors = false;
			this.dataGridView2.Size = new System.Drawing.Size(1164, 371);
			this.dataGridView2.TabIndex = 15;
			this.dataGridView2.VirtualMode = true;
			// 
			// FName
			// 
			this.FName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.FName.DataPropertyName = "Fname";
			this.FName.HeaderText = "First Name";
			this.FName.MinimumWidth = 4;
			this.FName.Name = "FName";
			this.FName.ReadOnly = true;
			this.FName.Width = 76;
			// 
			// LName
			// 
			this.LName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.LName.DataPropertyName = "Lname";
			this.LName.HeaderText = "Last Name";
			this.LName.Name = "LName";
			this.LName.ReadOnly = true;
			this.LName.Width = 77;
			// 
			// Race
			// 
			this.Race.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Race.DataPropertyName = "Race";
			this.Race.HeaderText = "Race";
			this.Race.Name = "Race";
			this.Race.ReadOnly = true;
			this.Race.Visible = false;
			this.Race.Width = 58;
			// 
			// BibNumber
			// 
			this.BibNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.BibNumber.DataPropertyName = "BibNumber";
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = null;
			this.BibNumber.DefaultCellStyle = dataGridViewCellStyle1;
			this.BibNumber.HeaderText = "Bib No:";
			this.BibNumber.Name = "BibNumber";
			this.BibNumber.Width = 62;
			// 
			// Status
			// 
			this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.Status.DataPropertyName = "Status";
			this.Status.HeaderText = "Status";
			this.Status.Items.AddRange(new object[] {
									"",
									"DNS",
									"Started",
									"DNF",
									"Finished",
									"DQ",
									"PRW",
									"Unranked",
									"Unknown"});
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			this.Status.Width = 43;
			// 
			// Sex
			// 
			this.Sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Sex.DataPropertyName = "Sex";
			this.Sex.HeaderText = "Sex";
			this.Sex.Items.AddRange(new object[] {
									"",
									"Male",
									"Female"});
			this.Sex.Name = "Sex";
			this.Sex.ReadOnly = true;
			this.Sex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Sex.Width = 50;
			// 
			// Age
			// 
			this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Age.DataPropertyName = "Age";
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = null;
			this.Age.DefaultCellStyle = dataGridViewCellStyle2;
			this.Age.HeaderText = "Age";
			this.Age.Name = "Age";
			this.Age.Visible = false;
			this.Age.Width = 51;
			// 
			// GunStart
			// 
			this.GunStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.GunStart.DataPropertyName = "GunStart";
			dataGridViewCellStyle3.Format = "G";
			dataGridViewCellStyle3.NullValue = null;
			this.GunStart.DefaultCellStyle = dataGridViewCellStyle3;
			this.GunStart.HeaderText = "Gun Start Time";
			this.GunStart.Name = "GunStart";
			this.GunStart.Visible = false;
			// 
			// ChipStart
			// 
			this.ChipStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ChipStart.DataPropertyName = "ChipStart";
			dataGridViewCellStyle4.Format = "G";
			dataGridViewCellStyle4.NullValue = null;
			this.ChipStart.DefaultCellStyle = dataGridViewCellStyle4;
			this.ChipStart.HeaderText = "Chip Start Time";
			this.ChipStart.Name = "ChipStart";
			this.ChipStart.Visible = false;
			// 
			// ChipEnd
			// 
			this.ChipEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ChipEnd.DataPropertyName = "ChipEnd";
			dataGridViewCellStyle5.Format = "G";
			dataGridViewCellStyle5.NullValue = null;
			this.ChipEnd.DefaultCellStyle = dataGridViewCellStyle5;
			this.ChipEnd.HeaderText = "Chip Finish Time";
			this.ChipEnd.Name = "ChipEnd";
			this.ChipEnd.Visible = false;
			// 
			// ManualEnd
			// 
			this.ManualEnd.DataPropertyName = "ManualEnd";
			dataGridViewCellStyle6.Format = "G";
			dataGridViewCellStyle6.NullValue = null;
			this.ManualEnd.DefaultCellStyle = dataGridViewCellStyle6;
			this.ManualEnd.HeaderText = "Manual Finish Time";
			this.ManualEnd.Name = "ManualEnd";
			this.ManualEnd.Visible = false;
			this.ManualEnd.Width = 92;
			// 
			// NettTotal
			// 
			this.NettTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.NettTotal.DataPropertyName = "NettTotal";
			dataGridViewCellStyle7.Format = "G";
			dataGridViewCellStyle7.NullValue = null;
			this.NettTotal.DefaultCellStyle = dataGridViewCellStyle7;
			this.NettTotal.HeaderText = "Nett Time";
			this.NettTotal.Name = "NettTotal";
			this.NettTotal.Visible = false;
			this.NettTotal.Width = 72;
			// 
			// GunTotal
			// 
			this.GunTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GunTotal.DataPropertyName = "GunTotal";
			dataGridViewCellStyle8.Format = "G";
			dataGridViewCellStyle8.NullValue = null;
			this.GunTotal.DefaultCellStyle = dataGridViewCellStyle8;
			this.GunTotal.HeaderText = "Gun Time";
			this.GunTotal.Name = "GunTotal";
			this.GunTotal.Width = 72;
			// 
			// Laps
			// 
			this.Laps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Laps.DataPropertyName = "Laps";
			dataGridViewCellStyle9.Format = "N0";
			dataGridViewCellStyle9.NullValue = null;
			this.Laps.DefaultCellStyle = dataGridViewCellStyle9;
			this.Laps.HeaderText = "Laps";
			this.Laps.Name = "Laps";
			this.Laps.Width = 55;
			// 
			// DOB
			// 
			this.DOB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.DOB.DataPropertyName = "DOB";
			dataGridViewCellStyle10.Format = "d";
			dataGridViewCellStyle10.NullValue = null;
			this.DOB.DefaultCellStyle = dataGridViewCellStyle10;
			this.DOB.HeaderText = "DOB";
			this.DOB.Name = "DOB";
			this.DOB.Visible = false;
			this.DOB.Width = 55;
			// 
			// OverallPos
			// 
			this.OverallPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.OverallPos.DataPropertyName = "OverallPos";
			dataGridViewCellStyle11.Format = "N0";
			this.OverallPos.DefaultCellStyle = dataGridViewCellStyle11;
			this.OverallPos.HeaderText = "Overall Position";
			this.OverallPos.Name = "OverallPos";
			this.OverallPos.Width = 50;
			// 
			// GenderPos
			// 
			this.GenderPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.GenderPos.DataPropertyName = "GenderPos";
			dataGridViewCellStyle12.Format = "N0";
			this.GenderPos.DefaultCellStyle = dataGridViewCellStyle12;
			this.GenderPos.HeaderText = "Gender Position";
			this.GenderPos.Name = "GenderPos";
			this.GenderPos.Width = 50;
			// 
			// CatPos
			// 
			this.CatPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.CatPos.DataPropertyName = "CatPos";
			dataGridViewCellStyle13.Format = "N0";
			this.CatPos.DefaultCellStyle = dataGridViewCellStyle13;
			this.CatPos.HeaderText = "Category Position";
			this.CatPos.Name = "CatPos";
			this.CatPos.Width = 50;
			// 
			// AgeCat
			// 
			this.AgeCat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.AgeCat.DataPropertyName = "AgeCat";
			this.AgeCat.HeaderText = "Cat";
			this.AgeCat.Name = "AgeCat";
			this.AgeCat.ReadOnly = true;
			this.AgeCat.Width = 48;
			// 
			// EPC
			// 
			this.EPC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.EPC.DataPropertyName = "EPC";
			this.EPC.HeaderText = "EPC";
			this.EPC.Name = "EPC";
			this.EPC.ReadOnly = true;
			this.EPC.ToolTipText = "Tag Unique Code";
			this.EPC.Visible = false;
			this.EPC.Width = 53;
			// 
			// unique_key
			// 
			this.unique_key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.unique_key.DataPropertyName = "unique_key";
			this.unique_key.HeaderText = "Key";
			this.unique_key.Name = "unique_key";
			this.unique_key.ReadOnly = true;
			this.unique_key.ToolTipText = "Fixed";
			this.unique_key.Visible = false;
			this.unique_key.Width = 50;
			// 
			// ResultsPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1261, 407);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.ChooseRace);
			this.Name = "ResultsPrint";
			this.Text = "ResultsPrint";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn unique_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn EPC;
		private System.Windows.Forms.DataGridViewTextBoxColumn AgeCat;
		private System.Windows.Forms.DataGridViewTextBoxColumn CatPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn GenderPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn OverallPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
		private System.Windows.Forms.DataGridViewTextBoxColumn Laps;
		private System.Windows.Forms.DataGridViewTextBoxColumn GunTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn NettTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn ManualEnd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChipEnd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChipStart;
		private System.Windows.Forms.DataGridViewTextBoxColumn GunStart;
		private System.Windows.Forms.DataGridViewTextBoxColumn Age;
		private System.Windows.Forms.DataGridViewComboBoxColumn Sex;
		private System.Windows.Forms.DataGridViewComboBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn BibNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn Race;
		private System.Windows.Forms.DataGridViewTextBoxColumn LName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FName;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox ChooseRace;
	}
}
