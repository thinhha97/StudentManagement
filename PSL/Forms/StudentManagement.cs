using BLL;
using DAL;
using PSL.CustomFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL.Forms
{
    public partial class StudentManagement : Form
    {
        public StudentManagement()
        {
            InitializeComponent();
            BuildMenu();
        }

        private void BuildMenu()
        {
            // 1. Load Menu list
            using (DataTable dt = DataConnection.ReturnDataTable("spLoadMenu", "@LoginID", UserInfo.LoginID))
            {
                DataRow[] parents = dt.Select("ParentMenuID is null");
                DataRow[] children = dt.Select("ParentMenuID = 'MNStudentManagement'");
                BuildMenuItems(dt, null, null);
            }
            // 2. Build Menu from top
            // 3. Test
        }

        private void BuildMenuItems(DataTable dt, string parentMenuID, ToolStripMenuItem parentMenu)
        {
            DataRow[] currentDataRow = null;
            if (string.IsNullOrEmpty(parentMenuID))
            {
                currentDataRow = dt.Select("ParentMenuID is null");
            }
            else
            {
                currentDataRow = dt.Select(string.Format("ParentMenuID = '{0}'", parentMenuID));
            }

            foreach (DataRow row in currentDataRow)
            {
                ToolStripMenuItem_StudentManagement tsmi = new ToolStripMenuItem_StudentManagement(row);
                tsmi.Click += Tsmi_Click;
                if (string.IsNullOrEmpty(parentMenuID))
                {
                    msMain.Items.Add(tsmi);
                }
                else
                {
                    parentMenu.DropDownItems.Add(tsmi);
                }
                BuildMenuItems(dt, tsmi.Name, tsmi);
            }
        }

        private void Tsmi_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem_StudentManagement currentMenuItem)
            {
                if (currentMenuItem.drDefine["ClassName"] is string _className && _className.Length > 0)
                {
                    if (currentMenuItem.drDefine["AssemblyName"] is string _assemblyName && _assemblyName.Length > 0)
                    {
                        string menuId = currentMenuItem.drDefine["MenuID"].ToString();
                        string classFullName = string.Format("{0}.{1}", _assemblyName, _className);
                        // Check if form is created
                        if (this.MdiChildren.Where(c => c is BaseForm).Cast<BaseForm>()
                            .FirstOrDefault(c => string.Compare(c.MenuID, menuId, true) == 0)
                            is Form existedForm)
                        {
                            existedForm.Activate();
                        }
                        else
                        {
                            var item = Activator.CreateInstance(_assemblyName, classFullName);
                            object _obj = item.Unwrap();
                            if (_obj is BaseForm form)
                            {
                                form.MdiParent = this;
                                form.MenuID = menuId.ToLower();
                                form.Show();
                            }
                        }
                    }
                }
                else
                {
                    switch (currentMenuItem.drDefine["MenuId"].ToString())
                    {
                        case "Logout":
                            Logout logout = new Logout();
                            logout.Execute();
                            break;
                    }
                }
            }
        }

        private void CreateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
