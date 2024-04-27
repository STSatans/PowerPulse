using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Application = System.Windows.Forms.Application;

namespace PowerPulse
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}