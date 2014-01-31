/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 28/01/2013
 * Time: 3:33 PM
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
using System.Collections.Concurrent;
using System.Timers;
using System.Globalization;
using DGVPrinterHelper;



namespace WinformsTiming
{
	
	
	namespace formstest
	{
		
		
		


		//One Day we will get rid of these....
		
public static class MyGlobals {
	
	static public string ReaderIP;
static public string Reader2IP;
	static public string firstrun;
	static public string	PrintReportLine;
	static public string	SecondsBetweenSplits;
	static public string ReportLines;
	static public int ReaderCount;
	
	


	//	static public string	PrintReportLine;
	//	static public string	PrintReportLine;
	//	static public string	PrintReportLine;


}

 
//here is the main class, everything should be inside here...

	 public  class MainClass
	{
	 	
	 	
	 		//function to play sounds including on 64bit linux
static bool IsPlaying = false;
static int waitlist = 0;

public static void PlayWav (string file)
{
	waitlist ++;
	//Console.WriteLine("Play a Wav");
while (IsPlaying == true && waitlist < 100) {
Thread.Sleep(10);
//Console.WriteLine("Sleeping for Wav");

}

	if (waitlist > 100) {
		
		//skip more stuff too much in the buffer
		
		waitlist --;
		//Console.WriteLine("Buffer full skipping audio");
		return;
		
		
	}
	

if (IsLinux == true)
{
	
	Console.WriteLine("Linux Detected");
			IsPlaying = true;

//we are all fucked if it comes to this! Retarded play sound hack
System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents=false; 
                            proc.StartInfo.FileName = "aplay";
                            proc.StartInfo.Arguments = "-q -t wav "+file;
//proc.StandardOutput.Dispose();
                            proc.Start();

//	System.Media.SoundPlayer playme = new System.Media.SoundPlayer(file);
//	playme.PlaySync();
//	Console.WriteLine("Playing {0}", file);
Thread.Sleep(10);
proc.Close();
IsPlaying = false;
waitlist --;
}
 else {
	
	try {
	
			IsPlaying = true;
	//normal 32 bit and windoze code here
//	Console.WriteLine("Non Linux OS");
		System.Media.SoundPlayer playme = new System.Media.SoundPlayer(file);
	playme.PlaySync();
//	Console.WriteLine("Playing {0}", file);
Thread.Sleep(10);
	IsPlaying = false;
	waitlist --;
	
	} catch {
		Console.WriteLine("Unble to play {0}",file);
		System.Media.SystemSounds.Exclamation.Play();
		IsPlaying = false;
		waitlist --;
	}
	
	
}
}

	 	
	 	
	 	
	 	
	 	
	 	DbSqlite sqwriter = new DbSqlite();
	 	
	 	static public ConcurrentDictionary<string, string> RaceStats = new ConcurrentDictionary<string, string>();
	 	
	 	static public ConcurrentDictionary<string, string> Top10 = new ConcurrentDictionary<string, string>();
	 	
	 	static public List<String> RunnerMessages = new List<string>();
	 	
	 	static public List<String> MainMessages = new List<string>();
	 	
	 	
	 	public string ThisInstanceName {get; set;}
	 	
	 	static public ConcurrentDictionary<string, string> RecentTags = new ConcurrentDictionary<string, string>();
	 	
	 	static public ConcurrentDictionary<string, string> TagsInView = new ConcurrentDictionary<string, string>();
	 	
	 	
	 	public static DateTime DateTimeFromUnixTimestampMillis(long millis)
{
    return UnixEpoch.AddMilliseconds(millis/1000);
}
	
	 	private static readonly DateTime UnixEpoch =
    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	 	
	 static public string RFIDConnectionString = "Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000";
	 	
	 	static string connectionString = @"Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000";
	
public static System.Data.SQLite.SQLiteConnection  RFIDTAGSTORE = new SQLiteConnection(connectionString);
		//Create a collection of readers

static Dictionary<string, string>	readers = new Dictionary<string, string>();


static List<LLRPClient> llrpreaders = new List<LLRPClient>();


 //public LLRPClient reader;
		public LLRPClient reader;

	
	//	static LLRPClient writer;

		
		
public	static	class Variables {
		
		public static bool SayAntenna;
			
		public static bool talk;	
		
		public static bool Beep;
			
			static public string RaceInProgressStats {get; set;}
		
			public static bool powersave;
			
			public static bool TestMode;

			public static string runninglog;

		public	static MainClass one;
			public static MainClass two;

	static	public string Reader1IP {get; set;}
	static	public string Reader2IP {get; set;}
			static	public string Reader1Name {get; set;}
			static	public string Reader2Name {get; set;}
			static public int ReadsPerSec {get;set;}
			static public int UpdateSecs {get;set;}
			static public int NewTagSecs {get;set;}
			

			static public string Reader2Enabled { get; set; }
	static	public bool RaceStart {get; set;}
	static	public string WriterIP {get; set;}
			static public int ReaderCount { get; set; }
			public static string EpcToWrite {get; set;}
			public static string EpcToRead {get; set;}
			

// = new Dictionary<string, string>();
// public RecentTagsSet { get RecentTags; set RecentTags; }
 

 }
	
	public static bool IsLinux 
		{
			
			get
			{
				int p = (int) Environment.OSVersion.Platform;
				return (p==4) || (p==6) || (p==128);
			}
			
		}
	
	
	
	
		public string ConvertStringToHex(string asciiString)
{
string hex = "";
foreach (char c in asciiString)
{
int tmp = c;
hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
}
return hex;
}	

		static public void CleanDictBackgroundTask ()
		
		{
			
			var modifyrecenttags = new List<string>();
			
			foreach(KeyValuePair<String,String> entry in RecentTags)
{
   DateTime RightNow = DateTime.Now.ToLocalTime ();
string TagLastSeen = entry.Value;
string tagepc = entry.Key;
DateTime tlst1 = Convert.ToDateTime (TagLastSeen);
TimeSpan ts = RightNow - tlst1;
//Console.WriteLine("I see a tag aged "+ tagepc + ts.TotalSeconds.ToString());
if (ts.TotalSeconds > Variables.NewTagSecs-1) {
	modifyrecenttags.Add (tagepc);
	//RecentTags.Remove (tagepc);
	
	
}

				
}
	//now we are outside the foreach loop we can remove the stale tags

	string removedvalue2;
	foreach (var key in modifyrecenttags)
		
	{
		RecentTags.TryRemove (key, out removedvalue2);
	//	Console.WriteLine("culled a tag that was more than 35 secs old");
		
	}
	
		}

  private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
    
  //	Console.WriteLine("fired background timer");
  	CleanDictBackgroundTask();
    }
			
		
		
		public class Races
		{
			
			private System.Windows.Forms.Timer _timer;

        // The last time the timer was started
        private DateTime _startTime = DateTime.MinValue;

        // Time between now and when the timer was started last
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;

        // Time between now and the first time timer was started after a reset
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;

        // Whether or not the timer is currently running
        private bool _timerRunning = false;			
			
			public string RaceName {get;set;}
			
			public System.Data.DataTableCollection thiscollection {get;set;}
		
			
		

			
			
			
			public static void TagSystemBeep ()
		{
			//	Console.WriteLine("Asked to beep");
			




			if (formstest.MainClass.Variables.Beep == true)
				{

				
			//	System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Beep.wav");
			//	snd.Play();
try
{
			
	PlayWav("Beep.wav");
		//	Console.WriteLine("I just said beep");
			//Thread.Sleep(250);
}
			//	System.Media.SystemSounds.Exclamation.Play();
catch
	
{
		System.Media.SystemSounds.Exclamation.Play();		
}
			
				}
		
		}

		
			
			
			public void RaceTimers (string name) 
			
			{
				string TimerRaceName = name;
			
				// Start the stopwatch
				
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        
			sw.Start();
			
			//record the race name and start time in the db
			
			
			}
			
			public void MakeNewTimer()
				
			{
					  // Set up a timer and fire the Tick event once per second (1000 ms)
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; 
         //   _timer.Tick += new EventHandler(_timer_Tick);
			}
			
			
			public void StartTimer()
				
			{
				 // If the timer isn't already running
            if (!_timerRunning)
            {
                // Set the start time to Now
                _startTime = DateTime.Now;

                // Store the total elapsed time so far
                _totalElapsedTime = _currentElapsedTime;

                _timer.Start();
                _timerRunning = true;
            }
            else // If the timer is already running
            {
                _timer.Stop();
                _timerRunning = false;
            }
            
            
			}
			
			
			public void StopTimer()
				
			{
				
				 // If the timer isn't already running
            if (!_timerRunning)
            {
                // Set the start time to Now
                _startTime = DateTime.Now;

                // Store the total elapsed time so far
                _totalElapsedTime = _currentElapsedTime;

                _timer.Start();
                _timerRunning = true;
            }
            else // If the timer is already running
            {
                _timer.Stop();
                _timerRunning = false;
            }
				
			}
			
			
			public void ResetTimer()
				
			{
				 // Stop and reset the timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;
				
			}
			
			
		}

 
		
		
		
		public  void WriterControl ()
		{
Variables.WriterIP = "192.168.11.50";
		

 // Create a LLRPClient instance.
        reader = new LLRPClient();

ENUM_ConnectionAttemptStatusType status;
        reader.Open(MainClass.Variables.WriterIP, 5000, out status);

 // Check for a connection error
        if (status != ENUM_ConnectionAttemptStatusType.Success)
        {
            // Could not connect to the reader.
            // Print out the error
            Console.WriteLine(status.ToString());
            // Do something here.
            // Your application should not continue.
            return;
        }

  /*
        If you successfully connect to the reader,
        the next step is to create a delegate.
        The delegate determines which function gets called
        when a report event occur.
        */
       reader.OnRoAccessReportReceived += new
           delegateRoAccessReport(OnReportEvent);
   
        // Send the messages
        Delete_AccessSpec();
        Delete_RoSpec();
Add_RoSpec();
        Add_AccessSpec();
      
        Enable_RoSpec();
        
          Enable_AccessSpec();
   
        // Wait until the user presses return
     //   Console.ReadLine();
   
        // Cleanup the reader by deleting the ROSpec
     //   Delete_AccessSpec();
		//	Delete_RoSpec();

		}
		
		public string thisreaderip {set; get;}
	
		public  void ReaderControl (string readerName, string readerIP)
		{
			string thisreadername;
			thisreadername = readerName;
			thisreaderip = readerIP;
		

			reader = new LLRPClient ();


			Console.WriteLine ("Created New Reader Instance. ");
		
		
			MainForm.Instance.AppendToTextBox("Created New Reader Instance. ");
			//connect to reader, second value is timeout

			ENUM_ConnectionAttemptStatusType status;
			reader.Open (thisreaderip, 5000, out status);

		//	MainForm.Instance.AppendToTextBox(status.ToString());

			// Check for a connection error
    
			Console.WriteLine ("Connecting to Reader " + thisreaderip);
			MainForm.Instance.AppendToTextBox("Connecting to Reader " + thisreaderip);
if (status == ENUM_ConnectionAttemptStatusType.Success) {
				MainForm.Instance.AppendToTextBox("Connected to " + thisreaderip);
				MainForm.Instance.UpdateReaderStatus(thisreaderip,true);
			}
			
			if (status != ENUM_ConnectionAttemptStatusType.Success) {
				// Could not connect to the reader.
				// Print out the error
	
				Console.WriteLine ("Unable to Connect to Reader " + thisreaderip);
				Console.WriteLine (status.ToString ());

				MainForm.Instance.AppendToTextBox("Unable to Connect to Reader " + thisreaderip);
				MainForm.Instance.AppendToTextBox(status.ToString() );
				
				// Do something here.
				// Your application should not continue.
    
				return;
			}

			/*
            If you successfully connect to the reader, the next step is to
            create a delegate. The delegate determines which function gets
            called when a report event occurs.
            */

          
           
			//First make sure the DB is in place

			//As this is the first time, open a connection to the database

//Open a new connection to the local Database file, this lives in the Application Directory

			//if this is not the first connection don't open the DB


			if (Variables.ReaderCount < 1) {

			//	Variables.runninglog = "\n First connection opening/creating DB \n";

				// moved to mainform RFIDTAGSTORE.Open ();


				string createSQL = "create table if not exists tagreads (readerip varchar(20), epc varchar(60) Primary Key, rssi int, ant int, firstseen TEXT, lastseen TEXT, created timestamp NOT NULL default CURRENT_TIMESTAMP)";

				string createSQL2 = "create table if not exists Athletes (unique_key INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,BibNumber TEXT,EPC TEXT,Fname TEXT,Lname TEXT,DOB TEXT,Age TEXT,Sex TEXT,Race TEXT,GunStart TEXT, ChipStart TEXT, Status TEXT, Laps INTEGER, ChipEnd TEXT, ManualEnd TEXT, NettTotal TEXT, GunTotal TEXT, OverallPos INTEGER, GenderPos INTEGER, CatPos INTEGER, AgeCat TEXT)";

				string createSQL3 = "create table if not exists Splits (unique_key INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,epc TEXT NOT NULL,readerip varchar(20), rssi TEXT,ant TEXT,firstseen TEXT,lastseen TEXT,created timestamp NOT NULL default (datetime('now','localtime')))";
 
				string createSQL4 = "create table if not exists Races (unique_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,RaceName TEXT,RaceNumber TEXT,RaceLaps TEXT,RaceLength TEXT,RaceDate TEXT,RaceStart TEXT,RaceWave1 TEXT,RaceWave2 TEXT,RaceWave3 TEXT,AgeCalcDate TEXT,RaceOver TEXT,LapDistance TEXT,RaceType TEXT,RaceHours TEXT)";
	
				
				using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
					System.Data.SQLite.SQLiteCommand createCommand = new SQLiteCommand (createSQL, RFIDTAGSTORE);
					createCommand.ExecuteNonQuery ();
					createCommand.Dispose ();
					//Commit the changes
					sqlTransaction.Commit ();
				}

				using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
					System.Data.SQLite.SQLiteCommand createCommand = new SQLiteCommand (createSQL2, RFIDTAGSTORE);
					createCommand.ExecuteNonQuery ();
					createCommand.Dispose ();
					//Commit the changes
					sqlTransaction.Commit ();
				}

				using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
					System.Data.SQLite.SQLiteCommand createCommand = new SQLiteCommand (createSQL3, RFIDTAGSTORE);
					createCommand.ExecuteNonQuery ();
					createCommand.Dispose ();
					//Commit the changes
					sqlTransaction.Commit ();
				}


				using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
					System.Data.SQLite.SQLiteCommand createCommand = new SQLiteCommand (createSQL4, RFIDTAGSTORE);
					createCommand.ExecuteNonQuery ();
					createCommand.Dispose ();
					//Commit the changes
					sqlTransaction.Commit ();
				}
			
//Now we have created the required tables we can insert data.
				Console.WriteLine ("Created Tables");
				MainForm.Instance.AppendToTextBox("Created Tables");
				
				Variables.ReaderCount ++;

			}
   
		//	Variables.runninglog = "\n Second  connection NOT opening/creating DB \n";

		reader.OnRoAccessReportReceived += new delegateRoAccessReport(OnReportEvent);
Console.WriteLine("Created a Delegate");
MainForm.Instance.AppendToTextBox("Created a Delegate");

//Enable Impinj extensions

 Enable_Impinj_Extension();
	
            // Send the messages


	Delete_RoSpec();
Console.WriteLine("Deleting ROSPEC");

           Add_RoSpec();
Console.WriteLine("Adding ROSPEC");

           Enable_RoSpec();
           
           
           //Start the timer that keeps the dictionary tag list clean
           
     //      System.Timers.Timer aTimer;
           
       //    aTimer = new System.Timers.Timer(5000);
      //     aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
      //     aTimer.Enabled = true;
      //     GC.KeepAlive(aTimer);
           
          

//Console.WriteLine("Enable ROSPEC");
//MyGlobals.firstrun = "Yes";

//Console.WriteLine("Done all the ROSPEC Shit");

            // Keep reading tags until the user presses return
    
		//    Console.ReadLine();
	//	Console.WriteLine("Exit as you request");
	
		//	RFIDTAGSTORE.Close();


            // Cleanup the reader by deleting the ROSpec
           //MainClass.Delete_RoSpec();
       }
   

	 private void Enable_Impinj_Extension()
        {
	 	
	 	MSG_ERROR_MESSAGE msg_err;
	 	
            MSG_IMPINJ_ENABLE_EXTENSIONS imp_msg = new MSG_IMPINJ_ENABLE_EXTENSIONS();
            MSG_CUSTOM_MESSAGE cust_rsp = reader.CUSTOM_MESSAGE(imp_msg, out msg_err, 8000);
            MSG_IMPINJ_ENABLE_EXTENSIONS_RESPONSE msg_rsp =
                cust_rsp as MSG_IMPINJ_ENABLE_EXTENSIONS_RESPONSE;

            if (msg_rsp != null)
            {
            	MainForm.Instance.AppendToTextBox(msg_rsp.ToString());
            }
            else if (msg_err != null)
            {
            	MainForm.Instance.AppendToTextBox(msg_err.ToString());
            }
            else
            MainForm.Instance.AppendToTextBox("Command time out!");
        }


		public  void ReaderClose ()
		{
			
			 Delete_AccessSpec();
			
			Delete_RoSpec();
			
			
//ENUM_ConnectionAttemptStatusType status;
		reader.Close();

		MainForm.Instance.UpdateReaderStatus(thisreaderip,false);
		
//aTimer.Enabled = false;
		}





public  void Delete_RoSpec()
        {

// Console.WriteLine("Starting to Delete ROSPEC.");
            MSG_DELETE_ROSPEC msg = new MSG_DELETE_ROSPEC();
//Console.WriteLine("SMSG_DELETE_ROSPEC msg = new MSG_DELETE_ROSPEC");

            msg.ROSpecID = 0;
//Console.WriteLine("msg.ROSpecID = 0;.");
            MSG_ERROR_MESSAGE msg_err;
//Console.WriteLine("MSG_ERROR_MESSAGE msg_err.");

			//crash here


            MSG_DELETE_ROSPEC_RESPONSE rsp = this.reader.DELETE_ROSPEC(msg, out msg_err, 5000);
		
//Console.WriteLine("SG_DELETE_ROSPEC_RESPONSE.");
            if (rsp != null)
            {
                // Success
//Console.WriteLine("Success - Got a response!.");
                Console.WriteLine(rsp.ToString());
              //  MainForm.Instance.AppendToTextBox(rsp.ToString());
            }
            else if (msg_err != null)
            {
                // Error
                Console.WriteLine(msg_err.ToString());
                MainForm.Instance.AppendToTextBox(msg_err.ToString());
            }
            else
            {
                // Timeout
                Console.WriteLine("Timeout Error.");
            }
        }


 public void Add_AccessSpec()
{
    MSG_ERROR_MESSAGE msg_err;
    MSG_ADD_ACCESSSPEC msg = new MSG_ADD_ACCESSSPEC();
    msg.AccessSpec = new PARAM_AccessSpec();
   
    /////////////////////////////////////////////////
    // AccessSpec
    /////////////////////////////////////////////////
    // AccessSpecID should be set to a unique identifier.
    msg.AccessSpec.AccessSpecID = 456;
    msg.AccessSpec.AntennaID = 0;
    // We're writing to a Gen2 tag
    msg.AccessSpec.ProtocolID = ENUM_AirProtocols.EPCGlobalClass1Gen2;
    // AccessSpecs must be disabled when you add them.
    msg.AccessSpec.CurrentState = ENUM_AccessSpecState.Disabled;
    msg.AccessSpec.ROSpecID = 0;
    // Setup the triggers
    msg.AccessSpec.AccessSpecStopTrigger =
        new PARAM_AccessSpecStopTrigger();
    msg.AccessSpec.AccessSpecStopTrigger.AccessSpecStopTrigger =
        ENUM_AccessSpecStopTriggerType.Null;
    // OperationCountValue indicate the number of times this Spec is
    // executed before it is deleted. If set to 0, this is equivalent
    // to no stop trigger defined.
    msg.AccessSpec.AccessSpecStopTrigger.OperationCountValue = 1;
   
    /////////////////////////////////////////////////
    // AccessCommand
    //
    // Define which tags we want to write to.
    /////////////////////////////////////////////////
    msg.AccessSpec.AccessCommand = new PARAM_AccessCommand();
    msg.AccessSpec.AccessCommand.AirProtocolTagSpec =
        new UNION_AirProtocolTagSpec();
    PARAM_C1G2TagSpec tagSpec = new PARAM_C1G2TagSpec();
    // Specify the target tag. Which tag do we want to write to?
    tagSpec.C1G2TargetTag = new PARAM_C1G2TargetTag[1];
    tagSpec.C1G2TargetTag[0] = new PARAM_C1G2TargetTag();
    tagSpec.C1G2TargetTag[0].Match = true;
    // We'll use the tag's EPC to determine if this is the label we want.
    // Set the memory bank to 1 (The EPC memory bank on a Monza 4 tag).
    tagSpec.C1G2TargetTag[0].MB = new TwoBits(1);
    // The first (msb) bit location of the specified memory
    // bank against which to compare the TagMask.
    // We'll set it to 0x20, to skip the protocol
    // control bits and CRC.
    tagSpec.C1G2TargetTag[0].Pointer = 0x20;
    
    //tag mask is the tag we want to find and write to
    tagSpec.C1G2TargetTag[0].TagMask = LLRPBitArray.FromHexString("ffffffffffffffffffffffff");   //(Variables.EpcToRead);
    Console.WriteLine("Looking for the tag "+Variables.EpcToRead);
    
    tagSpec.C1G2TargetTag[0].TagData = LLRPBitArray.FromHexString(Variables.EpcToRead);
    msg.AccessSpec.AccessCommand.AirProtocolTagSpec.Add(tagSpec);
   
    /////////////////////////////////////////////////
    // AccessCommandOpSpec
    //
    // Define the data we want to write.
    /////////////////////////////////////////////////
    msg.AccessSpec.AccessCommand.AccessCommandOpSpec = new UNION_AccessCommandOpSpec();
    PARAM_C1G2Write wr = new PARAM_C1G2Write();
    wr.AccessPassword = 0;
    // Bank 3 is user memory on a Monza 4 tag.
    wr.MB = new TwoBits(1);
    // OpSpecID should be set to a unique identifier.
    wr.OpSpecID = 111;
    // Write to the start of epc memory.
    wr.WordPointer = 2; //0x20;
    // Data to be written.
    
    //make the freaking entered shit a freaking 24 character long freaking hex string
    
    //insert racenumber by adding var in place of 0 below 
    
    string sexyepc = Variables.EpcToWrite.PadLeft(24, '0');
    
    
    wr.WriteData = UInt16Array.FromHexString(sexyepc); //("000000000000000000000999");//FromString(Variables.EpcToWrite);
   // Console.WriteLine("Trying to write "+Variables.EpcToWrite);
    msg.AccessSpec.AccessCommand.AccessCommandOpSpec.Add(wr);
   
    /////////////////////////////////////////////////
    // AccessReportSpec
    //
    // Define when we want to receive AccessReports
    /////////////////////////////////////////////////
    msg.AccessSpec.AccessReportSpec = new PARAM_AccessReportSpec();
    msg.AccessSpec.AccessReportSpec.AccessReportTrigger = ENUM_AccessReportTriggerType.End_Of_AccessSpec;
   
    // Send the message and check the reply
    MSG_ADD_ACCESSSPEC_RESPONSE rsp =
        reader.ADD_ACCESSSPEC(msg, out msg_err, 5000);
    if (rsp != null)
    {
        // Success
        Console.WriteLine(rsp.ToString());
       // MainForm.Instance.AppendToTextBox(rsp.ToString());
    }
    else if (msg_err != null)
    {
        // Error
        Console.WriteLine(msg_err.ToString());
        MainForm.Instance.AppendToTextBox(msg_err.ToString());
    }
    else
    {
        // Timeout
        Console.WriteLine("Timeout Error.");
    }
}

public void Delete_AccessSpec()
{
    MSG_ERROR_MESSAGE msg_err;
    MSG_DELETE_ACCESSSPEC msg = new MSG_DELETE_ACCESSSPEC();
    msg.AccessSpecID = 0;
    // Delete all AccessSpecs
    MSG_DELETE_ACCESSSPEC_RESPONSE rsp =
        reader.DELETE_ACCESSSPEC(msg, out msg_err, 5000);
    if (rsp != null)
    {
        // Success
        Console.WriteLine(rsp.ToString());
    }
    else if (msg_err != null)
    {
        // Error
        Console.WriteLine(msg_err.ToString());
    }
    else
    {
        // Timeout
        Console.WriteLine("Timeout Error.");
    }  
}

 public void Enable_AccessSpec()
{
    MSG_ERROR_MESSAGE msg_err;
    MSG_ENABLE_ACCESSSPEC msg = new MSG_ENABLE_ACCESSSPEC();
    msg.AccessSpecID = 456;
    MSG_ENABLE_ACCESSSPEC_RESPONSE rsp =
        reader.ENABLE_ACCESSSPEC(msg, out msg_err, 5000);
    if (rsp != null)
    {
        // Success
        Console.WriteLine(rsp.ToString());
    }
    else if (msg_err != null)
    {
        // Error
        Console.WriteLine(msg_err.ToString());
    }
    else
    {
        // Timeout
        Console.WriteLine("Timeout Error.");
    } 
}


        public  void Add_RoSpec()
		{
			MSG_ERROR_MESSAGE msg_err;
			MSG_ADD_ROSPEC msg = new MSG_ADD_ROSPEC();

			// Reader Operation Spec (ROSpec)
			msg.ROSpec = new PARAM_ROSpec();

			// ROSpec must be disabled by default
			msg.ROSpec.CurrentState = ENUM_ROSpecState.Disabled;

			// The ROSpec ID can be set to any number
			// You must use the same ID when enabling this ROSpec
			msg.ROSpec.ROSpecID = 123;

			// ROBoundarySpec
			// Specifies the start and stop triggers for the ROSpec
			msg.ROSpec.ROBoundarySpec = new PARAM_ROBoundarySpec();

			// Immediate start trigger
			// The reader will start reading tags as soon as the ROSpec is enabled
			msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger =
            new PARAM_ROSpecStartTrigger();
			msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.ROSpecStartTriggerType =
            //ENUM_ROSpecStartTriggerType.Immediate;
				ENUM_ROSpecStartTriggerType.Immediate;
			//msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.PeriodicTriggerValue = 0;


			// No stop trigger. Keep reading tags until the ROSpec is disabled.
			msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger = new PARAM_ROSpecStopTrigger();
			msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.ROSpecStopTriggerType =
            ENUM_ROSpecStopTriggerType.Null;
	
			//ENUM_ROSpecStopTriggerType.Duration;
			//msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.DurationTriggerValue = 1000;


			// Antenna Inventory Spec (AISpec)
			// Specifies which antennas and protocol to use
			msg.ROSpec.SpecParameter = new UNION_SpecParameter();
			PARAM_AISpec aiSpec = new PARAM_AISpec();
			aiSpec.AntennaIDs = new UInt16Array();

			// Enable all antennas
			aiSpec.AntennaIDs.Add(0);
			

			// No AISpec stop trigger. It stops when the ROSpec stops.
			aiSpec.AISpecStopTrigger = new PARAM_AISpecStopTrigger();
			aiSpec.AISpecStopTrigger.AISpecStopTriggerType =
            ENUM_AISpecStopTriggerType.Null;
				//ENUM_AISpecStopTriggerType.Duration;
		

				//set protocol
				
				aiSpec.InventoryParameterSpec = new PARAM_InventoryParameterSpec[1];
			aiSpec.InventoryParameterSpec [0] = new PARAM_InventoryParameterSpec();
			aiSpec.InventoryParameterSpec [0].InventoryParameterSpecID = 1234;
			aiSpec.InventoryParameterSpec [0].ProtocolID =
            ENUM_AirProtocols.EPCGlobalClass1Gen2;
		
//try and set power and sinsitivty



 aiSpec.InventoryParameterSpec[0].AntennaConfiguration = new PARAM_AntennaConfiguration[1];
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0] = new PARAM_AntennaConfiguration();
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFTransmitter = new PARAM_RFTransmitter();
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFTransmitter.HopTableID = 1;
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFTransmitter.ChannelIndex = 1;
 aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFTransmitter.TransmitPower = 71;
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFReceiver = new PARAM_RFReceiver();
aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].RFReceiver.ReceiverSensitivity = 1;


if (Variables.TestMode == true) {
	
	//change the settings so that there is no tag filtering on the reader
	// Set the search mode.
	
PARAM_ImpinjInventorySearchMode impISM = new PARAM_ImpinjInventorySearchMode();
impISM.InventorySearchMode = ENUM_ImpinjInventorySearchType.Dual_Target;
aiSpec.AddCustomParameter(impISM);
//aiSpec.Custom.Add(impISM);
}



//add all the shit above


			msg.ROSpec.SpecParameter.Add(aiSpec);
			
			
		

			// Report Spec
			msg.ROSpec.ROReportSpec = new PARAM_ROReportSpec();

			// Send a report for every tag read

			msg.ROSpec.ROReportSpec.ROReportTrigger =
            ENUM_ROReportTriggerType.Upon_N_Tags_Or_End_Of_ROSpec;


			msg.ROSpec.ROReportSpec.N = 1;
			msg.ROSpec.ROReportSpec.TagReportContentSelector =
          new PARAM_TagReportContentSelector();

			
			
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableAccessSpecID = true;
msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableAntennaID = true;
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableChannelIndex = true;
msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableFirstSeenTimestamp = true;
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableInventoryParameterSpecID = true;
msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableLastSeenTimestamp = true;
msg.ROSpec.ROReportSpec.TagReportContentSelector.EnablePeakRSSI = true;
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableROSpecID = true;
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableSpecIndex = true;
//msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableTagSeenCount = true;


//this is how we change sessions with LLRP

//if (1==2) {
//	
//PARAM_C1G2InventoryCommand cmd = new PARAM_C1G2InventoryCommand();
//cmd.C1G2RFControl = new PARAM_C1G2RFControl();
//cmd.C1G2RFControl.ModeIndex = 1001;
//cmd.C1G2RFControl.Tari = 0;
//cmd.C1G2SingulationControl = new PARAM_C1G2SingulationControl();
//cmd.C1G2SingulationControl.Session = new TwoBits(2);
//cmd.C1G2SingulationControl.TagPopulation = 32;
//cmd.C1G2SingulationControl.TagTransitTime = 1000;
//cmd.TagInventoryStateAware = false;
//PARAM_ImpinjInventorySearchMode search_mode = new PARAM_ImpinjInventorySearchMode();
//search_mode.InventorySearchMode = ENUM_ImpinjInventorySearchType.Dual_Target;
//cmd.AddCustomParameter(search_mode);
//	
//	
//	
//	
//	
//}






if (Variables.powersave == true) {
//experimental power save mode

PARAM_ImpinjLowDutyCycle impLD = new PARAM_ImpinjLowDutyCycle();
impLD.LowDutyCycleMode = ENUM_ImpinjLowDutyCycleMode.Enabled;
impLD.AddCustomParameter(impLD);


    }
		//why would this matter?
			//it should not

            MSG_ADD_ROSPEC_RESPONSE rsp = reader.ADD_ROSPEC(msg, out msg_err, 5000);

            if (rsp != null)
            {
                // Success
                Console.WriteLine(rsp.ToString());
              //  MainForm.Instance.AppendToTextBox(rsp.ToString());
            }
            else if (msg_err != null)
            {
                // Error
                Console.WriteLine(msg_err.ToString());
                MainForm.Instance.AppendToTextBox(msg_err.ToString());
            }
            else
            {
                // Timeout
                Console.WriteLine("Timeout Error.");
            }
        }

        public  void Enable_RoSpec()
        {
            MSG_ERROR_MESSAGE msg_err;
            MSG_ENABLE_ROSPEC msg = new MSG_ENABLE_ROSPEC();
            msg.ROSpecID = 123;
            MSG_ENABLE_ROSPEC_RESPONSE rsp =
            reader.ENABLE_ROSPEC(msg, out msg_err, 5000);


            if (rsp != null)
            {
                // Success
                Console.WriteLine(rsp.ToString());
             //   MainForm.Instance.AppendToTextBox(rsp.ToString());
				Console.WriteLine("Initialised OK");
            }
            else if (msg_err != null)
            {
                // Error
                Console.WriteLine(msg_err.ToString());
                MainForm.Instance.AppendToTextBox(msg_err.ToString());
				Console.WriteLine("Rospec Fucked, Sorry");
            }
            else
            {
                // Timeout
                Console.WriteLine("Timeout Error.");
            }
        }

        public  void OnReportEvent (MSG_RO_ACCESS_REPORT msg)
		{
        	
        	
	
			//	Console.WriteLine ("Waiting for a Tag Report");

			// Loop through all the tags in the report
			for (int i = 0; i < msg.TagReportData.Length; i++) {
					//	Console.WriteLine ("Got a Tag Report from {0}",ThisInstanceName);

				if (msg.TagReportData [i].EPCParameter.Count > 0) {
					string epc;
				
					ulong lastseen;
					lastseen = msg.TagReportData [i].LastSeenTimestampUTC.Microseconds;
							//Console.WriteLine ("Got Stuff in it");
					long lastseenlong = (long)lastseen;
					DateTime lastseendt = MainClass.DateTimeFromUnixTimestampMillis (lastseenlong);
					lastseendt = lastseendt.ToLocalTime();
					
					//reader datetime sanity check
					//if the reader date time is much different to local time use local time
					
					
					
					
					//DateTime dt = new DateTime(1970, 1, 1);
					//  dt.AddMilliseconds(lastseen);

					ulong firstseen;
					firstseen = msg.TagReportData [i].FirstSeenTimestampUTC.Microseconds;
					long firstseenlong = (long)firstseen;
					DateTime firstseendt = MainClass.DateTimeFromUnixTimestampMillis (firstseenlong);
					firstseendt = firstseendt.ToLocalTime();
					
					//reader datetime sanity check
					//if the reader date time is much different to local time use local time
					
					
					
					
					
					int antenna;
					antenna = msg.TagReportData [i].AntennaID.AntennaID;

					//	int seencount;
					//	seencount = msg.TagReportData [i].TagSeenCount.TagCount;

					int peakRSSI = 0;
					peakRSSI = msg.TagReportData [i].PeakRSSI.PeakRSSI;

					// Two possible types of EPC: 96-bit and 128-bit
					if (msg.TagReportData [i].EPCParameter [0].GetType () ==
						typeof(PARAM_EPC_96)) {
						epc = ((PARAM_EPC_96)(msg.TagReportData [i].EPCParameter [0])).EPC.ToHexString ();
					} else {
						epc = ((PARAM_EPCData)
                        (msg.TagReportData [i].EPCParameter [0])).EPC.ToHexString ();
					}

				//	Console.WriteLine("crap under here?");
				//	 Check if a write operation has occurred
				//
				//first check if it exists, if it does not were fucked.
				try {
				string accessreportstring = msg.TagReportData[i].AccessCommandOpSpecResult[0].ToString();
				Console.WriteLine("we wrote a tag dude " + accessreportstring);
				MainClass.Variables.one.Delete_AccessSpec();
				MainClass.Variables.one.Delete_RoSpec();
				MainClass.Variables.one.Add_RoSpec();
				MainClass.Variables.one.Enable_RoSpec();
				
				//add it to the list of epcs but skip the db part underneath....
				
				//	RecentTags.TryRemove (epc, out removedvalue);
				//			RecentTags.TryAdd (epc, RightNowString);
				
				}
				
				catch
				{
					
				//	Console.WriteLine("No tag writes here dude");
				}
				//if (msg.TagReportData [i].AccessCommandOpSpecResult [0] != null) {
					
				//	Console.WriteLine("we wrote a tag dude " + accessreportstring);
				//PARAM_C1G2WriteOpSpecResult result = (PARAM_C1G2WriteOpSpecResult) msg.TagReportData [i].AccessCommandOpSpecResult [0];
					//	Console.WriteLine (result.NumWordsWritten +
					//		" words written to tag with EPC = " + epc); 
				//	 }


						//	string TagReportLine;

		

						//	TagReportLine = ("EPC=" + epc + "  RSSI=" + peakRSSI + "  IP=" + MyGlobals.ReaderIP + "  ANT=" + antenna + " First Seen=" + firstseendt + " Last Seen=" + lastseendt);

						//	MyGlobals.ReportLines = TagReportLine;



						//Console.WriteLine(TagReportLine);
						//Variables.runninglog = TagReportLine;

						//Console.WriteLine("EPC=" + epc + "  RSSI=" + peakRSSI  + "  IP=" + MyGlobals.ReaderIP + "  ANT=" + antenna + " First Seen=" + firstseen + " Last Seen=" + lastseen);

						//		Console.WriteLine (TagReportLine);
						//MainWindow.textview2.Buffer.Text = TagReportLine;


						//	txtbox = epc;
						string updateTag = "No";
						string epcDateTime;
						string removedvalue;
						bool epcExists;
						
						//if we have never seen it befre give it a age greater than the filter so it gets read!
						
						DateTime ltrt; // = DateTime.Now.AddSeconds(-Variables.NewTagSecs);
DateTime RightNow = DateTime.Now.ToLocalTime ();
						string RightNowString = RightNow.ToString ();
						
						TagsInView.TryRemove (epc, out removedvalue);
							TagsInView.TryAdd (epc, RightNowString);
						
						if (RecentTags.ContainsKey (epc)) {
							epcDateTime = RecentTags [epc];
							//convert string to dt

							  ltrt = Convert.ToDateTime (epcDateTime);
						//	  Console.WriteLine("Tag last seen at "+ epcDateTime);
						}
						
						else
							
						{
							//its a new tag so treat it like one.
							
							//RecentTags.TryRemove (epc,out removedvalue);
							RecentTags.TryAdd (epc, RightNowString);
							updateTag = "No";
								goto NewTag;
							
						}


//Tag Filtering Under Here



//DateTime onesecsago = DateTime.Now.AddSeconds(-1);
//DateTime thirtysecsago = DateTime.Now.AddSeconds(-30);

TimeSpan ts = RightNow - ltrt;

if (Variables.TestMode == true) {
	
	//record each tag every 1/2 sec
	
		if (ts.TotalSeconds >= 0.5) {

							//tag last read more than xx sec ago, make new entry
						//	Console.WriteLine ("Tag seen more than {0} Second ago - New write",Variables.NewTagSecs) ;
						
						RecentTags.TryRemove (epc,out removedvalue);
							RecentTags.TryAdd (epc, RightNowString);
							TagsInView.TryRemove (epc, out removedvalue);
							TagsInView.TryAdd (epc, RightNowString);
							
							updateTag = "No";
							//Variables.runninglog = epc + " On Ant " + antenna;
						
						//	MainClass.Races.TagSystemBeep();
						//	Console.WriteLine("Beep Ya Bastard");
							goto NewTag;

						}
	
	
	
}
	
						//TimeSpan ts = RightNow - ltrt;
						//	MainWindow.UpdateTextBox(epc);

						//	Console.WriteLine ("Difference in Seconds = " + ts.TotalSeconds);

						if (ts.TotalSeconds < Variables.ReadsPerSec ) {

							//tag last read less than a sec ago, skipping to end
						//	Console.WriteLine ("Tag seen less than a Second ago - Filtered");
							goto FilteredTag;

						}
						
						if (ts.TotalSeconds > Variables.ReadsPerSec && ts.TotalSeconds < Variables.UpdateSecs) {

							//tag last read less than the update interval ago skipping write again
							
							//however we want to add it to the list of recently seen tags for the display and writing purposes
						//	Console.WriteLine ("Tag more than a Second ago - Updated");
							TagsInView.TryRemove (epc, out removedvalue);
							TagsInView.TryAdd (epc, RightNowString);
							goto FilteredTag;

						}
						

						if (ts.TotalSeconds > Variables.UpdateSecs && ts.TotalSeconds < Variables.NewTagSecs) {

							//tag last read less than 30 sec ago, Just updating last read
						//	Console.WriteLine ("Tag more than a Second ago - Updated");
							RecentTags.TryRemove (epc, out removedvalue);
							RecentTags.TryAdd (epc, RightNowString);
							TagsInView.TryRemove (epc, out removedvalue);
							TagsInView.TryAdd (epc, RightNowString);
							
							goto UpdateTag;

						}

						if (ts.TotalSeconds >= Variables.NewTagSecs) {

							//tag last read more than xx sec ago, make new entry
						//	Console.WriteLine ("Tag seen more than {0} Second ago - New write",Variables.NewTagSecs) ;
						
						RecentTags.TryRemove (epc,out removedvalue);
							RecentTags.TryAdd (epc, RightNowString);
							TagsInView.TryRemove (epc, out removedvalue);
							TagsInView.TryAdd (epc, RightNowString);
							
							updateTag = "No";
							//Variables.runninglog = epc + " On Ant " + antenna;
						
						//	MainClass.Races.TagSystemBeep();
						//	Console.WriteLine("Beep Ya Bastard");
							goto NewTag;

						}


						//presumably if we are here we should add a new entry for the tag


						Console.WriteLine ("I think we are lost");

						RecentTags.TryAdd (epc, RightNowString);

						//Beep!
						//Console.Beep(5000, 250);
						

				//	var task = Task.Factory.StartNew(System.Media.SystemSounds.Exclamation.Play());


						


						//(new System.Media.SoundPlayer("beep.wav")).PlaySync();

			//			System.Media.SoundPlayer tagbeep = new System.Media.SoundPlayer("/home/rolf/formstest/formstest/beep.wav");
			//		tagbeep.Load();	
			//		if (tagbeep.IsLoadCompleted) tagbeep.PlaySync();
			//		tagbeep.p
						// Now lets add this all to our SQlite Database

						//We want to write to a DB in Memory and every 10 seconds write that to disk



//TagReads tracks the first and last time we saw each Tag, the last time is constantly updated.
//In Theory this should give us Net time for tag with 2 reads...

//Splits records each time we see the tag again subject to the following criteria

//If Tag is New, enter a Split

//else if it is less than 30 seconds old update the last seen time

//Else if it is more than 30 seconds old add a new split

						UpdateTag:
						updateTag = "Yes";

//First lets search the splits table for the current EPC
						//			Console.WriteLine ("Open DB for Select on " + epc);
						//RFIDTAGSTORE.Open ();

						string selectSQL = "SELECT epc, lastseen, unique_key FROM splits WHERE epc = @epc ORDER BY created DESC";
						SQLiteCommand selectCommand = new SQLiteCommand (selectSQL, RFIDTAGSTORE);
						selectCommand.Parameters.AddWithValue ("@epc", epc);
						SQLiteDataReader dataReader = selectCommand.ExecuteReader ();
 
						//		Console.WriteLine ("Done Select");

// Use a variable to store the result of the search
						epcExists = dataReader.Read ();
						//			Console.WriteLine ("Found Existing EPC " + epcExists);

						DateTime trt = DateTime.Now;
						DateTime	thirtysecsago = DateTime.Now.AddSeconds(-30);
						
						string unique_key = "0";

						if (epcExists) {
							string TagReadTime = dataReader.GetString (1).ToString ();
							//			Console.WriteLine ("Got TagReadTime " + TagReadTime);

							unique_key = dataReader.GetInt32 (2).ToString ();

							//			Console.WriteLine ("Got key" + unique_key);
							trt = Convert.ToDateTime (TagReadTime);



							//calculate Reader Drift

							DateTime UTCNOW = DateTime.UtcNow;
							DateTime READERNOW = lastseendt;

							TimeSpan Drift = UTCNOW - READERNOW;

							//			Console.WriteLine("Drift is currently "+Drift+" Seconds");

							int Driftcorrection = -30 - Drift.Seconds;

							thirtysecsago = DateTime.UtcNow.AddSeconds (Driftcorrection);

							//	Console.WriteLine ("Got Strings");

							//				Console.WriteLine ("if epc exists " + epcExists + " and trt " + trt + " > " + thirtysecsago);

							//				Console.WriteLine ("last seen datetime = " + lastseendt + " First Seen DT " + firstseendt);

							dataReader.Close ();
							//				Console.WriteLine ("Closed datareader");

				
						}


// If epc is in the table and last read was less than 30 secs ago
						if (epcExists && trt > thirtysecsago) {

							//			Console.WriteLine ("EPC Found in DB and less than 30 secs old");
							// Update lastseen
						//	using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
								// Update the last seen date of the tag
							//	string updateSQL = "UPDATE splits SET lastseen = @lastseen WHERE unique_key = @unique_key";
							string newupdatesql = string.Format("UPDATE splits SET lastseen = '{0}'  WHERE unique_key = '{1}'",lastseendt, unique_key);
							sqwriter.SimpleSQliteInsert(newupdatesql);
							//	SQLiteCommand updateCommand = new SQLiteCommand (updateSQL, RFIDTAGSTORE);
							//	updateCommand.Parameters.AddWithValue ("@lastseen", lastseendt);
							//	updateCommand.Parameters.AddWithValue ("@unique_key", unique_key);
							//	updateCommand.ExecuteNonQuery ();
							//	sqlTransaction.Commit ();
						//	}
				
							//				Console.WriteLine ("DB Updated");
						}



						NewTag:

						if (updateTag != "Yes") {

//Console.WriteLine ("Open DB");
//RFIDTAGSTORE.Open();


									//	Console.WriteLine ("EPC Older than 30 secs or not found making new entry");
							// Insert epc as a new epc
					//		using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction()) {
						//		string insertSQL2 = "INSERT INTO splits(epc, readerip, rssi, ant, firstseen, lastseen) values ";
						//		insertSQL2 += "(@epc, @readerip, @peakRSSI, @antenna, @firstseen, @lastseen)";
                               
						if (Variables.TestMode == true) epc = "TEST_"+epc;
						
						
						string insertsql2 = string.Format("INSERT INTO splits(epc, readerip, rssi, ant, firstseen, lastseen) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",epc, ThisInstanceName.ToString(), peakRSSI, antenna, firstseendt, lastseendt);
						
						sqwriter.SimpleSQliteInsert(insertsql2);
						
							//	Console.WriteLine(insertSQL2);
								
							//	SQLiteCommand insertCommand = new SQLiteCommand (insertSQL2, RFIDTAGSTORE);

							//	insertCommand.Parameters.AddWithValue ("@readerip", ThisInstanceName.ToString());
							//	insertCommand.Parameters.AddWithValue ("@epc", epc);
							//	insertCommand.Parameters.AddWithValue ("@peakRSSI", peakRSSI);
							//	insertCommand.Parameters.AddWithValue ("@antenna", antenna);
							//	insertCommand.Parameters.AddWithValue ("@firstseen", firstseendt);
							//	insertCommand.Parameters.AddWithValue ("@lastseen", lastseendt);
							//	insertCommand.ExecuteNonQuery ();
							//	sqlTransaction.Commit ();
							//}
							
							
							//here goes nothing, try and update the database for this bib
							// But only if we are not in test mode!

							if (!Variables.TestMode == true)
								
							{
							
Reports rp = new Reports();


rp.GenerateSingleBibStats(epc);

							}
							
							
							//on the other hand if we are in test mode let's put the epc and rssi and antenna onto the box
							
							if (Variables.TestMode == true) {
							
								string epcstats = epc+" RDR:"+ThisInstanceName.ToString()+" / "+antenna+" RSSI:"+peakRSSI;
								
								formstest.MainClass.MainMessages.Add(epcstats);
							
							
							
							}

//Task statstask = new Task(() => rp.GenerateSingleBibStats(epc));

//statstask.Start();

//Thread statsthread = new Thread(() => rp.GenerateSingleBibStats(epc));
                  //       statsthread.IsBackground = true;
                   //      statsthread.Start();


//Console.WriteLine("Generating Stats for {0}",epc);
//rp.GenerateSingleBibStats(epc);

if (formstest.MainClass.Variables.SayAntenna == true)
	
{
	//call the antenna number
	PlayWav("antenna.wav");
	string antno = antenna.ToString() + ".wav";
	                                               		PlayWav (antno);
	
}


if (formstest.MainClass.Variables.talk == true)
				{
	
//	Console.WriteLine("Speaking EPC");
	
	//trip the epc and speak it
	int num;
	int snum;
	int.TryParse(epc, out num);
	string short_epc = "invalid";
	short_epc = epc.Substring(epc.Length-3).ToString();
	
	//short_epc = num.ToString();
	//Console.WriteLine("Full EPC {0}",epc);
	if (short_epc.Length < 5 && int.TryParse(short_epc, out snum) ) {
	//speak the number
//Console.WriteLine("Speaking EPC {0}",short_epc);
PlayWav ("Beep.wav");
	char[] Characters = short_epc.ToCharArray();
	ThreadPool.QueueUserWorkItem(new WaitCallback (delegate {
	                                               	
	                                               	foreach (char c in Characters) {
	                                               		
	                                               		string filename = c + ".wav";
	                                               		PlayWav (filename);
	                                               	//	Console.WriteLine("I said {0}",filename);
	                                               	}}));
		
	}
	
}

if (formstest.MainClass.Variables.Beep == true)
				{

				
			//	System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Beep.wav");
			//	snd.Play();
try
{
			
	PlayWav("Beep.wav");
		//	Console.WriteLine("I just said beep");
			//Thread.Sleep(250);
}
			//	System.Media.SystemSounds.Exclamation.Play();
catch
	
{
		System.Media.SystemSounds.Exclamation.Play();		
}

}

//Thread beepthread = new Thread(new ThreadStart(MainClass.Races.TagSystemBeep));
//beepthread.Start();

					//			Task t = Task.Factory.StartNew(MainClass.Races.TagSystemBeep);
					//		t.Start();
							




}
				


						//end initial if

						//readtags no longer needed

						/*

Console.WriteLine("About to replace seen tags");

			string insertSQL = "insert or replace into tagreads (epc, readerip, rssi, ant, firstseen, lastseen) values ";

					insertSQL += "(@epc, @readerip, @peakRSSI, @antenna, coalesce((select firstseen from tagreads where epc = @epc),@lastseen), @lastseen)";


using (SQLiteTransaction sqlTransaction = RFIDTAGSTORE.BeginTransaction())

					{

System.Data.SQLite.SQLiteCommand replaceCommand = new SQLiteCommand(insertSQL, RFIDTAGSTORE);

		replaceCommand.Parameters.AddWithValue("@readerip", MyGlobals.ReaderIP);
			replaceCommand.Parameters.AddWithValue("@epc", epc);
					replaceCommand.Parameters.AddWithValue("@peakRSSI", peakRSSI);
					replaceCommand.Parameters.AddWithValue("@antenna", antenna);
					replaceCommand.Parameters.AddWithValue("@firstseen", firstseen);
					replaceCommand.Parameters.AddWithValue("@lastseen", lastseen);

replaceCommand.ExecuteNonQuery();

sqlTransaction.Commit();

Console.WriteLine("Updated ReadTags");

					}


				
*/







						FilteredTag:




								
				
				
		
						//				Console.WriteLine("end");

						//RFIDTAGSTORE.Close ();
				
						;
					}
				}
			
			}


		
	}
}
	
	
	/// <summary>
	/// Description of TimingCode.
	/// </summary>
	public partial class TimingCode : Form
	{
		
		
		
		public TimingCode()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			SearchForEPC();
		
			 // Set the Format type and the CustomFormat string.
   dateTimePicker1.Format = DateTimePickerFormat.Custom;
   dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
   
    // Set the Format type and the CustomFormat string.
   dateTimePicker2.Format = DateTimePickerFormat.Custom;
   dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			
		}
	
		

		
		
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SearchForEPC();

	}
	
		public void SearchForEPC ()
			
		{
			//build query under here
			
			//convert from bib to EPC
			
			string paddedbib = EnterEPC.Text.PadLeft(24,'0');
			
			//calculate times for search
			
			DateTime rightnow = DateTime.Now.AddSeconds(1);
			
			DateTime nowlessinterval = DateTime.Now.AddMinutes(Convert.ToDouble(-numericUpDownMinutes.Value));
			
			//convert to string for search of sqlitedb
			
			string nowlessintervalstring = nowlessinterval.ToString("yyyy-MM-dd HH:mm:ss");

			
			string rightnowstring = rightnow.ToString("yyyy-MM-dd HH:mm:ss");
			
			string NewQuery = string.Format("Select * from Splits where epc = '{0}' AND created BETWEEN '{1}' AND '{2}'",paddedbib,nowlessintervalstring,rightnowstring) ;
			
			
			if (checkBoxAll.Checked == true) {
				
				 NewQuery = string.Format("Select * from Splits WHERE created BETWEEN '{0}' AND '{1}' " , nowlessintervalstring, rightnowstring); // where epc = '{0}' ",paddedbib) ;
			}
			
			
//Console.WriteLine(NewQuery);

//Pass string to function here....

		/// <remarks>
/// Creating a DataSet to feed the DataGridView
/// </remarks>  		
// 
DataSet results = new DataSet();
try
{
   
	results = DbSqlite.GetDataSetSqlite(NewQuery);
	dataGridView1.DataSource = results.Tables[0];
    	}
		
	
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
}
		
		void Button2Click(object sender, EventArgs e)
		{
			
			DialogResult result1 = MessageBox.Show("Do you really, really, really want to delete these reads? It's some heavy shit man","Yeah, but it's a dry heat",MessageBoxButtons.YesNoCancel);
			
			if (result1 == DialogResult.Yes) {
			
				DbSqlite dt = new DbSqlite();

			string deletetags = string.Format("Delete from Splits WHERE created Between '{0}' AND '{1}'",dateTimePicker1.Text,dateTimePicker2.Text);
			
			//DbSqlite.RFIDTAGSTORE.Open();
			
			dt.SimpleSQliteInsert(deletetags);
		
			//DbSqlite.RFIDTAGSTORE.Close();

			
			//Console.WriteLine(deletetags);
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			try
			{
			
		 DGVPrinter printer = new DGVPrinter();

    printer.Title = EnterEPC.Text;

    
    //	string statstext = " ";
				//string statstext = "Waiting for an update";
				
		//		try {
		//				if (formstest.MainClass.RaceStats.ContainsKey (ChooseRace.Text)) {
		//					statstext = formstest.MainClass.RaceStats [ChooseRace.Text];
		//	}
		//		}
				
		//		catch
					
		//		{
		//			 statstext = "Waiting for an update";
		//		}
    
    
 //   printer.SubTitle = statstext;

    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | 

                                  StringFormatFlags.NoClip;

    printer.PageNumbers = true;

    printer.PageNumberInHeader = false;

    printer.PorportionalColumns = true;

    printer.HeaderCellAlignment = StringAlignment.Near;

    printer.Footer =  "Printed at "+DateTime.Now.ToLocalTime();

    printer.FooterSpacing = 15;

    dataGridView1.Columns.Remove("firstseen");
    dataGridView1.Columns.Remove("rssi");

    printer.PrintDataGridView(dataGridView1);
		}	
			
			catch (Exception ex)
				
			{
				MessageBox.Show(ex.Message);
			}	
		}
		
		void Button4Click(object sender, EventArgs e)
		{
//fill datagrid with reads from last xx minutes


		}
		
		void CheckBoxAllCheckedChanged(object sender, EventArgs e)
		{
			
		}
		}
		
		
}


		