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
        private Form1 parent;

        public SettingsForm(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void myInit()
        {
            numericUpDownLineHeight.Value = (decimal)this.parent.mus.LineHeight;
            numericUpDownBlankSpace.Value = (decimal) parent.mus.BlankSpace;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.parent.mus.Save();
            this.Close();
        }

        private void numericUpDownLineHeight_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.LineHeight= (int) numericUpDownLineHeight.Value;
        }

        private void numericUpDownBlankSpace_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.BlankSpace = (int) numericUpDownBlankSpace.Value;
        }
    }
}
