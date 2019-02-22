using System;
using System.Threading;
using System.Windows.Forms;
using SteamAccCreator.Gui;
namespace SteamAccCreator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 
        private static Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            
            const string appName = "StmAccGen";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
    
}

