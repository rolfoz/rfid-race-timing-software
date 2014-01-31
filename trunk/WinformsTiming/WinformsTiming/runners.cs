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

using DGVPrinterHelper;
//imports DGVPrinterHelper;



namespace WinformsTiming
{
	/// <summary>
	/// Description of runners.
	/// </summary>
	public partial class runners : Form
	{
		
	public	List<string> everyrace = new List<string>();
		
		
			public  List<string>GetSQlitefieldlist(string mySelectQuery, string columnName) 
{ 
			
			//this will make a list of  results...
			
			List<string> columnList = new List<string>();
			
			RFIDTAGSTORE.Open();
			
 // SQLiteConnection sqreadConnection3 = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
  SQLiteCommand sqCommand2 = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE); 
//  sqCommand2.Connection.Open(); 
  SQLiteDataReader sqReader2 = sqCommand2.ExecuteReader(); 
  try 
  { 
    while(sqReader2.Read()) 
    { 
    	
    	string whateverwejustgot = sqReader2[columnName].ToString();
   // 	Console.Write("{0} ", whateverwejustgot);
    	columnList.Add(whateverwejustgot);
    	
    }
  } 
  finally 
  { 
    sqReader2.Close(); 
    RFIDTAGSTORE.Close();
   
    
  //  sqreadConnection3.Close(); 
 //   sqreadConnection3.Dispose();
    
  } 
  return columnList;
} 
		
		
		
		
		
		
				 SQLiteConnection RFIDTAGSTORE = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
		
				 public string allraces {get; set;}
		
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
                
    using (SQLiteConnection aconnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"))
    {
    	using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(NewQuery, aconnection))
    	{
    		/// <remarks>
    		/// Populating the DataGridView
    		/// </remarks>
    		adapter.Fill(results);
    		
    		ChooseRace.DataSource = results.Tables[0];
			ChooseRace.DisplayMember = "RaceName";
			ChooseRace.BindingContext = BindingContext;
			
			
			
				string getallraces = "Select RaceName from Races";
			
			everyrace = GetSQlitefieldlist(getallraces,"RaceName");
			
			RaceName.DataSource = everyrace;
			comboBoxRace2.DataSource = everyrace;
			
			//this.Race.DataSource = results;
			//this.Race.DisplayMember = "RaceName";
			
			
			
		//this.Race.ValueMember ="RaceName";
		
		//this.Race.DisplayMember = "RaceName";
		//this.Race.DataSource = results.Tables[0];
		
		
    		//dataGridView1.DataSource = results.Tables[0].DefaultView;
    	}
		}
	}
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
	
				
			}
		
		
		
		
		public runners()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			PopulateMenu();
			
				//Amazingly we have to make a whole seperate manual query to get the freaking drop downs to populate
			
			//string getallraces = "Select RaceName from Races";
			
			//everyrace = GetSQlitefieldlist(getallraces,"RaceName");
			
			
			
		}
		
		
		
		private void FillData(string selectCommand)
        {
			 /// <remarks>
    
			
			SQLiteConnection conn = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL");
       //     dataGridView2.AutoGenerateColumns = true;
            
         //   string newselectCommand = "select * from Athletes ORDER BY OverallPos ASC";
           SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, "Data Source=RFIDTAGSTORE.s3db;journal mode=WAL");
            conn.Open();
           DataSet ds = new DataSet();
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da);
            da.Fill(ds); //,"Design1"
            dataGridView2.DataSource = ds.Tables[0] ;
            
            
            		  if (ds.Tables[0].Rows.Count > 1)
    {
       
       // dataGridView2.Columns["Title"].Width = 300;
        dataGridView2.Columns["unique_key"].Visible = false;
    }
            
            //dataGridView2.DataMember = "Design1";
            conn.Close();
            
       	// we have to make a  seperate manual query to get the freaking drop downs to populate
			
			string getallraces = "Select RaceName from Races";
			
			everyrace = GetSQlitefieldlist(getallraces,"RaceName");
      }
		
	
	
		
			
		
		

			void Button1Click(object sender, System.EventArgs e)
		{
			
			
				string Query = string.Format("Select * from Athletes WHERE Race = '{0}' AND (Status LIKE '{1}' OR Status IS NULL)",ChooseRace.Text, comboBoxStatus.Text);
			
	
			
		//	Console.WriteLine(Query);
			
			FillData(Query);
			
	
		
			}
		
		 private void SaveData(DataGridView dgv, string selectCommand)  
     {  
		    /// <remarks>
    /// Setting the path where the database file is located
    /// </remarks>
 //   string database = "RFIDTAGSTORE.s3db";
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
//    SQLiteConnectionStringBuilder datasource2 = new SQLiteConnectionStringBuilder();
//    datasource2.Add("Data Source", database);
//    datasource2.Add("Version", "3");
 //   datasource2.Add("New", "False");
//    datasource2.Add("Compress", "True");	            	
		 	
		 	
        using(SQLiteConnection conn = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"))
        {
        	dataGridView2.EndEdit();
        
            conn.Open(); 
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, "Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"); 
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da); 
            DataTable dt = dgv.DataSource as DataTable;
            da.Update(dt);
            dt.AcceptChanges();
            Console.WriteLine("We think we just updated the table");
            
            conn.Close();
        }
     }
			
			
		
		
		
		
		void Button2Click(object sender, EventArgs e)
		{
			string Query = "Select * from Athletes WHERE Race = "+"\'" + ChooseRace.Text + "\'";
			
		
			
			SaveData(dataGridView2, Query);	
		}
		
		void Button3Click(object sender, EventArgs e)
		{
		
			importcsv ips = new importcsv();
			ips.Show();
			
		}
		
		
		
		void Button5Click(object sender, EventArgs e)
		{
			
			ResultsPrint rp = new ResultsPrint();
			rp.Show();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			
			SaveFileDialog sv = new SaveFileDialog();
			sv.Title = "I hate bugs";
			
			
			if (sv.ShowDialog() == DialogResult.OK)
            {
                string CsvFpath = sv.FileName;

                try
                {
                System.IO.StreamWriter csvFileWriter = new System.IO.StreamWriter(CsvFpath, false);

            int countColumn = dataGridView2.ColumnCount - 1;

            int iColCount = dataGridView2.Columns.Count;
string headers = "ID,BibNumber,dunno,First,Last,DOB,Age,Gender,RaceName,GunStart,ChipStart,Status,Laps,ChipEnd,ManualEnd,NettTime,GunTime,OverallPos,GenderPos,CatPos,Category";
            
            csvFileWriter.WriteLine(headers);
            
            foreach (DataGridViewRow dataRowObject in dataGridView2.Rows)
            {
                //Checking for New Row in DataGridView
                if (!dataRowObject.IsNewRow)
                {
                    string dataFromGrid = "";

                    dataFromGrid = dataRowObject.Cells[0].Value.ToString();

                    for (int i = 1; i <= countColumn; i++)
                    {
                        dataFromGrid = dataFromGrid + ',' + dataRowObject.Cells[i].Value.ToString();
                    }

                    //Writing Data Rows in File
                    csvFileWriter.WriteLine(dataFromGrid);
                }
            }


            csvFileWriter.Flush();
            csvFileWriter.Close();
        }
        catch (Exception exceptionObject)
        {
            MessageBox.Show(exceptionObject.ToString());
        }
			
			
			
			
			
			}
			
		}
		
		void Doh(object sender, DataGridViewRowErrorTextNeededEventArgs e)
		{
			//more nothing
		}
		
		void Somethingsmellsfunny(object sender, DataGridViewDataErrorEventArgs e)
		{
			
			//nothing
			
		}
		private	 DataSet runner = new DataSet();
		string runneruniquekey;
		string sqlsearchrunner;
		
		void Button6Click(object sender, EventArgs e)
		{
// Search based on last name , race and bib number

if (textBoxBib2.Text != "") {

 sqlsearchrunner = string.Format("Select * from Athletes WHERE BibNumber = '{0}'  AND Race = '{1}'",textBoxBib2.Text, comboBoxRace2.Text);

 try {
 
runner =  DbSqlite.GetDataSetSqlite(sqlsearchrunner);

if (runner.Tables[0].Rows.Count != 0) {
			
			comboBoxRace2.Text = runner.Tables[0].Rows[0]["Race"].ToString();
			textBoxFname.Text = runner.Tables[0].Rows[0]["Fname"].ToString();
			textBoxLname2.Text = runner.Tables[0].Rows[0]["Lname"].ToString();
			comboBoxSex.Text = runner.Tables[0].Rows[0]["Sex"].ToString();
			comboBoxStatus2.Text = runner.Tables[0].Rows[0]["Status"].ToString();
			dateTimePicker1.Text = runner.Tables[0].Rows[0]["DOB"].ToString();
			textBoxBib2.Text =  runner.Tables[0].Rows[0]["BibNumber"].ToString();
			textBoxGunStart.Text =  runner.Tables[0].Rows[0]["GunStart"].ToString();
			textBoxManualEnd.Text =  runner.Tables[0].Rows[0]["ManualEnd"].ToString();
			
			
			
runneruniquekey = runner.Tables[0].Rows[0]["unique_key"].ToString();
}

 }
 
 catch {MessageBox.Show("No result for that search");}

}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
// Save changes back to DB

string updatesqlrunner = string.Format("UPDATE Athletes SET Fname = '{0}', Lname = '{1}', Sex= '{2}', DOB= '{3}', Race= '{4}', Status= '{5}', BibNumber= '{6}', GunStart= '{7}', ManualEnd= '{8}' WHERE unique_key='{9}'",textBoxFname.Text, textBoxLname2.Text,comboBoxSex.Text, dateTimePicker1.Text, comboBoxRace2.Text, comboBoxStatus2.Text, textBoxBib2.Text, textBoxGunStart.Text, textBoxManualEnd.Text, runneruniquekey);

DbSqlite.SimpleSQliteAction(updatesqlrunner);

//update the view

runner =  DbSqlite.GetDataSetSqlite(sqlsearchrunner);


		}
		
		void Panel2Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void DataGridView2CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
//nothing			
		}
}
	
}

		
	

