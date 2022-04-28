using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    public partial class ReviewChanges : Form
    {
        public ReviewChanges(DataTable dt, Form parent)
        {

            this.MdiParent = parent;
            InitializeComponent();
            dgvReviewChanges.DataSource = dt;
            foreach (DataGridViewRow dr in dgvReviewChanges.Rows)
            {
                dr.DefaultCellStyle.BackColor = Color.Purple;

                //if (dr.Cells["Action"].Value == null)
                //{
                //    continue;
                //}
                //switch (dr.Cells["Action"].Value.ToString())
                //{
                //    case "Added":
                //        dr.DefaultCellStyle.BackColor = Color.Green;
                //        break;
                //    case "Modified":
                //        dr.DefaultCellStyle.BackColor = Color.Yellow;
                //        break;
                //    case "Deleted":
                //        dr.DefaultCellStyle.BackColor = Color.Red;

                //        break;
                //}

            }
        }


        private void BtnCommitChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
