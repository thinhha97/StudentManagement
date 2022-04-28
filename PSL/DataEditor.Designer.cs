namespace PSL
{
    partial class DataEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReload = new System.Windows.Forms.Button();
            this.dgvDataEditor = new System.Windows.Forms.DataGridView();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(12, 13);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(159, 27);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "&Load Data";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // dgvDataEditor
            // 
            this.dgvDataEditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDataEditor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataEditor.Location = new System.Drawing.Point(0, 49);
            this.dgvDataEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDataEditor.Name = "dgvDataEditor";
            this.dgvDataEditor.RowHeadersWidth = 51;
            this.dgvDataEditor.RowTemplate.Height = 24;
            this.dgvDataEditor.Size = new System.Drawing.Size(1082, 568);
            this.dgvDataEditor.TabIndex = 1;
            this.dgvDataEditor.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDataEditor_CellValueChanged);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.Location = new System.Drawing.Point(197, 14);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(159, 27);
            this.btnSaveData.TabIndex = 2;
            this.btnSaveData.Text = "&Save Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.BtnSaveData_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.Location = new System.Drawing.Point(396, 14);
            this.btnImportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(159, 27);
            this.btnImportExcel.TabIndex = 3;
            this.btnImportExcel.Text = "&Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.BtnImportExcel_Click);
            // 
            // DataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 616);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.dgvDataEditor);
            this.Controls.Add(this.btnReload);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataEditor";
            this.Text = "DataEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView dgvDataEditor;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnImportExcel;
    }
}