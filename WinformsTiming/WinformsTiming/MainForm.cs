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
using Timer = System.Timers.Timer;
using System.IO;


namespace WinformsTiming
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		 SQLiteConnection RFIDTAGSTORE = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
		static public bool calculatelock {set; get;}
		static public bool CalculateStats {get; set;}
		public Dictionary<string,bool> ReaderStatus = new Dictionary<string, bool>();
		private static MainForm instance;
		
		static public decimal beforeStart=15;
		static public decimal afterStart=1;
		static public decimal starttofinish=8;
		static public decimal minlaptime=3;
		
		  TextBoxStreamWriter  _writer = null;

		
		
		public static MainForm Instance
		{
			get {return instance;}
		}
		
		
		
		
		SQLiteConnection sqConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL"); 
	
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
	
			
			instance = this;
			
			System.Timers.Timer autostatsupdate = new System.Timers.Timer(60000);
			autostatsupdate.AutoReset = true;
			autostatsupdate.Interval = 60000;
			autostatsupdate.Elapsed += new System.Timers.ElapsedEventHandler(autostatsupdate_Elapsed);
			autostatsupdate.Start();
			
		
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			//if auto stats is enabled, run it every minute..
			
			DbSqlite.RFIDTAGSTORE.Open();
			formstest.MainClass.RFIDTAGSTORE.Open();
			DbSqlite.RFIDTAGSTORE2.Open();
			
			
				
			
			
			
		}
		
		
		void UpdateTextBoxRunners()
			
		{
			
			//Console.WriteLine("Starting maintext Loop");
			
			//loop through the list of messages
				
			for (int i = 0; i < formstest.MainClass.MainMessages.Count; i++)
			//foreach (string str1 in formstest.MainClass.RunnerMessages)
            {
				string str1 = formstest.MainClass.MainMessages[i];
				
			//	Console.WriteLine("in maintext Loop");
				try {	Invoke(new Action(delegate {textBoxRunners.Text += str1;textBoxRunners.TextAlign = HorizontalAlignment.Center;} ) );
					//textBox5.Text = str1;
					//Console.WriteLine(str1);
			
				//Thread.Sleep(50);
				formstest.MainClass.MainMessages.Remove(str1);
				//clear the screen
				Invoke(new Action(delegate {
				                  	textBoxRunners.Text += Environment.NewLine;
				                  
				                  textBoxRunners.SelectionStart = textBoxRunners.Text.Length;
  									textBoxRunners.ScrollToCaret();
				                  
				                  
				                  
				                  } ) );
				}
				
				catch {//oops}
			
			//show each one for 3 seconds and then delete it from the list 
				}
			}
				
			
			
		}
		
		
		
		public string GetSingleSQlitefield(string mySelectQuery, string columnName) 
{ 
			string whateverwejustgot="Nothing";
			//this will only work when there is just one result...
			

  SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE); 
  //sqCommand.Connection.Open(); 
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
   
  //  sqreadConnection2.Close(); 
  //   sqreadConnection2.Dispose();
    
  } 
  return whateverwejustgot;
} 
		
		public int AntennaStatsMins {get; set;}
		public int AntennaStatsUpdate {get; set;}
		//DataTable readerstats = new DataTable();
		
		public void UpdateAntennaStats()
			
		{
			
			
			DateTime getreadsfrom = System.DateTime.Now.AddMinutes(-Convert.ToDouble(AntennaStatsMins2.Value));
			
			DateTime timerightnow = System.DateTime.Now.AddMinutes(0);
				
			label6.Text = getreadsfrom.ToString("yyyy-MM-dd HH:mm:ss");
			
				RFIDTAGSTORE.Open();
			
				List<string> ReaderList = new List<string>();
				ReaderList.Add("Reader1");
				ReaderList.Add("Reader2");
				
				dataGridView1.Rows.Clear();
				
				foreach (var reader in ReaderList) {
					
								
				
			//query the db for any reads within the last xx minutes
			
			string getreadcounts1 = string.Format("SELECT COUNT(epc) FROM Splits WHERE readerip='{0}' AND ant='{1}' AND created BETWEEN '{2}' AND '{3}'",reader,"1",getreadsfrom.ToString("yyyy-MM-dd HH:mm:ss"),timerightnow.ToString("yyyy-MM-dd HH:mm:ss"));
			string getreadcounts2 = string.Format("SELECT COUNT(epc) FROM Splits WHERE readerip='{0}' AND ant='{1}' AND created BETWEEN '{2}' AND '{3}'",reader ,"2",getreadsfrom.ToString("yyyy-MM-dd HH:mm:ss"),timerightnow.ToString("yyyy-MM-dd HH:mm:ss"));
			string getreadcounts3 = string.Format("SELECT COUNT(epc) FROM Splits WHERE readerip='{0}' AND ant='{1}' AND created BETWEEN '{2}' AND '{3}'",reader ,"3",getreadsfrom.ToString("yyyy-MM-dd HH:mm:ss"),timerightnow.ToString("yyyy-MM-dd HH:mm:ss"));
			string getreadcounts4 = string.Format("SELECT COUNT(epc) FROM Splits WHERE readerip='{0}' AND ant='{1}' AND created BETWEEN '{2}' AND '{3}'",reader ,"4",getreadsfrom.ToString("yyyy-MM-dd HH:mm:ss"),timerightnow.ToString("yyyy-MM-dd HH:mm:ss"));
			
			
			
			string antcount1 = GetSingleSQlitefield(getreadcounts1,"COUNT(epc)");
				string antcount2 = GetSingleSQlitefield(getreadcounts2,"COUNT(epc)");
					string antcount3 = GetSingleSQlitefield(getreadcounts3,"COUNT(epc)");
						string antcount4 = GetSingleSQlitefield(getreadcounts4,"COUNT(epc)");
			
		
			
			dataGridView1.Rows.Add(reader,antcount1,antcount2,antcount3,antcount4);
			
		}
			
			
			RFIDTAGSTORE.Close();
		}
		
		
		public void UpdateReaderStatus (String name, bool connected)
	
		{
			if (!string.IsNullOrEmpty(name)) {
			if (ReaderStatus.ContainsKey(name)) ReaderStatus.Remove(name);
			if (connected == true) ReaderStatus.Add(name, connected);
			
			if (ReaderStatus.ContainsKey(Reader1IP.Text)) checkBox4.Checked = true; else checkBox4.Checked = false;
			if (ReaderStatus.ContainsKey(Reader2IP.Text)) checkBox5.Checked = true; else checkBox5.Checked = false;
			}
		}
			
		
		private  void autostatsupdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			
		{
			Console.WriteLine("Auto stats timer fired");
		
			
			AutoStats();
		}
			
		public  List<string>GetSQlitefieldlist(string mySelectQuery, string columnName) 
{ 
			
			//this will make a list of  results...
			
			List<string> columnList = new List<string>();
			
  
  SQLiteCommand sqCommand = new SQLiteCommand(mySelectQuery, sqConnection); 
  sqCommand.Connection.Open(); 
  SQLiteDataReader sqReader = sqCommand.ExecuteReader(); 
  try 
  { 
    while(sqReader.Read()) 
    { 
    	
    	string whateverwejustgot = sqReader[columnName].ToString();
   // 	Console.Write("{0} ", whateverwejustgot);
    	columnList.Add(whateverwejustgot);
    	
    }
  } 
  finally 
  { 
    sqReader.Close(); 
    sqConnection.Close(); 
  } 
  return columnList;
} 
		
		public void AutoStats ()
			
		{
			
			//if generate stats is yes look through the list of races and add any running races to the list
			
			if (CalculateStats == true && calculatelock == false) {
				
				Console.WriteLine("No lock stopping the auto report now");
				
				try
					
				{
				
				
				string racesinprogress = string.Format("Select RaceName from Races WHERE RaceOver ='{0}'","Running");
				//get the list of running races
				
			List<string> currentraces =	GetSQlitefieldlist(racesinprogress,"RaceName");
				
			Reports updater = new Reports();
			
			
			//loop through the list once every minute and generate the stats
			
				foreach (string race in currentraces )
			
				{
					Console.WriteLine("Auto Updating Stats for {0}", race);
					
					updater.GenerateRaceStats(race);
					
					
				}
			
				
				}
			catch
				
			{
				Console.WriteLine("Auto Report death...");
			}
			
				}
			
		}
		
		
		
		 public void AppendToTextBox (string value)
			
		{
			if (InvokeRequired)
			{
				this.Invoke(new Action<string>(AppendToTextBox), new object[] {value});
				return;
			}
			MainTextBox.AppendText(value + "\n");
		}
		
		
		void QueryClick(object sender, EventArgs e)
		{
				if (tagviewwindow == null)
				
			{
				tagviewwindow = new TimingCode();
				tagviewwindow.FormClosing += tagviewwindowclosing;
				
			//	RaceWindow.Parent = this;
			}
			tagviewwindow.Show();
			tagviewwindow.Focus();
		}
		
		public void tagviewwindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			tagviewwindow=null;
		}
		
		public void reportwindowclosing (object sender, FormClosingEventArgs e)
			
		{
			
			reportwindow=null;
		}
		void Button3Click(object sender, EventArgs e)
		{
				if (reportwindow == null)
				
			{
				reportwindow = new Reports();
				reportwindow.FormClosing += reportwindowclosing;
			//	RaceWindow.Parent = this;
			}
			reportwindow.Show();
			reportwindow.Focus();
		}
		
		
		
		
		
		void Button4Click(object sender, EventArgs e)
		{
			UpdateAntennaStats();
		}
		
		
		
	
	 public void RaceStatsBoxUpdate()
		
	{
		
		if (InvokeRequired)
			{
				this.Invoke(new Action(RaceStatsBoxUpdate));
				return;
			}
	 	
	 	
	 	RaceStatsBox.Clear();
		
		foreach (var race in formstest.MainClass.RaceStats) {
			
		


	 		RaceStatsBox.Text += race.Value.ToString();
	 		RaceStatsBox.Text += Environment.NewLine;
		}
	 	UpdateAntennaStats();
		
	}
	
		
		void Button5Click(object sender, EventArgs e)
		{
					//enter the current time as a manual read
			
			if (manualbib.Text !="") {
				
				DateTime manualnow = DateTime.Now.ToLocalTime();
				
				//as we are not specifying the race, we are just looking for bib numbers that started within the last 24 hrs...
				
				DateTime date24hrsago = DateTime.Now.AddHours(-24);
				
				string manualbibupdate = string.Format("Update Athletes SET ManualEnd='{0}' WHERE GunStart >= '{2}' AND BibNumber='{1}'",manualnow,manualbib.Text,date24hrsago.ToString());
				
				SimpleSQliteInsert(manualbibupdate);
				
				Console.WriteLine(manualbibupdate); }
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			
			//Add anonymous entry into splits table
			
			string panicinsert = string.Format("INSERT INTO Splits (epc) VALUES ('{0}')","Marker");
			SimpleSQliteInsert(panicinsert);
		}
		
		public void SimpleSQliteInsert(string mySelectQuery) 
{ 
			
				try {
				
				RFIDTAGSTORE.Open();
			
 //SQLiteConnection sqwriteConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
  
 SQLiteCommand sqCommandw = new SQLiteCommand(mySelectQuery, RFIDTAGSTORE);
 // sqCommandw.Connection.Open(); 
  sqCommandw.ExecuteNonQuery();
  sqCommandw.Dispose ();
  
  RFIDTAGSTORE.Close();
  //  sqwriteConnection.Close(); 
    
  //   sqwriteConnection.Dispose();
  
				}
				
				catch (Exception ex)
					
				{
					Console.WriteLine(ex.Message);
				}
    
} 
		
		
		
		
		
		void Button6Click(object sender, EventArgs e)
		{

	if (manualbib.Text !="") {
				
				DateTime manualnow = DateTime.Now.AddSeconds(-2);
				
				//as we are not specifying the race, we are just looking for bib numbers that started within the last 24 hrs...
				
				DateTime date24hrsago = DateTime.Now.AddHours(-24);
				
				string manualbibupdate = string.Format("Update Athletes SET ManualEnd='{0}' WHERE GunStart >= '{2}' AND BibNumber='{1}'",manualnow,manualbib.Text,date24hrsago.ToString());
				
				SimpleSQliteInsert(manualbibupdate);
				
				Console.WriteLine(manualbibupdate); }



			
		}
		
		void Button7Click(object sender, EventArgs e)
		{

if (manualbib.Text !="") {
				
				DateTime manualnow = DateTime.Now.AddSeconds(-5);
				
				//as we are not specifying the race, we are just looking for bib numbers that started within the last 24 hrs...
				
				DateTime date24hrsago = DateTime.Now.AddHours(-24);
				
				string manualbibupdate = string.Format("Update Athletes SET ManualEnd='{0}' WHERE GunStart >= '{2}' AND BibNumber='{1}'",manualnow,manualbib.Text,date24hrsago.ToString());
				
				SimpleSQliteInsert(manualbibupdate);
				
				Console.WriteLine(manualbibupdate); }


			
		}
		
		void Button9Click(object sender, EventArgs e)
		{

//first we need to convert the bib number to an EPC

if (manualbib.Text !="") {
	
	string epc = manualbib.Text.PadLeft(24,'0');


//Then we add an entry for now
string panicinsert = string.Format("INSERT INTO Splits (epc) VALUES ('{0}')",epc);
			SimpleSQliteInsert(panicinsert);


}
else {MessageBox.Show("You must enter a Bib Number!");}
			
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			 tabs frm = new tabs();
      //frm.TopLevel = false;
     // frm.Visible = true;
    //  frm.FormBorderStyle = FormBorderStyle.None;
    //  frm.Dock = DockStyle.Fill;
     // tabControl1.TabPages[0].Controls.Add(frm);
     frm.Show();
     frm.Focus();
     
     
        }
	
		 public Thread consolethread;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			 
//try and stop it locking up the UI

Thread consolethread = new Thread(new ThreadStart(ConsoleRedirect));
			consolethread.IsBackground = true;
			consolethread.Start();


            
            
		}
		
		
		void ConsoleRedirect ()
			
		{
			
				//	 Instantiate the writer
             _writer = new TextBoxStreamWriter(txtConsole);
             // Redirect the out Console stream
            Console.SetOut(_writer);

            Console.WriteLine("Now redirecting output to the text box");
            
           
			
			
		}
		
		
		
		
		void Timer1Tick(object sender, EventArgs e)
		{
			    Thread runnersthread = new Thread(new ThreadStart(UpdateTextBoxRunners));
			runnersthread.IsBackground = true;
			runnersthread.Start();
			
		//	 Console.WriteLine("Started Runner Stats Thread");
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			consolethread.Abort();
		}
		
		void CheckBox6CheckedChanged(object sender, EventArgs e)
		{

			if (checkBox6.Checked == true)	
				
				
			{
			
				TextBoxStreamWriter.consoleenabled = true;
				
				
			}
			if (checkBox6.Checked == false) 
				
			{
				TextBoxStreamWriter.consoleenabled =false;
				
				 // Recover the standard output stream so that a  
        // completion message can be displayed.
        StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
				
				
			}
				
				
		}
		
		void CheckBoxTestModeCheckedChanged(object sender, EventArgs e)
		{


if (checkBoxTestMode.Checked == true) {
				
				// Test Mode. We want to turn off stats calculation
				
				formstest.MainClass.Variables.TestMode = true;
	
	// We want to make the record beep interval every 2 secs for each tag
	
	formstest.MainClass.Variables.ReadsPerSec = 0;
	formstest.MainClass.Variables.UpdateSecs = 1;
	formstest.MainClass.Variables.NewTagSecs = 1;


//We want to record the tag with a test prefix on its number so it does not get included in results



//write only disable updates ...done with timing interval


//we want to flash up the tagid antenna and rssi on the screen
//set the mode to test


//we need to change the reader initialisation string to not do any filtering stuff


} else
				
			{
			
			//We just turned it off, lets try and reset things 
			
			// Test Mode. We want to turn off stats calculation
				
				formstest.MainClass.Variables.TestMode = false;
	
	// We want to make the record beep interval every 2 secs for each tag
	
	formstest.MainClass.Variables.ReadsPerSec = 1;
	formstest.MainClass.Variables.UpdateSecs = 30;
	formstest.MainClass.Variables.NewTagSecs = 90;
	
	MessageBox.Show("Test mode is off and the default setting of 1 Read/Sec, Update Every 30 Secs and New every 90 Secs has been applied. If you need something else make the changes and hit update!");
			
			
			}


		}
		
		void CheckBox7CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked == true) {
				
				//enable power save mode
				
				formstest.MainClass.Variables.powersave = true;
			} else {formstest.MainClass.Variables.powersave = false;}
			
			
		}
		
		void CheckBox8CheckedChanged(object sender, EventArgs e)
		{
			
		if (checkBox8.Checked == true) {
				
				//enable number speech
				
				formstest.MainClass.Variables.talk = true;
			} else {formstest.MainClass.Variables.talk = false;}	
			
		}
		
		void CheckBox9CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked == true) {
				
				//enable number speech
				
				formstest.MainClass.Variables.SayAntenna = true;
			} else {formstest.MainClass.Variables.SayAntenna = false;}	
		}
}
}







