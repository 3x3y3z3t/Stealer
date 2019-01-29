// ;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Stealer.AdditionalLibraries
{
    class RawBitmap
    {
        public enum Type { Raw_FromScreen }
        public byte[] RawData { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Bitmap Original { get; private set; }

        public RawBitmap(int _x, int _y, int _w, int _h, Type _type = Type.Raw_FromScreen)
        {
            Bitmap Original = new Bitmap(_w, _h);
            Graphics.FromImage(Original).CopyFromScreen(_x, _y, 0, 0, new Size(_w, _h), CopyPixelOperation.SourceCopy);
            BitmapData data = Original.LockBits(new Rectangle(0, 0, _w, _h), ImageLockMode.ReadOnly, Original.PixelFormat);
            RawData = new byte[_w * _h];
            Marshal.Copy(data.Scan0, RawData, 0, _w * _h);
            Width = data.Width;
            Height = data.Height;

            Original.UnlockBits(data);
        }

        public Point Find(byte[] _needle, int _w, int _h)
        {
            if (_w > Width)
                return new Point(-1, -1);

            int i = 0, j = 0, x = -1;
            while (i < Height)
            {
                int xx = x;
                xx = Find(i * Width + (x < 0 ? 0 : x), _needle, j * _w, _w);
                if (x < 0)
                {
                    x = xx;
                }
                if (xx >= 0)
                    ++j;
                else
                    j = 0;


                if (j >= _h)
                    return new Point(x, i);

                ++i;
            }

            return new Point(-1, -1);


        }

        private int Find(int _offs, byte[] _needle, int _noffs, int _nlength)
        {
            int i = 0, j = 0;
            while (i + 4 <= _nlength)
            {
                if (RawData[_offs + i + 0] == _needle[_noffs * j + 0] && // A;
                    RawData[_offs + i + 1] == _needle[_noffs * j + 1] && // R;
                    RawData[_offs + i + 2] == _needle[_noffs * j + 2] && // G;
                    RawData[_offs + i + 3] == _needle[_noffs * j + 3])   // B;
                {
                    ++j;
                }
                else
                {
                    j = 0;
                }
                if (j >= _nlength)
                    return i;
                ++i;
            }
            return -1;
        }

        private int Find(int[] _haystack, int[] _needle)
        {
            if (_haystack.Length < _needle.Length)
                return -1;

            int i = 0, j = 0;
            while (i + _needle.Length <= _haystack.Length)
            {
                if (_haystack[i] == _needle[j])
                {
                    ++j;
                }
                else
                {
                    j = 0;
                }

                if (j >= _needle.Length)
                {
                    return i;
                }



                ++i;
            }

            return -1;
        }
    }
}
