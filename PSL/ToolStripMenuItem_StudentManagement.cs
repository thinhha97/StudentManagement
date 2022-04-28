using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    public class ToolStripMenuItem_StudentManagement : ToolStripMenuItem
    {
        public DataRow drDefine = null;
        public ToolStripMenuItem_StudentManagement(DataRow _drDefine)
        {
            this.drDefine = _drDefine;
            this.Name = drDefine["MenuID"].ToString();
            this.Text = drDefine["Content"].ToString();
        }
    }
}
