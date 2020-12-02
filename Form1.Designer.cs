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
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownScale = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDiamondReduction = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDiamondWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCopyright = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiamondReduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiamondWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadFile
            // 
            this.buttonReadFile.Enabled = false;
            this.buttonReadFile.Location = new System.Drawing.Point(119, 18);
            this.buttonReadFile.Name = "buttonReadFile";
            this.buttonReadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonReadFile.TabIndex = 1;
            this.buttonReadFile.Text = "Read file";
            this.buttonReadFile.UseVisualStyleBackColor = true;
            this.buttonReadFile.Click += new System.EventHandler(this.buttonReadFile_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Enabled = false;
            this.buttonPrint.Location = new System.Drawing.Point(29, 287);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(119, 287);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(119, 59);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 23);
            this.buttonForward.TabIndex = 5;
            this.buttonForward.Text = "Forward";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(29, 59);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(29, 18);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Open Sd file";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Scale";
            // 
            // numericUpDownScale
            // 
            this.numericUpDownScale.DecimalPlaces = 1;
            this.numericUpDownScale.Enabled = false;
            this.numericUpDownScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownScale.Location = new System.Drawing.Point(136, 121);
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
            this.numericUpDownScale.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownScale.TabIndex = 10;
            this.numericUpDownScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownDiamondReduction
            // 
            this.numericUpDownDiamondReduction.Location = new System.Drawing.Point(136, 147);
            this.numericUpDownDiamondReduction.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownDiamondReduction.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDiamondReduction.Name = "numericUpDownDiamondReduction";
            this.numericUpDownDiamondReduction.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownDiamondReduction.TabIndex = 11;
            this.numericUpDownDiamondReduction.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Diamond H reduction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Diamond W size";
            // 
            // numericUpDownDiamondWidth
            // 
            this.numericUpDownDiamondWidth.Location = new System.Drawing.Point(136, 185);
            this.numericUpDownDiamondWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownDiamondWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDiamondWidth.Name = "numericUpDownDiamondWidth";
            this.numericUpDownDiamondWidth.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownDiamondWidth.TabIndex = 13;
            this.numericUpDownDiamondWidth.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Copyright";
            // 
            // textBoxCopyright
            // 
            this.textBoxCopyright.Location = new System.Drawing.Point(131, 224);
            this.textBoxCopyright.Name = "textBoxCopyright";
            this.textBoxCopyright.Size = new System.Drawing.Size(141, 20);
            this.textBoxCopyright.TabIndex = 16;
            this.textBoxCopyright.Text = "Thomas Bernhed 2020";
            this.textBoxCopyright.TextChanged += new System.EventHandler(this.textBoxCopyright_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 360);
            this.Controls.Add(this.textBoxCopyright);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownDiamondWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownDiamondReduction);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonReadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiamondReduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiamondWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReadFile;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownScale;
        private System.Windows.Forms.NumericUpDown numericUpDownDiamondReduction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDiamondWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCopyright;
    }
}

