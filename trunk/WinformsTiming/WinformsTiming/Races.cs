/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 3/02/2013
 * Time: 2:27 PM
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
	/// Description of Races.
	/// </summary>
	public partial class Races : Form
	{
		
		string thissearchstring;
		private	 DataSet ds2 = new DataSet();
		
		private void FillData(string selectCommand)
        {
			 /// <remarks>
    /// Setting the path where the database file is located
    /// </remarks>
    string database = "RFIDTAGSTORE.s3db";
    /// <remarks>
    /// Creating a ConnectionString pointing to the database file
    /// </remarks>
    SQLiteConnectionStringBuilder adatasource = new SQLiteConnectionStringBuilder();
    adatasource.Add("Data Source", database);
    adatasource.Add("Version", "3");
    adatasource.Add("New", "False");
    adatasource.Add("Compress", "True");	         
			
			
			SQLiteConnection conn = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db");
            dataGridView1.AutoGenerateColumns = true;
          //  string newselectCommand = "select * from Athletes";
           SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, adatasource.ConnectionString);
            conn.Open();
           DataSet ds = new DataSet();
           
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da);
            da.Fill(ds); //,"Design1"
            dataGridView1.DataSource = ds.Tables[0] ;
       //     dataGridView1.DataMember = "dgm";
            conn.Close();
      }
		
		
		 public static void SaveDataTable(DataGridView dgv, string selectCommand)  
     {  
	            	
		 	
		 	
        using(SQLiteConnection conn = new SQLiteConnection(DbSqlite.RFIDTAGSTORE))
        {
        	dgv.EndEdit();
        
           // conn.Open(); 
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, DbSqlite.RFIDTAGSTORE); 
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da); 
            DataTable dt = dgv.DataSource as DataTable;
            da.Update(dt);
            dt.AcceptChanges();
            Console.WriteLine("We think we just updated the table");
            
         //   conn.Close();
        }
     }
		
		
		
		
		
		
		
		public Races()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
		
			
		try {


			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			DataSet menu = DbSqlite.GetDataSetSqlite("SELECT * FROM races");

			ChooseRace.DataSource = menu.Tables[0];
			ChooseRace.DisplayMember = "RaceName";
			ChooseRace.BindingContext = BindingContext;

				dataGridView1.AutoGenerateColumns = true;

			dataGridView1.DataSource = menu.Tables[0];


		} catch (Exception ex)
			
		{
			MessageBox.Show (ex.Message);
		}
			
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{

			thissearchstring = string.Format("Select * from Races where RaceName = '{0}'",ChooseRace.Text); // where RaceName ="+ChooseRace.Text;

		
			ds2 =  DbSqlite.GetDataSetSqlite(thissearchstring);
			
			textBoxRaceName.Text = ds2.Tables[0].Rows[0]["RaceName"].ToString();
			textBoxRaceLength.Text = ds2.Tables[0].Rows[0]["RaceHours"].ToString();
			textBoxRaceLaps.Text = ds2.Tables[0].Rows[0]["RaceLaps"].ToString();
			comboBoxStatus.Text = ds2.Tables[0].Rows[0]["RaceOver"].ToString();
			comboBoxType.Text = ds2.Tables[0].Rows[0]["RaceType"].ToString();
			
			
			//dataGridView2.DataSource = ds2.Tables[0];
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			thissearchstring = string.Format("Select * from Races"); //where RaceName = '{0}'",ChooseRace.Text);
			Console.WriteLine(thissearchstring);
			
			DbSqlite.SaveDataTable(dataGridView1,thissearchstring);

			DataSet menu = DbSqlite.GetDataSetSqlite("SELECT * FROM races");
			
			ChooseRace.DataSource = menu.Tables[0];
			ChooseRace.DisplayMember = "RaceName";
			ChooseRace.BindingContext = BindingContext;
			
			dataGridView1.AutoGenerateColumns = true;
			
			dataGridView1.DataSource = menu.Tables[0];
			
			
		}
		
		void Button3Click(object sender, System.EventArgs e)
		{
//save changes to db

string updateracesql = string.Format("UPDATE Races SET RaceOver = '{0}', RaceLaps = '{1}', RaceHours = '{2}', RaceType = '{3}' WHERE RaceName = '{4}'",comboBoxStatus.Text,textBoxRaceLaps.Text,textBoxRaceLength.Text,comboBoxType.Text,textBoxRaceName.Text );

Console.WriteLine(updateracesql);
DbSqlite.SimpleSQliteAction(updateracesql);

//refresh data in view

ds2 =  DbSqlite.GetDataSetSqlite(thissearchstring);

		}
		
		
		
		
		
	
		
		
	}
}
