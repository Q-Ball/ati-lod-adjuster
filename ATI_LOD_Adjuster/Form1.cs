using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using Microsoft.Win32;

namespace ATI_LOD_Adjuster
{
    public partial class Form1 : Form
    {

        public static string ATIKeyPath = "";
        public static RegistryKey ATIVideoKey;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ATIVideoKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Video", true);

            // Check if 0000\UMD key exists in any of the HID keys
            foreach (string subkey0 in ATIVideoKey.GetSubKeyNames()) {
                RegistryKey UMDKey = ATIVideoKey.OpenSubKey(subkey0 + @"\0000\UMD", true);
                if (UMDKey != null) {
                    ATIKeyPath = subkey0 + @"\0000\UMD\";
                }
            }

            // Create LodAdj key if it does not exist
            var LodAdjCheck = (byte[])ATIVideoKey.OpenSubKey(ATIKeyPath).GetValue("LodAdj");
            if (LodAdjCheck == null) {
                MessageBox.Show("LodAdj key not found. Creating one with default value.");
                ATIVideoKey.CreateSubKey(ATIKeyPath).SetValue("LodAdj", new byte[] { 48, 0, 46, 0, 48, 0 }, RegistryValueKind.Binary);
            }

            //Read value of LodAdj and update elements on screen
            var LodAdjValue = BitConverter.ToString((byte[])ATIVideoKey.OpenSubKey(ATIKeyPath).GetValue("LodAdj"), 0);

            // Set label and trackbar values
            if (LodAdjValue == "2D-00-31-00-30-00-2E-00-30-00") { label1.Text = "-10"; trackBar1.Value = -10; }
            else if (LodAdjValue == "2D-00-39-00-2E-00-30-00") { label1.Text = "-9"; trackBar1.Value = -9; }
            else if (LodAdjValue == "2D-00-38-00-2E-00-30-00") { label1.Text = "-8"; trackBar1.Value = -8; }
            else if (LodAdjValue == "2D-00-37-00-2E-00-30-00") { label1.Text = "-7"; trackBar1.Value = -7; }
            else if (LodAdjValue == "2D-00-36-00-2E-00-30-00") { label1.Text = "-6"; trackBar1.Value = -6; }
            else if (LodAdjValue == "2D-00-35-00-2E-00-30-00") { label1.Text = "-5"; trackBar1.Value = -5; }
            else if (LodAdjValue == "2D-00-34-00-2E-00-30-00") { label1.Text = "-4"; trackBar1.Value = -4; }
            else if (LodAdjValue == "2D-00-33-00-2E-00-30-00") { label1.Text = "-3"; trackBar1.Value = -3; }
            else if (LodAdjValue == "2D-00-32-00-2E-00-30-00") { label1.Text = "-2"; trackBar1.Value = -2; }
            else if (LodAdjValue == "2D-00-31-00-2E-00-30-00") { label1.Text = "-1"; trackBar1.Value = -1; }
            else if (LodAdjValue == "31-00-2E-00-30-00") { label1.Text = "1"; trackBar1.Value = 1; }
            else if (LodAdjValue == "32-00-2E-00-30-00") { label1.Text = "2"; trackBar1.Value = 2; }
            else if (LodAdjValue == "33-00-2E-00-30-00") { label1.Text = "3"; trackBar1.Value = 3; }
            else if (LodAdjValue == "34-00-2E-00-30-00") { label1.Text = "4"; trackBar1.Value = 4; }
            else if (LodAdjValue == "35-00-2E-00-30-00") { label1.Text = "5"; trackBar1.Value = 5; }
            else if (LodAdjValue == "36-00-2E-00-30-00") { label1.Text = "6"; trackBar1.Value = 6; }
            else if (LodAdjValue == "37-00-2E-00-30-00") { label1.Text = "7"; trackBar1.Value = 7; }
            else if (LodAdjValue == "38-00-2E-00-30-00") { label1.Text = "8"; trackBar1.Value = 8; }
            else if (LodAdjValue == "39-00-2E-00-30-00") { label1.Text = "9"; trackBar1.Value = 9; }
            else if (LodAdjValue == "31-00-30-00-2E-00-30-00") { label1.Text = "10"; trackBar1.Value = 10; }
            else if (LodAdjValue == "30-00-2E-00-30-00") { label1.Text = "0"; trackBar1.Value = 0; }
            else { MessageBox.Show("Can't read LodAdj value."); }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
		    if (trackBar1.Value == -10) { label1.Text = "-10";}
		    else if (trackBar1.Value == -9) { label1.Text = "-9";}
		    else if (trackBar1.Value == -8) { label1.Text = "-8";}
		    else if (trackBar1.Value == -7) { label1.Text = "-7";}
		    else if (trackBar1.Value == -6) { label1.Text = "-6";}
		    else if (trackBar1.Value == -5) { label1.Text = "-5";}
		    else if (trackBar1.Value == -4) { label1.Text = "-4";}
		    else if (trackBar1.Value == -3) { label1.Text = "-3";}
		    else if (trackBar1.Value == -2) { label1.Text = "-2";}
		    else if (trackBar1.Value == -1) { label1.Text = "-1";}
		    else if (trackBar1.Value == 0) { label1.Text = "0";}
		    else if (trackBar1.Value == 1) { label1.Text = "1";}
		    else if (trackBar1.Value == 2) { label1.Text = "2";}
		    else if (trackBar1.Value == 3) { label1.Text = "3";}
		    else if (trackBar1.Value == 4) { label1.Text = "4";}
		    else if (trackBar1.Value == 5) { label1.Text = "5";}
		    else if (trackBar1.Value == 6) { label1.Text = "6";}
		    else if (trackBar1.Value == 7) { label1.Text = "7";}
		    else if (trackBar1.Value == 8) { label1.Text = "8";}
		    else if (trackBar1.Value == 9) { label1.Text = "9";}
		    else if (trackBar1.Value == 10) { label1.Text = "10";}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] LodAdjNewValue = {};
            if (trackBar1.Value == -10) { LodAdjNewValue = new byte[] {45,0,49,0,48,0,46,0,48,0}; }
            if (trackBar1.Value == -9) { LodAdjNewValue = new byte[] {45,0,57,0,46,0,48,0}; }
            if (trackBar1.Value == -8) { LodAdjNewValue = new byte[] {45,0,56,0,46,0,48,0}; }
            if (trackBar1.Value == -7) { LodAdjNewValue = new byte[] {45,0,55,0,46,0,48,0}; }
            if (trackBar1.Value == -6) { LodAdjNewValue = new byte[] {45,0,54,0,46,0,48,0}; }
            if (trackBar1.Value == -5) { LodAdjNewValue = new byte[] {45,0,53,0,46,0,48,0}; }
            if (trackBar1.Value == -4) { LodAdjNewValue = new byte[] {45,0,52,0,46,0,48,0}; }
            if (trackBar1.Value == -3) { LodAdjNewValue = new byte[] {45,0,51,0,46,0,48,0}; }
            if (trackBar1.Value == -2) { LodAdjNewValue = new byte[] {45,0,50,0,46,0,48,0}; }
            if (trackBar1.Value == -1) { LodAdjNewValue = new byte[] {45,0,49,0,46,0,48,0}; }
            if (trackBar1.Value == 0) { LodAdjNewValue = new byte[] {48,0,46,0,48,0}; }
            if (trackBar1.Value == 1) { LodAdjNewValue = new byte[] {49,0,46,0,48,0}; }
            if (trackBar1.Value == 2) { LodAdjNewValue = new byte[] {50,0,46,0,48,0}; }
            if (trackBar1.Value == 3) { LodAdjNewValue = new byte[] {51,0,46,0,48,0}; }
            if (trackBar1.Value == 4) { LodAdjNewValue = new byte[] {52,0,46,0,48,0}; }
            if (trackBar1.Value == 5) { LodAdjNewValue = new byte[] {53,0,46,0,48,0}; }
            if (trackBar1.Value == 6) { LodAdjNewValue = new byte[] {54,0,46,0,48,0}; }
            if (trackBar1.Value == 7) { LodAdjNewValue = new byte[] {55,0,46,0,48,0}; }
            if (trackBar1.Value == 8) { LodAdjNewValue = new byte[] {56,0,46,0,48,0}; }
            if (trackBar1.Value == 9) { LodAdjNewValue = new byte[] {57,0,46,0,48,0}; }
            if (trackBar1.Value == 10) { LodAdjNewValue = new byte[] {49,0,48,0,46,0,48,0}; }

            try {
                ATIVideoKey.CreateSubKey(ATIKeyPath).SetValue("LodAdj", LodAdjNewValue, RegistryValueKind.Binary);
                MessageBox.Show("LOD changed successfully");
            }
            catch (Exception ex) {
                MessageBox.Show("Error has occured! " + ex.Message);
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
//                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
