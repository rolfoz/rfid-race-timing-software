/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 15/02/2013
 * Time: 10:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 // Lets try and get all the db methods into here..
 
 
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
using System.Collections.Concurrent;
using System.Timers;
using System.Globalization;

namespace WinformsTiming
{
	/// <summary>
	/// Description of DbSqlite.
	/// </summary>
	public partial class DbSqlite : Form
	{
		
		public  static SQLiteConnection RFIDTAGSTORE = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=12000"); 
		
		public  static SQLiteConnection RFIDTAGSTORE2 = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=12000"); 
		
		//public static DataTable DTSQ;
	
		public static DataSet GetDataSetSqlite (string sqlquery)
			
		{
			
			DataSet results = new DataSet();
try
{
	
	 // using (SQLiteConnection connection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"))
    {
    	using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlquery, RFIDTAGSTORE))
    	{
    		/// <remarks>
    		/// Populating the DataGridView
    		/// </remarks>
    		adapter.Fill(results);
    	//	DTSQ = results.Tables[0];
    
    	
    	}
		}
	 return results;

	}
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
    
    return results;
}
	
	
		
		
	
}
		
		
		 public static void SaveDataTable(DataGridView dgv, string selectCommand)  
     {  
	            	
		 	
		 	
        using(SQLiteConnection conn = new SQLiteConnection(RFIDTAGSTORE))
        {
        	dgv.EndEdit();
        
         //   conn.Open(); 
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, RFIDTAGSTORE); 
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da); 
            DataTable dt = dgv.DataSource as DataTable;
            da.Update(dt);
            dt.AcceptChanges();
            Console.WriteLine("We think we just updated the table");
            
        //    conn.Close();
        }
     }
	
	
	

			
			
			
		



		public string GetSingleSQlitefield(string mySelectQuery, string columnName)
{ 
			string whateverwejustgot="Nothing";
			//this will only work when there is just one result...
			

  SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE2); 
 // sqCommand.Connection.Open(); 
  SQLiteDataReader sqReader = sqCommand.ExecuteReader(); 
  try 
  { 
    while(sqReader.Read()) 
    { 
    	
    	 return sqReader[columnName].ToString();
    	//Console.Write("{0} ", whateverwejustgot);
    	
    }
  } 
  finally 
  { 
    sqReader.Close(); 
    sqReader.Dispose();
   
 //   RFIDTAGSTORE2.Close(); 
  //   sqreadConnection2.Dispose();
    
  } 
  return whateverwejustgot;
} 
		
		public  List<string>GetSQlitefieldlist(string mySelectQuery, string columnName) 
{ 
			
			//this will make a list of  results...
			
			List<string> columnList = new List<string>();
			
 // SQLiteConnection sqreadConnection3 = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
  SQLiteCommand sqCommand2 = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE2); 
  //sqCommand2.Connection.Open(); 
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
    sqReader2.Dispose();
   
    
  // RFIDTAGSTORE2.Close(); 
 //   sqreadConnection3.Dispose();
    
  } 
  return columnList;
} 
		
		static readonly object WriteLock = new object();
		
		public void SimpleSQliteInsert(string query)

{
			lock(WriteLock) {

  using (SQLiteTransaction dbTrans = formstest.MainClass.RFIDTAGSTORE.BeginTransaction())

  {

    using (SQLiteCommand cmd = formstest.MainClass.RFIDTAGSTORE.CreateCommand())

    {

      cmd.CommandText = query; //"INSERT INTO TestCase(MyValue) VALUES(?)";

     // DbParameter Field1 = cmd.CreateParameter();

    //  cmd.Parameters.Add(Field1);

        cmd.ExecuteNonQuery();

      }



    dbTrans.Commit();
    
  }
    
  }

		}


		public static void SimpleSQliteAction(string query)

{
			lock(WriteLock) {

  using (SQLiteTransaction dbTrans = formstest.MainClass.RFIDTAGSTORE.BeginTransaction())

  {

    using (SQLiteCommand cmd = formstest.MainClass.RFIDTAGSTORE.CreateCommand())

    {

      cmd.CommandText = query; //"INSERT INTO TestCase(MyValue) VALUES(?)";

     // DbParameter Field1 = cmd.CreateParameter();

    //  cmd.Parameters.Add(Field1);

        cmd.ExecuteNonQuery();

      }



    dbTrans.Commit();
    
  }
    
  }

		}
		
		
		
		
			public void SimpleSQliteInsertold(string mySelectQuery) 
{ 
			
				try {
			
 //SQLiteConnection sqwriteConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
  
 SQLiteCommand sqCommandw = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE);
 // sqCommandw.Connection.Open(); 
  sqCommandw.ExecuteNonQuery();
  sqCommandw.Dispose ();
  
 
  //  sqwriteConnection.Close(); 
    
  //   sqwriteConnection.Dispose();
  
				}
				
				catch (Exception ex)
					
				{
					Console.WriteLine(ex.Message);
				}
    
} 
		
		
		
		
		public DbSqlite()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
