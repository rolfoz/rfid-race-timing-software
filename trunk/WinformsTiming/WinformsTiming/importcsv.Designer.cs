/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 4/02/2013
 * Time: 1:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinformsTiming
{
	partial class importcsv
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.BibNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bb = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.Bib = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.ChooseRace = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dataSet1 = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Select CSV File";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(641, 71);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Save Table Below";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(224, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Ensure that the colums below line up";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.BibNo,
									this.aa,
									this.bb,
									this.dd,
									this.cc,
									this.First});
			this.dataGridView1.Location = new System.Drawing.Point(-3, 157);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView1.Size = new System.Drawing.Size(1225, 232);
			this.dataGridView1.TabIndex = 3;
			// 
			// BibNo
			// 
			this.BibNo.DataPropertyName = "BibNumber";
			this.BibNo.HeaderText = "BibNumber";
			this.BibNo.Name = "BibNo";
			// 
			// aa
			// 
			this.aa.DataPropertyName = "Fname";
			this.aa.HeaderText = "Fname";
			this.aa.Name = "aa";
			// 
			// bb
			// 
			this.bb.DataPropertyName = "Lname";
			this.bb.HeaderText = "Lname";
			this.bb.Name = "bb";
			// 
			// dd
			// 
			this.dd.DataPropertyName = "Age";
			this.dd.HeaderText = "DOB";
			this.dd.Name = "dd";
			// 
			// cc
			// 
			this.cc.DataPropertyName = "DOB";
			this.cc.HeaderText = "Age";
			this.cc.Name = "cc";
			// 
			// First
			// 
			this.First.DataPropertyName = "Sex";
			this.First.HeaderText = "Sex";
			this.First.Name = "First";
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Bib,
									this.Fname,
									this.Lname,
									this.DOB,
									this.Age,
									this.Sex});
			this.dataGridView2.Location = new System.Drawing.Point(-3, 132);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dataGridView2.Size = new System.Drawing.Size(1225, 85);
			this.dataGridView2.TabIndex = 4;
			// 
			// Bib
			// 
			this.Bib.HeaderText = "Bib Number";
			this.Bib.Name = "Bib";
			this.Bib.ReadOnly = true;
			// 
			// Fname
			// 
			this.Fname.HeaderText = "First Name";
			this.Fname.Name = "Fname";
			this.Fname.ReadOnly = true;
			// 
			// Lname
			// 
			this.Lname.HeaderText = "Last Name";
			this.Lname.Name = "Lname";
			this.Lname.ReadOnly = true;
			// 
			// DOB
			// 
			this.DOB.HeaderText = "DOB";
			this.DOB.Name = "DOB";
			this.DOB.ReadOnly = true;
			// 
			// Age
			// 
			this.Age.HeaderText = "Age";
			this.Age.Name = "Age";
			this.Age.ReadOnly = true;
			// 
			// Sex
			// 
			this.Sex.HeaderText = "Gender";
			this.Sex.Name = "Sex";
			this.Sex.ReadOnly = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(224, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Gender must be Male or Female";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Date Must be dd/mm/yyyy";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
			// 
			// ChooseRace
			// 
			this.ChooseRace.FormattingEnabled = true;
			this.ChooseRace.Location = new System.Drawing.Point(641, 27);
			this.ChooseRace.Name = "ChooseRace";
			this.ChooseRace.Size = new System.Drawing.Size(121, 21);
			this.ChooseRace.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(615, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Select Race to add runners to";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// importcsv
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1268, 401);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ChooseRace);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView2);
			this.Name = "importcsv";
			this.Text = "importcsv";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ChooseRace;
		private System.Windows.Forms.DataGridViewTextBoxColumn dd;
		private System.Windows.Forms.DataGridViewTextBoxColumn cc;
		private System.Windows.Forms.DataGridViewTextBoxColumn bb;
		private System.Windows.Forms.DataGridViewTextBoxColumn aa;
		private System.Windows.Forms.DataGridViewTextBoxColumn First;
		private System.Windows.Forms.DataGridViewTextBoxColumn BibNo;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
		private System.Windows.Forms.DataGridViewTextBoxColumn Age;
		private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
		private System.Windows.Forms.DataGridViewTextBoxColumn Lname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Fname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Bib;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}
