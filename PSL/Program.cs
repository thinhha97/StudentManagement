using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GrantAccess(Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CheckConnectionFile())
            {
                Login login = new Login();
                Application.Run(login);
                if (login.DialogResult == DialogResult.OK)
                {
                    Application.Run(new StudentManagement());
                }
            }
            else
            {
                Application.Run(new SetConnectionInfo());
            }
        }
        private static bool CheckConnectionFile()
        {
            string path = Path.Combine(Application.StartupPath, CommonConst.SQLConfigFileName);
            if (File.Exists(path))
            {
                // Read encrypted connection string from config file.
                string connectionStringEncrypted = File.ReadAllText(path);
                // Decrypt connection string.
                string connectionString = Encryption.Decrypt(connectionStringEncrypted);
                // Set connectionString property to connectionString.
                DataConnection.connectionString = connectionString;
                // Check connection and return the result.
                return DataConnection.TestConnection();
            }
            else
            {
                return false;
            }
        }
        private static void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
    }
}
