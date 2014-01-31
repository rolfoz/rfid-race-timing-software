/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 28/01/2013
 * Time: 2:05 PM
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
	/// Description of Race.
	/// </summary>
	public partial class SelectRace : Form
	{
		 
public string RaceStartValue;
public string RaceType;
public string RaceLaps;
public string RaceHours;
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
       
		
		public void FillData(string selectCommand)
        {
			 /// <remarks>
    /// Setting the path where the database file is located
    /// </remarks>
   // string database = "RFIDTAGSTORE.s3db";
   
 //  	 string database = "RFIDTAGSTORE.s3db";
   
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
 //   SQLiteConnectionStringBuilder adatasource = new SQLiteConnectionStringBuilder();
 //   adatasource.Add("Data Source", database);
  //  adatasource.Add("Version", "3");
 //   adatasource.Add("New", "False");
 //   adatasource.Add("Compress", "True");	         
			
			
			SQLiteConnection conn = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL");
            dataGridView1.AutoGenerateColumns = true;
          //  string newselectCommand = "select * from Athletes";
           SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, conn);
            conn.Open();
           DataSet ds = new DataSet();
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da);
            da.Fill(ds); //,"Design1"
            dataGridView1.DataSource = ds.Tables[0] ;
            //dataGridView2.DataMember = "Design1";
            conn.Close();
            
           // DataTable dt = ds.Tables[0];
      }
	
		
		public SelectRace()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			FillData("Select * from Races");
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
 //   string database = "RFIDTAGSTORE.s3db";
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
 //   SQLiteConnectionStringBuilder datasource = new SQLiteConnectionStringBuilder();
  //  datasource.Add("Data Source", database);
 //   datasource.Add("Version", "3");
//    datasource.Add("New", "False");
//    datasource.Add("Compress", "True");	            
    /// <remarks>
    /// Starting the connection and sending the query
    /// </remarks>	            
    using (SQLiteConnection aconnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"))
    {
    	using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(NewQuery, aconnection))
    	{
    		/// <remarks>
    		/// Populating the DataGridView
    		/// </remarks>
    		adapter.Fill(results);
    		
    		SelectRace2.DataSource = results.Tables[0];
			SelectRace2.DisplayMember = "RaceName";
			SelectRace2.BindingContext = BindingContext;
    		
    		//dataGridView1.DataSource = results.Tables[0].DefaultView;
    	}
		}
	}
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
			
			
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			TimersWindow tww = new TimersWindow();
			
			tww.TimerRaceName = SelectRace2.Text;
			
			//check the db to see if this race is already started
			//if it is we use the existing start time
			//if not we write the starttime to the db
			
			//selectquery = "Select * from Races where "
			
			//ExecuteSQLQuery("Select * from Races where RaceName =");
			
			//fill the datatable
			
			string racestartquery = string.Format("Select * from Races WHERE RaceName = '{0}'", SelectRace2.Text);
			
			Console.WriteLine(racestartquery);
			//FillData(racestartquery);
			
			//search the datatable for the value
			
			//string connstring = "Data Source=RFIDTAGSTORE.s3db";
			
			CreateSQLiteDataReader(racestartquery);
		
	
			tww.RaceTimeStartTime = DateTime.Now.ToLocalTime ();
			
			try {
			
			tww.RaceTimeStartTime = Convert.ToDateTime(RaceStartValue) ;
			
			}
				
			catch {
			string sqlinsert = string.Format("UPDATE Races SET RaceStart='{0}', RaceOver = '{1}' WHERE RaceName ='{2}'",tww.RaceTimeStartTime,"Running",SelectRace2.Text);
			
			Console.WriteLine(sqlinsert);
			
			DbSqlite r = new DbSqlite();
			
		//	DbSqlite.RFIDTAGSTORE.Open();
			
			r.SimpleSQliteInsert(sqlinsert);
			
			
	//Lets also set the GunTime for all the athletes in the race.
		
	string	 setstartsql = string.Format("UPDATE Athletes SET GunStart='{0}', NettTotal = null, GunTotal = null, OverallPos = null, GenderPos = null, CatPos = null  WHERE Race='{1}'",tww.RaceTimeStartTime.ToString(), SelectRace2.Text);
			
		 r.SimpleSQliteInsert(setstartsql);
		 
		 Console.WriteLine(setstartsql);
		 
	//	DbSqlite.RFIDTAGSTORE.Close();
		 
			}
			
			
			
			//tww.RaceTimeStartTime = SQLRaceStartTime;
			
			tww.RaceLaps = RaceLaps;
			tww.RaceHours = RaceHours;
			tww.RaceType = RaceType;
			
			tww.Text = SelectRace2.Text + " Timer";
			tww.Show();
						
		//	var race = new formstest.MainClass.Races();
			//	race.RaceName = SelectRace2.Text;
			
        
			}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			
		}
		
		public void CreateSQLiteDataReader(string mySelectQuery) 
{ 
			
			
			
  SQLiteConnection sqConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"); 
  SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, sqConnection); 
  sqCommand.Connection.Open(); 
  SQLiteDataReader sqReader = sqCommand.ExecuteReader(); 
  try 
  { 
    while(sqReader.Read()) 
    { 
    	
    	RaceStartValue = sqReader["RaceStart"].ToString();
    	RaceType = sqReader["RaceType"].ToString();
    	RaceLaps = sqReader["RaceLaps"].ToString();
    	RaceHours = sqReader["RaceHours"].ToString();
    	
    	Console.Write("{0} ", sqReader["RaceStart"]);
    }
  } 
  finally 
  { 
    sqReader.Close(); 
    sqConnection.Close(); 
  } 
} 
		
		
		
		
		
		}
	}

