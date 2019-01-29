// ;
using ExWorkshop;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Stealer
{
    public partial class Stealer : Form
    {
        public class SToolTip : ToolTip
        {
            public SToolTip()
            {
                InitialDelay = 200;
                ReshowDelay = 100;
                AutoPopDelay = 5000;
            }
        }

        StealerClicker clicker;

        private bool appRunning;
        public int col = 0, row = 0;
        

        public Stealer()
        {
            InitializeComponent();

            FormClosing += Stealer_FormClosing;
            Load += Stealer_Load;

            pnBig.Paint += PnIcon_Paint;

            //this.StartPosition = FormStartPosition.Manual;
            //Location = Point.Empty;

            new ToolTip { InitialDelay = 5000, AutoPopDelay = 1000 }.SetToolTip(lblReadme,
                "I don't think you don't understand what I'm saying, because it's quite obvious.\n" +
                "Just, click, me, to, maybe call for help from somewhere... Actually most items can\n" +
                "say for themselves, and they may even tell you their stories if they want.\n" +
                "Oh, maybe you're just wondering why I'm not a button but a label, right? Honestly\n" +
                "even I don't know, I'm born as a label at the first place.");
            new SToolTip().SetToolTip(checkStealMore,
                "Powerful stealing technique which steals multiple times.\n" +
                "Require NoLegs with stealing gear in position 2.");
            new SToolTip().SetToolTip(checkDoubleSteal,
                "Sometimes you feel so good that your fingers move twice as fast.\n" +
                "Require the game to be speeded up by 2x.");


            appRunning = true;


        }

        private void PnIcon_Paint(object sender, PaintEventArgs e)
        {
        //    Graphics pg = e.Graphics;
        //    using (Bitmap bmp = new Bitmap(201, 449))
        //    {
        //        using (Graphics g = Graphics.FromImage(bmp))
        //        {
        //            g.CopyFromScreen(446 + clicker.targetArea.X, 235 + clicker.targetArea.Y, 0, 0, new Size(201, 449));
        //            // there is always 3 column no matter what;
        //            Bitmap b = bmp.Clone(new Rectangle(3 + 0, 2 + 61 * row , 190, 61), bmp.PixelFormat);
        //            pg.DrawImage(b, 0.0f, 0.0f);
        //        }
        //    }

        }

        private void Stealer_Load(object sender, EventArgs e)
        {
            clicker = new StealerClicker();
            new Thread(new ThreadStart(UpdateMonitor)).Start();


        }

        public void UpdateMonitor()
        {
            while (appRunning)
            {
                // TODO: query data from clicker;
                lock (this)
                {
                    if (clicker.AppRunning)
                    {
                        if (clicker.TargetAppRunning)
                            lblAppRunning.SafeInvoke((Label lbl) => { lbl.Text = clicker.TargetAppName + " is running.."; lbl.ForeColor = Color.DarkGreen; });
                        else
                            lblAppRunning.SafeInvoke((Label lbl) => { lbl.Text = clicker.TargetAppName + " is not running."; lbl.ForeColor = Color.Red; });

                        lblStolen.SafeInvoke((Label lbl) => { lbl.Text = "Stolen: " + clicker.Counter; });
                        //lblStolen.SafeInvoke((Label lbl) => { lbl.Text = "targetArea: " + clicker.targetArea; }); // dbg;
                        //Console.WriteLine();



                        // icon: 61x61;

                    




                    }
                }

                Thread.Sleep(17);
            }
        }

        private void Stealer_FormClosing(object sender, FormClosingEventArgs e)
        {
            clicker.Stop();
            appRunning = false;
        }

        private void lblReadme_Click(object sender, EventArgs e)
        {
            // open the readme;
            TextBox tb = new TextBox
            {
                Location = new Point(12, 12),
                Size = new Size(776, 426),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point, 0),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Text = Values.rmstring
            };
            tb.Select(0, 0);

            Form rm = new Form
            {
                Text = "Readme",
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
            rm.SuspendLayout();
            rm.ClientSize = new Size(800, 450);
            rm.Controls.Add(tb);
            rm.ResumeLayout(true);
            //rm.Click += (object obj, EventArgs evt) => { DialogResult = DialogResult.OK; };

            rm.ShowDialog();
        }

        private void Stealer_Activated(object sender, EventArgs e)
        {
            clicker.Pause();
        }

        private void Stealer_Click(object sender, EventArgs e)
        {
            clicker.Pause();
        }

        private void btnSteal_Click(object sender, EventArgs e)
        {
            clicker.Start();
        }

        private void checkStealMore_CheckedChanged(object sender, EventArgs e)
        {
            lock (this)
            {
                clicker.StealMore = checkStealMore.Checked;
                //clicker.Init(true);
            }
        }

        private void checkDoubleSteal_CheckedChanged(object sender, EventArgs e)
        {
            clicker.Mod = 0.6f;
        }
    }
}
