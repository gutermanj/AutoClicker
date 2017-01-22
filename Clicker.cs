using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Teboscreen
{

    public static class MyGlobals
    {
        public static Rectangle newRectangle { get; set; }

    }

    class Clicker
    {



        private static System.Timers.Timer aTimer;

        public static void ClickData(Rectangle SelectionRectangle, string Command)
        {
            Console.WriteLine("Selection Rectangle: " + SelectionRectangle);


            if (Command == "potato")
            {



                if (MessageBox.Show("Press ALT + TAB to focus the AutoClicker, then CTRL + F to stop the program \nClick OK to begin!", "Confirm", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                {

                    MyGlobals.newRectangle = SelectionRectangle;

                    // Create a timer with a ten second interval.
                    aTimer = new System.Timers.Timer(2000);

                    // Hook up the Elapsed event for the timer.
                    aTimer.Elapsed += new System.Timers.ElapsedEventHandler(StartIt);

                    Random r = new Random();
                    int rInt = r.Next(1000, 3000);
                    Console.WriteLine(rInt);

                    // Set the Interval to 2 seconds (2000 milliseconds).
                    aTimer.Interval = rInt;
                    aTimer.Enabled = true;

                }

            }
            else if (Command == "tomato")
            {
                aTimer.Stop();
                aTimer.Dispose();
                MessageBox.Show("Stopped!");
            }
        }



        public static void StartIt(object Potato, EventArgs e)
        {
            Random r = new Random();
            int rSleep = r.Next(150, 1500);
            Console.WriteLine(rSleep);


            System.Threading.Thread.Sleep(rSleep);

            int RandomXCoor = r.Next(MyGlobals.newRectangle.X, MyGlobals.newRectangle.X + MyGlobals.newRectangle.Width);

            int RandomYCoor = r.Next(MyGlobals.newRectangle.Y, MyGlobals.newRectangle.Y + MyGlobals.newRectangle.Height);

            LeftMouseClick(RandomXCoor, RandomYCoor);
        }



        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);

        }

    }


}