using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Teboscreen
{

    public partial class ControlPanel : Form
    {

        string ScreenPath;
        private static bool TipsShowing;

        private Form m_InstanceRef = null;
        public Form InstanceRef
        {

            get
            {

                return m_InstanceRef;

            }
            set
            {

                m_InstanceRef = value;

            }

        }

        public ControlPanel()
        {

            InitializeComponent();

            this.Hide();

            MessageBox.Show("Thank you for choosing AutoClicker v0.0.1 \n How to use: \n\n - Place the item on the same inventory spot as the high alchemy spell \n\n - Select the 'Capure Area' button \n\n - Drag the capture area around the desired item \n\n - Double-click anywhere on the screen to save the capture area \n\n - AutoClicker randomly selects a pixel to click on within the dimensions selected, avoiding bot detection, enjoy!", "AutoClicker v0.0.1", MessageBoxButtons.OK);


        }

        public ControlPanel(bool Save)
        {

            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form_Close);

        }

        public void key_press(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }


        private void keyTest(KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "S")
            {

                screenCapture(true);

            }

        }


        private void Form_Close(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }

        private void bttCaptureArea_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form1 = new Form1();
            form1.InstanceRef = this;
            form1.Show();

            bttCaptureArea.Enabled = false;


        }

        public void screenCapture(bool showCursor)
        {

            Point curPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            Size curSize = new Size();
            curSize.Height = Cursor.Current.Size.Height;
            curSize.Width = Cursor.Current.Size.Width;

            ScreenPath = "";

            if (!ScreenShot.saveToClipboard)
            {

                saveFileDialog1.DefaultExt = "bmp";
                saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|png files (*.png)|*.png";
                saveFileDialog1.Title = "Save screenshot to...";
                saveFileDialog1.ShowDialog();
                ScreenPath = saveFileDialog1.FileName;

            }

            

            if (ScreenPath!=""||ScreenShot.saveToClipboard)
            {

                //Conceal this form while the screen capture takes place
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.TopMost = false;

                //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
                System.Threading.Thread.Sleep(250);

                Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                string fi = "";

                if (ScreenPath != "")
                {

                    fi = new FileInfo(ScreenPath).Extension;

                }

                ScreenShot.CaptureImage(showCursor, curSize, curPos, Point.Empty, Point.Empty, bounds, ScreenPath, fi);

                //The screen has been captured and saved to a file so bring this form back into the foreground
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.TopMost = true;

                if (ScreenShot.saveToClipboard)
                {

                    MessageBox.Show("Screen saved to clipboard", "AutoClicker v0.0.1", MessageBoxButtons.OK);
                    


                }
                else
                {

                    MessageBox.Show("Screen saved to file", "AutoClicker v0.0.1", MessageBoxButtons.OK);

                }


            }


        }

        private void bttCaptureScreen_Click(object sender, EventArgs e)
        {

            screenCapture(false);

        }

        private void bttTips_Click(object sender, EventArgs e)
        {
            if (TipsShowing)
            {

                TipsShowing = false;
                ControlPanel.ActiveForm.Width = 500;

            }
            else
            {

                TipsShowing = true;
                ControlPanel.ActiveForm.Width = 385;

            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {

            this.KeyUp += new KeyEventHandler(key_press);

            System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
            Byte[] buffer = new byte[] { (byte)149 };
            string bullet = System.Text.Encoding.GetEncoding(1252).GetString(buffer);

            TipsShowing = false;
            this.Width = 400;

        }

        /*
        private void saveToClipboard_CheckedChanged(object sender, EventArgs e)
        {

            ScreenShot.saveToClipboard = saveToClipboard.Checked;
            
        }
        */

        private void saveToClipboard_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttCaptureArea_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttTips_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void bttCaptureScreen_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void txtTips_KeyUp(object sender, KeyEventArgs e)
        {

            keyTest(e);

        }

        private void txtTips_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void current_click_counter_Click(object sender, EventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Rectangle NullRectangle = new Rectangle(0, 0, 0 ,0);

            if (keyData == (Keys.Control | Keys.F))
            {
                Clicker.ClickData(NullRectangle, "tomato");
                bttCaptureArea.Enabled = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}