/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 8/04/2013
 * Time: 12:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsTiming
{
	/// <summary>
	/// Description of tabs.
	/// </summary>
	public partial class tabs : Form
	{
		public tabs()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TabPage1Click(object sender, EventArgs e)
		{
			 Races frm = new Races();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[0].Controls.Add(frm);
		}
		
		void TabPage6Click(object sender, EventArgs e)
		{
			
			 MainForm frm = new MainForm();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[5].Controls.Add(frm);
			
		}
		
		void TabPage2Click(object sender, EventArgs e)
		{
			 runners rnn = new runners();
      rnn.TopLevel = false;
      rnn.Visible = true;
      rnn.FormBorderStyle = FormBorderStyle.None;
      rnn.Dock = DockStyle.Fill;
      tabControl1.TabPages[1].Controls.Add(rnn);
		}
		
		void TabPage3Click(object sender, EventArgs e)
		{
			 TagWrite frm = new TagWrite();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[2].Controls.Add(frm);
		}
		
		void TabPage4Click(object sender, EventArgs e)
		{
			 Reports frm = new Reports();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[3].Controls.Add(frm);
		}
		
		void TabPage7Click(object sender, EventArgs e)
		{
			 SelectRace frm = new SelectRace();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[5].Controls.Add(frm);
		}
		
		void TabPage8Click(object sender, EventArgs e)
		{
			 TimingCode frm = new TimingCode();
      frm.TopLevel = false;
      frm.Visible = true;
      frm.FormBorderStyle = FormBorderStyle.None;
      frm.Dock = DockStyle.Fill;
      tabControl1.TabPages[6].Controls.Add(frm);
		}
	}
}
