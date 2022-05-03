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
    public partial class Login : Form
    {
        readonly string savedCredentialPath = Path.Combine(Application.StartupPath, CommonConst.SavedCredentialFileName);
        private string _usernameEncrypted = string.Empty;
        private string _passwordEncrypted = string.Empty;
        private bool _rememberMe = false;
        public Login()
        {
            InitializeComponent();
            LoadCredential();
        }

        private void LoadCredential()
        {
            if (File.Exists(savedCredentialPath))
            {
                ReadCredentialInfo();
                chbRememberPassword.Checked = _rememberMe;
                txtUsername.Text = Encryption.Decrypt(_usernameEncrypted);
                txtPassword.Text = Encryption.Decrypt(_passwordEncrypted);
            }

        }

        private void ReadCredentialInfo()
        {
            try
            {
                string[] file = File.ReadAllLines(savedCredentialPath);
                _rememberMe = bool.Parse(Encryption.Decrypt(file[0]));
                _usernameEncrypted = file[1];
                _passwordEncrypted = file[2];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveCredentialInfo()
        {
            string[] lines = new string[3];
            lines[0] = Encryption.CustomEncrypt(chbRememberPassword.Checked.ToString());
            lines[1] = Encryption.CustomEncrypt(txtUsername.Text);
            lines[2] = Encryption.CustomEncrypt(txtPassword.Text);
            File.WriteAllLines(savedCredentialPath, lines);
        }

        private void DeleteCredentialInfo()
        {
            if (File.Exists(savedCredentialPath))
            {
                File.Delete(savedCredentialPath);
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = Encryption.Encrypt(txtPassword.Text);
            using (DataTable dt = DataConnection.ReturnDataTable("spCheckLogin", "@Username", username, "@Password", password))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] is int _loginId)
                    {
                        UserInfo.LoginID = _loginId;
                        if (chbRememberPassword.Checked)
                        {
                            SaveCredentialInfo();
                        }
                        else
                        {
                            DeleteCredentialInfo();
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There's an error calling stored procedure spCheckLogin - in PSL.Login");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
