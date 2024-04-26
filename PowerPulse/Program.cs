using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string serverUrl = "https://github.com/STSatans/PowerPulse";
            string localFilePath = "update.exe"; // Path to save the downloaded update
            string executablePath = "PowerPulse.exe"; // Path of your main executable

            AutoUpdater updater = new AutoUpdater(serverUrl, localFilePath, executablePath);

            if (updater.CheckForUpdates())
            {
                DialogResult result = MessageBox.Show("An update is available. Do you want to download and install it?", "Update Available", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (updater.DownloadUpdate())
                    {
                        MessageBox.Show("Update downloaded successfully. Applying...");
                        updater.ApplyUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Failed to download update. Please try again later.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No updates available.");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
