﻿namespace SdGraphics
{
    partial class Form1
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
            if (disposing && (components != null)) {
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
            this.buttonReadFile = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownLineHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCopyrightName = new System.Windows.Forms.TextBox();
            this.checkBoxBorder = new System.Windows.Forms.CheckBox();
            this.numericUpDownDancersSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownBlankSpace = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownNoseSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCopyrightYear = new System.Windows.Forms.NumericUpDown();
            this.buttonBeginnin = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownMarginTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownMaxLineLength = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxBreakLines = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadFile
            // 
            this.buttonReadFile.Enabled = false;
            this.buttonReadFile.Location = new System.Drawing.Point(178, 28);
            this.buttonReadFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonReadFile.Name = "buttonReadFile";
            this.buttonReadFile.Size = new System.Drawing.Size(112, 35);
            this.buttonReadFile.TabIndex = 1;
            this.buttonReadFile.Text = "Read file";
            this.buttonReadFile.UseVisualStyleBackColor = true;
            this.buttonReadFile.Click += new System.EventHandler(this.buttonReadFile_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Enabled = false;
            this.buttonPrint.Location = new System.Drawing.Point(44, 612);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(112, 35);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(178, 612);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 35);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(44, 28);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(112, 35);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Open Sd file";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Scale";
            // 
            // numericUpDownScale
            // 
            this.numericUpDownScale.DecimalPlaces = 1;
            this.numericUpDownScale.Enabled = false;
            this.numericUpDownScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownScale.Location = new System.Drawing.Point(114, 94);
            this.numericUpDownScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownScale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownScale.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownScale.Name = "numericUpDownScale";
            this.numericUpDownScale.Size = new System.Drawing.Size(69, 26);
            this.numericUpDownScale.TabIndex = 10;
            this.numericUpDownScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownScale.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Line height";
            // 
            // numericUpDownLineHeight
            // 
            this.numericUpDownLineHeight.Location = new System.Drawing.Point(114, 183);
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
            this.numericUpDownLineHeight.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownLineHeight.TabIndex = 13;
            this.numericUpDownLineHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownLineHeight.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 382);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Copyright name";
            // 
            // textBoxCopyrightName
            // 
            this.textBoxCopyrightName.Location = new System.Drawing.Point(128, 378);
            this.textBoxCopyrightName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCopyrightName.Name = "textBoxCopyrightName";
            this.textBoxCopyrightName.Size = new System.Drawing.Size(210, 26);
            this.textBoxCopyrightName.TabIndex = 16;
            this.textBoxCopyrightName.Text = "Thomas Bernhed";
            // 
            // checkBoxBorder
            // 
            this.checkBoxBorder.AutoSize = true;
            this.checkBoxBorder.Location = new System.Drawing.Point(213, 272);
            this.checkBoxBorder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBorder.Name = "checkBoxBorder";
            this.checkBoxBorder.Size = new System.Drawing.Size(115, 24);
            this.checkBoxBorder.TabIndex = 17;
            this.checkBoxBorder.Text = "Draw border";
            this.checkBoxBorder.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDancersSize
            // 
            this.numericUpDownDancersSize.Location = new System.Drawing.Point(114, 138);
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
            this.numericUpDownDancersSize.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownDancersSize.TabIndex = 11;
            this.numericUpDownDancersSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDancersSize.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dancer size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Blank space";
            // 
            // numericUpDownBlankSpace
            // 
            this.numericUpDownBlankSpace.Location = new System.Drawing.Point(114, 228);
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
            this.numericUpDownBlankSpace.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownBlankSpace.TabIndex = 18;
            this.numericUpDownBlankSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownBlankSpace.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Nose size";
            // 
            // numericUpDownNoseSize
            // 
            this.numericUpDownNoseSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNoseSize.Location = new System.Drawing.Point(114, 272);
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
            this.numericUpDownNoseSize.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownNoseSize.TabIndex = 20;
            this.numericUpDownNoseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNoseSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 428);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Copyright year";
            // 
            // numericUpDownCopyrightYear
            // 
            this.numericUpDownCopyrightYear.Location = new System.Drawing.Point(144, 422);
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
            this.numericUpDownCopyrightYear.Size = new System.Drawing.Size(69, 26);
            this.numericUpDownCopyrightYear.TabIndex = 22;
            this.numericUpDownCopyrightYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCopyrightYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // buttonBeginnin
            // 
            this.buttonBeginnin.Image = global::SdGraphics.Properties.Resources.beginning;
            this.buttonBeginnin.Location = new System.Drawing.Point(26, 26);
            this.buttonBeginnin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBeginnin.Name = "buttonBeginnin";
            this.buttonBeginnin.Size = new System.Drawing.Size(40, 38);
            this.buttonBeginnin.TabIndex = 27;
            this.buttonBeginnin.UseVisualStyleBackColor = true;
            this.buttonBeginnin.Click += new System.EventHandler(this.buttonBeginnin_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Image = global::SdGraphics.Properties.Resources.end;
            this.buttonEnd.Location = new System.Drawing.Point(174, 26);
            this.buttonEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(40, 38);
            this.buttonEnd.TabIndex = 26;
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Image = global::SdGraphics.Properties.Resources.backward;
            this.buttonBack.Location = new System.Drawing.Point(75, 26);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(40, 38);
            this.buttonBack.TabIndex = 25;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click_1);
            // 
            // buttonForward
            // 
            this.buttonForward.Image = global::SdGraphics.Properties.Resources.forward;
            this.buttonForward.Location = new System.Drawing.Point(124, 26);
            this.buttonForward.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(40, 38);
            this.buttonForward.TabIndex = 24;
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBeginnin);
            this.groupBox1.Controls.Add(this.buttonEnd);
            this.groupBox1.Controls.Add(this.buttonBack);
            this.groupBox1.Controls.Add(this.buttonForward);
            this.groupBox1.Location = new System.Drawing.Point(39, 497);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(250, 83);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navigate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(209, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Margin top";
            // 
            // numericUpDownMarginTop
            // 
            this.numericUpDownMarginTop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMarginTop.Location = new System.Drawing.Point(325, 94);
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
            this.numericUpDownMarginTop.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownMarginTop.TabIndex = 30;
            this.numericUpDownMarginTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMarginTop.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDownMarginBottom
            // 
            this.numericUpDownMarginBottom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMarginBottom.Location = new System.Drawing.Point(325, 143);
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
            this.numericUpDownMarginBottom.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownMarginBottom.TabIndex = 32;
            this.numericUpDownMarginBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMarginBottom.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(209, 145);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Margin bottom";
            // 
            // numericUpDownMaxLineLength
            // 
            this.numericUpDownMaxLineLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMaxLineLength.Location = new System.Drawing.Point(325, 187);
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
            this.numericUpDownMaxLineLength.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownMaxLineLength.TabIndex = 34;
            this.numericUpDownMaxLineLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMaxLineLength.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(209, 189);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Max line lrngth";
            // 
            // checkBoxBreakLines
            // 
            this.checkBoxBreakLines.AutoSize = true;
            this.checkBoxBreakLines.Checked = true;
            this.checkBoxBreakLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBreakLines.Location = new System.Drawing.Point(213, 223);
            this.checkBoxBreakLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBreakLines.Name = "checkBoxBreakLines";
            this.checkBoxBreakLines.Size = new System.Drawing.Size(106, 24);
            this.checkBoxBreakLines.TabIndex = 35;
            this.checkBoxBreakLines.Text = "Break lines";
            this.checkBoxBreakLines.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 694);
            this.Controls.Add(this.checkBoxBreakLines);
            this.Controls.Add(this.numericUpDownMaxLineLength);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownMarginBottom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownMarginTop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownCopyrightYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownNoseSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownBlankSpace);
            this.Controls.Add(this.checkBoxBorder);
            this.Controls.Add(this.textBoxCopyrightName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownLineHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownDancersSize);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonReadFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReadFile;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownLineHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCopyrightName;
        private System.Windows.Forms.CheckBox checkBoxBorder;
        private System.Windows.Forms.NumericUpDown numericUpDownDancersSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownBlankSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownNoseSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCopyrightYear;
        private System.Windows.Forms.Button buttonBeginnin;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginTop;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginBottom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLineLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxBreakLines;
    }
}

