namespace Stealer
{
    partial class Stealer
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
            this.lblReadme = new System.Windows.Forms.Label();
            this.lblAppRunning = new System.Windows.Forms.Label();
            this.btnSteal = new System.Windows.Forms.Button();
            this.checkStealMore = new System.Windows.Forms.CheckBox();
            this.checkDoubleSteal = new System.Windows.Forms.CheckBox();
            this.lblStolen = new System.Windows.Forms.Label();
            this.pnBig = new System.Windows.Forms.Panel();
            this.tbPixData = new System.Windows.Forms.TextBox();
            this.pnIcon = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblReadme
            // 
            this.lblReadme.AutoSize = true;
            this.lblReadme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReadme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadme.ForeColor = System.Drawing.Color.Red;
            this.lblReadme.Location = new System.Drawing.Point(12, 9);
            this.lblReadme.Name = "lblReadme";
            this.lblReadme.Size = new System.Drawing.Size(301, 15);
            this.lblReadme.TabIndex = 0;
            this.lblReadme.Text = "CLICK ME for help. Hover over item for tooltip.";
            this.lblReadme.Click += new System.EventHandler(this.lblReadme_Click);
            // 
            // lblAppRunning
            // 
            this.lblAppRunning.AutoSize = true;
            this.lblAppRunning.Location = new System.Drawing.Point(12, 57);
            this.lblAppRunning.Name = "lblAppRunning";
            this.lblAppRunning.Size = new System.Drawing.Size(95, 13);
            this.lblAppRunning.TabIndex = 1;
            this.lblAppRunning.Text = "App is not running.";
            // 
            // btnSteal
            // 
            this.btnSteal.Location = new System.Drawing.Point(12, 155);
            this.btnSteal.Name = "btnSteal";
            this.btnSteal.Size = new System.Drawing.Size(75, 23);
            this.btnSteal.TabIndex = 2;
            this.btnSteal.Text = "Steal!";
            this.btnSteal.UseVisualStyleBackColor = true;
            this.btnSteal.Click += new System.EventHandler(this.btnSteal_Click);
            // 
            // checkStealMore
            // 
            this.checkStealMore.AutoSize = true;
            this.checkStealMore.Location = new System.Drawing.Point(12, 119);
            this.checkStealMore.Name = "checkStealMore";
            this.checkStealMore.Size = new System.Drawing.Size(213, 30);
            this.checkStealMore.TabIndex = 3;
            this.checkStealMore.Text = "Steal More\r\n(NoLegs with stealing gear in position 2)";
            this.checkStealMore.UseVisualStyleBackColor = true;
            this.checkStealMore.CheckedChanged += new System.EventHandler(this.checkStealMore_CheckedChanged);
            // 
            // checkDoubleSteal
            // 
            this.checkDoubleSteal.AutoSize = true;
            this.checkDoubleSteal.Location = new System.Drawing.Point(93, 159);
            this.checkDoubleSteal.Name = "checkDoubleSteal";
            this.checkDoubleSteal.Size = new System.Drawing.Size(54, 17);
            this.checkDoubleSteal.TabIndex = 4;
            this.checkDoubleSteal.Text = "Haste";
            this.checkDoubleSteal.UseVisualStyleBackColor = true;
            this.checkDoubleSteal.CheckedChanged += new System.EventHandler(this.checkDoubleSteal_CheckedChanged);
            // 
            // lblStolen
            // 
            this.lblStolen.AutoSize = true;
            this.lblStolen.Location = new System.Drawing.Point(12, 181);
            this.lblStolen.Name = "lblStolen";
            this.lblStolen.Size = new System.Drawing.Size(49, 13);
            this.lblStolen.TabIndex = 5;
            this.lblStolen.Text = "Stolen: 0";
            // 
            // pnBig
            // 
            this.pnBig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBig.Location = new System.Drawing.Point(15, 332);
            this.pnBig.Name = "pnBig";
            this.pnBig.Size = new System.Drawing.Size(227, 341);
            this.pnBig.TabIndex = 9;
            // 
            // tbPixData
            // 
            this.tbPixData.Location = new System.Drawing.Point(12, 679);
            this.tbPixData.Name = "tbPixData";
            this.tbPixData.Size = new System.Drawing.Size(301, 20);
            this.tbPixData.TabIndex = 11;
            // 
            // pnIcon
            // 
            this.pnIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnIcon.Location = new System.Drawing.Point(248, 332);
            this.pnIcon.Name = "pnIcon";
            this.pnIcon.Size = new System.Drawing.Size(65, 65);
            this.pnIcon.TabIndex = 12;
            // 
            // Stealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 211);
            this.Controls.Add(this.pnIcon);
            this.Controls.Add(this.tbPixData);
            this.Controls.Add(this.pnBig);
            this.Controls.Add(this.lblStolen);
            this.Controls.Add(this.checkDoubleSteal);
            this.Controls.Add(this.checkStealMore);
            this.Controls.Add(this.btnSteal);
            this.Controls.Add(this.lblAppRunning);
            this.Controls.Add(this.lblReadme);
            this.MaximizeBox = false;
            this.Name = "Stealer";
            this.Text = "Stealer2";
            this.Activated += new System.EventHandler(this.Stealer_Activated);
            this.Click += new System.EventHandler(this.Stealer_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReadme;
        private System.Windows.Forms.Label lblAppRunning;
        private System.Windows.Forms.Button btnSteal;
        private System.Windows.Forms.CheckBox checkStealMore;
        private System.Windows.Forms.CheckBox checkDoubleSteal;
        private System.Windows.Forms.Label lblStolen;
        private System.Windows.Forms.Panel pnBig;
        private System.Windows.Forms.TextBox tbPixData;
        private System.Windows.Forms.Panel pnIcon;
    }
}