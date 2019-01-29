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
            this.lblCount = new System.Windows.Forms.Label();
            this.btnUpdateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.checkStealMore = new System.Windows.Forms.CheckBox();
            this.btnReadMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 117);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Steal";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(138, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Draw Debug Grid";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 143);
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
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target:";
            // 
            // cbTarget
            // 
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Items.AddRange(new object[] {
            "Ultimate Chibi Knight at The Beyond",
            "Zombie Hydra in The Rapture cave"});
            this.cbTarget.Location = new System.Drawing.Point(59, 53);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(199, 21);
            this.cbTarget.TabIndex = 5;
            this.cbTarget.Text = "(Select one..)";
            this.cbTarget.SelectedIndexChanged += new System.EventHandler(this.cbTarget_SelectedIndexChanged);
            // 
            // checkStealMore
            // 
            this.checkStealMore.AutoSize = true;
            this.checkStealMore.Location = new System.Drawing.Point(18, 81);
            this.checkStealMore.Name = "checkStealMore";
            this.checkStealMore.Size = new System.Drawing.Size(221, 30);
            this.checkStealMore.TabIndex = 6;
            this.checkStealMore.Text = "Stealmore \r\n(character with stealing gear in position 2)";
            this.checkStealMore.UseVisualStyleBackColor = true;
            this.checkStealMore.CheckedChanged += new System.EventHandler(this.checkStealMore_CheckedChanged);
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
            this.ClientSize = new System.Drawing.Size(273, 169);
            this.Controls.Add(this.btnReadMe);
            this.Controls.Add(this.checkStealMore);
            this.Controls.Add(this.cbTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Stealer v1.3 by Arime-chan";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ToolTip btnUpdateTooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.CheckBox checkStealMore;
        private System.Windows.Forms.Button btnReadMe;
    }
}

