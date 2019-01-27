using System;
using System.Windows.Forms;

namespace Image_Editor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (OutOfMemoryException)
            {
                GC.Collect();
            }
        }
    }
}