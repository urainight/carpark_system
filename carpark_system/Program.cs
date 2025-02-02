using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carpark_system
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
            string SaveUser = Properties.Settings.Default.Username;
            Console.WriteLine(SaveUser);
            if (!string.IsNullOrEmpty(SaveUser) && Userdb.CheckUserLogin(SaveUser))
            {
                Application.Run(new WorkForm(SaveUser));
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}
