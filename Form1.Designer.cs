namespace Stealer
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.checkFastMode = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnUpdateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.checkStealMore = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numOffsY = new System.Windows.Forms.NumericUpDown();
            this.numOffsX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReadMe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsX)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 157);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Steal";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 53);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Draw Debug Grid";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // checkFastMode
            // 
            this.checkFastMode.AutoSize = true;
            this.checkFastMode.Checked = true;
            this.checkFastMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFastMode.Enabled = false;
            this.checkFastMode.Location = new System.Drawing.Point(96, 161);
            this.checkFastMode.Name = "checkFastMode";
            this.checkFastMode.Size = new System.Drawing.Size(81, 17);
            this.checkFastMode.TabIndex = 2;
            this.checkFastMode.Text = "Quick Steal";
            this.checkFastMode.UseVisualStyleBackColor = true;
            this.checkFastMode.CheckedChanged += new System.EventHandler(this.checkFastMode_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 183);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(83, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Overall Count: 0";
            // 
            // btnUpdateTooltip
            // 
            this.btnUpdateTooltip.AutomaticDelay = 100;
            this.btnUpdateTooltip.AutoPopDelay = 5000;
            this.btnUpdateTooltip.InitialDelay = 100;
            this.btnUpdateTooltip.ReshowDelay = 20;
            this.btnUpdateTooltip.ToolTipTitle = "Update/Draw Debug Grid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target:";
            // 
            // cbTarget
            // 
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Items.AddRange(new object[] {
            "Custom Target",
            "Ultimate Chibi Knight at The Beyond",
            "Zombie Hydra in The Rapture cave"});
            this.cbTarget.Location = new System.Drawing.Point(59, 93);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(177, 21);
            this.cbTarget.TabIndex = 5;
            this.cbTarget.Text = "(Select one..)";
            this.cbTarget.SelectedIndexChanged += new System.EventHandler(this.cbTarget_SelectedIndexChanged);
            // 
            // checkStealMore
            // 
            this.checkStealMore.AutoSize = true;
            this.checkStealMore.Location = new System.Drawing.Point(18, 121);
            this.checkStealMore.Name = "checkStealMore";
            this.checkStealMore.Size = new System.Drawing.Size(221, 30);
            this.checkStealMore.TabIndex = 6;
            this.checkStealMore.Text = "Stealmore \r\n(character with stealing gear in position 2)";
            this.checkStealMore.UseVisualStyleBackColor = true;
            this.checkStealMore.CheckedChanged += new System.EventHandler(this.checkStealMore_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Custom Target Information:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Column:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Row:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "+";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(54, 90);
            this.numX.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(40, 20);
            this.numX.TabIndex = 12;
            this.numX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(54, 114);
            this.numY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(40, 20);
            this.numY.TabIndex = 14;
            this.numY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numOffsY
            // 
            this.numOffsY.Location = new System.Drawing.Point(119, 114);
            this.numOffsY.Name = "numOffsY";
            this.numOffsY.Size = new System.Drawing.Size(75, 20);
            this.numOffsY.TabIndex = 15;
            // 
            // numOffsX
            // 
            this.numOffsX.Location = new System.Drawing.Point(119, 90);
            this.numOffsX.Name = "numOffsX";
            this.numOffsX.Size = new System.Drawing.Size(75, 20);
            this.numOffsX.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(3, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 52);
            this.label7.TabIndex = 16;
            this.label7.Text = "NOTE that incorrect values may lead to \r\nclicks being generated at wrong position" +
    "\r\nor not being generated at all.\r\nRow and Column is indexed starting from 1.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numOffsY);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numOffsX);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numY);
            this.panel1.Controls.Add(this.numX);
            this.panel1.Location = new System.Drawing.Point(12, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 225);
            this.panel1.TabIndex = 18;
            // 
            // btnReadMe
            // 
            this.btnReadMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadMe.ForeColor = System.Drawing.Color.Red;
            this.btnReadMe.Location = new System.Drawing.Point(12, 12);
            this.btnReadMe.Name = "btnReadMe";
            this.btnReadMe.Size = new System.Drawing.Size(120, 35);
            this.btnReadMe.TabIndex = 20;
            this.btnReadMe.Text = "README";
            this.btnReadMe.UseVisualStyleBackColor = true;
            this.btnReadMe.Click += new System.EventHandler(this.btnReadMe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 222);
            this.Controls.Add(this.btnReadMe);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkStealMore);
            this.Controls.Add(this.cbTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.checkFastMode);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Stealer v1.2 by Arime-chan";
            this.Activated += new System.EventHandler(this.Form1_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox checkFastMode;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ToolTip btnUpdateTooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.CheckBox checkStealMore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numOffsY;
        private System.Windows.Forms.NumericUpDown numOffsX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadMe;
    }
}

