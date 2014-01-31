/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 6/02/2013
 * Time: 10:45 AM
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
using System.Net;



using DGVPrinterHelper;

namespace WinformsTiming
{
	/// <summary>
	/// Description of ResultsPrint.
	/// </summary>
	public partial class ResultsPrint : Form
	{
		
		private void PopulateMenu()
				
			{
							string NewQuery = "Select * from Races"; //+ "\'%"+ SelectRace.Text+"\'";
//Console.WriteLine(NewQuery);

//Pass string to function here....

		/// <remarks>
/// Creating a DataSet to feed the DataGridView
/// </remarks>  		
// 
DataSet results = new DataSet();
try
{
   results =  DbSqlite.GetDataSetSqlite(NewQuery);

    		
    		ChooseRace.DataSource = results.Tables[0];
			ChooseRace.DisplayMember = "RaceName";
			ChooseRace.BindingContext = BindingContext;
    		
    		//dataGridView1.DataSource = results.Tables[0].DefaultView;
    	}
		
	
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
	
				
			}
		
		
		private void FillData(string selectCommand)
        {
			
           DataSet ds = new DataSet();
           
           
            ds =  DbSqlite.GetDataSetSqlite(selectCommand);
         
            dataGridView2.DataSource = ds.Tables[0] ;
            
        
            
            	DataView overall = ds.Tables[0].DefaultView;
			overall.Sort = "OverallPos ASC";
			dataGridView2.DataSource = overall;
            
            if (checkBox4.Checked == true) {
            	
            	
            	DataView agecat = ds.Tables[0].DefaultView;
			agecat.Sort = "AgeCat ASC, CatPos ASC";
			dataGridView2.DataSource = agecat;
            	
            	
            }
      }
		
		
		
		
		
		
		
		
		
		
		public ResultsPrint()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
						PopulateMenu();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			
			string Query = "Select * from Athletes WHERE Race = "+"\'" + ChooseRace.Text + "\'";
			
		if (checkBox1.Checked==true)  Query = "Select * from Athletes WHERE Race = "+"\'" + ChooseRace.Text + "\' AND OverallPos >='1'";
			
		if (checkBox2.Checked==true)  Query = "Select * from Athletes WHERE Race = "+"\'" + ChooseRace.Text + "\' AND OverallPos >='1' AND Sex='Male'";
		
		if (checkBox3.Checked==true)  Query = "Select * from Athletes WHERE Race = "+"\'" + ChooseRace.Text + "\' AND OverallPos >='1' AND Sex='Female'";
		


//	Console.WriteLine(Query);
			
			FillData(Query);
				
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
			try
			{
			
		 DGVPrinter printer = new DGVPrinter();

    printer.Title = ChooseRace.Text;

    
    	string statstext = " ";
				//string statstext = "Waiting for an update";
				
				try {
						if (formstest.MainClass.RaceStats.ContainsKey (ChooseRace.Text)) {
							statstext = formstest.MainClass.RaceStats [ChooseRace.Text];
			}
				}
				
				catch
					
				{
					 statstext = "Waiting for an update";
				}
    
    
    printer.SubTitle = statstext;

    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | 

                                  StringFormatFlags.NoClip;

    printer.PageNumbers = true;

    printer.PageNumberInHeader = false;

    printer.PorportionalColumns = true;

    printer.HeaderCellAlignment = StringAlignment.Near;

    printer.Footer =  "Printed at "+DateTime.Now.ToLocalTime();

    printer.FooterSpacing = 15;



    printer.PrintDataGridView(dataGridView2);
		}	
			
			catch (Exception ex)
				
			{
				MessageBox.Show(ex.Message);
			}
		
		}
		
					private StringBuilder htmlpagecreator(DataGridView dg)
{
     StringBuilder strB = new StringBuilder();
    //create html & table
  
    strB.AppendLine(@"<link href=""styles/styles.css"" rel=""stylesheet"" type=""text/css"" />");
    strB.AppendLine(@"<link href=""styles/new.css"" rel=""stylesheet"" type=""text/css"" />");
    strB.AppendLine(@"<script type=""text/javascript"" src=""js/jquery-1.9.1.min.js""></script>");
    strB.AppendLine(@"<script type=""text/javascript"" src=""js/jquery.tablesorter.js""></script>");
     strB.AppendLine(@"<script type=""text/javascript"" src=""js/live-results.js""></script>");
     strB.AppendLine(@"<meta http-equiv=""refresh"" content=""60"">");
    
     string LastUpdateTime = DateTime.Now.ToString();
     
    try
    {
     
     strB.AppendLine("<html><body><p><strong>Results for: " + dg.Rows[0].Cells["Race"].Value.ToString()       + "  Last updated at: " + LastUpdateTime + " </strong></p><center><" +
                    "table border='1' cellpadding='4' cellspacing='0'><thead>");
                    
    strB.AppendLine("<tr>");
    //cteate table header
    for (int i = 0; i < dg.Columns.Count; i++)
    {
        strB.AppendLine("<th align='center' valign='middle'>" + dg.Columns[i].HeaderText + "</th>");
    }
    //create table body
    strB.AppendLine("<tr>");
    for (int i = 0; i < dg.Rows.Count; i++)
    {
        strB.AppendLine("<tr></thead><tbody>");
        foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
        {
        	strB.AppendLine("<td align='center' valign='middle'>");
        		strB.AppendLine(dgvc.Value.ToString());
            strB.AppendLine("</td>");
        }
        strB.AppendLine("</tr>");

    }
    
    }
    
    catch
    	
    {
    	 strB.AppendLine("<html><body><p><strong>No Race In Progress</strong></p><center>");
    	
    }
    
    //table footer & end of html file
    strB.AppendLine("</tbody></table></center></body></html>");
    return strB;
					
					}
		
		
		
		void none(object sender, DataGridViewDataErrorEventArgs e)
		{
			//stop it bitching
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			
			
			//lets drop the columns we don't want
			
			dataGridView2.Columns.Remove("unique_key");
			dataGridView2.Columns.Remove("EPC");
			dataGridView2.Columns.Remove("ChipStart");
			dataGridView2.Columns.Remove("ChipEnd");
			dataGridView2.Columns.Remove("NettTotal");
			dataGridView2.Columns.Remove("ManualEnd");
			dataGridView2.Columns.Remove("DOB");
			dataGridView2.Columns.Remove("Age");
			
		//drop these too if no age cats

			dataGridView2.Columns.Remove("CatPos");
			dataGridView2.Columns.Remove("AgeCat");
			
			//lets build an HTML page for the race results
			
			StringBuilder resultspage = htmlpagecreator(dataGridView2);
			
			//Now lets try and FTP it to the server
			
			 // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.raceready.com.au/timing/results-upload.html");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("raceready","sc0rp200!!!");
            
            //lets stop it appending the bloody results over and over again!
            
            if(File.Exists(@"results_upload.html"))
{
    File.Delete(@"results_upload.html");
}
            
            StreamWriter sw = new StreamWriter("results_upload.html", true, Encoding.UTF8);//creating html file
       
            //write datagridview contents to HTML file
        sw.Write(resultspage.ToString());
        sw.Close();
            
            
            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader("results_upload.html");
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
    
            response.Close();
			

			
		}
		}
	}

