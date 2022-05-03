using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL.CustomFunctions
{
    public class Logout
    {
        public void Execute()
        {
            if (MessageBox.Show("Do you want to log out?", "Log out?", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
