/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 30/01/2013
 * Time: 1:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using Impinj.OctaneSdk;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Collections;
 
 
 
 
 
namespace WinformsTiming
{
	partial class runners
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.textBoxManualEnd = new System.Windows.Forms.TextBox();
			this.textBoxChipEnd = new System.Windows.Forms.TextBox();
			this.textBoxChipStart = new System.Windows.Forms.TextBox();
			this.textBoxGunStart = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBoxBib2 = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.comboBoxSex = new System.Windows.Forms.ComboBox();
			this.textBoxLname2 = new System.Windows.Forms.TextBox();
			this.textBoxFname = new System.Windows.Forms.TextBox();
			this.comboBoxRace2 = new System.Windows.Forms.ComboBox();
			this.comboBoxStatus2 = new System.Windows.Forms.ComboBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ChooseRace = new System.Windows.Forms.ComboBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BibNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Sex = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.GunStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChipStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChipEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ManualEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GunTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NettTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Laps = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceName = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.Race = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.OverallPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GenderPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CatPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AgeCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unique_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button7);
			this.splitContainer1.Panel1.Controls.Add(this.button6);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxManualEnd);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxChipEnd);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxChipStart);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxGunStart);
			this.splitContainer1.Panel1.Controls.Add(this.label13);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxBib2);
			this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxSex);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxLname2);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxFname);
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxRace2);
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxStatus2);
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxStatus);
			this.splitContainer1.Panel1.Controls.Add(this.label12);
			this.splitContainer1.Panel1.Controls.Add(this.label11);
			this.splitContainer1.Panel1.Controls.Add(this.label10);
			this.splitContainer1.Panel1.Controls.Add(this.label9);
			this.splitContainer1.Panel1.Controls.Add(this.label8);
			this.splitContainer1.Panel1.Controls.Add(this.label7);
			this.splitContainer1.Panel1.Controls.Add(this.label6);
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.button5);
			this.splitContainer1.Panel1.Controls.Add(this.button4);
			this.splitContainer1.Panel1.Controls.Add(this.button3);
			this.splitContainer1.Panel1.Controls.Add(this.button2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.ChooseRace);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
			this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2Paint);
			this.splitContainer1.Size = new System.Drawing.Size(1294, 433);
			this.splitContainer1.SplitterDistance = 184;
			this.splitContainer1.TabIndex = 0;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(281, 86);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(152, 23);
			this.button7.TabIndex = 35;
			this.button7.Text = "Save Changes";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(376, 56);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(57, 23);
			this.button6.TabIndex = 34;
			this.button6.Text = "Search";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// textBoxManualEnd
			// 
			this.textBoxManualEnd.Location = new System.Drawing.Point(540, 79);
			this.textBoxManualEnd.Name = "textBoxManualEnd";
			this.textBoxManualEnd.Size = new System.Drawing.Size(207, 20);
			this.textBoxManualEnd.TabIndex = 33;
			// 
			// textBoxChipEnd
			// 
			this.textBoxChipEnd.Location = new System.Drawing.Point(540, 53);
			this.textBoxChipEnd.Name = "textBoxChipEnd";
			this.textBoxChipEnd.ReadOnly = true;
			this.textBoxChipEnd.Size = new System.Drawing.Size(207, 20);
			this.textBoxChipEnd.TabIndex = 32;
			// 
			// textBoxChipStart
			// 
			this.textBoxChipStart.Location = new System.Drawing.Point(540, 29);
			this.textBoxChipStart.Name = "textBoxChipStart";
			this.textBoxChipStart.ReadOnly = true;
			this.textBoxChipStart.Size = new System.Drawing.Size(207, 20);
			this.textBoxChipStart.TabIndex = 31;
			// 
			// textBoxGunStart
			// 
			this.textBoxGunStart.Location = new System.Drawing.Point(540, 5);
			this.textBoxGunStart.Name = "textBoxGunStart";
			this.textBoxGunStart.Size = new System.Drawing.Size(207, 20);
			this.textBoxGunStart.TabIndex = 30;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(207, 132);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(98, 18);
			this.label13.TabIndex = 29;
			this.label13.Text = "Status (%=ALL)";
			// 
			// textBoxBib2
			// 
			this.textBoxBib2.Location = new System.Drawing.Point(270, 56);
			this.textBoxBib2.Name = "textBoxBib2";
			this.textBoxBib2.Size = new System.Drawing.Size(100, 20);
			this.textBoxBib2.TabIndex = 28;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(75, 86);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(110, 20);
			this.dateTimePicker1.TabIndex = 27;
			this.dateTimePicker1.Value = new System.DateTime(2013, 2, 26, 0, 0, 0, 0);
			// 
			// comboBoxSex
			// 
			this.comboBoxSex.FormattingEnabled = true;
			this.comboBoxSex.Items.AddRange(new object[] {
									"",
									"Male",
									"Female"});
			this.comboBoxSex.Location = new System.Drawing.Point(75, 56);
			this.comboBoxSex.Name = "comboBoxSex";
			this.comboBoxSex.Size = new System.Drawing.Size(79, 21);
			this.comboBoxSex.TabIndex = 26;
			// 
			// textBoxLname2
			// 
			this.textBoxLname2.Location = new System.Drawing.Point(75, 29);
			this.textBoxLname2.Name = "textBoxLname2";
			this.textBoxLname2.Size = new System.Drawing.Size(145, 20);
			this.textBoxLname2.TabIndex = 25;
			// 
			// textBoxFname
			// 
			this.textBoxFname.Location = new System.Drawing.Point(75, 3);
			this.textBoxFname.Name = "textBoxFname";
			this.textBoxFname.Size = new System.Drawing.Size(145, 20);
			this.textBoxFname.TabIndex = 24;
			// 
			// comboBoxRace2
			// 
			this.comboBoxRace2.FormattingEnabled = true;
			this.comboBoxRace2.Location = new System.Drawing.Point(270, 3);
			this.comboBoxRace2.Name = "comboBoxRace2";
			this.comboBoxRace2.Size = new System.Drawing.Size(175, 21);
			this.comboBoxRace2.TabIndex = 23;
			// 
			// comboBoxStatus2
			// 
			this.comboBoxStatus2.FormattingEnabled = true;
			this.comboBoxStatus2.Items.AddRange(new object[] {
									"",
									"PRW",
									"DNS",
									"Started",
									"DNF",
									"Finished",
									"DQ",
									"Unranked",
									"Unknown"});
			this.comboBoxStatus2.Location = new System.Drawing.Point(270, 29);
			this.comboBoxStatus2.Name = "comboBoxStatus2";
			this.comboBoxStatus2.Size = new System.Drawing.Size(121, 21);
			this.comboBoxStatus2.TabIndex = 22;
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Items.AddRange(new object[] {
									"",
									"PRW",
									"DNS",
									"Started",
									"DNF",
									"Finished",
									"DQ",
									"Unranked",
									"Unknown",
									"%"});
			this.comboBoxStatus.Location = new System.Drawing.Point(197, 155);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(121, 21);
			this.comboBoxStatus.TabIndex = 21;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(463, 82);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(71, 18);
			this.label12.TabIndex = 18;
			this.label12.Text = "Manual End";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(474, 59);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 18);
			this.label11.TabIndex = 17;
			this.label11.Text = "Chip End";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(481, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 18);
			this.label10.TabIndex = 16;
			this.label10.Text = "Chip Start";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(481, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 17);
			this.label9.TabIndex = 15;
			this.label9.Text = "Gun Start";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 91);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 17);
			this.label8.TabIndex = 14;
			this.label8.Text = "DOB";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(13, 59);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 18);
			this.label7.TabIndex = 13;
			this.label7.Text = "Sex";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(226, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 18);
			this.label6.TabIndex = 12;
			this.label6.Text = "Status";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(226, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "Race";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(226, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "Bib No";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "Last Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "First Name";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(1181, 151);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(110, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "Print View";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(1181, 32);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(110, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Export Results";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1181, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(110, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Import Runners";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(765, 153);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(172, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Save Changes Below";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(37, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select Race";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(343, 153);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Show Runners";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// ChooseRace
			// 
			this.ChooseRace.FormattingEnabled = true;
			this.ChooseRace.Location = new System.Drawing.Point(0, 153);
			this.ChooseRace.Name = "ChooseRace";
			this.ChooseRace.Size = new System.Drawing.Size(175, 21);
			this.ChooseRace.TabIndex = 0;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToOrderColumns = true;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.FName,
									this.LName,
									this.BibNumber,
									this.Status,
									this.Sex,
									this.GunStart,
									this.ChipStart,
									this.ChipEnd,
									this.ManualEnd,
									this.GunTotal,
									this.NettTotal,
									this.DOB,
									this.EPC,
									this.Laps,
									this.RaceName,
									this.Age});
			this.dataGridView2.Location = new System.Drawing.Point(0, 3);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(1291, 239);
			this.dataGridView2.TabIndex = 0;
			this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2CellContentClick);
			this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Somethingsmellsfunny);
			this.dataGridView2.RowErrorTextNeeded += new System.Windows.Forms.DataGridViewRowErrorTextNeededEventHandler(this.Doh);
			// 
			// FName
			// 
			this.FName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FName.DataPropertyName = "Fname";
			this.FName.HeaderText = "First Name";
			this.FName.Name = "FName";
			// 
			// LName
			// 
			this.LName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.LName.DataPropertyName = "Lname";
			this.LName.HeaderText = "Last Name";
			this.LName.Name = "LName";
			this.LName.Width = 77;
			// 
			// BibNumber
			// 
			this.BibNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
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
			this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
			this.Sex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Sex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Sex.Width = 50;
			// 
			// GunStart
			// 
			this.GunStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.GunStart.DataPropertyName = "GunStart";
			dataGridViewCellStyle2.Format = "G";
			dataGridViewCellStyle2.NullValue = null;
			this.GunStart.DefaultCellStyle = dataGridViewCellStyle2;
			this.GunStart.HeaderText = "Gun Start Time";
			this.GunStart.Name = "GunStart";
			// 
			// ChipStart
			// 
			this.ChipStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ChipStart.DataPropertyName = "ChipStart";
			dataGridViewCellStyle3.Format = "G";
			dataGridViewCellStyle3.NullValue = null;
			this.ChipStart.DefaultCellStyle = dataGridViewCellStyle3;
			this.ChipStart.HeaderText = "Chip Start Time";
			this.ChipStart.Name = "ChipStart";
			// 
			// ChipEnd
			// 
			this.ChipEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ChipEnd.DataPropertyName = "ChipEnd";
			dataGridViewCellStyle4.Format = "G";
			dataGridViewCellStyle4.NullValue = null;
			this.ChipEnd.DefaultCellStyle = dataGridViewCellStyle4;
			this.ChipEnd.HeaderText = "Chip Finish Time";
			this.ChipEnd.Name = "ChipEnd";
			// 
			// ManualEnd
			// 
			this.ManualEnd.DataPropertyName = "ManualEnd";
			dataGridViewCellStyle5.Format = "G";
			dataGridViewCellStyle5.NullValue = null;
			this.ManualEnd.DefaultCellStyle = dataGridViewCellStyle5;
			this.ManualEnd.HeaderText = "Manual Finish Time";
			this.ManualEnd.Name = "ManualEnd";
			// 
			// GunTotal
			// 
			this.GunTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.GunTotal.DataPropertyName = "GunTotal";
			dataGridViewCellStyle6.Format = "G";
			dataGridViewCellStyle6.NullValue = null;
			this.GunTotal.DefaultCellStyle = dataGridViewCellStyle6;
			this.GunTotal.HeaderText = "Gun Time";
			this.GunTotal.Name = "GunTotal";
			this.GunTotal.Width = 72;
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
			this.NettTotal.Width = 72;
			// 
			// DOB
			// 
			this.DOB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.DOB.DataPropertyName = "DOB";
			dataGridViewCellStyle8.Format = "d";
			dataGridViewCellStyle8.NullValue = null;
			this.DOB.DefaultCellStyle = dataGridViewCellStyle8;
			this.DOB.HeaderText = "DOB";
			this.DOB.Name = "DOB";
			this.DOB.Width = 55;
			// 
			// EPC
			// 
			this.EPC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.EPC.DataPropertyName = "EPC";
			this.EPC.HeaderText = "EPC";
			this.EPC.Name = "EPC";
			this.EPC.ToolTipText = "Tag Unique Code";
			this.EPC.Visible = false;
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
			// RaceName
			// 
			this.RaceName.DataPropertyName = "Race";
			this.RaceName.HeaderText = "Race Name";
			this.RaceName.Name = "RaceName";
			this.RaceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// Age
			// 
			this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Age.DataPropertyName = "Age";
			dataGridViewCellStyle10.Format = "N0";
			dataGridViewCellStyle10.NullValue = null;
			this.Age.DefaultCellStyle = dataGridViewCellStyle10;
			this.Age.HeaderText = "Age";
			this.Age.Name = "Age";
			this.Age.Width = 51;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(130, 80);
			this.dataGrid1.TabIndex = 0;
			// 
			// dataGrid2
			// 
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(0, 0);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(130, 80);
			this.dataGrid2.TabIndex = 0;
			// 
			// Race
			// 
			this.Race.Name = "Race";
			// 
			// OverallPos
			// 
			this.OverallPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.OverallPos.DataPropertyName = "OverallPos";
			dataGridViewCellStyle11.Format = "N0";
			this.OverallPos.DefaultCellStyle = dataGridViewCellStyle11;
			this.OverallPos.HeaderText = "Overall Position";
			this.OverallPos.Name = "OverallPos";
			// 
			// GenderPos
			// 
			this.GenderPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.GenderPos.DataPropertyName = "GenderPos";
			dataGridViewCellStyle12.Format = "N0";
			this.GenderPos.DefaultCellStyle = dataGridViewCellStyle12;
			this.GenderPos.HeaderText = "Gender Position";
			this.GenderPos.Name = "GenderPos";
			// 
			// CatPos
			// 
			this.CatPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.CatPos.DataPropertyName = "CatPos";
			dataGridViewCellStyle13.Format = "N0";
			this.CatPos.DefaultCellStyle = dataGridViewCellStyle13;
			this.CatPos.HeaderText = "Category Position";
			this.CatPos.Name = "CatPos";
			// 
			// AgeCat
			// 
			this.AgeCat.DataPropertyName = "AgeCat";
			this.AgeCat.HeaderText = "Cat";
			this.AgeCat.Name = "AgeCat";
			this.AgeCat.Width = 67;
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
			// 
			// runners
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1294, 429);
			this.Controls.Add(this.splitContainer1);
			this.Name = "runners";
			this.Text = "runners";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBoxGunStart;
		private System.Windows.Forms.TextBox textBoxChipStart;
		private System.Windows.Forms.TextBox textBoxChipEnd;
		private System.Windows.Forms.TextBox textBoxManualEnd;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBoxBib2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox comboBoxStatus;
		private System.Windows.Forms.ComboBox comboBoxStatus2;
		private System.Windows.Forms.ComboBox comboBoxRace2;
		private System.Windows.Forms.TextBox textBoxFname;
		private System.Windows.Forms.TextBox textBoxLname2;
		private System.Windows.Forms.ComboBox comboBoxSex;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewComboBoxColumn RaceName;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.DataGridViewTextBoxColumn AgeCat;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridViewTextBoxColumn CatPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn GenderPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn OverallPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn GunTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn NettTotal;
		private System.Windows.Forms.DataGridViewComboBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn ManualEnd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChipEnd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChipStart;
		private System.Windows.Forms.DataGridViewTextBoxColumn GunStart;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Laps;
		private System.Windows.Forms.DataGridViewComboBoxColumn Race;
		private System.Windows.Forms.DataGridViewComboBoxColumn Sex;
		private System.Windows.Forms.DataGridViewTextBoxColumn Age;
		private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
		private System.Windows.Forms.DataGridViewTextBoxColumn LName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FName;
		private System.Windows.Forms.DataGridViewTextBoxColumn EPC;
		private System.Windows.Forms.DataGridViewTextBoxColumn BibNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn unique_key;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid2;
		
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox ChooseRace;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		
	
		
		
	}
}
