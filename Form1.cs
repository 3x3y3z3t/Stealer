// ;
using ExWorkshop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Stealer
{
    public partial class Form1 : Form
    {
        public struct RECT
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        public struct POINT
        {
            public int x;
            public int y;
        }

        public struct PCURSORINFO
        {
            public int cbSize;
            public int flag;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        [DllImport("User32.dll")]
        public static extern bool GetCursorInfo(out PCURSORINFO _pci);

        [DllImport("User32.dll")]
        public static extern void mouse_event(int _dwFlags, int _dx, int _dy, int _dwData, int _dwExtraInfo);

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr _hWnd, ref RECT _rect);

        class Sequence
        {
            public List<int> Grids { get; private set; }
            public List<float> Offses { get; private set; }
            public List<float> Durs { get; private set; }
            public List<int> Waits { get; private set; }
            public bool CanStealMore { get; set; } // TODO: hack;

            public Sequence()
            {
                Grids = new List<int>();
                Offses = new List<float>();
                Durs = new List<float>();
                Waits = new List<int>();
                CanStealMore = false;
            }

            public void Add(int _x, int _y, float _offsX, float _offsY, float _dur, int _wait)
            {
                Grids.Add(_x);
                Grids.Add(_y);
                Offses.Add(_offsX);
                Offses.Add(_offsY);
                Durs.Add(_dur);
                Waits.Add(_wait);
            }
        }

        bool appRunning;
        bool running;

        bool fastmode = true;
        bool stealmore = false;
        Thread thread;
        
        Process ebf5;
        Point ebf5Pos;

        Sequence activePreset = null;

        DebugGrid fsf;

        public Form1()
        {
            InitializeComponent();

            numOffsX.Maximum = new decimal(Values.bw * 0.5f);
            numOffsX.Minimum = new decimal(Values.bw * -0.5f);
            numOffsY.Maximum = new decimal(Values.bh * 0.5f);
            numOffsY.Minimum = new decimal(Values.bh * -0.5f);

            cbTarget.SelectedIndex = 2;
            init(2);
            btnUpdate.Visible = false;

            
            btnUpdateTooltip.SetToolTip(btnUpdate,
                "Force updating the process list to find EBF 5.\n" +
                "Also draw a Debug Grid to assist finding clicking location.\n" +
                "Click on the square at bottom-right to close the grid.");

            
            appRunning = true;
            running = false;

            thread = new Thread(new ThreadStart(run));
            thread.Start();



            fsf = new DebugGrid
            {
                StartPosition = FormStartPosition.Manual
            };
            //fsf.Location = new Point(104, 104);
            //fsf.ShowDialog(this);
            //fsf.Visible = false;


            //this.GotFocus += Form1_GotFocus;
            this.FormClosing += Form1_FormClosing;
            this.MouseClick += Form1_MouseClick;

            this.btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Epic Battle Fantasy 5");
            if (processes.Length == 1)
            {
                ebf5 = null;
                ebf5 = processes[0];
                RECT wndRect = new RECT();
                GetWindowRect(ebf5.MainWindowHandle, ref wndRect);
                ebf5Pos = new Point(wndRect.Left + 1, wndRect.Top + 25);
                //fsf.SafeInvoke((DebugGrid f) => { f.Location = new Point(ebf5Pos.X + 1, ebf5Pos.Y + 1); }); // TODO: hack?;
                fsf.Location = new Point(ebf5Pos.X + 1, ebf5Pos.Y + 1);
            }
            processes = null;

            this.Visible = false;
            fsf.visible = true;
            DialogResult ds = DialogResult.No;
            fsf.SafeInvoke((DebugGrid f) => { ds = f.ShowDialog(this); });

            if (ds == DialogResult.OK)
            {
                this.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            appRunning = false;
            thread.Join();
            fsf.stop();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Got Click!");
            running = false;
        }

        private void Form1_GotFocus(object sender, EventArgs e)
        {
            //Console.WriteLine("Got Focus!");
            running = false;
        }

        const int gw = 0, gh = 0;

        public void run()
        {
            UInt64 overallCounter = 0UL;
            UInt64 sessionCounter = 0UL;
            ebf5 = null;
            ebf5Pos = new Point();
            while (appRunning)
            {
                sessionCounter = 0UL;
                
                while (running)
                {
                    if (ebf5 == null)
                    {
                        Process[] processes = Process.GetProcessesByName("Epic Battle Fantasy 5");
                        if (processes.Length == 1)
                        {
                            Console.WriteLine("found!");
                            ebf5 = processes[0];
                            RECT wndRect = new RECT();
                            GetWindowRect(ebf5.MainWindowHandle, ref wndRect);
                            ebf5Pos = new Point(wndRect.Left, wndRect.Top);
                        }
                        processes = null;
                    }

                    if (ebf5 != null)
                    {
                        if (activePreset == null)
                        {
                            //Console.WriteLine("Please choose a preset.");
                            break;
                        }
                        //Console.WriteLine("running...");
                        //Console.WriteLine(ebf5Pos.X + ", " + ebf5Pos.Y);

                        // ===== 1 =====
                        if (!engage())
                            break;

                        // ===== 2 =====
                        if (!steal())
                            break;
                        else
                            ++overallCounter;

                        // ===== 3 =====
                        if (stealmore)
                        {
                            if (!steal_more())
                                break;
                            else
                                ++overallCounter;
                        }

                        // ===== 4 =====
                        if (!ecscape())
                            break;


                        //++sessionCounter;

                        lblCount.SafeInvoke(delegate (Label lbl)
                        { lbl.Text = "Overall Count: " + overallCounter; });
                    }
                }
                Thread.Sleep(100);
            }

        }

        void init(int _preset = -1)
        {
            if (_preset == -1)
                return;

            switch (_preset)
            {
                case -1:
                    activePreset = null;
                    return;
                case 1:
                {
                    activePreset = new Sequence();
                    // add Init Battle;
                    activePreset.Add(19, 6, 0.0f, -15.0f, 100.0f, 3000);
                    // add First Target Location;
                    activePreset.Add(16, 8, -8.3f, 11.1f, 100.0f, 1500);
                    activePreset.CanStealMore = false;
                    break;
                }
                case 2:
                {
                    activePreset = new Sequence();
                    // add Init Battle;
                    activePreset.Add(7, 6, 0.0f, -15.0f, 100.0f, 3000);
                    // add First Target Location;
                    activePreset.Add(17, 4, -14.9f, 17.9f, 100.0f, 1500);
                    // add Second Target Location;
                    activePreset.Add(18, 7, -24.5f, 6.4f, 100.0f, 2200);
                    activePreset.CanStealMore = true;
                    break;
                }

            }
            
        }

        bool engage()
        {
            // move mouse to battle location, then init battle;
            move_cursor_to_square(activePreset.Grids[0], activePreset.Grids[1], activePreset.Offses[0], activePreset.Offses[1], activePreset.Durs[0]);
            if (!try_click())
                return false;
            Thread.Sleep(activePreset.Waits[0]);
            return true;
        }

        bool steal()
        {
            // move mouse to Recently Used location, wait until clickable;
            move_cursor_to_square(8, 12, 10.5f, 24.1f, 1250.0f);
            if (!try_click())
                return false;
            Thread.Sleep(75);

            // move mouse to target, wait until clickable;
            move_cursor_to_square(activePreset.Grids[2], activePreset.Grids[3], activePreset.Offses[2], activePreset.Offses[3], activePreset.Durs[1]);
            if (!try_click())
                return false;
            // wait for animation;
            Thread.Sleep(activePreset.Waits[1]);

            return true;
        }

        bool steal_more()
        {
            if (activePreset.CanStealMore)
            {
                // move mouse to Recently Used location, wait until clickable;
                move_cursor_to_square(8, 12, 10.5f, 24.1f, 1250.0f);
                if (!try_click())
                    return false;
                Thread.Sleep(75);

                // move mouse to target, wait until clickable;
                move_cursor_to_square(activePreset.Grids[4], activePreset.Grids[5], activePreset.Offses[4], activePreset.Offses[5], activePreset.Durs[2]);
                if (!try_click())
                    return false;
                // wait for animation;
                Thread.Sleep(activePreset.Waits[2]);
            }
            return true;
        }

        bool ecscape()
        {
            // move mouse to Tactic, wait until clickable;
            move_cursor_to_square(7, 10, 0.0f, 8.6f, 1250.0f);
            if (!try_click())
                return false;
            Thread.Sleep(75);
            // move mouse to tactic, wait until clickable;
            move_cursor_to_square(9, 12, 14.9f, -15.9f, 1250.0f);
            if (!try_click())
                return false;
            Thread.Sleep(75);
            // move to players area, wait until clickable;
            move_cursor_to_square(5, 5, 0.0f, 0.0f, 1250.0f);
            if (!try_click())
                return false;
            // wait for animation;
            Thread.Sleep(4000);

            return true;
        }

        void move_cursor_to_pos(float _x, float _y, float _dur = 1000.0f)
        {
            if (fastmode)
            {
                Cursor.Position = new Point((int)_x + 1, (int)_y + 1);
                Thread.Sleep(10);
                Cursor.Position = new Point((int)_x - 1, (int)_y - 1);
                Thread.Sleep(10);
                Cursor.Position = new Point((int)_x, (int)_y);
                Thread.Sleep(50);
            }
            else
            {
                // ***** BROKEN *****   
                //while (Math.Abs(MouseSimulator.X - _x) > 5.0f || Math.Abs(MouseSimulator.Y - _y) > 5.0f)
                //{
                //    float segm = _dur / 10f;
                //    PointF curPos = MouseSimulator.Position;
                //    float moveX = (_x - curPos.X) / segm;
                //    float moveY = (_y - curPos.Y) / segm;

                //    for (int i = 0; i < segm; ++i)
                //    {
                //        Thread.Sleep(10);
                //        MouseSimulator.X += (int)(moveX);
                //        MouseSimulator.Y += (int)(moveY);
                //    }
                //}
            }
        }

        void move_cursor_to_square(int _x, int _y, float offsX = 0.0f, float offsY = 0.0f, float _dur = 1000.0f)
        {
            move_cursor_to_pos(
                (int)((_x - 0.5f) * Values.bw + ebf5Pos.X + 1 + offsX),
                (int)((_y - 0.5f) * Values.bh + ebf5Pos.Y + 26 + offsY),
                _dur);


        }

        bool try_click()
        {
            if (!running)
                return false;

            while (!should_click())
                Thread.Sleep(50);
            
            // press the button;
            mouse_event(0x02, 0, 0, 0, 0);
            // release the button;
            mouse_event(0x04, 0, 0, 0, 0);
            return true;
        }

        bool should_click()
        {
            PCURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(PCURSORINFO));
            if (GetCursorInfo(out pci))
            {
                //Console.WriteLine(pci.hCursor);
                if (pci.hCursor == (IntPtr)65567)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

            //if (Cursor.Handle == (IntPtr)65567)
            //    return true;
            //else
            //    return false;
        }

        private void checkFastMode_CheckedChanged(object sender, EventArgs e)
        {
            fastmode = checkFastMode.Checked;
        }

        private void cbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTarget.SelectedIndex == 0)
            {
                //panel1.Visible = true;
                //SuspendLayout();
                //this.ClientSize = new Size(374, 541);
                //ResumeLayout(true);
                btnStart.Enabled = false;
                init(-1);
            }
            else
            {
                SuspendLayout();
                panel1.Visible = false;
                this.ClientSize = new Size(374, 222);
                btnStart.Enabled = true;
                ResumeLayout(true);
                switch (cbTarget.SelectedIndex)
                {
                    case 1:
                    {
                        init(1);
                        break;
                    }
                    case 2:
                    {
                        init(2);
                        break;
                    }
                }
            }
        }

        private void checkStealMore_CheckedChanged(object sender, EventArgs e)
        {
            stealmore = checkStealMore.Checked;
        }

        private void btnReadMe_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox
            {
                Location = new Point(12, 12),
                Size = new Size(776, 426),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point, 0),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Text = rmstring
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            running = true;
        }
    }
}
