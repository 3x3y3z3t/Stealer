// ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Exw.ClickerCore
{
    public abstract class Clicker
    {
        #region Win32 API Imports
        public struct RECT
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; } // outside;
            public int Bottom { get; set; } // outside;
        }

        [DllImport("User32.dll")]
        public static extern void mouse_event(int _dwFlags, int _dx, int _dy, int _dwData, int _dwExtraInfo);

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr _hWnd, ref RECT _rect);
        #endregion

        public const string CLICKER_CORE_VERSION = "1.3";

        public Point GlobalOffset { get; protected set; }
        public string TargetAppName { get; protected set; }
        public bool TargetAppRunning { get { return target != null; } }
        public bool AppRunning { get; private set; }
        public bool Running { get; private set; }
        public uint Counter { get; protected set; }
        public float Mod { get; set; }

        private Process target;
        public Rectangle targetArea;
        protected List<Action> Sequence { get; private set; }
        private int seqIndex;
        private Thread thread;

        protected Clicker(string _targetAppName = "")
        {
            GlobalOffset = Point.Empty;
            TargetAppName = _targetAppName;
            AppRunning = true;
            Running = false;
            Counter = 0;
            Mod = 1.0f;

            target = null;
            targetArea = Rectangle.Empty;
            seqIndex = 0;
            Sequence = new List<Action>();
            thread = new Thread(new ThreadStart(Run));
            Init();
            thread.Start();
        }

        public void Run()
        {
            while (AppRunning)
            {
                while (Running)
                {
                    if (UpdateAppStatus())
                    {
                        OnRunning();
                    }
                    else
                    {
                        Running = false;
                    }

                    //Thread.Sleep(17);
                }
                if (!UpdateAppStatus(true))
                    Running = false;
                OnIdle();
                Thread.Sleep(34); // skip 2 frames;
            }
        }

        public bool UpdateAppStatus(bool _forceUpdate = false)
        {
            // no app is specified so there is no need to update;
            if (TargetAppName == null || TargetAppName.Equals(string.Empty))
                return true;

            if (_forceUpdate || target == null)
            {
                Process[] processes = Process.GetProcessesByName(TargetAppName);
                if (processes.Length == 1)
                {
                    target = processes[0];
                    RECT wndRect = new RECT();
                    GetWindowRect(target.MainWindowHandle, ref wndRect);
                    targetArea = new Rectangle(wndRect.Left + 3, wndRect.Top + 27, wndRect.Right - wndRect.Left - 6, wndRect.Bottom - wndRect.Top - 29);
                    processes = null;
                    //Console.WriteLine(target == null);
                    return true;
                }
                else
                {
                    target = null;
                    processes = null;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void Start()
        {
            if (TargetAppName == null || TargetAppName.Equals(string.Empty) || target != null)
                Running = true;
        }

        public void Pause()
        {
            Running = false;
            seqIndex = 0;
        }

        public void Stop()
        {
            Running = false;
            AppRunning = false;
            thread.Join(1000);
        }

        public bool PerformAction(int _index = -1)
        {
            if (_index >= Sequence.Count)
                return false;

            if (_index < 0)
            {
                _index = seqIndex;
                //++seqIndex;
                if (++seqIndex >= Sequence.Count)
                    seqIndex = 0;
            }

            switch (Sequence[_index].ActionType)
            {
                case Action.Type.ACTION_MOVE:
                    MoveAction ma = (MoveAction)Sequence[_index];
                    Point pt = ma.Behavior == null ? ma.Position : ma.Behavior();
                    //Cursor.Position = new Point(ma.X - 1 + targetArea.X + GlobalOffset.X, ma.Y - 1 + targetArea.Y + GlobalOffset.Y);
                    //Thread.Sleep(17);
                    //Cursor.Position = new Point((int)move.X + 1 + GlobalOffset.X, (int)move.Y + 1 + GlobalOffset.Y);
                    //Thread.Sleep(17);
                    Cursor.Position = new Point(pt.X + targetArea.X + GlobalOffset.X, pt.Y + targetArea.Y + GlobalOffset.X);
                    Thread.Sleep(17); // stabilize for 1 frame;
                    break;

                case Action.Type.ACTION_CLICK:
                    ClickAction ca = (ClickAction)Sequence[_index];
                    if ((ca.Behavior == null) ? true : ca.Behavior())
                    {
                        while (!ShouldClick())
                            Thread.Sleep(17);
                        mouse_event(ca.Button, 0, 0, 0, 0); // press the button;
                        mouse_event(ca.Button * 2, 0, 0, 0, 0); // release the button;
                        Counter += ca.IncreaseCounter;
                        Thread.Sleep(17); // stabilize for 1 frame to prevent "drag" behavior;
                    }
                    break;

                case Action.Type.ACTION_DELAY:
                    Thread.Sleep((int)(((DelayAction)Sequence[_index]).Delay * Mod));
                    break;

                case Action.Type.ACTION_CUSTOM:
                    ((CustomAction)Sequence[_index]).Behavior();
                    break;
            }

            return true;
        }

        public bool AddDelay(uint _delay = 17, int _index = -1)
        {
            if (_index > Sequence.Count)
                return false;
            else if (_index >= 0)
                Sequence.Insert(_index, new DelayAction(_delay == 0 ? 1 : _delay));
            else
                Sequence.Add(new DelayAction(_delay == 0 ? 1 : _delay));
            if (_index >= 0 && _index <= seqIndex)
                ++seqIndex;
            return true;
        }

        public bool Add(Action _action, int _index = -1)
        {
            if (_index > Sequence.Count)
                return false;
            else if (_index >= 0)
                Sequence.Insert(_index, _action);
            else
                Sequence.Add(_action);
            if (_index >= 0 && _index <= seqIndex)
                ++seqIndex;
            return true;
        }

        public bool AddMove(int _x, int _y, int _index = -1)
        {
            return Add(new MoveAction(_x, _y), _index);
        }

        public bool AddMove(Action.ActionBehavior<Point> _behavior, int _index = -1)
        {
            return Add(new MoveAction(_behavior), _index);
        }

        public bool AddClick(int _button = (int)ClickAction.ButtonMask.BTN_LEFT, int _index = -1)
        {
            return Add(new ClickAction(_button), _index);
        }

        public bool AddClick(uint _counter, int _button = (int)ClickAction.ButtonMask.BTN_LEFT, int _index = -1)
        {
            return Add(new ClickAction(_counter, _button), _index);
        }

        public bool AddClick(Action.ActionBehavior<bool> _behavior, int _button = (int)ClickAction.ButtonMask.BTN_LEFT, int _index = -1)
        {
            return Add(new ClickAction(_behavior, _button), _index);
        }

        public bool AddClick(Action.ActionBehavior<bool> _behavior, uint _counter, int _button = (int)ClickAction.ButtonMask.BTN_LEFT, int _index = -1)
        {
            return Add(new ClickAction(_behavior, _counter, _button), _index);
        }

        public bool AddDelay(Action.ActionBehavior<int> _behavior, int _index = -1)
        {
            return Add(new DelayAction(_behavior), _index);
        }

        public bool AddCustom(Action.ActionBehavior _behavior, int _index = -1)
        {
            return Add(new CustomAction(_behavior), _index);
        }

        public bool Remove(int _index)
        {
            if (_index < 0 || _index >= Sequence.Count)
                return false;
            Sequence.RemoveAt(_index);
            if (seqIndex > _index)
                --seqIndex;
            return true;
        }

        public bool Skip(int _count = 1)
        {
            if (Sequence.Count - seqIndex < _count)
                return false;
            seqIndex += _count;
            if (seqIndex >= Sequence.Count)
                seqIndex = 0;
            return true;
        }

        protected virtual void Init() { }

        protected virtual void OnIdle() { }

        protected virtual void OnRunning() { PerformAction(); }

        protected virtual bool ShouldClick() { return true; }
    }


}
