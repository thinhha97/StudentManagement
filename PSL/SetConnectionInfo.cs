using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    public partial class SetConnectionInfo : Form
    {
        public SetConnectionInfo()
        {
            InitializeComponent();
        }

        private void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            DataConnection.SetConnectionInfo(txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
            if (DataConnection.TestConnection())
            {
                string connectionStringEncrypted = Encryption.CustomEncrypt(DataConnection.connectionString);
                string path = Path.Combine(Application.StartupPath, CommonConst.SQLConfigFileName);
                try
                {
                    File.WriteAllText(path, connectionStringEncrypted);
                    if (MessageBox.Show("Do you want to restart the application?", "Restart required", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
