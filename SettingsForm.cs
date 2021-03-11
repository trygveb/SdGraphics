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
            this.myInit();
        }

        private void myInit()
        {
            checkBoxBreakLines.Checked = parent.mus.Breaklines;
            numericUpDownBlankSpace.Value = (decimal)parent.mus.BlankSpace;
            numericUpDownCopyrightYear.Value = (decimal)parent.mus.Copyrightyear;
            numericUpDownDancerSize.Value = (decimal)parent.mus.DancerSize;
            numericUpDownLineHeight.Value = (decimal)this.parent.mus.LineHeight;
            numericUpDownMarginBottom.Value = (decimal)parent.mus.MarginBottom;
            numericUpDownMarginTop.Value = (decimal)parent.mus.Margintop;
            numericUpDownMaxLineLength.Value = (decimal)parent.mus.MaxLineLenght;
            numericUpDownNoseSize.Value = (decimal)parent.mus.NoseSize;
            textBoxCopyrightName.Text = parent.mus.Copyrightname;
            textBoxBaseFolder.Text = parent.mus.BaseFolder;

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

        private void numericUpDownMarginBottom_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.MarginBottom = (int) numericUpDownMarginBottom.Value;
        }

        private void numericUpDownMaxLineLength_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.MaxLineLenght = (int) numericUpDownMaxLineLength.Value;
        }

        private void numericUpDownDancerSize_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.DancerSize = (int) numericUpDownDancerSize.Value;
        }

        private void numericUpDownNoseSize_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.NoseSize = (int) numericUpDownNoseSize.Value;
        }

        private void numericUpDownMarginTop_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.Margintop = (int) numericUpDownMarginTop.Value;
        }

        private void numericUpDownCopyrightYear_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.Copyrightyear = (int) numericUpDownCopyrightYear.Value;
        }

        private void textBoxCopyrightName_TextChanged(object sender, EventArgs e)
        {
            this.parent.mus.Copyrightname = textBoxCopyrightName.Text;
        }

        private void checkBoxBreakLines_CheckedChanged(object sender, EventArgs e)
        {
            this.parent.mus.Breaklines = checkBoxBreakLines.Checked;
        }

        private void buttonChangeFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK) {
                textBoxBaseFolder.Text = folderDlg.SelectedPath;
                this.parent.mus.BaseFolder = textBoxBaseFolder.Text;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
