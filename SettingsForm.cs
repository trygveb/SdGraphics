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
            foreach (Form1.SdPen sdPen in parent.MySdPens) {
                comboBoxPens.Items.Add(sdPen.Name);
            }
            comboBoxPens.SelectedItem = parent.MySdPens[0].Name;
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
            this.parent.mus.LineHeight = (int)numericUpDownLineHeight.Value;
        }

        private void numericUpDownBlankSpace_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.BlankSpace = (int)numericUpDownBlankSpace.Value;
        }

        private void numericUpDownMarginBottom_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.MarginBottom = (int)numericUpDownMarginBottom.Value;
        }

        private void numericUpDownMaxLineLength_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.MaxLineLenght = (int)numericUpDownMaxLineLength.Value;
        }

        private void numericUpDownDancerSize_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.DancerSize = (int)numericUpDownDancerSize.Value;
        }

        private void numericUpDownNoseSize_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.NoseSize = (int)numericUpDownNoseSize.Value;
        }

        private void numericUpDownMarginTop_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.Margintop = (int)numericUpDownMarginTop.Value;
        }

        private void numericUpDownCopyrightYear_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.Copyrightyear = (int)numericUpDownCopyrightYear.Value;
        }

        private void textBoxCopyrightName_TextChanged(object sender, EventArgs e)
        {
            this.parent.mus.Copyrightname = textBoxCopyrightName.Text;
        }

        private void checkBoxBreakLines_CheckedChanged(object sender, EventArgs e)
        {
            this.parent.mus.Breaklines = checkBoxBreakLines.Checked;
        }



        private void buttonPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                textBoxColor.BackColor = colorDialog1.Color;

                Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
                setColorForPen(pen, colorDialog1.Color);
            }
        }

        private void comboBoxPens_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            String hexColor = getUserSettingsPen(pen).Substring(0, 7);
            textBoxColor.BackColor = ColorTranslator.FromHtml(hexColor);
         }
        private void setColorForPen(Form1.SdPen pen, Color color)
        {
            
            //#AABBCC;1;dotted
            switch (pen.Name) {
                case "PhantomPen":
                    parent.mus.PhantomPen = replaceColor(parent.mus.PhantomPen, color);
                    break;
                case "CallerPen":
                    parent.mus.CallerPen = replaceColor(parent.mus.CallerPen, color);
                    break;
                case "DancerPen":
                    parent.mus.DancerPen = replaceColor(parent.mus.DancerPen, color);
                    break;
                case "DancerNosePen":
                    parent.mus.DancerNosePen = replaceColor(parent.mus.DancerNosePen, color);
                    break;
                case "CalleNosePen":
                    parent.mus.CalleNosePen = replaceColor(parent.mus.CalleNosePen, color);
                    break;
                default:
                    break;
            }

        }
        private String replaceColor(String pen, Color color)
        {
            String x= String.Format("{0};{1};{2}",
                this.toHex(color),
                pen.Substring(8, 1),
                pen.Substring(10));
            return x;
        }
        private String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }
        private String getUserSettingsPen(Form1.SdPen pen)
        {
            String retVal = "";
            switch (pen.Name) {
                case "PhantomPen":
                    retVal= parent.mus.PhantomPen;
                    break;
                case "CallerPen":
                    retVal = parent.mus.CallerPen;
                    break;
                case "DancerPen":
                    retVal = parent.mus.DancerPen;
                    break;
                case "DancerNosePen":
                    retVal = parent.mus.DancerNosePen;
                    break;
                case "CalleNosePen":
                    retVal = parent.mus.CalleNosePen;
                    break;
                default:
                    retVal= "";
                    break;
            }
            return retVal;
        }
    }
}
