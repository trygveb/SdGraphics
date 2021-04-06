using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
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
            checkBoxBreakLines.Checked = parent.mus.BreakLines;
            numericUpDownBlankSpace.Value = (decimal)parent.mus.BlankSpace;
            numericUpDownCopyrightYear.Value = (decimal)parent.mus.CopyrightYear;
            numericUpDownDancerSize.Value = (decimal)parent.mus.DancerSize;
            numericUpDownLineHeight.Value = (decimal)this.parent.mus.LineHeight;
            numericUpDownMarginBottom.Value = (decimal)parent.mus.MarginBottom;
            numericUpDownMarginTop.Value = (decimal)parent.mus.MarginTop;
            numericUpDownMaxLineLength.Value = (decimal)parent.mus.MaxLineLength;
            numericUpDownNoseSize.Value = (decimal)parent.mus.NoseSize;
            textBoxCopyrightName.Text = parent.mus.CopyrightName;
            foreach (SdGraphicsPen sdGraphicPen in parent.mus.SdGraphicPens) {
                comboBoxPens.Items.Add(sdGraphicPen.Name);
            }
            comboBoxPens.SelectedItem = parent.mus.SdGraphicPens[0].Name;

            foreach (SdGraphicsBrush sdGraphicBrush in parent.mus.SdGraphicBrushes) {
                comboBoxBrushes.Items.Add(sdGraphicBrush.Name);
            }
            comboBoxBrushes.SelectedItem = parent.mus.SdGraphicBrushes[0].Name;
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
            this.parent.mus.MaxLineLength = (int)numericUpDownMaxLineLength.Value;
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
            this.parent.mus.MarginTop = (int)numericUpDownMarginTop.Value;
        }

        private void numericUpDownCopyrightYear_ValueChanged(object sender, EventArgs e)
        {
            this.parent.mus.CopyrightYear = (int)numericUpDownCopyrightYear.Value;
        }

        private void textBoxCopyrightName_TextChanged(object sender, EventArgs e)
        {
            this.parent.mus.CopyrightName = textBoxCopyrightName.Text;
        }

        private void checkBoxBreakLines_CheckedChanged(object sender, EventArgs e)
        {
            this.parent.mus.BreakLines = checkBoxBreakLines.Checked;
        }



        private void buttonPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                textBoxPenColor.BackColor = colorDialog1.Color;
                SdGraphicsPen pen = parent.mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
                pen.setColor(colorDialog1.Color);
            }
        }

        private void comboBoxPens_SelectedIndexChanged(object sender, EventArgs e)
        {
            SdGraphicsPen sdGraphicsPen = parent.mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            String hexColor = sdGraphicsPen.getHexColor();
            textBoxPenColor.BackColor = sdGraphicsPen.Pen.Color;
            numericUpDownThickness.Value = (Decimal) sdGraphicsPen.Pen.Width;
            if (sdGraphicsPen.Pen.DashStyle.Equals(DashStyle.Dash)) {
                radioButtonDashed.Checked = true;
            } else {
                radioButtonSolid.Checked = true;
            }
        }

        //}
        //private String replaceColor(String pen, Color color)
        //{
        //    String x = String.Format("{0};{1};{2}",
        //        this.toHex(color),
        //        pen.Substring(8, 1),
        //        pen.Substring(10));
        //    return x;
        //}
        private String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }

        private void numericUpDownThickness_ValueChanged(object sender, EventArgs e)
        {
            SdGraphicsPen pen = parent.mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
//            Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            pen.Pen.Width= (float)numericUpDownThickness.Value;

        }

        private void radioButtonSolid_CheckedChanged(object sender, EventArgs e)
        {
            SdGraphicsPen pen = parent.mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            //String style = radioButtonDashed.Checked ? (String) radioButtonDashed.Tag : (String) radioButtonSolid.Tag;
            //setLineStyleForPen(pen, style);
            pen.Pen.DashStyle= radioButtonDashed.Checked ? DashStyle.Dash:DashStyle.Solid;

        }

        private void comboBoxBrushes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SdGraphicsBrush sdGraphicsBrush = parent.mus.SdGraphicBrushes.Where(f => f.Name.Equals(comboBoxBrushes.SelectedItem)).FirstOrDefault();
            String hexColor = sdGraphicsBrush.getHexColor();
            textBoxBrushColor.BackColor = sdGraphicsBrush.Brush.Color;
            // Currently onlu solid bruses are allowed
            if (sdGraphicsBrush.FillType.Equals("Solid")) {
                radioButtonSolidBrush.Checked = true;
            } else {
                radioButtonSolidBrush.Checked = false;
            }

        }

        private void buttonBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                textBoxBrushColor.BackColor = colorDialog1.Color;
                SdGraphicsBrush brush = parent.mus.SdGraphicBrushes.Where(f => f.Name.Equals(comboBoxBrushes.SelectedItem)).FirstOrDefault();
                brush.setColor(colorDialog1.Color);
            }
        }
    }
}
