using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TinyChat_Client
{
    internal static class Utils
    {
        internal enum SoundType
        {
            NewClient,
            NewMsg,
            NewMsgPow,
            Exit
        }


        //this function saves the chat history as an HTML file
        internal static void SaveAsHTML(string fileName, string[] lines, string titleString)
        {
            string htmlString = "<HTML>" + Environment.NewLine;
            string dateTime = "( " + DateTime.Now.ToLongTimeString() + " )";
            //generate the header for the HTML file
            htmlString += "<meta charset=utf-8/>" + Environment.NewLine;
            htmlString += "<Title>" + titleString + "</Title>" + Environment.NewLine;
            htmlString += "<link rel='stylesheet' href='Files/Styles.css' type='Text/Css'" + Environment.NewLine;
            htmlString += "<Body>" + Environment.NewLine;
            htmlString += "<Table align='center'><TR><TD class='Header'>" + titleString + "</TD><TD class='Header'>" +
                           dateTime + "</TD><TD><IMG src='Files/face.gif'/></TD></TR></Table><HR width='60%'>";
            htmlString += Environment.NewLine + "<Table>";

            //convert the messages to the html file
            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    htmlString += "<TR><TD><IMG src='Files/arrow.gif'/></TD><TD>" + line +
                                  "</TD></TR>" + Environment.NewLine;
                }
            }

            htmlString += "</Table>";
            htmlString += Environment.NewLine + "</Body></HTML>";

            string dirName = fileName.Substring(0, fileName.LastIndexOf('\\'));

            //create resource manager and load resources into files
            Directory.CreateDirectory(dirName + "\\Files");
            Resourcer rm = new Resourcer(LoadMethod.CallingCode);

            rm.ExtractAndSave("face.gif", dirName + "\\Files\\face.gif");
            rm.ExtractAndSave("arrow.gif", dirName + "\\Files\\arrow.gif");
            rm.ExtractAndSave("Styles.css", dirName + "\\Files\\Styles.css");

            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(htmlString);
            sw.Flush();
            sw.Close();
            
        }

        //play a sound for the client
        internal static void PlaySound(SoundType type)
        {
            //create resource manager to handle the files
            Resourcer rm = new Resourcer(LoadMethod.CallingCode);

            System.Media.SoundPlayer sound = new System.Media.SoundPlayer();

            switch(type)
            {
                case (SoundType.NewClient):
                    sound.Stream = rm.GetResourceStream("Knock.wav");
                    sound.Play();
                    break;
                case (SoundType.Exit):
                    sound.Stream = rm.GetResourceStream("Door.wav");
                    sound.Play();
                    break;
                case (SoundType.NewMsg):
                    sound.Stream = rm.GetResourceStream("Message.wav");
                    sound.Play();
                    break;
                case (SoundType.NewMsgPow):
                    sound.Stream = rm.GetResourceStream("Pow.wav");
                    sound.Play();
                    break;
            }
        }

        //detects keys that are valid for read only fields (so basically no letter, number or symbol keys)
        internal static bool IsValidKeyForReadOnlyFields(Keys k)
        {
            switch (k)
            {
                case (Keys.Up):
                case (Keys.Down):
                case (Keys.Left):
                case (Keys.Right):
                case (Keys.PageUp):
                case (Keys.PageDown):
                case (Keys.F1):
                case (Keys.F2):
                case (Keys.F3):
                case (Keys.F4):
                case (Keys.F5):
                case (Keys.F6):
                case (Keys.F7):
                case (Keys.F8):
                case (Keys.F9):
                case (Keys.F10):
                case (Keys.F11):
                case (Keys.F12):
                case (Keys.F13):
                case (Keys.F14):
                case (Keys.F15):
                case (Keys.F16):
                case (Keys.F17):
                case (Keys.F18):
                case (Keys.F19):
                case (Keys.F20):
                case (Keys.F21):
                case (Keys.F22):
                case (Keys.F23):
                case (Keys.F24):
                case (Keys.Shift):
                case (Keys.ShiftKey):
                case (Keys.Control):
                case (Keys.ControlKey):
                case (Keys.CapsLock):
                case (Keys.Scroll):
                case (Keys.Alt):
                case (Keys.Apps):
                case (Keys.End):
                case (Keys.Escape):
                case (Keys.Help):
                case (Keys.Home):
                case (Keys.Insert):
                case (Keys.LButton):
                case (Keys.LControlKey):
                case (Keys.LMenu):
                case (Keys.MButton):
                case (Keys.Menu):
                case (Keys.VolumeDown):
                case (Keys.VolumeMute):
                case (Keys.VolumeUp):
                case (Keys.XButton1):
                case (Keys.XButton2):
                case (Keys.Zoom):
                    return true;
                default:
                    return false;
            }
        }
    }
}
