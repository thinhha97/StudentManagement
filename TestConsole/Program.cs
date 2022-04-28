using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConsole
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string password = @"abc@123";
            string passwordEncrypted = Encryption.Encrypt(password);
            Clipboard.SetText(passwordEncrypted);
            Console.WriteLine("Copied to clipboard");
            Console.ReadLine();
        }
    }
}
