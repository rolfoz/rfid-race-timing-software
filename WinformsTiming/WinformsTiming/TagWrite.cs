/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 1/02/2013
 * Time: 4:51 PM
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
using System.Timers;


namespace WinformsTiming
{
	/// <summary>
	/// Description of TagWrite.
	/// </summary>
	public partial class TagWrite : Form
	{
		
		
			formstest.MainClass mchammer = new WinformsTiming.formstest.MainClass();
		
		//Get list of current tags from Dictionary into a table, enter number of recent seconds to show
		
	 	void CurrentTagView ()
			
		{
			
			DataTable foundTags = new DataTable();
			foundTags.Columns.Add("epc");
			foundTags.Columns.Add("newepc");
			foundTags.Columns.Add("ts");
		
			Dictionary<string,string> copy = new Dictionary<string,string>(formstest.MainClass.TagsInView);
			
			foreach (string str1 in copy.Keys)
            {
				string str2 = copy[str1];
				
				DateTime RightNow = DateTime.Now.ToLocalTime ();

DateTime tlst1 = Convert.ToDateTime (str2);
TimeSpan ts = RightNow - tlst1;
//Console.WriteLine("I see a tag aged "+ tagepc + ts.TotalSeconds.ToString());
if (ts.TotalSeconds < 3) {

				
				
				
                {
                    foundTags.Rows.Add(str1,str2);  // This line needs editing 
                }
}
            dataGridViewCurrentTags.DataSource = foundTags;	
			
			
		}
		}
		
		public TagWrite()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			// update the tag view every 2 secs
			
			
           
           
		
		}
		
		
		
		void Timer1Tick(object sender, EventArgs e)
		{
			CurrentTagView ();
		}
		
		void DataGridViewCurrentTagsCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
			
			
			
			
			if (dataGridViewCurrentTags.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
    {
				
				
				string TagToWrite = dataGridViewCurrentTags.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
string messageboxstring = "Write "+ NewEpcInput.Text +" To " + TagToWrite;    



				if (checkBox2.Checked == true)
	
					{

				DialogResult result1 = MessageBox.Show(messageboxstring,"Write New TAG", MessageBoxButtons.YesNo);
       
       
       
				if (result1 != DialogResult.Yes) {goto END;}
 


						}
				
					
       	//code to write tag goes here...
       	Console.WriteLine("Writing Tag");
       	
 
       	
       	formstest.MainClass.Variables.EpcToWrite = NewEpcInput.Text;
       	formstest.MainClass.Variables.EpcToRead = TagToWrite;
       
       //	mchammer.WriterControl ();
       
       
       formstest.MainClass.Variables.one.Delete_AccessSpec();
       formstest.MainClass.Variables.one.Add_AccessSpec();
       formstest.MainClass.Variables.one.Enable_AccessSpec();
     //  formstest.MainClass.Variables.one.Enable_RoSpec();
     
     int count = 1;
     
    AUTOINC: ;
     
     if (checkBox1.Checked == true) {
     
     int epcdecimal = Convert.ToInt32(NewEpcInput.Text);
     
     
     //lets check that we can actually see a bib with the new epc before we do anything
     
     string sexyepc = NewEpcInput.Text.PadLeft(24, '0');
     
     Thread.Sleep(350);
     
     if (formstest.MainClass.TagsInView.ContainsKey (sexyepc)) {
     
     epcdecimal++;
     
     Console.WriteLine("I see the bib number {0}",sexyepc);
     
     NewEpcInput.Text = epcdecimal.ToString();
     
     }
     
     else
     	
     {
     	
     	//count the number of tries.. give up after 4
     	count++;
     	Console.WriteLine("I dont see the bib number {0} Try {1}",sexyepc,count.ToString());
     	
     	if (count > 20) goto END ;
     	goto AUTOINC ; 
     }
     
     
     }
     
     }
       END: ;
			
			}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			
//add one manually for when we need to skip a bib or two
			int epcdecimal = Convert.ToInt32(NewEpcInput.Text);
			 epcdecimal++;
			 NewEpcInput.Text = epcdecimal.ToString();
		}
    }
		
	
	
	
	}
		

		
	

