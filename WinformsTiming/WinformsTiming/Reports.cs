/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 5/02/2013
 * Time: 1:39 PM
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

namespace WinformsTiming
{
	/// <summary>
	/// Description of Reports.
	/// </summary>
	public partial class Reports : Form
	{
		
		public bool resultslock;
		public bool statstimerlock;
		public bool statslock;
		
		public static string agecat1 = "Gen Y";
		public static string agecat2 = "Gen X";
		public static string agecat3 = "Boomers";
		
		 SQLiteConnection RFIDTAGSTORE = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
		
	//	SQLiteConnection sqreadConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
		
	//	SQLiteConnection sqwriteConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
		

//	public string CountLaps (string bibnumber, string racename)
		
//	{
		
		
		//look for all laps between race start and race end
		
		//string countlaps = string.Format("SELECT COUNT(epc) FROM Splits WHERE epc='{0}' AND created > '{1}'",paddedbib,racestartplus);
		
		
		
		
//	}


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
	RFIDTAGSTORE.Open();
            SQLiteConnection sqreadConnection = new SQLiteConnection("Data Source=RFIDTAGSTORE.s3db;journal mode=WAL;Pooling=true;busy_timeout=3000"); 
    	using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(NewQuery, sqreadConnection))
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
	
	
	catch (Exception error)
{
    MessageBox.Show("Exception caught: " + error.Message);
}
	finally
		
	{
				
	RFIDTAGSTORE.Close();	}
		
	}
		
		
		
		
		
		
			private object lockmethod = new object();
			
			
			
			public void GenerateSingleBibStats (string epc)
				
			{
				statslock = true;
				
				DbSqlite sbs = new DbSqlite();
				
				//open the db connection
				
	//		DbSqlite.RFIDTAGSTORE.Open();
				
				//hey wait  a minute, we are being triggered by epc reads so we need to convert the epc to a bib number
				
				// We need to strip all but the last 3 characters from the epc
				
				string	bib = epc.Substring(epc.Length -3);
				
				Console.WriteLine("Got a bib number {0}",bib);
				
				
				//we want to generate update stats that we can flash on the screen at the finish
				//if its a normal race we just want to flash the name and Guntime
				//If its a lap race we want to flash the name and lap count...
				
				string runnerstatsmessage = "(" + bib +") ";
				
				
				
				//first lets get the racename from the bib number, we only want races that are actually running at the moment.

//So lets use the running field in the race status, we just need to make sure we set finisheshed races as such..

				//Last 24hrs OK?
				//When the Race starts it sets the GunTime so lets use that
				DateTime last24hrs = DateTime.Now.AddHours(-24);
		string	last24hrsstring = last24hrs.ToString("yyyy-MM-dd HH:mm:ss");
				
				string rightnowtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				
				DateTime RightNow = DateTime.Now.AddSeconds(1);
				
				string findracename = string.Format("SELECT RaceName from Races INNER JOIN Athletes on RaceName = Athletes.Race Where BibNumber='{0}' AND RaceOver='Running'",bib);
				
				string racename = sbs.GetSingleSQlitefield(findracename,"RaceName");
				
			//	Console.WriteLine(findracename);
				
				Console.WriteLine("Got a RaceName {0}",racename);
				
				if (racename == "Nothing") {
					
					//This is not the bib you are looking for, you may pass
					
			//		Console.WriteLine("No Race found for bib {0}",bib);
					return;
					
					
				}
				
				//Now we know the bib number and race name we can update stats for an individual runner
				
			//		string getracestarttimesql = string.Format("Select RaceStart from Races WHERE RaceName='{0}'",racename);
			
			// I think we are better to use the start time from the athletes row
			
			string getracestarttimesql = string.Format("Select GunStart from Athletes WHERE BibNumber='{0}' AND Race='{1}'",bib, racename);
			
			
		string racestarttimestring = sbs.GetSingleSQlitefield(getracestarttimesql,"GunStart");
		
	//	Console.WriteLine("Got a Race StartTime of {0}", racestarttimestring);
		
		
		//we may as well get their name for the stats page
		
		string getrunnernamesql = string.Format("Select Fname from Athletes WHERE BibNumber='{0}' AND Race='{1}'",bib, racename);
			
			
		string runnerFname = sbs.GetSingleSQlitefield(getrunnernamesql,"Fname");
		
		 getrunnernamesql = string.Format("Select Lname from Athletes WHERE BibNumber='{0}' AND Race='{1}'",bib, racename);
			
			
		string runnerLname = sbs.GetSingleSQlitefield(getrunnernamesql,"Lname");
		
		
		string runnerfullname = runnerFname + " " + runnerLname;
		
		//runnerstatsmessage += bib +" ";
		runnerstatsmessage += runnerfullname;
		
	//	Console.WriteLine("Got a Race StartTime of {0}", racestarttimestring);
		
		
		string getracetypesql = string.Format("Select RaceType from Races WHERE RaceName='{0}'",racename);
		
		string racetype = sbs.GetSingleSQlitefield(getracetypesql,"RaceType");
		
		
		//If the racetype is laps we should get the number of laps
		
		string racelaps ="1";
		
		if (racetype == "Laps") {
			
			string getracelapssql = string.Format("Select RaceLaps from Races WHERE RaceName='{0}'",racename);
		
		 racelaps = sbs.GetSingleSQlitefield(getracelapssql,"RaceLaps");
			
			
		}
		
		
		//If the racetype is period we should work out the finish time
		string raceendtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		string raceperiod;
		DateTime RaceFinishTime = DateTime.Now.AddMinutes(10);
		
		
		if (racetype == "Period") {
			
			string getraceperiodsql = string.Format("Select RaceHours from Races WHERE RaceName='{0}'",racename);
		
		 raceperiod = sbs.GetSingleSQlitefield(getraceperiodsql,"RaceHours");
		
		 RaceFinishTime = Convert.ToDateTime(racestarttimestring).AddHours(Convert.ToDouble(raceperiod));
			raceendtime = RaceFinishTime.ToString("yyyy-MM-dd HH:mm:ss");
		}
		
		//lets calculate the stuff we need just once!
		
		//figure out read times close to the race start time
	DateTime racestarttime;
		
	if (!DateTime.TryParse(racestarttimestring, out racestarttime)) {
			
			//oops no valid start time for this race lets get out of here!
			
			Console.WriteLine("No Valid Race Start Time, Bailing {0}",racestarttime.ToString());
			
			return;
			
		}
	
//	Console.WriteLine(racestarttimestring);
//	Console.WriteLine(racestarttime);
		
			DateTime starttimeless1minute = racestarttime.AddMinutes(Convert.ToDouble(-MainForm.beforeStart));
			DateTime startimeplus1minute = racestarttime.AddMinutes(Convert.ToDouble(MainForm.afterStart));
			
			DateTime earliestfinishtime = racestarttime.AddMinutes(Convert.ToDouble(MainForm.starttofinish));
			
			//fucking date formats !
		string startimeless = starttimeless1minute.ToString("yyyy-MM-dd HH:mm:ss");
			string starttimeplus = startimeplus1minute.ToString("yyyy-MM-dd HH:mm:ss");
			
			string earliestfinish = earliestfinishtime.ToString("yyyy-MM-dd HH:mm:ss");
				
					//handle unranked times and more with the Status field - 
			
			string CurrentStatusQ = string.Format("Select Status from Athletes WHERE BibNumber='{0}' and Race = '{1}'",bib,racename);
			
			string CurrentStatus = sbs.GetSingleSQlitefield(CurrentStatusQ,"Status");
			
			
			Console.WriteLine("Processing Bib Number {0}",bib);
			
			
				//make the bib match the epc
			
			string paddedbib = bib.PadLeft(24,'0');
			
			
		
//lets see if we can optimise things.

//There is no point getting and setting the start time evert loop, if the status is running then we can skip this bit

string chipreadstarttime = "Nothing";

if (CurrentStatus != "Started" && CurrentStatus != "Finished") {

//Then calculate if we got a start read and add that to their record
			//lookup their bib number in the splits table and see if there is something arounf the start time
	
			
			//get the start read time
			
			string searchforstartread = string.Format("Select created from Splits WHERE epc='{0}' and created BETWEEN '{1}' AND '{2}'",paddedbib,startimeless,starttimeplus);
			
			 chipreadstarttime = sbs.GetSingleSQlitefield(searchforstartread,"created");
			
	
	//If we got a start read, then put it into the Athletes table
			
			string startreadstatus = CurrentStatus;
			
			//lets skip the people in the classes we don't want to touch
			
			if(chipreadstarttime == "Nothing" && CurrentStatus != "Unranked" && CurrentStatus != "DNS"  ) 
			{
				
				 startreadstatus = "Unknown" ;
			
			}  else
				
			{
				if (CurrentStatus != "Unranked") startreadstatus = "Started";
				
			}
					
					
			string insertstartread = string.Format("UPDATE Athletes SET ChipStart='{0}', Status = '{1}' WHERE BibNumber='{2}' AND Race='{3}'",chipreadstarttime,startreadstatus,bib,racename);
			
			sbs.SimpleSQliteInsert(insertstartread);

}

			
			
			
			//lets try and handle laps
			
			string lapcount ="0";
			
			if (racetype == "Period" || racetype == "Laps" && CurrentStatus != "Finished" ) {
				
				
		string countlapssql = string.Format("SELECT COUNT(epc) FROM Splits WHERE epc='{0}' AND created BETWEEN '{1}' AND '{2}'",paddedbib,starttimeplus,raceendtime);
				
	//	Console.WriteLine(countlapssql);
	
		 lapcount = sbs.GetSingleSQlitefield(countlapssql,"COUNT(epc)");
		 
		 //now lets insert that into the athletes record
		 
		 runnerstatsmessage += " Lap="+lapcount;
		 
		 string insertlapcount = string.Format("UPDATE Athletes SET Laps ='{0}' WHERE BibNumber ='{1}'",lapcount,bib);
		
		 sbs.SimpleSQliteInsert(insertlapcount);
		 
		 	
		 
		 //it would be nice to be able to calculate the overal position now...
		 
		
		}
			
			string thisstatus ="Finished";
			
				if (racetype == "Period" && RightNow < RaceFinishTime) {
				
				thisstatus = CurrentStatus;
				
			}
			
			if (racetype == "Laps" && (Convert.ToInt32(racelaps) > Convert.ToInt32(lapcount)) ) {
				
				Console.WriteLine("Racetype is {0} and on lap {1} of {2}",racetype, lapcount,racelaps);
				
				thisstatus = CurrentStatus;
			}
			
			
				
			string chipfinishreadtime = "Nothing";
			
			//This should only happen once as we exclude finishers, right?
			
			//for period races we want to skip this completely
			
			//for lap races we only want to record the time when we are on the last lap.
			
		//	if (racetype == "Period") goto SkipThisBit;


		//	if (racetype == "Laps" && Convert.ToInt32(racelaps) > Convert.ToInt32(lapcount))  goto SkipThisBit;
			
			
			
			//if we got a finish read then put it in the Athletes table
			
			//we want to make sure we get the last one only.
			
			//We absolutely don't want to keep doing this after they bloody finish!
			
			if (CurrentStatus != "Finished") 
				
			{
				string searchforfinishread;
				//We want the first read for normal races or the last read for lap races.
				
				if (racetype == "Laps" || racetype == "Period" ){
					
					
					 searchforfinishread = string.Format("Select created from Splits WHERE epc='{0}' and created > '{1}' ORDER BY created DESC LIMIT '{2}'",paddedbib,earliestfinish,racelaps);
					
				}  else {
					
					
					 searchforfinishread = string.Format("Select created from Splits WHERE epc='{0}' and created > '{1}' ORDER BY created ASC LIMIT '{2}'",paddedbib,earliestfinish,racelaps);
					
				}
			
			
			
			
			 chipfinishreadtime = sbs.GetSingleSQlitefield(searchforfinishread,"created");
			
			//update table
			
			
			string insertfinishread = string.Format("UPDATE Athletes SET ChipEnd='{0}' WHERE BibNumber='{1}' AND Race='{2}'",chipfinishreadtime,bib,racename);
			
			sbs.SimpleSQliteInsert(insertfinishread);
			
			
			
			}
			
			
			//if we got start and finish times then calculate the elapsed for gun and net
			
			
			TimeSpan guntotal = new TimeSpan();
			TimeSpan netttotal = new TimeSpan();
			
		//	Console.WriteLine("About to work out times");
			
		
			
			
			
			if (chipfinishreadtime != "Nothing" && CurrentStatus != "Finished") {
			
			guntotal = Convert.ToDateTime(chipfinishreadtime) - Convert.ToDateTime(racestarttime);
			
			string fuckinggun = guntotal.ToString();
			
			Console.WriteLine("Got a Finish Chip Read");
			
			if (chipreadstarttime != "Nothing") {
				
				Console.WriteLine("Got a Start Chip Read");
				
			
			netttotal = Convert.ToDateTime(chipfinishreadtime) - Convert.ToDateTime(chipreadstarttime);
			
			string fuckingnett = netttotal.ToString();
			
			
		string updatetotaltimes1;

			if (CurrentStatus == "Unranked") {
				
				
				 updatetotaltimes1 = string.Format("UPDATE Athletes SET NettTotal = '{0}', GunTotal = '{1}' WHERE BibNumber = '{2}' AND Race = '{3}'", fuckingnett, fuckinggun, bib, racename);
				
			} else {
			
			
		
			
			
			 updatetotaltimes1 = string.Format("UPDATE Athletes SET NettTotal = '{0}', GunTotal = '{1}', Status = '{2}' WHERE BibNumber = '{3}' AND Race = '{4}' AND Status IS NOT '{5}'", fuckingnett, fuckinggun, thisstatus, bib, racename, "DQ");
			
			}
			
			
			sbs.SimpleSQliteInsert(updatetotaltimes1);
			
		//	Console.WriteLine(updatetotaltimes1);
			
			}
			
			
			//update the elapsed times in the Athletes table
			//if we got a finish read, set the status to finished
			
			//fuckinggun = "Sausages";
			
			Console.WriteLine("Got guntotal of {0} for bib {1}",fuckinggun,bib);
			
		string updatetotaltimes2;
				if (CurrentStatus == "Unranked") {
			
			
			 updatetotaltimes2 = string.Format("UPDATE Athletes SET GunTotal = '{0}' WHERE BibNumber = '{1}' AND Race = '{2}'", fuckinggun, bib, racename);
			
			}  else
				
			{
							 updatetotaltimes2 = string.Format("UPDATE Athletes SET GunTotal = '{0}', Status = '{1}' WHERE BibNumber = '{2}' AND Race = '{3}' AND Status IS NOT '{4}'", fuckinggun, thisstatus, bib, racename, "DQ");
			}
			
			
				
			//	Console.WriteLine(updatetotaltimes2);
				
			sbs.SimpleSQliteInsert(updatetotaltimes2);
			
		
			//lets store the athletes bib number, name, laps and guntotal together for the scoreboard
			
			if (racetype != "Laps") {	runnerstatsmessage += " " + fuckinggun;}
			
	//		DbSqlite.RFIDTAGSTORE.Close();
			
			CalculateResults(racename);
			
	//		DbSqlite.RFIDTAGSTORE.Open();
		}
		
		
		if (chipfinishreadtime == "Nothing" && CurrentStatus != "Finished") {
		
				try 
				{
				
				//Lets try using the manual finish time...
				string searchformanualfinish = string.Format("Select ManualEnd from Athletes WHERE BibNumber='{0}' and Race = '{1}'",bib,racename);
			
			string manualfinishtime = sbs.GetSingleSQlitefield(searchformanualfinish,"ManualEnd");
			
		//	Console.WriteLine(manualfinishtime);
			
				guntotal = Convert.ToDateTime(manualfinishtime) - Convert.ToDateTime(racestarttime);
			
			//	Console.WriteLine(guntotal);
				
				if (chipreadstarttime != "Nothing") {
				
			netttotal = Convert.ToDateTime(manualfinishtime) - Convert.ToDateTime(chipreadstarttime);
			
				}
			
			Console.WriteLine("Got Guntotal of {0} And Nett of {1} for Bib{2}", guntotal.ToString(),netttotal.ToString(),bib);
			
			//update the elapsed times in the Athletes table
			//if we got a finish read, set the status to finished
			string updatetotaltimes;
			if (CurrentStatus == "Unranked") {
			
			
			 updatetotaltimes = string.Format("UPDATE Athletes SET NettTotal='{0}', GunTotal='{1}' WHERE BibNumber='{2}' AND Race='{3}' AND Status != '{5}'",netttotal.ToString(),guntotal.ToString(),bib,racename,"DQ");
			
			} else {
			
			 updatetotaltimes = string.Format("UPDATE Athletes SET NettTotal='{0}', GunTotal='{1}', Status='{4}' WHERE BibNumber='{2}' AND Race='{3}' AND Status != '{5}'",netttotal.ToString(),guntotal.ToString(),bib,racename,"Finished","DQ");
			
			}
			
			
			sbs.SimpleSQliteInsert(updatetotaltimes);
			
				
				}
				
				catch
					
				{
		//	Console.WriteLine("No valid Manual finish times skipping");
			
				}
		//		Console.WriteLine("No valid Read finish times skipping");
		
		}
			//SkipThisBit: ;
			
			
			
			string CurrentPosition = string.Format("Select GenderPos from Athletes WHERE BibNumber='{0}' and Race = '{1}'",bib,racename);
			
		  CurrentPosition = sbs.GetSingleSQlitefield(CurrentPosition,"GenderPos");
			
		//	DbSqlite.RFIDTAGSTORE.Close();
			
			statslock = false;
			
			//push the runner stats message to the display somehow...
			if (racetype == "Laps" || racetype == "Period") runnerstatsmessage += " GPos="+CurrentPosition;
			
		//	Console.WriteLine(runnerstatsmessage);
			formstest.MainClass.RunnerMessages.Add(runnerstatsmessage);
			formstest.MainClass.MainMessages.Add(runnerstatsmessage);
				
			}
			
			
		public  void GenerateRaceStats(string racename)
		//Build all the stats for a selected race
		{
		//	lock (lockmethod) {
		
		DbSqlite grs = new DbSqlite();
		try
		{
		
			if (statslock == true) return;
			
		//	DbSqlite.RFIDTAGSTORE.Open();  //open the connection once for the method
		
		if (MainForm.calculatelock != true) {
			
		
		MainForm.calculatelock = true;
			
			
		string getracestarttimesql = string.Format("Select RaceStart from Races WHERE RaceName='{0}'",racename);
			
		string racestarttime = grs.GetSingleSQlitefield(getracestarttimesql,"RaceStart");
		
		
		string getracetypesql = string.Format("Select RaceType from Races WHERE RaceName='{0}'",racename);
		
		string racetype = grs.GetSingleSQlitefield(getracetypesql,"RaceType");
		
		
		//If the racetype is laps we should get the number of laps
		
		string racelaps ="1";
		
		if (racetype == "Laps") {
			
			string getracelapssql = string.Format("Select RaceLaps from Races WHERE RaceName='{0}'",racename);
		
		 racelaps = grs.GetSingleSQlitefield(getracelapssql,"RaceLaps");
			
			
		}
		
		
		//If the racetype is period we should work out the finish time
		string raceendtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		string raceperiod;
		
		if (racetype == "Period") {
			
			string getraceperiodsql = string.Format("Select RaceHours from Races WHERE RaceName='{0}'",racename);
		
		 raceperiod = grs.GetSingleSQlitefield(getraceperiodsql,"RaceHours");
		
		DateTime RaceFinishTime = Convert.ToDateTime(racestarttime).AddHours(Convert.ToDouble(raceperiod));
			raceendtime = RaceFinishTime.ToString("yyyy-MM-dd HH:mm:ss");
		}
		
		//lets calculate the stuff we need just once!
		
		string startimeless="";
		string starttimeplus="";
	string earliestfinish="";
			
			
		if (racestarttime != "Nothing" && racestarttime != "") {

		//figure out read times close to the race start time
			
			DateTime starttimeless1minute = Convert.ToDateTime(racestarttime).AddMinutes(Convert.ToDouble(-MainForm.beforeStart));
			DateTime startimeplus1minute = Convert.ToDateTime(racestarttime).AddMinutes(Convert.ToDouble(MainForm.afterStart));
			
			DateTime earliestfinishtime = Convert.ToDateTime(racestarttime).AddMinutes(Convert.ToDouble(MainForm.starttofinish));
			
			//fucking date formats !
		 startimeless = starttimeless1minute.ToString("yyyy-MM-dd HH:mm:ss");
			 starttimeplus = startimeplus1minute.ToString("yyyy-MM-dd HH:mm:ss");
			
			 earliestfinish = earliestfinishtime.ToString("yyyy-MM-dd HH:mm:ss");
			
			
		}

			
		//First add the race start time to all records - OR clean the slate! ?
	
string setstartsql; //for fucks sake, its gonna exist anyway

if (racestarttime == " " || racestarttime == null || racestarttime == "") //stop the no valid date crash
{
	
	Console.WriteLine("No valid start time giving up");
//	DbSqlite.RFIDTAGSTORE.Close();
	MainForm.calculatelock = false;
	return;
	
		
			}

		
		if (checkBox1.Checked == true) {
	
	Console.WriteLine("Doing Full Reset");
		
	if (checkBox3.Checked == true) {
	
		 setstartsql = string.Format("UPDATE Athletes SET GunStart='{0}', NettTotal = null, GunTotal = null, OverallPos = null, GenderPos = null, CatPos = null, Status = null  WHERE Race='{1}'",racestarttime, racename);
	}
		 
		  setstartsql = string.Format("UPDATE Athletes SET GunStart='{0}', NettTotal = null, GunTotal = null, OverallPos = null, GenderPos = null, CatPos = null  WHERE Race='{1}'",racestarttime, racename);
		 
		grs.SimpleSQliteInsert(setstartsql);
		
	}

// else {
		
//	Console.WriteLine("Just Updating");
	// setstartsql = string.Format("UPDATE Athletes SET GunStart='{0}'  WHERE Race='{1}' AND Status !='{2}' AND Status !='{3}' AND Status !='{4}' AND Status !='{5}'",racestarttime, racename,"Started","Finished","DNF","PRW");
		
	//	}

			
		
		
		//Get all the athletes in this race
		
		string selectraceparticipants;
		
		if (checkBox1.Checked == true) {
		
		 selectraceparticipants = string.Format("Select BibNumber from Athletes WHERE Race='{0}' AND Status IS NOT '{1}' AND Status is not'{2}' AND Status is not '{3}'",racename, "DQ", "PRW", "DNF");
		
		}
		
		else {
		
			 selectraceparticipants = string.Format("Select BibNumber from Athletes WHERE Race='{0}' AND Status IS NOT '{1}' AND Status is not'{2}' AND Status is not '{3}' And Status is not '{4}'",racename,"Finished", "DQ", "PRW", "DNF");
			 Console.WriteLine("Selecting only  finishers");
		}
			
		//Console.WriteLine("about to make list of runners");
		
			
		List<string> BibNumberList = grs.GetSQlitefieldlist(selectraceparticipants,"BibNumber");
		
		Console.WriteLine("I've got {0} in this list",BibNumberList.Count.ToString());
		
		foreach (string bib in BibNumberList )
			
		{
			
			
			//handle unranked times and more with the Status field - 
			
			string CurrentStatusQ = string.Format("Select Status from Athletes WHERE BibNumber='{0}' and Race = '{1}'",bib,racename);
			
			string CurrentStatus = grs.GetSingleSQlitefield(CurrentStatusQ,"Status");
			
			
			Console.WriteLine("Processing Bib Number {0}",bib);
			
			
				//make the bib match the epc
			
			string paddedbib = bib.PadLeft(24,'0');
			
			
		
//lets see if we can optimise things.

//There is no point getting and setting the start time evert loop, if the status is running then we can skip this bit

string chipreadstarttime = "Nothing";

if (CurrentStatus != "Started") {

//Then calculate if we got a start read and add that to their record
			//lookup their bib number in the splits table and see if there is something arounf the start time
	
			
			//get the start read time
			
			string searchforstartread = string.Format("Select created from Splits WHERE epc='{0}' and created BETWEEN '{1}' AND '{2}'",paddedbib,startimeless,starttimeplus);
			
			 chipreadstarttime = grs.GetSingleSQlitefield(searchforstartread,"created");
			
	
	//If we got a start read, then put it into the Athletes table
			
			string startreadstatus = CurrentStatus;
			
			//lets skip the people in the classes we don't want to touch
			
			if(chipreadstarttime == "Nothing" && CurrentStatus != "Unranked" && CurrentStatus != "DNS" && CurrentStatus != "PRW") 
			{
				
				 startreadstatus = "Unknown" ;
			
			}  else
				
			{
				if (CurrentStatus != "Unranked" && CurrentStatus != "DNS" && CurrentStatus != "PRW") startreadstatus = "Started";
				
			}
					
					
			string insertstartread = string.Format("UPDATE Athletes SET ChipStart='{0}', Status = '{1}' WHERE BibNumber='{2}' AND Race='{3}'",chipreadstarttime,startreadstatus,bib,racename);
			
			grs.SimpleSQliteInsert(insertstartread);

}

			
			
			
			//lets try and handle laps
			
			string lapcount ="0";
			
			
			if ( racetype == "Laps" || racetype == "Period" && CurrentStatus != "Finished" ) {
				
				
		string countlapssql = string.Format("SELECT COUNT(epc) FROM Splits WHERE epc='{0}' AND created BETWEEN '{1}' AND '{2}' ORDER BY created ASC LIMIT '{3}'",paddedbib,starttimeplus,raceendtime,racelaps);
				
		
	
	
		 lapcount = grs.GetSingleSQlitefield(countlapssql,"COUNT(epc)");
		 
		 //now lets insert that into the athletes record
		 
		 
		 string insertlapcount = string.Format("UPDATE Athletes SET Laps ='{0}' WHERE BibNumber ='{1}'",lapcount,bib);
		
		 grs.SimpleSQliteInsert(insertlapcount);
		 
		 	
		
		}
			
			
			
				
			string chipfinishreadtime = "Nothing";
			
			
			
			//This should only happen once as we exclude finishers, right?
			
			//for period races we want to skip this completely
			
			//for lap races we only want to record the time when we are on the last lap.
			
			if (racetype == "Period") goto SkipThisBit;


			if (racetype == "Laps" && Convert.ToInt32(racelaps) > Convert.ToInt32(lapcount))  goto SkipThisBit;
			
			
			
			//if we got a finish read then put it in the Athletes table
			
			string searchforfinishread;
			//if we got a finish read then put it in the Athletes table
			
				if (racetype == "Laps" || racetype == "Period" && CurrentStatus != "Finished"){
					
					
					 searchforfinishread = string.Format("Select created from Splits WHERE epc='{0}' and created > '{1}' ORDER BY created DESC LIMIT '{2}'",paddedbib,earliestfinish,racelaps);
					
				}  else {
					
					
					 searchforfinishread = string.Format("Select created from Splits WHERE epc='{0}' and created > '{1}' ORDER BY created ASC LIMIT '{2}'",paddedbib,earliestfinish,racelaps);
					
				}
			
			//string searchforfinishread = string.Format("Select created from Splits WHERE epc='{0}' and created > '{1}' ORDER BY created DESC",paddedbib,earliestfinish);
			
			 chipfinishreadtime = grs.GetSingleSQlitefield(searchforfinishread,"created");
			
			//update table
			
			
			string insertfinishread = string.Format("UPDATE Athletes SET ChipEnd='{0}' WHERE BibNumber='{1}' AND Race='{2}'",chipfinishreadtime,bib,racename);
			
			grs.SimpleSQliteInsert(insertfinishread);
			
			
			
			
			
			//if we got start and finish times then calculate the elapsed for gun and net
			
			
			TimeSpan guntotal = new TimeSpan();
			TimeSpan netttotal = new TimeSpan();
			
		//	Console.WriteLine("About to work out times");
			
		
			
			
			
			if (chipfinishreadtime != "Nothing") {
			
			guntotal = Convert.ToDateTime(chipfinishreadtime) - Convert.ToDateTime(racestarttime);
			
			string fuckinggun = guntotal.ToString();
			
		//	Console.WriteLine("Got a Finish Chip Read");
			
			if (chipreadstarttime != "Nothing") {
				
			//	Console.WriteLine("Got a Start Chip Read");
				
			
			netttotal = Convert.ToDateTime(chipfinishreadtime) - Convert.ToDateTime(chipreadstarttime);
			
			string fuckingnett = netttotal.ToString();
			
			
			
			
		string updatetotaltimes1;

			if (CurrentStatus == "Unranked") {
				
				
				 updatetotaltimes1 = string.Format("UPDATE Athletes SET NettTotal = '{0}', GunTotal = '{1}' WHERE BibNumber = '{2}' AND Race = '{3}'", fuckingnett, fuckinggun, bib, racename);
				
			} else {
			
			
			 updatetotaltimes1 = string.Format("UPDATE Athletes SET NettTotal = '{0}', GunTotal = '{1}', Status = '{2}' WHERE BibNumber = '{3}' AND Race = '{4}' AND Status IS NOT '{5}'", fuckingnett, fuckinggun, "Finished", bib, racename, "DQ");
			
			}
			
			
			grs.SimpleSQliteInsert(updatetotaltimes1);
			
		//	Console.WriteLine(updatetotaltimes1);
			
			}
			
			
			//update the elapsed times in the Athletes table
			//if we got a finish read, set the status to finished
			
			//fuckinggun = "Sausages";
			
			Console.WriteLine("Got guntotal of {0} for bib {1}",fuckinggun,bib);
			
		string updatetotaltimes2;
				if (CurrentStatus == "Unranked") {
			
			
			 updatetotaltimes2 = string.Format("UPDATE Athletes SET GunTotal = '{0}' WHERE BibNumber = '{1}' AND Race = '{2}'", fuckinggun, bib, racename);
			
			}  else
				
			{
							 updatetotaltimes2 = string.Format("UPDATE Athletes SET GunTotal = '{0}', Status = '{1}' WHERE BibNumber = '{2}' AND Race = '{3}' AND Status IS NOT '{4}'", fuckinggun, "Finished", bib, racename, "DQ");
			}
			
			
				
		//		Console.WriteLine(updatetotaltimes2);
				
			grs.SimpleSQliteInsert(updatetotaltimes2);
			
		
			
		}
		
		
		if (chipfinishreadtime == "Nothing") {
		
				try 
				{
				
				//Lets try using the manual finish time...
				string searchformanualfinish = string.Format("Select ManualEnd from Athletes WHERE BibNumber='{0}' and Race = '{1}'",bib,racename);
			
			string manualfinishtime = grs.GetSingleSQlitefield(searchformanualfinish,"ManualEnd");
			
		//	Console.WriteLine(manualfinishtime);
			
				guntotal = Convert.ToDateTime(manualfinishtime) - Convert.ToDateTime(racestarttime);
			
	//			Console.WriteLine(guntotal);
				
				if (chipreadstarttime != "Nothing") {
				
			netttotal = Convert.ToDateTime(manualfinishtime) - Convert.ToDateTime(chipreadstarttime);
			
				}
			
			Console.WriteLine("Got Guntotal of {0} And Nett of {1} for Bib{2}", guntotal.ToString(),netttotal.ToString(),bib);
			
			//update the elapsed times in the Athletes table
			//if we got a finish read, set the status to finished
			string updatetotaltimes;
			if (CurrentStatus == "Unranked") {
			
			
			 updatetotaltimes = string.Format("UPDATE Athletes SET NettTotal='{0}', GunTotal='{1}' WHERE BibNumber='{2}' AND Race='{3}' AND Status != '{5}'",netttotal.ToString(),guntotal.ToString(),bib,racename,"DQ");
			
			} else {
			
			 updatetotaltimes = string.Format("UPDATE Athletes SET NettTotal='{0}', GunTotal='{1}', Status='{4}' WHERE BibNumber='{2}' AND Race='{3}' AND Status != '{5}'",netttotal.ToString(),guntotal.ToString(),bib,racename,"Finished","DQ");
			
			}
			
			
			grs.SimpleSQliteInsert(updatetotaltimes);
			
				
				}
				
				catch
					
				{
		//	Console.WriteLine("No valid Manual finish times skipping");
			
				}
		//		Console.WriteLine("No valid Read finish times skipping");
		
		}
		SkipThisBit: ;
			//we can skip this part if we already did it...
			
			string agecatq = string.Format("SELECT AgeCat from Athletes WHERE BibNumber='{0}' and Race='{1}'",bib,racename);
			
			string agecatexists = grs.GetSingleSQlitefield(agecatq,"AgeCat");
			
	//		if (agecatexists == "Nothing" || agecatexists == "") {
			
				
			//work out the age categories based on DOB
			
			//get their DOB
			
			
			
			string agequery = string.Format("SELECT DOB from Athletes WHERE BibNumber='{0}' and Race='{1}'",bib,racename);
			
			string dobtxt = grs.GetSingleSQlitefield(agequery,"DOB");
			
			DateTime dob = Convert.ToDateTime(dobtxt);
			
			//work out their age on jan 1 2013
			
			DateTime	raceagedate = new DateTime(2013, 01, 01);
			
			TimeSpan age = new TimeSpan();
			
			age = raceagedate - dob;
			
			int correctedage = age.Days/365;
			
			//assign an age catgory and insert it into the tables
			
			string agecat="Unknown";
			
			//if (correctedage <35) agecat = "34 and under";
			//if (correctedage >=35 && correctedage <45) agecat = "35 - 44";
		//	if (correctedage >=45) agecat = "45+";
			
		
		
			if (correctedage <36) agecat = agecat1;
			if (correctedage >=36 && correctedage <47) agecat = agecat2;
			if (correctedage >=47) agecat = agecat3;
			
			
			//write the age cat
			
			string addagecat = string.Format("Update Athletes SET AgeCat='{0}' WHERE Race='{1}' AND BibNumber='{2}'",agecat,racename,bib);
			
			grs.SimpleSQliteInsert(addagecat);
			
			}
			
//		Console.WriteLine("Loop Ends Here");
//		}
		
		
		
		
		//how many runners started the race
		
	string countstarters = string.Format("Select COUNT(BibNumber) from Athletes WHERE Race='{0}'",racename);
		
	string entrants = grs.GetSingleSQlitefield(countstarters,"COUNT(BibNumber)");
		
		//how many DNS were there
		
			
	string countdns = string.Format("SELECT COUNT(BibNumber) from Athletes WHERE Race='{0}' AND ( Status = '{1}' OR Status = '{2}') ",racename,"DNS","PRW");
		
	string didnotstart = grs.GetSingleSQlitefield(countdns,"COUNT(BibNumber)");
	
	//how many have finished the race
	
	
	string countfinishers = string.Format("SELECT COUNT(BibNumber) from Athletes WHERE Race='{0}' AND Status = '{1}'",racename,"Finished");
	
	string finishers = grs.GetSingleSQlitefield(countfinishers,"COUNT(BibNumber)");
	
	//how many dnfs have we added?
	
	string countdnfs = string.Format("SELECT COUNT(BibNumber) from Athletes WHERE Race='{0}' and ( Status='{1}' OR Status ='{2}')",racename,"DNF","DQ");
	
	
	string dnfs = grs.GetSingleSQlitefield(countdnfs,"COUNT(BibNumber)");
	
	
	//how many are still out on the course
	//Just Starters minus dns minus finishers minus dnf, easy right!
	
	//freaking strings and ints
	
	int s;
bool result	= Int32.TryParse(entrants, out s);
	int dns;
result	= Int32.TryParse(didnotstart, out dns);
	int dnf;
result	= Int32.TryParse(dnfs, out dnf);
	int f;
result	= Int32.TryParse(finishers, out f);
	
	
	int stillrunning = s - dns - dnf - f;
	
	
	
	string currentstats = string.Format("{0}.  Entrants:{1}  DNS:{2}  DNF:{3}  Finished:{4}  Running:{5}",racename,entrants,didnotstart,dnfs,finishers,stillrunning);
	
	string someting;
	formstest.MainClass.RaceStats.TryRemove(racename, out  someting);
	formstest.MainClass.RaceStats.TryAdd(racename,currentstats);
	
	MainForm.Instance.RaceStatsBoxUpdate();
	
	
	
		}
	
	//textBox1.Text = currentstats;
	
	//are we working on Gun or Nett times?  Default is Gun
	
		//	}  /// <summary>
			/// <c---End Lo
			/// </summary>
			
		
			
		}
		
		
		catch(Exception e)
			
		{
			//report died
			Console.WriteLine(e);
		}
		
		
			
		
			CalculateResults(racename);
			
				//DbSqlite.RFIDTAGSTORE.Close(); //close the connection once for the method
			
			MainForm.calculatelock = false;
		
		} //end method
		
	
		
		private object lockmethod2 = new object();
		
		void CalculateResults(string racename)
			
		{
			
			
			DbSqlite cr = new DbSqlite();
			
			
			lock (lockmethod2){
				
			//	Console.WriteLine("Calculating Results");
				
				
				//lets get the race type so we know how to handle laps
				
				
				
				
				
			//	DbSqlite.RFIDTAGSTORE.Open();
				
				string getracetypesql = string.Format("Select RaceType from Races WHERE RaceName='{0}'",racename);
		
		string racetype = cr.GetSingleSQlitefield(getracetypesql,"RaceType");
				
				
				
			
			//first get a list of all the bib numbers that are have finish times in overall positon and are not DQ or DNF or PRW or Unranked
			
			string selectoverall;
			
			if (racetype == "Period" || racetype == "Laps") {  
			
			//if this is a period race we need to order by laps and NOT FInished!
			
			 selectoverall = string.Format("SELECT BibNumber, Laps from Athletes WHERE Race='{0}'  ORDER BY Laps DESC, GunTotal ASC",racename);
			
			} 
			
else
				
			{
				
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' ORDER BY GunTotal ASC",racename,"Finished");
			
				
				
			}
			
			List<string> BibNumberList2 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			int position = 1;
		foreach (string bib in BibNumberList2 )
			
		{
			
			string insertoverallposition = string.Format("UPDATE Athletes SET OverallPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			
			//now get a list of all male overall
			
			
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND SEX='{2}' ORDER BY GunTotal ASC",racename,"Finished","Male");
			
			if (racetype == "Period" || racetype == "Laps") {
			
			//if this is a period race we need to order by laps
 selectoverall = string.Format("SELECT BibNumber, Laps from Athletes WHERE Race='{0}'  AND SEX='{1}' ORDER BY Laps DESC, GunTotal ASC",racename,"Male");
				 }
			
			
			


				 List<string> BibNumberList3 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList3 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET GenderPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			
			
			//now get a list of all female overall
			

				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND SEX='{2}' ORDER BY GunTotal ASC",racename,"Finished","Female");
			
				 
				 if (racetype == "Period" || racetype == "Laps") {
				 	
							 selectoverall = string.Format("SELECT BibNumber, Laps from Athletes WHERE Race='{0}'  AND SEX='{1}' ORDER BY Laps DESC, GunTotal ASC",racename,"Female");
							 
			}
				 
			List<string> BibNumberList4 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList4 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET GenderPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
		
		if (checkBoxAgeGroups.Checked == true) {
		
		
			//now get male under 35
			string AgeCat = agecat1;
		string	 Sex = "Male";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal, Laps from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList5 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList5 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			//now get female under 35
			 AgeCat = agecat1;
			 Sex = "Female";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList6 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList6 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			
			//now get male 35-44
			 AgeCat = agecat2;
			 Sex = "Male";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList7 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList7 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			
			//now get female 35-44
			
			 AgeCat = agecat2;
			 Sex = "Female";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList8 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList8 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			//now get male over 45
			 AgeCat = agecat3;
			 Sex = "Male";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList9 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList9 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
			
			//now get female over 45
			 AgeCat = agecat3;
			 Sex = "Female";
				 selectoverall = string.Format("SELECT BibNumber, GunTotal from Athletes WHERE Race='{0}' AND Status='{1}' AND Sex='{2}' AND AgeCat='{3}' ORDER BY GunTotal, Laps ASC",racename,"Finished",Sex,AgeCat);
			
			List<string> BibNumberList10 = cr.GetSQlitefieldlist(selectoverall,"BibNumber");
		
			 position = 1;
		foreach (string bib in BibNumberList10 )
			
		{
			
		string	insertoverallposition = string.Format("UPDATE Athletes SET CatPos='{0}' WHERE Race='{1}' AND BibNumber='{2}'",position.ToString(),racename,bib);
			cr.SimpleSQliteInsert(insertoverallposition);
			 position++;
			
		}
		
		} //end agegroups filter
		
			
			 // DbSqlite.RFIDTAGSTORE.Close();
			
			
			//ok lets try and get the top 10 positions into a string we can use if it is a lap type race....
			
	if (racetype == "Period" || racetype == "Laps") {  
			
			string getracetop10 = string.Format("Select BibNumber, Fname, LName, Laps, OverallPos, GenderPos from Athletes WHERE Race = '{0}' ORDER BY OverallPos ASC LIMIT 10",racename);
			
			DataSet dstop = new DataSet();
			
		dstop =	DbSqlite.GetDataSetSqlite(getracetop10);
		
		Console.WriteLine(getracetop10);
	//	
		DataTable results = dstop.Tables[0];
		
		StringBuilder top10resultsstring = top10positions(results);
			
		Console.WriteLine(top10resultsstring);
		
		string whatever;
		
		WinformsTiming.formstest.MainClass.Top10.TryRemove(racename, out whatever);
		
		WinformsTiming.formstest.MainClass.Top10.TryAdd(racename,top10resultsstring.ToString());
		
		}	}
		
		}
		
		
		
		static StringBuilder top10positions (DataTable dg)
			
		{
			
			 StringBuilder strB = new StringBuilder();
    //create header
  
  
   //  strB.AppendLine(@"Top 10 Positions Overall");
   // strB.AppendLine("Bib Name     Laps    Overall Pos   Gender Pos");
    
     string LastUpdateTime = DateTime.Now.ToString();
     
    try
    {
    	
    	int i =0;
     
   //  strB.AppendLine("Results for: " + dg.Rows[0].Cells["Race"].Value.ToString()       + "  Last updated at: " + LastUpdateTime  );
                   
    //strB.AppendLine(Environment.NewLine);
    //cteate table header
    
  //  243 Two Fortythree 10 2 1
    
   foreach (DataRow dataRow in dg.Rows)
   	
   {
   	

   	string alstring = "(" + dg.Rows[i]["BibNumber"].ToString() + ")";
   		alstring += " ";
   		alstring += dg.Rows[i]["Fname"].ToString();
   		alstring += " ";
   	alstring += dg.Rows[i]["Lname"].ToString();
   		alstring += "  Laps=" + dg.Rows[i]["Laps"].ToString();
   		alstring += "  Overall Pos=" + dg.Rows[i]["OverallPos"].ToString();
   	alstring += "  Sex Pos=" + dg.Rows[i]["GenderPos"].ToString();
   	//string rowstring = string.Join(" ", dg.Rows[i].ItemArray); 
   	
   	
   	strB.AppendLine( alstring );          //   string.Join(" ", (string[])dataRow.ItemArray));    //dataRow.ItemArray.ToString())) ;
   	//  strB.AppendLine(Environment.NewLine);
   	
   	i++;
   	
    }
    
    }
    
    catch
    	
    {
    	// strB.AppendLine("No Results Yet!");
    	
    }
    
    //table footer & end of html file
 //   strB.AppendLine("</tbody></table></center></body></html>");
    return strB;
					
			
			
			
		}
		
		
		
		
		
		public Reports()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			PopulateMenu();
			
			
	numericUpDown1.Value = 	MainForm.beforeStart;
numericUpDown2.Value = MainForm.afterStart;
numericUpDown3.Value = MainForm.starttofinish;
numericUpDown4.Value = MainForm.minlaptime;
			
			
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string option1 = ChooseRace.Text;
			Thread thread = new Thread(() => GenerateRaceStats(option1));
			thread.Start();
			
			//GenerateRaceStats(ChooseRace.Text)
		}
	
		
		void Button2Click(object sender, EventArgs e)
		{
			
			string option1 = ChooseRace.Text;
			Thread thread2 = new Thread(() => CalculateResults(option1));
			thread2.Start();
			
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{

				ResultsPrint rp = new ResultsPrint();
			rp.Show();
			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
		textBox1.Text = formstest.MainClass.RaceStats.Values.ToString();	
		}
		
		void Button5Click(object sender, EventArgs e)
		{

//write the values to the variables...

MainForm.beforeStart = numericUpDown1.Value;
MainForm.afterStart = numericUpDown2.Value;
MainForm.starttofinish = numericUpDown3.Value;
MainForm.minlaptime = numericUpDown4.Value;
			
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			
		}
	}
	
	
}
