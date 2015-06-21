using System;
using System.Windows.Forms;
using System.Collections;

namespace UI
{
    static class Program
    {
        static private Hashtable htConfigParameters;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
           
            Application.Run(new SecurePassMain());
            

        }
    }
}
