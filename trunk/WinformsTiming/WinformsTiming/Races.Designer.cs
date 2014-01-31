/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 3/02/2013
 * Time: 2:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinformsTiming
{
	partial class Races
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
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.unique_ud = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.RaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceLaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceWave1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceWave2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceWave3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AgeCalcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceOver = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.LapDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChooseRace = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBoxRaceName = new System.Windows.Forms.TextBox();
			this.textBoxRaceLaps = new System.Windows.Forms.TextBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.textBoxRaceLength = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Race to Edit";
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.unique_ud,
									this.RaceHours,
									this.RaceType,
									this.RaceName,
									this.RaceNumber,
									this.RaceLaps,
									this.RaceLength,
									this.RaceDate,
									this.RaceStart,
									this.RaceWave1,
									this.RaceWave2,
									this.RaceWave3,
									this.AgeCalcDate,
									this.RaceOver,
									this.LapDistance});
			this.dataGridView1.Location = new System.Drawing.Point(12, 181);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGridView1.Size = new System.Drawing.Size(1240, 230);
			this.dataGridView1.TabIndex = 0;
			
			// 
			// unique_ud
			// 
			this.unique_ud.DataPropertyName = "unique_id";
			this.unique_ud.HeaderText = "Unique ID";
			this.unique_ud.Name = "unique_ud";
			this.unique_ud.ReadOnly = true;
			this.unique_ud.Visible = false;
			this.unique_ud.Width = 80;
			// 
			// RaceHours
			// 
			this.RaceHours.DataPropertyName = "RaceHours";
			this.RaceHours.HeaderText = "Race Length(Hrs)";
			this.RaceHours.Name = "RaceHours";
			this.RaceHours.Width = 106;
			// 
			// RaceType
			// 
			this.RaceType.DataPropertyName = "RaceType";
			this.RaceType.HeaderText = "Race Type";
			this.RaceType.Items.AddRange(new object[] {
									"Normal",
									"Laps",
									"Period"});
			this.RaceType.Name = "RaceType";
			this.RaceType.Width = 59;
			// 
			// RaceName
			// 
			this.RaceName.DataPropertyName = "RaceName";
			this.RaceName.HeaderText = "Race Name";
			this.RaceName.Name = "RaceName";
			this.RaceName.Width = 82;
			// 
			// RaceNumber
			// 
			this.RaceNumber.DataPropertyName = "RaceNumber";
			this.RaceNumber.HeaderText = "Race Number";
			this.RaceNumber.Name = "RaceNumber";
			this.RaceNumber.Width = 90;
			// 
			// RaceLaps
			// 
			this.RaceLaps.DataPropertyName = "RaceLaps";
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = null;
			this.RaceLaps.DefaultCellStyle = dataGridViewCellStyle1;
			this.RaceLaps.HeaderText = "Race Laps";
			this.RaceLaps.Name = "RaceLaps";
			this.RaceLaps.Width = 78;
			// 
			// RaceLength
			// 
			this.RaceLength.DataPropertyName = "RaceLength";
			dataGridViewCellStyle2.Format = "N2";
			dataGridViewCellStyle2.NullValue = null;
			this.RaceLength.DefaultCellStyle = dataGridViewCellStyle2;
			this.RaceLength.HeaderText = "Race Length(km)";
			this.RaceLength.Name = "RaceLength";
			this.RaceLength.Width = 105;
			// 
			// RaceDate
			// 
			this.RaceDate.DataPropertyName = "RaceDate";
			dataGridViewCellStyle3.Format = "d";
			dataGridViewCellStyle3.NullValue = null;
			this.RaceDate.DefaultCellStyle = dataGridViewCellStyle3;
			this.RaceDate.HeaderText = "Race Date";
			this.RaceDate.Name = "RaceDate";
			this.RaceDate.Width = 78;
			// 
			// RaceStart
			// 
			this.RaceStart.DataPropertyName = "RaceStart";
			dataGridViewCellStyle4.Format = "G";
			dataGridViewCellStyle4.NullValue = null;
			this.RaceStart.DefaultCellStyle = dataGridViewCellStyle4;
			this.RaceStart.HeaderText = "Race Start";
			this.RaceStart.Name = "RaceStart";
			this.RaceStart.Width = 77;
			// 
			// RaceWave1
			// 
			this.RaceWave1.DataPropertyName = "RaceWave1";
			dataGridViewCellStyle5.Format = "G";
			dataGridViewCellStyle5.NullValue = null;
			this.RaceWave1.DefaultCellStyle = dataGridViewCellStyle5;
			this.RaceWave1.HeaderText = "Wave 1 Start";
			this.RaceWave1.Name = "RaceWave1";
			this.RaceWave1.Width = 68;
			// 
			// RaceWave2
			// 
			this.RaceWave2.DataPropertyName = "RaceWave2";
			dataGridViewCellStyle6.Format = "G";
			dataGridViewCellStyle6.NullValue = null;
			this.RaceWave2.DefaultCellStyle = dataGridViewCellStyle6;
			this.RaceWave2.HeaderText = "Wave 2 Start";
			this.RaceWave2.Name = "RaceWave2";
			this.RaceWave2.Width = 68;
			// 
			// RaceWave3
			// 
			this.RaceWave3.DataPropertyName = "RaceWave3";
			dataGridViewCellStyle7.Format = "G";
			dataGridViewCellStyle7.NullValue = null;
			this.RaceWave3.DefaultCellStyle = dataGridViewCellStyle7;
			this.RaceWave3.HeaderText = "Wave 3 Start";
			this.RaceWave3.Name = "RaceWave3";
			this.RaceWave3.Width = 68;
			// 
			// AgeCalcDate
			// 
			this.AgeCalcDate.DataPropertyName = "AgeCalcDate";
			dataGridViewCellStyle8.Format = "d";
			dataGridViewCellStyle8.NullValue = null;
			this.AgeCalcDate.DefaultCellStyle = dataGridViewCellStyle8;
			this.AgeCalcDate.HeaderText = "Age Calc Date";
			this.AgeCalcDate.Name = "AgeCalcDate";
			this.AgeCalcDate.Width = 93;
			// 
			// RaceOver
			// 
			this.RaceOver.DataPropertyName = "RaceOver";
			this.RaceOver.HeaderText = "Race Over";
			this.RaceOver.Items.AddRange(new object[] {
									"Not Started",
									"Running",
									"Finished"});
			this.RaceOver.Name = "RaceOver";
			this.RaceOver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.RaceOver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.RaceOver.Width = 78;
			// 
			// LapDistance
			// 
			this.LapDistance.DataPropertyName = "LapDistance";
			dataGridViewCellStyle9.Format = "N2";
			dataGridViewCellStyle9.NullValue = null;
			this.LapDistance.DefaultCellStyle = dataGridViewCellStyle9;
			this.LapDistance.HeaderText = "Lap Distance(km)";
			this.LapDistance.Name = "LapDistance";
			this.LapDistance.Width = 105;
			// 
			// ChooseRace
			// 
			this.ChooseRace.FormattingEnabled = true;
			this.ChooseRace.Location = new System.Drawing.Point(118, 0);
			this.ChooseRace.Name = "ChooseRace";
			this.ChooseRace.Size = new System.Drawing.Size(121, 21);
			this.ChooseRace.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(245, 0);
			this.button1.Name = "button1";
			this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Show";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 152);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(196, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Save Changes Below";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(261, 155);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(294, 20);
			this.textBox1.TabIndex = 6;
			this.textBox1.Text = "Normal = 1 Lap, Laps = Count Laps, Period = Hrs (ie 6Hr)";
			// 
			// textBoxRaceName
			// 
			this.textBoxRaceName.Location = new System.Drawing.Point(12, 54);
			this.textBoxRaceName.Name = "textBoxRaceName";
			this.textBoxRaceName.ReadOnly = true;
			this.textBoxRaceName.Size = new System.Drawing.Size(225, 20);
			this.textBoxRaceName.TabIndex = 7;
			// 
			// textBoxRaceLaps
			// 
			this.textBoxRaceLaps.Location = new System.Drawing.Point(585, 54);
			this.textBoxRaceLaps.Name = "textBoxRaceLaps";
			this.textBoxRaceLaps.Size = new System.Drawing.Size(53, 20);
			this.textBoxRaceLaps.TabIndex = 8;
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Items.AddRange(new object[] {
									"",
									"Not Started",
									"Finished",
									"Running"});
			this.comboBoxStatus.Location = new System.Drawing.Point(273, 54);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(121, 21);
			this.comboBoxStatus.TabIndex = 9;
			// 
			// comboBoxType
			// 
			this.comboBoxType.FormattingEnabled = true;
			this.comboBoxType.Items.AddRange(new object[] {
									"",
									"Normal",
									"Laps",
									"Period"});
			this.comboBoxType.Location = new System.Drawing.Point(434, 54);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(121, 21);
			this.comboBoxType.TabIndex = 10;
			// 
			// textBoxRaceLength
			// 
			this.textBoxRaceLength.Location = new System.Drawing.Point(670, 54);
			this.textBoxRaceLength.Name = "textBoxRaceLength";
			this.textBoxRaceLength.Size = new System.Drawing.Size(61, 20);
			this.textBoxRaceLength.TabIndex = 11;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(763, 52);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(126, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "Save Changes";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Race Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(273, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 14;
			this.label3.Text = "Race Status";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(434, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 15);
			this.label4.TabIndex = 15;
			this.label4.Text = "Race Type";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(585, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 15);
			this.label5.TabIndex = 16;
			this.label5.Text = "Laps";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(670, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 15);
			this.label6.TabIndex = 17;
			this.label6.Text = "Hours";
			// 
			// Races
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 414);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBoxRaceLength);
			this.Controls.Add(this.comboBoxType);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.textBoxRaceLaps);
			this.Controls.Add(this.textBoxRaceName);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.ChooseRace);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Name = "Races";
			this.Text = "Races";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBoxRaceLength;
		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.ComboBox comboBoxStatus;
		private System.Windows.Forms.TextBox textBoxRaceLaps;
		private System.Windows.Forms.TextBox textBoxRaceName;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGridViewComboBoxColumn RaceType;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceHours;
		private System.Windows.Forms.DataGridViewTextBoxColumn LapDistance;
		private System.Windows.Forms.DataGridViewComboBoxColumn RaceOver;
		private System.Windows.Forms.DataGridViewTextBoxColumn AgeCalcDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceWave3;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceWave2;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceWave1;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceStart;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceLength;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceLaps;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn RaceName;
		private System.Windows.Forms.DataGridViewTextBoxColumn unique_ud;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox ChooseRace;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		
		
		
		
	}
}
