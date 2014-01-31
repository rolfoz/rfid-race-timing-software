/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 28/01/2013
 * Time: 1:47 PM
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
using System.Net.NetworkInformation;
 
 
namespace WinformsTiming
{
	partial class MainForm
	{
		
		Races RaceWindow = null;
		SelectRace startracewindow = null;
		TimingCode tagviewwindow = null;
		Reports reportwindow = null;
		runners runnerswindow = null;
		TagWrite tagwritewindow = null;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ReadsPerSec = new System.Windows.Forms.NumericUpDown();
			this.UpdateSecs = new System.Windows.Forms.NumericUpDown();
			this.NewSecs = new System.Windows.Forms.NumericUpDown();
			this.Reader1IP = new System.Windows.Forms.TextBox();
			this.Reader2IP = new System.Windows.Forms.TextBox();
			this.Connect = new System.Windows.Forms.Button();
			this.Disconnect = new System.Windows.Forms.Button();
			this.UpdateBtn = new System.Windows.Forms.Button();
			this.MainTextBox = new System.Windows.Forms.TextBox();
			this.OpenRace = new System.Windows.Forms.Button();
			this.WriteTag = new System.Windows.Forms.Button();
			this.Query = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Reader = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Antenna1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Ant2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Ant3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Ant4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RaceStatsBox = new System.Windows.Forms.TextBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.AntennaStatsMins2 = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.manualbib = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxRunners = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBoxTestMode = new System.Windows.Forms.CheckBox();
			this.button10 = new System.Windows.Forms.Button();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ReadsPerSec)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpdateSecs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewSecs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AntennaStatsMins2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(37, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Reader1 IP";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(37, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Reader2 IP";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(25, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Reads/Sec";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(90, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Update Secs";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(174, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "New Secs";
			// 
			// ReadsPerSec
			// 
			this.ReadsPerSec.Location = new System.Drawing.Point(37, 131);
			this.ReadsPerSec.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.ReadsPerSec.Name = "ReadsPerSec";
			this.ReadsPerSec.Size = new System.Drawing.Size(29, 20);
			this.ReadsPerSec.TabIndex = 5;
			this.ReadsPerSec.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.ReadsPerSec.ValueChanged += new System.EventHandler(this.ReadsPerSecValueChanged);
			// 
			// UpdateSecs
			// 
			this.UpdateSecs.Location = new System.Drawing.Point(100, 131);
			this.UpdateSecs.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.UpdateSecs.Name = "UpdateSecs";
			this.UpdateSecs.Size = new System.Drawing.Size(37, 20);
			this.UpdateSecs.TabIndex = 6;
			this.UpdateSecs.Value = new decimal(new int[] {
									30,
									0,
									0,
									0});
			this.UpdateSecs.ValueChanged += new System.EventHandler(this.UpdateSecsValueChanged);
			// 
			// NewSecs
			// 
			this.NewSecs.Location = new System.Drawing.Point(184, 131);
			this.NewSecs.Maximum = new decimal(new int[] {
									1200,
									0,
									0,
									0});
			this.NewSecs.Minimum = new decimal(new int[] {
									20,
									0,
									0,
									0});
			this.NewSecs.Name = "NewSecs";
			this.NewSecs.Size = new System.Drawing.Size(41, 20);
			this.NewSecs.TabIndex = 7;
			this.NewSecs.Value = new decimal(new int[] {
									180,
									0,
									0,
									0});
			this.NewSecs.ValueChanged += new System.EventHandler(this.NewSecsValueChanged);
			// 
			// Reader1IP
			// 
			this.Reader1IP.Location = new System.Drawing.Point(37, 25);
			this.Reader1IP.Name = "Reader1IP";
			this.Reader1IP.Size = new System.Drawing.Size(100, 20);
			this.Reader1IP.TabIndex = 8;
			this.Reader1IP.Text = "192.168.11.50";
			// 
			// Reader2IP
			// 
			this.Reader2IP.Location = new System.Drawing.Point(37, 71);
			this.Reader2IP.Name = "Reader2IP";
			this.Reader2IP.Size = new System.Drawing.Size(100, 20);
			this.Reader2IP.TabIndex = 9;
			this.Reader2IP.Text = "192.168.10.52";
			// 
			// Connect
			// 
			this.Connect.Location = new System.Drawing.Point(159, 22);
			this.Connect.Name = "Connect";
			this.Connect.Size = new System.Drawing.Size(125, 23);
			this.Connect.TabIndex = 10;
			this.Connect.Text = "Connect Readers";
			this.Connect.UseVisualStyleBackColor = true;
			this.Connect.Click += new System.EventHandler(this.ConnectClick);
			// 
			// Disconnect
			// 
			this.Disconnect.Location = new System.Drawing.Point(159, 68);
			this.Disconnect.Name = "Disconnect";
			this.Disconnect.Size = new System.Drawing.Size(125, 23);
			this.Disconnect.TabIndex = 11;
			this.Disconnect.Text = "Disconect Readers";
			this.Disconnect.UseVisualStyleBackColor = true;
			this.Disconnect.Click += new System.EventHandler(this.DisconnectClick);
			// 
			// UpdateBtn
			// 
			this.UpdateBtn.Location = new System.Drawing.Point(37, 171);
			this.UpdateBtn.Name = "UpdateBtn";
			this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
			this.UpdateBtn.TabIndex = 12;
			this.UpdateBtn.Text = "Update";
			this.UpdateBtn.UseVisualStyleBackColor = true;
			this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtnClick);
			// 
			// MainTextBox
			// 
			this.MainTextBox.Location = new System.Drawing.Point(12, 204);
			this.MainTextBox.Multiline = true;
			this.MainTextBox.Name = "MainTextBox";
			this.MainTextBox.ReadOnly = true;
			this.MainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.MainTextBox.Size = new System.Drawing.Size(396, 103);
			this.MainTextBox.TabIndex = 13;
			// 
			// OpenRace
			// 
			this.OpenRace.Location = new System.Drawing.Point(437, 12);
			this.OpenRace.Name = "OpenRace";
			this.OpenRace.Size = new System.Drawing.Size(136, 23);
			this.OpenRace.TabIndex = 14;
			this.OpenRace.Text = "Open Race Window";
			this.OpenRace.UseVisualStyleBackColor = true;
			this.OpenRace.Click += new System.EventHandler(this.OpenRaceClick);
			// 
			// WriteTag
			// 
			this.WriteTag.Location = new System.Drawing.Point(437, 41);
			this.WriteTag.Name = "WriteTag";
			this.WriteTag.Size = new System.Drawing.Size(136, 23);
			this.WriteTag.TabIndex = 15;
			this.WriteTag.Text = "Open Chip Write Window";
			this.WriteTag.UseVisualStyleBackColor = true;
			this.WriteTag.Click += new System.EventHandler(this.WriteTagClick);
			// 
			// Query
			// 
			this.Query.Location = new System.Drawing.Point(437, 70);
			this.Query.Name = "Query";
			this.Query.Size = new System.Drawing.Size(136, 23);
			this.Query.TabIndex = 16;
			this.Query.Text = "View Tags";
			this.Query.UseVisualStyleBackColor = true;
			this.Query.Click += new System.EventHandler(this.QueryClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(437, 99);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "View Runners";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(437, 128);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(136, 23);
			this.button2.TabIndex = 18;
			this.button2.Text = "View Races";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(437, 157);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 23);
			this.button3.TabIndex = 19;
			this.button3.Text = "Race Stats";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(255, 128);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(63, 24);
			this.checkBox1.TabIndex = 20;
			this.checkBox1.Text = "Beep?";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(12, 67);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(20, 24);
			this.checkBox2.TabIndex = 21;
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(127, 170);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(85, 24);
			this.checkBox3.TabIndex = 22;
			this.checkBox3.Text = "Auto  Stats?";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Reader,
									this.Antenna1,
									this.Ant2,
									this.Ant3,
									this.Ant4});
			this.dataGridView1.DataMember = "readerstats";
			this.dataGridView1.Location = new System.Drawing.Point(694, 41);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dataGridView1.Size = new System.Drawing.Size(544, 81);
			this.dataGridView1.TabIndex = 25;
			// 
			// Reader
			// 
			this.Reader.Name = "Reader";
			this.Reader.ReadOnly = true;
			// 
			// Antenna1
			// 
			this.Antenna1.Name = "Antenna1";
			this.Antenna1.ReadOnly = true;
			// 
			// Ant2
			// 
			this.Ant2.Name = "Ant2";
			this.Ant2.ReadOnly = true;
			// 
			// Ant3
			// 
			this.Ant3.Name = "Ant3";
			this.Ant3.ReadOnly = true;
			// 
			// Ant4
			// 
			this.Ant4.Name = "Ant4";
			this.Ant4.ReadOnly = true;
			// 
			// RaceStatsBox
			// 
			this.RaceStatsBox.Location = new System.Drawing.Point(694, 128);
			this.RaceStatsBox.Multiline = true;
			this.RaceStatsBox.Name = "RaceStatsBox";
			this.RaceStatsBox.ReadOnly = true;
			this.RaceStatsBox.Size = new System.Drawing.Size(544, 75);
			this.RaceStatsBox.TabIndex = 29;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoCheck = false;
			this.checkBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.checkBox5.Location = new System.Drawing.Point(304, 71);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(104, 24);
			this.checkBox5.TabIndex = 24;
			this.checkBox5.Text = "Connected?";
			this.checkBox5.UseVisualStyleBackColor = false;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoCheck = false;
			this.checkBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.checkBox4.Location = new System.Drawing.Point(304, 23);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(104, 24);
			this.checkBox4.TabIndex = 23;
			this.checkBox4.Text = "Connected?";
			this.checkBox4.UseVisualStyleBackColor = false;
			// 
			// AntennaStatsMins2
			// 
			this.AntennaStatsMins2.Location = new System.Drawing.Point(866, 7);
			this.AntennaStatsMins2.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.AntennaStatsMins2.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.AntennaStatsMins2.Name = "AntennaStatsMins2";
			this.AntennaStatsMins2.Size = new System.Drawing.Size(74, 20);
			this.AntennaStatsMins2.TabIndex = 31;
			this.AntennaStatsMins2.Value = new decimal(new int[] {
									60,
									0,
									0,
									0});
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(946, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(92, 16);
			this.label8.TabIndex = 32;
			this.label8.Text = "Showing From:";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(762, 4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 33;
			this.button4.Text = "Update Now";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(1034, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(140, 21);
			this.label6.TabIndex = 34;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(582, 232);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(42, 23);
			this.button5.TabIndex = 35;
			this.button5.Text = "Now!";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(694, 204);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(143, 23);
			this.label7.TabIndex = 37;
			this.label7.Text = "Manual Input";
			// 
			// manualbib
			// 
			this.manualbib.Location = new System.Drawing.Point(588, 204);
			this.manualbib.Name = "manualbib";
			this.manualbib.Size = new System.Drawing.Size(100, 20);
			this.manualbib.TabIndex = 36;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(630, 232);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(58, 23);
			this.button6.TabIndex = 38;
			this.button6.Text = "-2 Secs";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(694, 232);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(51, 23);
			this.button7.TabIndex = 39;
			this.button7.Text = "-5 Secs";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button8.Location = new System.Drawing.Point(442, 190);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(131, 67);
			this.button8.TabIndex = 40;
			this.button8.Text = "Panic Button!";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(785, 232);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 41;
			this.button9.Text = "Add Lap";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// txtConsole
			// 
			this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.txtConsole.Location = new System.Drawing.Point(12, 328);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ReadOnly = true;
			this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConsole.Size = new System.Drawing.Size(396, 98);
			this.txtConsole.TabIndex = 42;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(613, 184);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 19);
			this.label9.TabIndex = 44;
			this.label9.Text = "Bib";
			// 
			// textBoxRunners
			// 
			this.textBoxRunners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxRunners.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxRunners.Location = new System.Drawing.Point(437, 275);
			this.textBoxRunners.Multiline = true;
			this.textBoxRunners.Name = "textBoxRunners";
			this.textBoxRunners.ReadOnly = true;
			this.textBoxRunners.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxRunners.Size = new System.Drawing.Size(801, 151);
			this.textBoxRunners.TabIndex = 45;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(339, 171);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(92, 24);
			this.checkBox6.TabIndex = 46;
			this.checkBox6.Text = "Console Out";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox6CheckedChanged);
			// 
			// checkBoxTestMode
			// 
			this.checkBoxTestMode.Location = new System.Drawing.Point(255, -2);
			this.checkBoxTestMode.Name = "checkBoxTestMode";
			this.checkBoxTestMode.Size = new System.Drawing.Size(86, 19);
			this.checkBoxTestMode.TabIndex = 47;
			this.checkBoxTestMode.Text = "Test Mode";
			this.checkBoxTestMode.UseVisualStyleBackColor = true;
			this.checkBoxTestMode.CheckedChanged += new System.EventHandler(this.CheckBoxTestModeCheckedChanged);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(597, 9);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 48;
			this.button10.Text = "Tab Mode";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10Click);
			// 
			// checkBox7
			// 
			this.checkBox7.Location = new System.Drawing.Point(159, -2);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(86, 19);
			this.checkBox7.TabIndex = 49;
			this.checkBox7.Text = "Power Save";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += new System.EventHandler(this.CheckBox7CheckedChanged);
			// 
			// checkBox8
			// 
			this.checkBox8.Location = new System.Drawing.Point(324, 126);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(63, 24);
			this.checkBox8.TabIndex = 50;
			this.checkBox8.Text = "Talk?";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox8.CheckedChanged += new System.EventHandler(this.CheckBox8CheckedChanged);
			// 
			// checkBox9
			// 
			this.checkBox9.Location = new System.Drawing.Point(339, -2);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(86, 19);
			this.checkBox9.TabIndex = 51;
			this.checkBox9.Text = "Say Ant";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.CheckedChanged += new System.EventHandler(this.CheckBox9CheckedChanged);
			// 
			// MainForm
			// 
			this.AcceptButton = this.button8;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1250, 438);
			this.Controls.Add(this.checkBox9);
			this.Controls.Add(this.checkBox8);
			this.Controls.Add(this.checkBox7);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.checkBoxTestMode);
			this.Controls.Add(this.checkBox6);
			this.Controls.Add(this.textBoxRunners);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.manualbib);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.AntennaStatsMins2);
			this.Controls.Add(this.RaceStatsBox);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.checkBox5);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Query);
			this.Controls.Add(this.WriteTag);
			this.Controls.Add(this.OpenRace);
			this.Controls.Add(this.MainTextBox);
			this.Controls.Add(this.UpdateBtn);
			this.Controls.Add(this.Disconnect);
			this.Controls.Add(this.Connect);
			this.Controls.Add(this.Reader2IP);
			this.Controls.Add(this.Reader1IP);
			this.Controls.Add(this.NewSecs);
			this.Controls.Add(this.UpdateSecs);
			this.Controls.Add(this.ReadsPerSec);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "RaceReady Timing V2.0";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.ReadsPerSec)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpdateSecs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewSecs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AntennaStatsMins2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.CheckBox checkBoxTestMode;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox textBoxRunners;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtConsole;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox manualbib;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown AntennaStatsMins2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Reader;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox RaceStatsBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ant4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ant3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ant2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Antenna1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button Query;
		private System.Windows.Forms.Button WriteTag;
		private System.Windows.Forms.Button OpenRace;
		public System.Windows.Forms.TextBox MainTextBox;
		private System.Windows.Forms.Button UpdateBtn;
		private System.Windows.Forms.Button Disconnect;
		private System.Windows.Forms.Button Connect;
		private System.Windows.Forms.TextBox Reader2IP;
		private System.Windows.Forms.TextBox Reader1IP;
		private System.Windows.Forms.NumericUpDown NewSecs;
		private System.Windows.Forms.NumericUpDown UpdateSecs;
		private System.Windows.Forms.NumericUpDown ReadsPerSec;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		
		void ConnectClick(object sender, System.EventArgs e)
		{
			//Set the variables from the form

			WinformsTiming.formstest.MainClass.Variables.ReadsPerSec = (int)ReadsPerSec.Value;
			WinformsTiming.formstest.MainClass.Variables.UpdateSecs = (int)UpdateSecs.Value;
			WinformsTiming.formstest.MainClass.Variables.NewTagSecs = (int)NewSecs.Value;
			WinformsTiming.formstest.MainClass.Variables.Beep = checkBox1.Checked;
			CalculateStats = checkBox3.Checked;
			
			formstest.MainClass.Variables.Reader1IP = Reader1IP.Text;
			formstest.MainClass.Variables.Reader2IP = Reader2IP.Text;
//			MainClass.Variables.Reader1Name = ReaderOneName.Text;
//			MainClass.Variables.Reader2Name = ReaderTwoName.Text;
string ReaderOneName = "Reader One";
string ReaderTwoName = "Reader Two";
			//Start the readers
		//	UpdateTextBox();
		
		Ping x = new Ping();
PingReply reply = x.Send(Reader1IP.Text); //enter ip of the machine
if (reply.Status == IPStatus.Success)
{
		
		
		
		formstest.MainClass.Variables.one  = new formstest.MainClass {ThisInstanceName = "Reader1"};
			formstest.MainClass.Variables.one.ReaderControl(ReaderOneName,Reader1IP.Text);
			//MainTextBox.AppendText("Conecting to Reader One \n");
		//	AppendToTextBox("Conecting to Reader One");
		
} else MessageBox.Show("Reader One not responding to network ping");
			

			if (checkBox2.Checked == true) {
			
			
			//check we can see the reader...
			
			
			
			Ping x2 = new Ping();
PingReply reply2 = x2.Send(Reader2IP.Text); //enter ip of the machine
if (reply2.Status == IPStatus.Success)
{
	
			
			formstest.MainClass.Variables.two = new formstest.MainClass {ThisInstanceName = "Reader2"};

		formstest.MainClass.Variables.two.ReaderControl(ReaderTwoName,Reader2IP.Text);
		//MainTextBox.AppendText("Conecting to Reader Two \n");
	//	AppendToTextBox("Conecting to Reader Two");
	
} else MessageBox.Show("Reader Two not responding to network ping");
	
}
		}
		
		
		
		
		
		void DisconnectClick(object sender, System.EventArgs e)
		{
			
			try
			{
			
			formstest.MainClass.Variables.one.ReaderClose();
			

			MainTextBox.AppendText("Closing Reader One \n");
			}
			
			catch
				
			{
				MessageBox.Show("Unable to Close Reader One");
			}
			
		
//if reader2 is connected...
if (checkBox5.Checked == true) {

			try
			{
			
			formstest.MainClass.Variables.two.ReaderClose();
			

			MainTextBox.AppendText("Closing Reader Two \n");
			}
			
			catch
				
			{
				MessageBox.Show("Unable to Close Reader Two");
			}
			
}
			
			}
		
		void OpenRaceClick(object sender, System.EventArgs e)
		{
			
				if (startracewindow == null)
				
			{
				startracewindow = new SelectRace();
				startracewindow.FormClosing += fmanageracewindowclosing;
				
			//	RaceWindow.Parent = this;
			}
				
				
			startracewindow.Show();
			
			startracewindow.Focus();
			
			
			
		}
		
		public void fmanageracewindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			startracewindow=null;
		}
			
			
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
				if (runnerswindow == null)
				
			{
				runnerswindow = new runners();
				runnerswindow.FormClosing += runnerswindowclosing;
			//	RaceWindow.Parent = this;
			}
			runnerswindow.Show();
			runnerswindow.Focus();
		}
		
		public void runnerswindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			runnerswindow=null;
		}
		
		
		void ReadsPerSecValueChanged(object sender, System.EventArgs e)
		{
			WinformsTiming.formstest.MainClass.Variables.ReadsPerSec = (int)ReadsPerSec.Value;
		}
		
		void WriteTagClick(object sender, System.EventArgs e)
		{
		
	if (tagwritewindow == null)
				
			{
				tagwritewindow = new TagWrite();
				tagwritewindow.FormClosing += tagwritewindowclosing;
			//	RaceWindow.Parent = this;
			}
			tagwritewindow.Show();
			tagwritewindow.Focus();
		}
		
			public void tagwritewindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			tagwritewindow=null;
		}
		
		
		void UpdateBtnClick(object sender, System.EventArgs e)
		{
			WinformsTiming.formstest.MainClass.Variables.UpdateSecs = (int)UpdateSecs.Value;
			WinformsTiming.formstest.MainClass.Variables.NewTagSecs = (int)NewSecs.Value;
			WinformsTiming.formstest.MainClass.Variables.ReadsPerSec = (int)ReadsPerSec.Value;
			CalculateStats = checkBox3.Checked;
			
			WinformsTiming.formstest.MainClass.Variables.Beep = checkBox1.Checked;
			
			
			
			
		}
		
		void UpdateSecsValueChanged(object sender, System.EventArgs e)
		{
			WinformsTiming.formstest.MainClass.Variables.UpdateSecs = (int)UpdateSecs.Value;
		}
		
		void NewSecsValueChanged(object sender, System.EventArgs e)
		{
			WinformsTiming.formstest.MainClass.Variables.NewTagSecs = (int)NewSecs.Value;
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
			
			
			if (RaceWindow == null)
				
			{
				RaceWindow = new Races();
				RaceWindow.FormClosing += racewindowclosing;
			//	RaceWindow.Parent = this;
			}
			RaceWindow.Show();
			RaceWindow.Focus();
		}
		
		public void racewindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			RaceWindow=null;
		}
		
		void CheckBox1CheckedChanged(object sender, System.EventArgs e)
		{
			//if the value is set unset it, otherwise set it
			
			if (formstest.MainClass.Variables.Beep == false) 
				
			{
				formstest.MainClass.Variables.Beep = true ;
			}
			
			else
			{
				formstest.MainClass.Variables.Beep = false ;
			}
		}
		
	
	}
}
