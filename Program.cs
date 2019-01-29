using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Stealer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Stealer f = new Stealer();
            Application.Run(f);


            //f.run(true);
        }
    }
}
