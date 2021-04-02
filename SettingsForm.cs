using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            foreach (SdGraphicsPen sdGraphicPen in parent.MySdGraphicPens) {
                comboBoxPens.Items.Add(sdGraphicPen.Name);
            }
            comboBoxPens.SelectedItem = parent.MySdGraphicPens[0].Name;
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
                textBoxColor.BackColor = colorDialog1.Color;

                SdGraphicsPen pen = parent.MySdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
                pen.setColor(colorDialog1.Color);
            }
        }

        private void comboBoxPens_SelectedIndexChanged(object sender, EventArgs e)
        {
//            Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            SdGraphicsPen sdGraphicsPen = parent.MySdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            String hexColor = sdGraphicsPen.getHexColor();
            //            String hexColor = getUserSettingsPen(pen).Substring(0, 7);
            // String thickness = getUserSettingsPen(pen).Substring(8, 1);
            //textBoxColor.BackColor = ColorTranslator.FromHtml(hexColor);
            textBoxColor.BackColor = sdGraphicsPen.Pen.Color;
            numericUpDownThickness.Value = (Decimal) sdGraphicsPen.Pen.Width;
            if (sdGraphicsPen.Pen.DashStyle.Equals(DashStyle.Dash)) {
                radioButtonDashed.Checked = true;
            } else {
                radioButtonSolid.Checked = true;
            }
        }
        //private void setColorForPen(Form1.SdPen pen, Color color)
        //{

        //    //#AABBCC;1;dotted
        //    switch (pen.Name) {
        //        case "PhantomPen":
        //            parent.mus.PhantomPen = replaceColor(parent.mus.PhantomPen, color);
        //            break;
        //        case "CallerPen":
        //            parent.mus.CallerPen = replaceColor(parent.mus.CallerPen, color);
        //            break;
        //        case "DancerPen":
        //            parent.mus.DancerPen = replaceColor(parent.mus.DancerPen, color);
        //            break;
        //        case "DancerNosePen":
        //            parent.mus.DancerNosePen = replaceColor(parent.mus.DancerNosePen, color);
        //            break;
        //        case "CalleNosePen":
        //            parent.mus.CalleNosePen = replaceColor(parent.mus.CalleNosePen, color);
        //            break;
        //        default:
        //            break;
        //    }

        //}
        private void setLineStyleForPen(Form1.SdPen pen, String style)
        {

            //#AABBCC;1;dotted
            switch (pen.Name) {
                case "PhantomPen":
                    parent.mus.PhantomPen = replaceLineStyle(parent.mus.PhantomPen, style);
                    break;
                case "CallerPen":
                    parent.mus.CallerPen = replaceLineStyle(parent.mus.CallerPen, style);
                    break;
                case "DancerPen":
                    parent.mus.DancerPen = replaceLineStyle(parent.mus.DancerPen, style);
                    break;
                case "DancerNosePen":
                    parent.mus.DancerNosePen = replaceLineStyle(parent.mus.DancerNosePen, style);
                    break;
                case "CalleNosePen":
                    parent.mus.CalleNosePen = replaceLineStyle(parent.mus.CalleNosePen, style);
                    break;
                default:
                    break;
            }

        }

        private void setThicknessForPen(Form1.SdPen pen, String thickness)
        {

            //#AABBCC;1;dotted
            switch (pen.Name) {
                case "PhantomPen":
                    parent.mus.PhantomPen = replaceThickness(parent.mus.PhantomPen, thickness);
                    break;
                case "CallerPen":
                    parent.mus.CallerPen = replaceThickness(parent.mus.CallerPen, thickness);
                    break;
                case "DancerPen":
                    parent.mus.DancerPen = replaceThickness(parent.mus.DancerPen, thickness);
                    break;
                case "DancerNosePen":
                    parent.mus.DancerNosePen = replaceThickness(parent.mus.DancerNosePen, thickness);
                    break;
                case "CalleNosePen":
                    parent.mus.CalleNosePen = replaceThickness(parent.mus.CalleNosePen, thickness);
                    break;
                default:
                    break;
            }

        }
        private String replaceColor(String pen, Color color)
        {
            String x = String.Format("{0};{1};{2}",
                this.toHex(color),
                pen.Substring(8, 1),
                pen.Substring(10));
            return x;
        }
        private String replaceLineStyle(String pen, String lineStyle)
        {
            String x = String.Format("{0};{1};{2}",
               pen.Substring(0, 7),
               pen.Substring(8, 1),
               lineStyle);
            return x;
        }
        private String replaceThickness(String pen, String thickness)
        {
            String x = String.Format("{0};{1};{2}",
               pen.Substring(0, 7),
               thickness,
               pen.Substring(10));
            return x;
        }
        private String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pen"></param>
        /// <returns>The (serialized) string representation of a pen</returns>
        private String getUserSettingsPen(Form1.SdPen pen)
        {
            String retVal = "";
            switch (pen.Name) {
                case "PhantomPen":
                    retVal = parent.mus.PhantomPen;
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
                    retVal = "";
                    break;
            }
            return retVal;
        }

        private void numericUpDownThickness_ValueChanged(object sender, EventArgs e)
        {
            Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            setThicknessForPen(pen, numericUpDownThickness.Value.ToString());

        }

        private void radioButtonSolid_CheckedChanged(object sender, EventArgs e)
        {
            Form1.SdPen pen = parent.MySdPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            String style = radioButtonDashed.Checked ? (String) radioButtonDashed.Tag : (String) radioButtonSolid.Tag;
            setLineStyleForPen(pen, style);

        }
    }
}
