using System;
using System.Collections.Generic;
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
        #region --------------------------------------------------- Attributes
        private UserSettings mus;
        private Form1 parent;
        #endregion ------------------------------------------------ Attributes

        #region --------------------------------------------------- Methods
        public SettingsForm(Form1 parent)
        {
            this.parent = parent;
            mus = parent.mus;
            InitializeComponent();
            this.myInit();
        }

        private SdGraphicsBrush getSelectedBrush()
        {
            string name = comboBoxBrushes.SelectedItem.ToString();
            SdGraphicsBrush sdGraphicsBrush = mus.SdGraphicBrushes.Where(f => f.Key.Equals(name)).FirstOrDefault().Value;
            return sdGraphicsBrush;
        }

        private SdGraphicsPen getSelectedPen()
        {
            string name = comboBoxPens.SelectedItem.ToString();
            SdGraphicsPen sdGraphicsPen = mus.SdGraphicPens.Where(f => f.Key.Equals(name)).FirstOrDefault().Value;
            return sdGraphicsPen;
        }

        private void myInit()
        {
            checkBoxBreakLines.Checked = mus.BreakLines;
            checkBoxPageHeaders.Checked = mus.PageHeaders;
            numericUpDownBlankSpace.Value = (decimal)mus.BlankSpace;
            numericUpDownCopyrightYear.Value = (decimal)mus.CopyrightYear;
            numericUpDownDancerSize.Value = (decimal)mus.DancerSize;
            numericUpDownLineHeight.Value = (decimal)this.mus.LineHeight;
            numericUpDownMarginBottom.Value = (decimal)mus.MarginBottom;
            numericUpDownMarginTop.Value = (decimal)mus.MarginTop;
            numericUpDownMaxLineLength.Value = (decimal)mus.MaxLineLength;
            numericUpDownNoseSize.Value = (decimal)mus.NoseSize;
            textBoxCopyrightName.Text = mus.CopyrightName;

            foreach (KeyValuePair<string, SdGraphicsPen> kvp in mus.SdGraphicPens) {
                comboBoxPens.Items.Add(kvp.Value.Name);
            }
            comboBoxPens.SelectedItem = comboBoxPens.Items[0];// mus.SdGraphicPens.First().Value.Name;
            
            // Solid is checked by default
            SdGraphicsPen sdGraphicsPen = getSelectedPen();
            radioButtonDashedPen.Checked = sdGraphicsPen.Pen.DashStyle == DashStyle.Dash;

            foreach (KeyValuePair<string, SdGraphicsBrush> kvp in mus.SdGraphicBrushes) {
                comboBoxBrushes.Items.Add(kvp.Value.Name);
            }
            comboBoxBrushes.SelectedItem = comboBoxBrushes.Items[0];
            textBoxPageWidth.Text = mus.PageSize.Width.ToString();
            textBoxPageHeight.Text = mus.PageSize.Height.ToString();
        }
        private String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }

        private void updatePageSize()
        {
            int w = Convert.ToInt32(textBoxPageWidth.Text);
            int h = Convert.ToInt32(textBoxPageHeight.Text);
            mus.PageSize = new SettingsValues.SizeStruct(w, h);
        }

        #endregion ------------------------------------------------ Methods

        #region --------------------------------------------------- Event handlers
        private void buttonBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                textBoxBrushColor.BackColor = colorDialog1.Color;
                SdGraphicsBrush sdGraphicsBrush = getSelectedBrush();
                sdGraphicsBrush.setColor(colorDialog1.Color);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.mus.Save();
            this.Close();
        }

        private void buttonPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                textBoxPenColor.BackColor = colorDialog1.Color;
                SdGraphicsPen sdGraphicsPen = getSelectedPen();
                //  SdGraphicsPen pen = mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
                sdGraphicsPen.setColor(colorDialog1.Color);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "This is a permanent reset. You will lose all changes. Do you wish to continue?",
                "Warning",
                MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes)) {
                mus.MyReset();
                mus.Reload();
                myInit();
            }
        }

        private void checkBoxBreakLines_CheckedChanged(object sender, EventArgs e)
        {
            this.mus.BreakLines = checkBoxBreakLines.Checked;
        }

        private void comboBoxBrushes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SdGraphicsBrush sdGraphicsBrush = getSelectedBrush();
            String hexColor = sdGraphicsBrush.getHexColor();
            textBoxBrushColor.BackColor = sdGraphicsBrush.Brush.Color;
            // Currently only solid bruses are allowed
            if (sdGraphicsBrush.FillType.Equals("Solid")) {
                radioButtonSolidBrush.Checked = true;
            } else {
                radioButtonSolidBrush.Checked = false;
            }

        }

        private void comboBoxPens_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SdGraphicsPen sdGraphicsPen = mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            SdGraphicsPen sdGraphicsPen = getSelectedPen();
            String hexColor = sdGraphicsPen.getHexColor();
            textBoxPenColor.BackColor = sdGraphicsPen.Pen.Color;
            numericUpDownThickness.Value = (Decimal)sdGraphicsPen.Pen.Width;
            if (sdGraphicsPen.Pen.DashStyle.Equals(DashStyle.Dash)) {
                radioButtonDashedPen.Checked = true;
            } else {
                radioButtonSolidPen.Checked = true;
            }
        }

        private void numericUpDownBlankSpace_ValueChanged(object sender, EventArgs e)
        {
            this.mus.BlankSpace = (int)numericUpDownBlankSpace.Value;
        }

        private void numericUpDownCopyrightYear_ValueChanged(object sender, EventArgs e)
        {
            this.mus.CopyrightYear = (int)numericUpDownCopyrightYear.Value;
        }

        private void numericUpDownDancerSize_ValueChanged(object sender, EventArgs e)
        {
            this.mus.DancerSize = (int)numericUpDownDancerSize.Value;
        }

        private void numericUpDownLineHeight_ValueChanged(object sender, EventArgs e)
        {
            this.mus.LineHeight = (int)numericUpDownLineHeight.Value;
        }
        private void numericUpDownMarginBottom_ValueChanged(object sender, EventArgs e)
        {
            this.mus.MarginBottom = (int)numericUpDownMarginBottom.Value;
        }

        private void numericUpDownMarginTop_ValueChanged(object sender, EventArgs e)
        {
            this.mus.MarginTop = (int)numericUpDownMarginTop.Value;
        }

        private void numericUpDownMaxLineLength_ValueChanged(object sender, EventArgs e)
        {
            this.mus.MaxLineLength = (int)numericUpDownMaxLineLength.Value;
        }
        private void numericUpDownNoseSize_ValueChanged(object sender, EventArgs e)
        {
            this.mus.NoseSize = (int)numericUpDownNoseSize.Value;
        }
        private void numericUpDownThickness_ValueChanged(object sender, EventArgs e)
        {
            SdGraphicsPen sdGraphicsPen = getSelectedPen();
            //            SdGraphicsPen pen = mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            sdGraphicsPen.Pen.Width = (float)numericUpDownThickness.Value;

        }

        private void radioButtonSolid_CheckedChanged(object sender, EventArgs e)
        {
            //SdGraphicsPen pen = mus.SdGraphicPens.Where(f => f.Name.Equals(comboBoxPens.SelectedItem)).FirstOrDefault();
            SdGraphicsPen sdGraphicsPen = getSelectedPen();
            //String style = radioButtonDashed.Checked ? (String) radioButtonDashed.Tag : (String) radioButtonSolid.Tag;
            //setLineStyleForPen(pen, style);
            sdGraphicsPen.Pen.DashStyle = radioButtonDashedPen.Checked ? DashStyle.Dash : DashStyle.Solid;

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxCopyrightName_TextChanged(object sender, EventArgs e)
        {
            this.mus.CopyrightName = textBoxCopyrightName.Text;
        }
        private void textBoxPageHeight_TextChanged(object sender, EventArgs e)
        {
            updatePageSize();
        }

        private void textBoxPageWidth_TextChanged(object sender, EventArgs e)
        {
            updatePageSize();
        }
        #endregion ------------------------------------------------ Event handlers

        private void radioButtonDashedPen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPageHeaders_CheckedChanged(object sender, EventArgs e)
        {
            this.mus.PageHeaders = checkBoxPageHeaders.Checked;
        }
    }
}
