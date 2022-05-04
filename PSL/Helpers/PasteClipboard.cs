using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;

namespace PSL.Helpers
{
    public static class PasteClipboard
    {
        public static void ExecutePasteClipboard(AdvancedDataGridView dgData, DataTable dataTable)
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int linesCount = lines.Length;
                int iFail = 0, iRow = dgData.CurrentCell.RowIndex;
                int iCol = dgData.CurrentCell.ColumnIndex;
                if (linesCount + iRow > dgData.Rows.Count)
                {
                    for (int i = 0; i < linesCount - 2; i++)
                    {
                        dataTable.Rows.Add();
                    }
                }
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < dgData.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < dgData.ColumnCount)
                            {
                                oCell = dgData[iCol + i, iRow];
                                if (!oCell.ReadOnly && oCell != null)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i],
                                                              oCell.ValueType);
                                        oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                    {
                                        iFail++;
                                    }
                                    //only traps a fail if the data has changed 
                                    //and you are pasting into a read only cell
                                }
                                else
                                {
                                    iFail++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} updates failed due" +
                                        " to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
    }
}
