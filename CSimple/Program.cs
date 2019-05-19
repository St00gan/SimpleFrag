using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBase;

namespace CSimple
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var thread = new Thread(ThreadStart);
            // allow UI with ApartmentState.STA though [STAThread] above should give that to you
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            Application.Run(new Form1());
        }

        private static void ThreadStart()
        {
            Application.Run(new ZBase.Menu()); // <-- other form started on its own UI thread
        }
    }
}
