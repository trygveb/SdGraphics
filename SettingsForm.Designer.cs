
namespace SdGraphics
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLineHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDancersSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownCopyrightYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMarginTop = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCopyrightName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlankSpace = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxBreakLines = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownNoseSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxLineLength = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.label12);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Controls.Add(this.numericUpDownLineHeight);
            this.panelSettings.Controls.Add(this.numericUpDownDancersSize);
            this.panelSettings.Controls.Add(this.label7);
            this.panelSettings.Controls.Add(this.label9);
            this.panelSettings.Controls.Add(this.numericUpDownCopyrightYear);
            this.panelSettings.Controls.Add(this.numericUpDownMarginTop);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.textBoxCopyrightName);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.numericUpDownMarginBottom);
            this.panelSettings.Controls.Add(this.numericUpDownBlankSpace);
            this.panelSettings.Controls.Add(this.label8);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.label6);
            this.panelSettings.Controls.Add(this.checkBoxBreakLines);
            this.panelSettings.Controls.Add(this.label10);
            this.panelSettings.Controls.Add(this.numericUpDownNoseSize);
            this.panelSettings.Controls.Add(this.numericUpDownMaxLineLength);
            this.panelSettings.Location = new System.Drawing.Point(44, 12);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(377, 270);
            this.panelSettings.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dancer size";
            // 
            // numericUpDownLineHeight
            // 
            this.numericUpDownLineHeight.Location = new System.Drawing.Point(121, 44);
            this.numericUpDownLineHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownLineHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownLineHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLineHeight.Name = "numericUpDownLineHeight";
            this.numericUpDownLineHeight.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownLineHeight.TabIndex = 13;
            this.numericUpDownLineHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownLineHeight.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownLineHeight.ValueChanged += new System.EventHandler(this.numericUpDownLineHeight_ValueChanged);
            // 
            // numericUpDownDancersSize
            // 
            this.numericUpDownDancersSize.Location = new System.Drawing.Point(301, 44);
            this.numericUpDownDancersSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownDancersSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownDancersSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownDancersSize.Name = "numericUpDownDancersSize";
            this.numericUpDownDancersSize.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownDancersSize.TabIndex = 11;
            this.numericUpDownDancersSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDancersSize.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 232);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Copyright year";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 119);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Margin bottom";
            // 
            // numericUpDownCopyrightYear
            // 
            this.numericUpDownCopyrightYear.Location = new System.Drawing.Point(121, 226);
            this.numericUpDownCopyrightYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownCopyrightYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numericUpDownCopyrightYear.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.numericUpDownCopyrightYear.Name = "numericUpDownCopyrightYear";
            this.numericUpDownCopyrightYear.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownCopyrightYear.TabIndex = 22;
            this.numericUpDownCopyrightYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCopyrightYear.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // numericUpDownMarginTop
            // 
            this.numericUpDownMarginTop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMarginTop.Location = new System.Drawing.Point(301, 116);
            this.numericUpDownMarginTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownMarginTop.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownMarginTop.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMarginTop.Name = "numericUpDownMarginTop";
            this.numericUpDownMarginTop.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownMarginTop.TabIndex = 30;
            this.numericUpDownMarginTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMarginTop.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Line height";
            // 
            // textBoxCopyrightName
            // 
            this.textBoxCopyrightName.Location = new System.Drawing.Point(121, 191);
            this.textBoxCopyrightName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCopyrightName.Name = "textBoxCopyrightName";
            this.textBoxCopyrightName.Size = new System.Drawing.Size(210, 20);
            this.textBoxCopyrightName.TabIndex = 16;
            this.textBoxCopyrightName.Text = "Thomas Bernhed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Copyright name";
            // 
            // numericUpDownMarginBottom
            // 
            this.numericUpDownMarginBottom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMarginBottom.Location = new System.Drawing.Point(121, 116);
            this.numericUpDownMarginBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownMarginBottom.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownMarginBottom.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownMarginBottom.Name = "numericUpDownMarginBottom";
            this.numericUpDownMarginBottom.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownMarginBottom.TabIndex = 32;
            this.numericUpDownMarginBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMarginBottom.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownBlankSpace
            // 
            this.numericUpDownBlankSpace.Location = new System.Drawing.Point(121, 80);
            this.numericUpDownBlankSpace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownBlankSpace.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBlankSpace.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownBlankSpace.Name = "numericUpDownBlankSpace";
            this.numericUpDownBlankSpace.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownBlankSpace.TabIndex = 18;
            this.numericUpDownBlankSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownBlankSpace.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownBlankSpace.ValueChanged += new System.EventHandler(this.numericUpDownBlankSpace_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(203, 119);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Margin top";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Blank space";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Nose size";
            // 
            // checkBoxBreakLines
            // 
            this.checkBoxBreakLines.AutoSize = true;
            this.checkBoxBreakLines.Checked = true;
            this.checkBoxBreakLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBreakLines.Location = new System.Drawing.Point(207, 157);
            this.checkBoxBreakLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBreakLines.Name = "checkBoxBreakLines";
            this.checkBoxBreakLines.Size = new System.Drawing.Size(78, 17);
            this.checkBoxBreakLines.TabIndex = 35;
            this.checkBoxBreakLines.Text = "Break lines";
            this.checkBoxBreakLines.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 159);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Max line length";
            // 
            // numericUpDownNoseSize
            // 
            this.numericUpDownNoseSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNoseSize.Location = new System.Drawing.Point(301, 80);
            this.numericUpDownNoseSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownNoseSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNoseSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNoseSize.Name = "numericUpDownNoseSize";
            this.numericUpDownNoseSize.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownNoseSize.TabIndex = 20;
            this.numericUpDownNoseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNoseSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numericUpDownMaxLineLength
            // 
            this.numericUpDownMaxLineLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMaxLineLength.Location = new System.Drawing.Point(121, 156);
            this.numericUpDownMaxLineLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownMaxLineLength.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownMaxLineLength.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownMaxLineLength.Name = "numericUpDownMaxLineLength";
            this.numericUpDownMaxLineLength.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownMaxLineLength.TabIndex = 34;
            this.numericUpDownMaxLineLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMaxLineLength.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(44, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 46;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(300, 320);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 47;
            this.buttonOk.Text = "Save";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 395);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.panelSettings);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLineHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownDancersSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownCopyrightYear;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCopyrightName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginBottom;
        private System.Windows.Forms.NumericUpDown numericUpDownBlankSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxBreakLines;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownNoseSize;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLineLength;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}