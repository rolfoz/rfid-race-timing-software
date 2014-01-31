/*
 * Created by SharpDevelop.
 * User: rolf
 * Date: 28/02/2013
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WinformsTiming
{
	/// <summary>
	/// Description of TextBoxStreamWriter.
	/// </summary>
	 public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;
       public static bool consoleenabled;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

       // public override void Write(char value)
      //  {
       //     base.Write(value);
      //      _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
     //   }
     
     //updated to be thread safe
     
     public override void Write(char value) {
     	
     	
     	if (consoleenabled == true) {
     	
MethodInvoker action = delegate { _output.AppendText(value.ToString()); };
_output.BeginInvoke(action);
}
     
     }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
