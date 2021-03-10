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
            this.checkBoxBorder = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.radioButtonCallerView = new System.Windows.Forms.RadioButton();
            this.radioButtonDancerView = new System.Windows.Forms.RadioButton();
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
            this.checkBoxShowPartner = new System.Windows.Forms.CheckBox();
            this.radioButtonBelle = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownNoseUp = new System.Windows.Forms.NumericUpDown();
            this.radioButtonBeau = new System.Windows.Forms.RadioButton();
            this.buttonExit = new System.Windows.Forms.Button();
            this.checkBoxCreateHTML = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.groupBoxView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxFocusDancer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoseUp)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadFile
            // 
            this.buttonReadFile.Enabled = false;
            this.buttonReadFile.Location = new System.Drawing.Point(27, 396);
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
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(21, 68);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(371, 26);
            this.textBoxFile.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 45);
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
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
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
            this.opeSdFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.opeSdFileToolStripMenuItem.Text = "&Open Sd file";
            this.opeSdFileToolStripMenuItem.Click += new System.EventHandler(this.openSdFileToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
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
            this.groupBoxFocusDancer.Enabled = false;
            this.groupBoxFocusDancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFocusDancer.Location = new System.Drawing.Point(206, 151);
            this.groupBoxFocusDancer.Name = "groupBoxFocusDancer";
            this.groupBoxFocusDancer.Size = new System.Drawing.Size(188, 159);
            this.groupBoxFocusDancer.TabIndex = 42;
            this.groupBoxFocusDancer.TabStop = false;
            this.groupBoxFocusDancer.Text = "Focus dancer";
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
            3,
            0,
            0,
            0});
            this.numericUpDownNoseUp.ValueChanged += new System.EventHandler(this.numericUpDownNoseUp_ValueChanged);
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
            this.radioButtonBeau.CheckedChanged += new System.EventHandler(this.radioButtonBeau_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(246, 394);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(95, 37);
            this.buttonExit.TabIndex = 48;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click_1);
            // 
            // checkBoxCreateHTML
            // 
            this.checkBoxCreateHTML.AutoSize = true;
            this.checkBoxCreateHTML.Checked = true;
            this.checkBoxCreateHTML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreateHTML.Location = new System.Drawing.Point(18, 270);
            this.checkBoxCreateHTML.Name = "checkBoxCreateHTML";
            this.checkBoxCreateHTML.Size = new System.Drawing.Size(173, 24);
            this.checkBoxCreateHTML.TabIndex = 50;
            this.checkBoxCreateHTML.Text = "Create HTML output";
            this.checkBoxCreateHTML.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 445);
            this.Controls.Add(this.checkBoxCreateHTML);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBoxFocusDancer);
            this.Controls.Add(this.textBoxFile);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxBorder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.RadioButton radioButtonCallerView;
        private System.Windows.Forms.RadioButton radioButtonDancerView;
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
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxCreateHTML;
    }
}

