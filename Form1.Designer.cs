namespace SdGraphics
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
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownMarginTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownMaxLineLength = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxBreakLines = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.radioButtonCallerView = new System.Windows.Forms.RadioButton();
            this.radioButtonDancerView = new System.Windows.Forms.RadioButton();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opeSdFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxFocusDancer = new System.Windows.Forms.GroupBox();
            this.radioButtonBelle = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownNoseUp = new System.Windows.Forms.NumericUpDown();
            this.radioButtonBeau = new System.Windows.Forms.RadioButton();
            this.checkBoxShowPartner = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.groupBoxView.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxFocusDancer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseUp)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadFile
            // 
            this.buttonReadFile.Enabled = false;
            this.buttonReadFile.Location = new System.Drawing.Point(206, 605);
            this.buttonReadFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonReadFile.Name = "buttonReadFile";
            this.buttonReadFile.Size = new System.Drawing.Size(143, 35);
            this.buttonReadFile.TabIndex = 1;
            this.buttonReadFile.Text = "Redraw";
            this.buttonReadFile.UseVisualStyleBackColor = true;
            this.buttonReadFile.Click += new System.EventHandler(this.buttonReadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zoom";
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
            this.numericUpDownScale.Location = new System.Drawing.Point(114, 151);
            this.numericUpDownScale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownScale.Maximum = new decimal(new int[] {
            2,
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
            this.label3.Location = new System.Drawing.Point(2, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Line height";
            // 
            // numericUpDownLineHeight
            // 
            this.numericUpDownLineHeight.Location = new System.Drawing.Point(121, 48);
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
            this.label4.Location = new System.Drawing.Point(2, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Copyright name";
            // 
            // textBoxCopyrightName
            // 
            this.textBoxCopyrightName.Location = new System.Drawing.Point(121, 195);
            this.textBoxCopyrightName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCopyrightName.Name = "textBoxCopyrightName";
            this.textBoxCopyrightName.Size = new System.Drawing.Size(210, 26);
            this.textBoxCopyrightName.TabIndex = 16;
            this.textBoxCopyrightName.Text = "Thomas Bernhed";
            // 
            // checkBoxBorder
            // 
            this.checkBoxBorder.AutoSize = true;
            this.checkBoxBorder.Location = new System.Drawing.Point(206, 109);
            this.checkBoxBorder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBorder.Name = "checkBoxBorder";
            this.checkBoxBorder.Size = new System.Drawing.Size(115, 24);
            this.checkBoxBorder.TabIndex = 17;
            this.checkBoxBorder.Text = "Draw border";
            this.checkBoxBorder.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDancersSize
            // 
            this.numericUpDownDancersSize.Location = new System.Drawing.Point(301, 48);
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
            this.label2.Location = new System.Drawing.Point(203, 51);
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
            this.label5.Location = new System.Drawing.Point(2, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Blank space";
            // 
            // numericUpDownBlankSpace
            // 
            this.numericUpDownBlankSpace.Location = new System.Drawing.Point(121, 84);
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
            this.label6.Location = new System.Drawing.Point(203, 87);
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
            this.numericUpDownNoseSize.Location = new System.Drawing.Point(301, 84);
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
            this.label7.Location = new System.Drawing.Point(2, 236);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Copyright year";
            // 
            // numericUpDownCopyrightYear
            // 
            this.numericUpDownCopyrightYear.Location = new System.Drawing.Point(121, 230);
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
            2021,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(203, 123);
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
            this.numericUpDownMarginTop.Location = new System.Drawing.Point(301, 120);
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
            this.numericUpDownMarginBottom.Location = new System.Drawing.Point(121, 120);
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
            this.label9.Location = new System.Drawing.Point(2, 123);
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
            this.numericUpDownMaxLineLength.Location = new System.Drawing.Point(121, 160);
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
            this.label10.Location = new System.Drawing.Point(2, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Max line length";
            // 
            // checkBoxBreakLines
            // 
            this.checkBoxBreakLines.AutoSize = true;
            this.checkBoxBreakLines.Checked = true;
            this.checkBoxBreakLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBreakLines.Location = new System.Drawing.Point(207, 161);
            this.checkBoxBreakLines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBreakLines.Name = "checkBoxBreakLines";
            this.checkBoxBreakLines.Size = new System.Drawing.Size(106, 24);
            this.checkBoxBreakLines.TabIndex = 35;
            this.checkBoxBreakLines.Text = "Break lines";
            this.checkBoxBreakLines.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Columns";
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(115, 107);
            this.numericUpDownColumns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownColumns.TabIndex = 36;
            this.numericUpDownColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.radioButtonCallerView);
            this.groupBoxView.Controls.Add(this.radioButtonDancerView);
            this.groupBoxView.Location = new System.Drawing.Point(15, 197);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(173, 77);
            this.groupBoxView.TabIndex = 42;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View";
            // 
            // radioButtonCallerView
            // 
            this.radioButtonCallerView.AutoSize = true;
            this.radioButtonCallerView.Checked = true;
            this.radioButtonCallerView.Location = new System.Drawing.Point(88, 25);
            this.radioButtonCallerView.Name = "radioButtonCallerView";
            this.radioButtonCallerView.Size = new System.Drawing.Size(67, 24);
            this.radioButtonCallerView.TabIndex = 1;
            this.radioButtonCallerView.TabStop = true;
            this.radioButtonCallerView.Text = "Caller";
            this.radioButtonCallerView.UseVisualStyleBackColor = true;
            // 
            // radioButtonDancerView
            // 
            this.radioButtonDancerView.AutoSize = true;
            this.radioButtonDancerView.Location = new System.Drawing.Point(3, 25);
            this.radioButtonDancerView.Name = "radioButtonDancerView";
            this.radioButtonDancerView.Size = new System.Drawing.Size(79, 24);
            this.radioButtonDancerView.TabIndex = 0;
            this.radioButtonDancerView.Text = "Dancer";
            this.radioButtonDancerView.UseVisualStyleBackColor = true;
            this.radioButtonDancerView.CheckedChanged += new System.EventHandler(this.radioButtonDancerView_CheckedChanged);
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
            this.panelSettings.Location = new System.Drawing.Point(28, 316);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(377, 272);
            this.panelSettings.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 22);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "Settings";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(21, 73);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(371, 26);
            this.textBoxFile.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 50);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 20);
            this.label14.TabIndex = 46;
            this.label14.Text = "Opened file";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opeSdFileToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // opeSdFileToolStripMenuItem
            // 
            this.opeSdFileToolStripMenuItem.Name = "opeSdFileToolStripMenuItem";
            this.opeSdFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opeSdFileToolStripMenuItem.Text = "&Open Sd file";
            this.opeSdFileToolStripMenuItem.Click += new System.EventHandler(this.openSdFileToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            // 
            // groupBoxFocusDancer
            // 
            this.groupBoxFocusDancer.Controls.Add(this.checkBoxShowPartner);
            this.groupBoxFocusDancer.Controls.Add(this.radioButtonBelle);
            this.groupBoxFocusDancer.Controls.Add(this.label13);
            this.groupBoxFocusDancer.Controls.Add(this.numericUpDownNoseUp);
            this.groupBoxFocusDancer.Controls.Add(this.radioButtonBeau);
            this.groupBoxFocusDancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFocusDancer.Location = new System.Drawing.Point(206, 151);
            this.groupBoxFocusDancer.Name = "groupBoxFocusDancer";
            this.groupBoxFocusDancer.Size = new System.Drawing.Size(188, 159);
            this.groupBoxFocusDancer.TabIndex = 42;
            this.groupBoxFocusDancer.TabStop = false;
            this.groupBoxFocusDancer.Text = "Focus dancer";
            this.groupBoxFocusDancer.Visible = false;
            // 
            // radioButtonBelle
            // 
            this.radioButtonBelle.AutoSize = true;
            this.radioButtonBelle.Location = new System.Drawing.Point(95, 39);
            this.radioButtonBelle.Name = "radioButtonBelle";
            this.radioButtonBelle.Size = new System.Drawing.Size(62, 24);
            this.radioButtonBelle.TabIndex = 1;
            this.radioButtonBelle.Text = "Belle";
            this.radioButtonBelle.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 20);
            this.label13.TabIndex = 41;
            this.label13.Text = "Couple no";
            // 
            // numericUpDownNoseUp
            // 
            this.numericUpDownNoseUp.Location = new System.Drawing.Point(102, 71);
            this.numericUpDownNoseUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownNoseUp.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNoseUp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNoseUp.Name = "numericUpDownNoseUp";
            this.numericUpDownNoseUp.Size = new System.Drawing.Size(55, 26);
            this.numericUpDownNoseUp.TabIndex = 39;
            this.numericUpDownNoseUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNoseUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButtonBeau
            // 
            this.radioButtonBeau.AutoSize = true;
            this.radioButtonBeau.Checked = true;
            this.radioButtonBeau.Location = new System.Drawing.Point(6, 39);
            this.radioButtonBeau.Name = "radioButtonBeau";
            this.radioButtonBeau.Size = new System.Drawing.Size(65, 24);
            this.radioButtonBeau.TabIndex = 0;
            this.radioButtonBeau.TabStop = true;
            this.radioButtonBeau.Text = "Beau";
            this.radioButtonBeau.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowPartner
            // 
            this.checkBoxShowPartner.AutoSize = true;
            this.checkBoxShowPartner.Location = new System.Drawing.Point(12, 119);
            this.checkBoxShowPartner.Name = "checkBoxShowPartner";
            this.checkBoxShowPartner.Size = new System.Drawing.Size(123, 24);
            this.checkBoxShowPartner.TabIndex = 42;
            this.checkBoxShowPartner.Text = "Show partner";
            this.checkBoxShowPartner.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 745);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBoxFocusDancer);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDownColumns);
            this.Controls.Add(this.checkBoxBorder);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReadFile);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDancersSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlankSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopyrightYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLineLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxFocusDancer.ResumeLayout(false);
            this.groupBoxFocusDancer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReadFile;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginTop;
        private System.Windows.Forms.NumericUpDown numericUpDownMarginBottom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLineLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxBreakLines;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.RadioButton radioButtonCallerView;
        private System.Windows.Forms.RadioButton radioButtonDancerView;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opeSdFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBoxFocusDancer;
        private System.Windows.Forms.RadioButton radioButtonBelle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownNoseUp;
        private System.Windows.Forms.RadioButton radioButtonBeau;
        private System.Windows.Forms.CheckBox checkBoxShowPartner;
    }
}

