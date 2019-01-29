// ;
using Exw.ClickerCore;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Stealer
{
    public class StealerClicker : Clicker
    {
        #region Win32 API Imports
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
        #endregion

        public bool StealMore { get; set; }

        private bool firsttime;

        private Point escPoint;

        protected override void Init()
        {
            base.Init();
            GlobalOffset = new Point(0, 0);
            TargetAppName = "Epic Battle Fantasy 5";

            // TODO: add firsttime;

            // 63 x 49;
            // x = 1        1250    1
            // y = 1    25  699     1

            StealMore = false;
            firsttime = false;
            escPoint = new Point(540, 560);




#if true
            // init battle: (375, 249, 437, 298);
            AddMove(406, 274);
            AddClick(0U);
            AddDelay(2200);

            // move to "Skill" button: (299, 505, 433, 541);
            AddMove(366, 523);
            AddClick(() => { return firsttime; }, 0U);

            // move to "Recently Used" area, or move to scan skill;
            AddMove(() =>
            {
                if (firsttime)
                {
                    // TODO: scan skill;
                    return new Point(0, 0);
                }
                else
                {
                    return new Point(490, 600);
                }
            });
            AddClick(0U);

            // move to foe 1: ();
            AddMove(1018, 156);
            AddClick();
            AddDelay(1900);

            // move to "Limit" button: (299, 429, 433, 465);

            // move to "Recently Used" area, or move to scan skill;
            AddMove(() =>
            {
                if (StealMore && firsttime)
                {
                    // TODO: scan skill;
                    return new Point(0, 0);
                }
                else
                {
                    return new Point(490, 600);
                }

            });
            AddClick(() => { return StealMore; }, 0U);

            // move to foe 2: ();
            AddMove(1068, 331);
            AddClick(() => { return StealMore; });
            AddDelay(() =>
            {
                if (StealMore)
                    return 1900;
                return 0;
            });

            // move to "Tactics" button: (299, 467, 433, 503);
            AddMove(366, 485);
            AddClick(0U);

            // move to "Escape": ();
            AddMove(() =>
            {
                if (firsttime)
                {
                    // TODO: scan Ecscape;
                    // 446, 339, 580, 595 (135 x 257);
                    escPoint = new Point(0, 0);
                }
                return escPoint;
            });
            AddClick(0U);

            // move to party: ();
            AddMove(252, 256);
            AddClick(0U);
            AddDelay(4300);

            //AddCustom(() => { Pause(); });
            //AddCustom(() =>
            //{
            //// failsafe;
            //if (firsttime) {
            //    firsttime = false;
            //    Remove(3);
            //    Remove(3);
            //    Remove(3);
            //    Remove(Sequence.Count - 1);
            //}
            //});
#else
            RawBitmap rbm = new RawBitmap(466, 399, 135, 257);
            
            // this should spam cursor on the four corner;
            int x1 = 299, y1 = 467;
            int x2 = 433, y2 = 503;
            //AddMove(() =>
            //{
            //    if (firsttime)
            //    {
            //        firsttime = false;
            //        return new Point(x1, y1);
            //    }
            //    else
            //    {
            //        firsttime = true;
            //        return new Point(0, 0);
            //    }
            //});
            AddMove(x1, y1);
            AddDelay(500);
            AddMove(x2, y1);
            AddDelay(500);
            AddMove(x2, y2);
            AddDelay(500);
            AddMove(x1, y2);
            AddDelay(500);


            Bitmap stealitem;
            

#endif

            //firsttime = true;

        }

        protected override void OnRunning()
        {
            base.OnRunning();



            UpdateAppStatus(true);
            //Remove(1);
        }

        protected override bool ShouldClick()
        {
            PCURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(PCURSORINFO));
            if (GetCursorInfo(out pci))
            {
                //Console.WriteLine(pci.hCursor == (IntPtr)65567);
                //return (pci.hCursor == (IntPtr)65567);
                if (pci.hCursor == (IntPtr)65567)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }

}
