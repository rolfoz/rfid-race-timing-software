/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 3/02/2013
 * Time: 2:52 PM
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
using System.Globalization;


namespace WinformsTiming
{
	/// <summary>
	/// Description of TimersWindow.
	/// </summary>
	public partial class TimersWindow : Form
	{
	
		public bool updating;
	 
		
		//public string statstxt = "Updating...";
		
		 // Because we have not specified a namespace, this
        // will be a System.Windows.Forms.Timer instance
      //  private System.Windows.Forms.Timer _timer;

        // The last time the timer was started
        private DateTime _startTime = DateTime.MinValue;

        // Time between now and when the timer was started last
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;

        // Time between now and the first time timer was started after a reset
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;

        // Whether or not the timer is currently running
      //  private bool _timerRunning = false;		

        public string TimerRaceName {get; set;}
        public string RaceLaps  {get; set;}
        public bool ShowTop10 {get; set;}
        
        public string RaceType  {get; set;}
        public string RaceHours  {get; set;}
        
        
        public DateTime RaceTimeStartTime {get; set;}
        
        DateTime RightNow = DateTime.Now.ToLocalTime ();
			
        void _timer_Tick(object sender, EventArgs e)
        {
            // We do this to chop off any stray milliseconds resulting from 
            // the Timer's inherent inaccuracy, with the bonus that the 
            // TimeSpan.ToString() method will now show correct HH:MM:SS format
            var timeSinceStartTime = DateTime.Now - _startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours, 
                                              timeSinceStartTime.Minutes, 
                                              timeSinceStartTime.Seconds);

            // The current elapsed time is the time since the start button was
            // clicked, plus the total time elapsed since the last reset
            _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;

            // These are just two Label controls which display the current 
            // elapsed time and total elapsed time
           textBox2.Text = _currentElapsedTime.ToString();
            textBox1.Text = timeSinceStartTime.ToString();
        }

        
        void updatestats()
       {
        	
        	
        	
        try
        {
        	
        //	formstest.MainClass.RaceStats.TryAdd( "waiting",  "waiting");
		
        	foreach (string str1 in formstest.MainClass.RaceStats.Values)
           {
				string statstext = formstest.MainClass.RaceStats[str1];
				Invoke(new Action(delegate {textBox2.Text = statstext;} ) );
				
				Thread.Sleep(10000);
        	
        		//set the variable, sleep for 5 secs
        		
        	}
        }
        	
        catch

        {
        //go here to die...	
        }
       	}
            
        

		
		public TimersWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			 AutoTimeShow();
			//System.Timers.Timer anewtimer = new System.Timers.Timer(10000);
			//anewtimer.Elapsed += new ElapsedEventHandler(ThreadPool.QueueUserWorkItem(delegate {updatestats;}));
			//anewtimer.Enabled = true;
			
			ThreadPool.QueueUserWorkItem( delegate {updatestats();} );
			ThreadPool.QueueUserWorkItem( delegate {UpdateTextBox5();} );
			
		}
		
		void AutoTimeShow()
			
		{
			
			//get the time the race started
			
			
			//get the current time
			 DateTime RightNow = DateTime.Now.ToLocalTime ();
			
			//show the elapsed time
			
			
			 var timeSinceStartTime = DateTime.Now - RaceTimeStartTime;
			
			 timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours, 
                                              timeSinceStartTime.Minutes, 
                                              timeSinceStartTime.Seconds);
		
			
			//repeat to keep the display updated
			
			
			 textBox1.Text = timeSinceStartTime.ToString();
			textBox1.TextAlign = HorizontalAlignment.Center;
			 textBox4.Text = DateTime.Now.ToString();
			textBox4.TextAlign = HorizontalAlignment.Center;
			
			
	
			
			//updatestats();
			
			//textBox2.Text = statstxt;
			string statstext = " ";
				//string statstext = "Waiting for an update";
				
				try {
						if (formstest.MainClass.RaceStats.ContainsKey (TimerRaceName)) {
							statstext = formstest.MainClass.RaceStats [TimerRaceName];
			}
				}
				
				catch
					
				{
					 statstext = "Waiting for an update";
				}
				
			
			textBox2.Text = statstext;
			
			textBox2.TextAlign = HorizontalAlignment.Center;
			
			
			//textbox5 is the runners name and stats
			//we want to show the string for 3 seconds and then move on to the next one
			//we don't want to stop everything else updating so we are going to use another thread
			//I bet we have to invoke something now....
			
			
			
			Thread racersthread = new Thread(new ThreadStart(UpdateTextBox5));
			racersthread.IsBackground = true;
			racersthread.Start();
			//UpdateTextBox5();
			
			
			
			
			
			
		
		
	//	if(results.Rows.Count > 0)
//{
// txtamount.Text= Convert.ToString(dvDataTable["amount"]);
		
try {
	
	
	//if it's a lap race then put up the results, otherwise put up the tags in view
	
	if (RaceType == "Laps" || RaceType == "Period" && ShowTop10 == true){
		
textBox3.Text = WinformsTiming.formstest.MainClass.Top10[TimerRaceName].ToString();

	} else
		
	{
		
		//Show the tags in view
		
		
		//clear the old tags
		textBox3.Text = " ";
		
		
	//copy the bloody dictionary to stop the crashing!
			
			Dictionary<string,string> copy = new Dictionary<string,string>(formstest.MainClass.RecentTags);

			foreach (string str1 in copy.Keys)
            {
				string str2 = copy[str1];
				
				DateTime RightNow2 = DateTime.Now.ToLocalTime ();

DateTime tlst1 = Convert.ToDateTime (str2);
TimeSpan ts = RightNow2 - tlst1;
//Console.WriteLine("I see a tag aged "+ str1.Remove(0,21) + ts.TotalSeconds.ToString());
if (ts.TotalSeconds < 5) {
	
	textBox3.Text += str1.Remove(0,21) +"  ";
		
		
	}
			}
	} }
 
 


catch
	
{
	textBox3.Text = "No Results Yet...";
	
}
 

			textBox3.TextAlign = HorizontalAlignment.Center;
			
		
		
			
	
	//lookup the racers name and time and laps
	
	//if (RaceType == "Laps") {textBox3.Text += "\n Runner Name Lap 99" ;}
	
	
	

		}

		
		
		
		
		
		void UpdateTextBox5()
			
		{
			
			if (updating==true) return;
			updating=true;
			
			//loop through the list of messages
				
			for (int i = 0; i < formstest.MainClass.RunnerMessages.Count; i++)
			//foreach (string str1 in formstest.MainClass.RunnerMessages)
            {
				string str1 = formstest.MainClass.RunnerMessages[i];
				
				try {	Invoke(new Action(delegate {textBox5.Text = str1;textBox5.TextAlign = HorizontalAlignment.Center;} ) );
					//textBox5.Text = str1;
					//Console.WriteLine(str1);
			
				Thread.Sleep(4000);
				formstest.MainClass.RunnerMessages.Remove(str1);
				//clear the screen
				Invoke(new Action(delegate {textBox5.Text = "*";textBox5.TextAlign = HorizontalAlignment.Center;} ) );
				
				//lets also try and put the overall results into the next textbox..
				Invoke(new Action(delegate {textBox5.Text = "*";textBox5.TextAlign = HorizontalAlignment.Center;} ) );
				
				
				}
				
				catch {//oops}
			
			//show each one for 3 seconds and then delete it from the list 
				}
			}
				
				updating=false;
			
		}
		
	
		
		void Timer1Tick(object sender, EventArgs e)
		{
			AutoTimeShow();
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
