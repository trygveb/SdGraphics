using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SdGraphics
{
    public partial class SettingsForm : Form
    {
        public static SdGraphics.SettingsStruct MySettings;
        private SdGraphics.SettingsStruct settingsIn;
        public SettingsForm(SdGraphics.SettingsStruct settingsIn)
        {
            InitializeComponent();
            MySettings = settingsIn;
            this.settingsIn = MySettings;
        }

        private void myInit()
        {
            numericUpDownLineHeight.Value = (decimal)this.settingsIn.lineHeight;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MySettings = this.settingsIn;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownLineHeight_ValueChanged(object sender, EventArgs e)
        {
            MySettings.lineHeight= (int) numericUpDownLineHeight.Value;
        }
    }
}
