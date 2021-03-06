using BLL;
using DAL;
using OfficeOpenXml;
using PSL.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL.Forms
{
    public partial class DataEditor : BaseForm
    {
        private FormSetting FormSetting;
        DataTable dtSource = null;
        readonly BindingSource bindingSource = new BindingSource();
        private bool _unsavedChanges = false;
        private bool _encrypted = false;
        public DataEditor()
        {
            InitializeComponent();
            ToggleBtnSaveData();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // base on menuid to load data using stored procedure or select commandtext.
            this.FormSetting = BLL.FormSetting.Instance(this.MenuID);
            this.Text = this.MenuID;
            if (this.FormSetting != null)
            {
                if (FormSetting.LoadDataImmediately)
                {
                    LoadDataFromDatabase();
                    if (dgvDataEditor.Columns.Contains("CreateAt")) {
                        dgvDataEditor.Columns["CreatedAt"].ReadOnly = true;
                    }
                    if (dgvDataEditor.Columns.Contains("ModifiedAt")) {
                        dgvDataEditor.Columns["ModifiedAt"].ReadOnly = true;
                    }
                }
            }
            else
            {
                throw new Exception("This form has not been configured in FormSetting table");
            }
        }

        private void LoadDataFromDatabase()
        {
            dtSource = DataConnection.ReturnDataTable(String.IsNullOrEmpty(this.FormSetting.ProcedureName)
                ? this.FormSetting.SelectCommandText
                : this.FormSetting.ProcedureName, "@LoginID", UserInfo.LoginID);
            bindingSource.DataSource = dtSource;
            dgvDataEditor.DataSource = bindingSource;

            _unsavedChanges = false;
            ToggleBtnSaveData();
        }
        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (_unsavedChanges)
            {
                var dialogResult = MessageBox.Show("Do you want to save changes?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveData();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            LoadDataFromDatabase();
            _unsavedChanges = false;
        }

        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                this.FormSetting.SelectCommandText,
                DataConnection.GetConnection());
            using (SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da))
            {
                try
                {
                    da.Update((DataTable)bindingSource.DataSource);
                    LoadDataFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ToggleBtnSaveData()
        {
            if (_unsavedChanges)
            {
                btnSaveData.Enabled = true;
            }
            else
            {
                btnSaveData.Enabled = false;
            }
        }

        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) " +
                    "|*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb",
                    FilterIndex = 3,
                    Multiselect = false,
                    Title = "Open Excel File - Student Management",
                    InitialDirectory = @"Desktop"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathName = openFileDialog.FileName;
                    string fileName = Path.
                        GetFileNameWithoutExtension(openFileDialog.FileName);
                    DataTable dt = new DataTable();
                    string connString = String.Empty;

                    FileInfo fileInfo = new FileInfo(pathName);
                    if (!fileInfo.Exists)
                    {
                        throw new Exception("File does not exist!");
                    }
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int colCount = worksheet.Dimension.End.Column;
                        int rowCount = worksheet.Dimension.End.Row;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                dt.Rows[row - 1][col - 1] = worksheet.Cells[row, col].Value?.ToString().Trim();
                            }
                        }
                    }
                    BindingSource bd = new BindingSource
                    {
                        DataSource = dt
                    };
                    ImportExcel importExcel = new ImportExcel(bd, this.MdiParent);
                    importExcel.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvDataEditor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string text = dgvDataEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (dgvDataEditor.Columns[e.ColumnIndex].Name == "Password")
            {
                if (!_encrypted)
                {
                    _encrypted = true;
                    dgvDataEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encryption.Encrypt(text);
                }
                _encrypted = false;
            }
            _unsavedChanges = true;
            ToggleBtnSaveData();
        }

        private void DataEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_unsavedChanges)
            {
                if (MessageBox.Show(@"Do you want to close this form?\r\nAll unsaved data will be lost.", "Close form?", MessageBoxButtons.YesNo)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DataEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboard.ExecutePasteClipboard(dgvDataEditor,dtSource);
            }
        }
    }
}
