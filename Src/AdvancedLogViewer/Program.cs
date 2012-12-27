using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvancedLogViewer.UI;

namespace AdvancedLogViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if !(DEBUG)
            try
#endif
            {
                Scarfsail.Logging.Log.Configure("");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mainForm = new MainForm(args);
                if (!mainForm.DontRunApplication)
                    Application.Run(mainForm);
            }           
#if !(DEBUG)
            catch (Exception ex)
            {
                MessageBox.Show("Exception during startup: "+ex.ToString());
                throw;
            }
#endif
        }
    }
}
