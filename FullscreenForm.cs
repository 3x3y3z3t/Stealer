// ;
using ExWorkshop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Stealer
{
    public partial class FullscreenForm : Form
    {
        public struct Line
        {
            public PointF p1;
            public PointF p2;

            public Line(PointF _p1, PointF _p2)
            {
                p1 = _p1;
                p2 = _p2;
            }
        }

        public struct Coordinate
        {
            public int x;
            public int y;
            public float offsX;
            public float offsY;
        }

        const int tipW = 250;
        const int tipH = 65;

        List<Line> lines;
        Point tipPos;
        Coordinate coord; // TODO: hack;

        bool running;
        public bool visible; // TODO: hack;
        Thread thread;

        public FullscreenForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.Click += FullscreenForm_Click;
            this.Paint += FullscreenForm_Paint;

            this.BackColor = Color.FromArgb(12, 34, 56);
            this.TransparencyKey = this.BackColor;

            lines = new List<Line>();
            
            // vertical lines;
            for (int x = 0; x < Values.gw; ++x)
            {
                lines.Add(new Line(new PointF(x * Values.bw, 0), new PointF(x * Values.bw, Values.cy - 1)));
            }
            lines.Add(new Line(new PointF(Values.cx - 1, Values.cy - 31), new PointF(Values.cx - 1, Values.cy - 1)));

            // horizontal lines;
            for (int y = 0; y < Values.gh; ++y)
            {
                lines.Add(new Line(new PointF(0, y * Values.bh), new PointF(Values.cx - 1, y * Values.bh)));
            }
            lines.Add(new Line(new PointF(Values.cx - 31, Values.cy - 1), new PointF(Values.cx - 1, Values.cy - 1)));

            tipPos = Point.Empty;
            coord = new Coordinate();

            running = true;
            visible = false;
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private void FullscreenForm_Click(object sender, EventArgs e)
        {
            //running = false;
            //thread.Join();
            //lines.Clear();

            //this.Visible = false;
            //this.Owner.Visible = true;

            this.visible = false;
            this.DialogResult = DialogResult.OK;
        }

        private void FullscreenForm_Paint(object sender, PaintEventArgs e)
        {
            if (visible)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                Pen p = new Pen(Color.Cyan);
                SolidBrush b = new SolidBrush(Color.Cyan);
                
                foreach (Line l in lines)
                {
                    g.DrawLine(p, l.p1, l.p2);
                }

                g.FillRectangle(new SolidBrush(Color.Cyan), Values.cx - 26, Values.cy - 26, 20, 20);

                b.Color = SystemColors.Info;
                g.FillRectangle(new SolidBrush(SystemColors.Info), tipPos.X, tipPos.Y, tipW, tipH);

                b.Color = SystemColors.InfoText;
                g.DrawString("Recommendation:", new Font("Microsoft Sans Serif", 8, FontStyle.Bold | FontStyle.Italic), b, tipPos.X + 5, tipPos.Y + 5);
                g.DrawString(string.Format("Battle Location: Column {0}, row {1}.", coord.x + 1, coord.y + 1),
                    new Font("Microsoft Sans Serif", 8), b, tipPos.X + 5, tipPos.Y + 25);
                g.DrawString(string.Format("Target Position: Column {0} {2:+0.0f;-0.0f}, row {1} {3:+0.0f;-0.0f}.", coord.x + 1, coord.y + 1, coord.offsX, coord.offsY),
                    new Font("Microsoft Sans Serif", 8), b, tipPos.X + 5, tipPos.Y + 40);

                p.Color = SystemColors.WindowFrame;
                g.DrawRectangle(p, tipPos.X, tipPos.Y, tipW, tipH);
            }

        }

        void Run()
        {
            while (running)
            {
                if (visible)
                {
                    Point rp = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
                    if (rp.X >= 0 && rp.X < Values.cx &&
                        rp.Y >= 0 && rp.Y < Values.cy)
                    {
                        Size s = new Size(-20, -20);
                        if (rp.X > Values.cx - tipW - 30)
                            s.Width = tipW + 20;
                        if (rp.Y > Values.cy - tipH - 30)
                            s.Height = tipH + 20;
                        tipPos = Point.Subtract(rp, s);

                        coord.x = (int)(rp.X / Values.bw);
                        coord.y = (int)(rp.Y / Values.bh);
                        coord.offsX = rp.X - ((coord.x + 0.5f) * Values.bw);
                        coord.offsY = rp.Y - ((coord.y + 0.5f) * Values.bh);

                        this.SafeInvoke((FullscreenForm form) => { form.Invalidate(); });
                    }
                }
                Thread.Sleep(16);
            }
        }

        public void stop()
        {
            running = false;
            thread.Join();
        }
    }
}
