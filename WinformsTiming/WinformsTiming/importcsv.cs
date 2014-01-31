/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 4/02/2013
 * Time: 1:32 PM
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
	/// <summary>
	/// Description of importcsv.
	/// </summary>
	public partial class importcsv : Form
	{
		
		public void SimpleSQliteInsert(string mySelectQuery) 
{ 
			
			
			
  SQLiteConnection sqConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db"); 
  SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, sqConnection); 
  sqCommand.Connection.Open(); 
  sqCommand.ExecuteNonQuery();
 
    sqConnection.Close(); 
  
} 
		
		
		private void PopulateMenu()
				
			{
							string NewQuery = "Select * from Races"; //+ "\'%"+ SelectRace.Text+"\'";
Console.WriteLine(NewQuery);

//Pass string to function here....

		/// <remarks>
/// Creating a DataSet to feed the DataGridView
/// </remarks>  		
// 
DataSet results = new DataSet();
try
{
    /// <remarks>
    /// Setting the path where the database file is located
    /// </remarks>
    string database = "RFIDTAGSTORE.s3db";
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
    SQLiteConnectionStringBuilder datasource = new SQLiteConnectionStringBuilder();
    datasource.Add("Data Source", database);
    datasource.Add("Version", "3");
    datasource.Add("New", "False");
    datasource.Add("Compress", "True");	            
    /// <remarks>
    /// Starting the connection and sending the query
    /// </remarks>	            
    using (SQLiteConnection aconnection = new SQLiteConnection(datasource.ConnectionString))
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
    		
    		//dataGridView1.DataSource = results.Tables[0].DefaultView;
    	}
		}
	}
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
	
				
			}
		
		
		
		 private void SaveData(DataGridView dgv, string selectCommand)  
     {  
		 	string messageboxstring = string.Format("Did you select the correct race to add them to? {0}",ChooseRace.Text);
		 		DialogResult result1 = MessageBox.Show(messageboxstring,"Import Runners", MessageBoxButtons.YesNo);
       
       
       
       if (result1 == DialogResult.Yes) {
		 			
		 			
		 			//clean the database, remove any racers for the race...
		 			
		 			string cleantable = string.Format("DELETE FROM Athletes WHERE Race= '{0}'",ChooseRace.Text);
		 			
		 			SimpleSQliteInsert(cleantable);
		 			
		 			
		    /// <remarks>
    /// Setting the path where the database file is located
    /// </remarks>
    string database = "RFIDTAGSTORE.s3db";
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
    SQLiteConnectionStringBuilder datasource2 = new SQLiteConnectionStringBuilder();
    datasource2.Add("Data Source", database);
    datasource2.Add("Version", "3");
    datasource2.Add("New", "False");
    datasource2.Add("Compress", "True");	            	
		 	
    	//stopp editing
        	dataGridView1.EndEdit();
        
        

        	//turn the datagridview into a dataset
        	
        	DataSet ds = new DataSet();
        	
        	DataTable dt = new DataTable("DataFromCSV");
        	//ds.Tables.Add(dt);
        	
        	//create colums
        	
        //	foreach (DataGridViewColumn col in dataGridView1.Columns)
   
        //	{
       // 		dt.Columns.Add(col.DataPropertyName, typeof(string));
        
       // 	}
        		
//fill the rows of table:

 string connectionString = @"Data Source=RFIDTAGSTORE.s3db";
	
 System.Data.SQLite.SQLiteConnection  RFIDTAGSTORE2 = new SQLiteConnection(connectionString);
	


StringBuilder insert = new StringBuilder();

foreach (DataGridViewRow row in dataGridView1.Rows)
	
{
	
	
	if (row.IsNewRow)
		
		continue;
	 for (int c = 0; c < row.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        insert.Append(row.Cells[c].Value + "|");
                    }
	
	 string InsertRow = insert.ToString();
	 InsertRow = InsertRow.Remove(InsertRow.Length - 1);
	 string[] values = InsertRow.Split('|');
	 
	 
	 
	 RFIDTAGSTORE2.Open();
	 
		using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE2.BeginTransaction()) {
								string insertSQL2 = "INSERT INTO Athletes(BibNumber, Fname, Lname, DOB, Age, Sex, Race) values ";
								insertSQL2 += "(@bib, @fname, @lname, @dob, @age, @sex, @racename)";
                               //	insertSQL2 += "(@InsertRow)";
						Console.WriteLine(insertSQL2);
								SQLiteCommand insertCommand = new SQLiteCommand (insertSQL2, RFIDTAGSTORE2);

								insertCommand.Parameters.AddWithValue ("@bib", values[0].PadLeft(3,'0'));
								insertCommand.Parameters.AddWithValue ("@fname", values[1]);
								insertCommand.Parameters.AddWithValue ("@lname", values[2]);
								insertCommand.Parameters.AddWithValue ("@dob", values[3]);
								insertCommand.Parameters.AddWithValue ("@age", values[4]);
								insertCommand.Parameters.AddWithValue ("@sex", values[5]);
								insertCommand.Parameters.AddWithValue ("@racename", ChooseRace.Text);
								
								insertCommand.ExecuteNonQuery ();
								sqlTransaction.Commit ();
								RFIDTAGSTORE2.Close();
								
								insert.Clear();
	
							}
   
	
	
	
	
}
	
    
  
   
		/* 	
        using(SQLiteConnection conn = new SQLiteConnection(datasource2.ConnectionString))
        {
        	
        	
        	selectCommand = "Select BibNumber, Fname, Lname, Age, DOB, Sex from Athletes";
        	
            conn.Open(); 
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, datasource2.ConnectionString); 
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da); 
          //  DataTable dt = dgv.DataSource as DataTable;
          da.MissingSchemaAction = MissingSchemaAction.Ignore;
               da.MissingMappingAction = MissingMappingAction.Passthrough;
            da.Update(dt);
            dt.AcceptChanges();
            Console.WriteLine("We think we just updated the table");
            
            conn.Close();
        }
        
        */
   
//Tell them the import worked and then close the window 

string messageboxstring2 = string.Format("Import appears to have worked for {0}. Close this window and check the result in the runners page.",ChooseRace.Text);
		 		DialogResult result2 = MessageBox.Show(messageboxstring2,"Import OK", MessageBoxButtons.YesNo);
		 		
		 		if (result2 == DialogResult.Yes) { 


//close the current window

this.Close();
		 			
		 		}

		 		}
		
		 }
		
		public importcsv()
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
		
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{

Stream myStream = null;
    OpenFileDialog openFileDialog1 = new OpenFileDialog();

    openFileDialog1.InitialDirectory = "c:\\" ;
    openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*" ;
    openFileDialog1.FilterIndex = 1 ;
    openFileDialog1.RestoreDirectory = true ;

    if(openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        try
        {
            if ((myStream = openFileDialog1.OpenFile()) != null)
            {
                using (myStream)
                {
                    // Insert code to read the stream here.
                    
                    
                     System.IO.StreamReader fileReader = new System.IO.StreamReader(myStream, false);
                    
                       while (fileReader.Peek() != -1)
                        {
                       
                          string  fileRow = fileReader.ReadLine();
                        var  fileDataField = fileRow.Split(',');
                            dataGridView1.Rows.Add(fileDataField);
                        }
                        fileReader.Dispose();
                        fileReader.Close();
                    
                  
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        }
    }



		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
				string Query = "Select * from Athletes";// WHERE Race = "+"\'" + ChooseRace.Text + "\'";
				SaveData(dataGridView1,Query);
			
		}
	}
}
