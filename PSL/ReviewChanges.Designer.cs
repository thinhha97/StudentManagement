namespace PSL
{
    partial class ReviewChanges
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
            this.dgvReviewChanges = new System.Windows.Forms.DataGridView();
            this.btnCommitChanges = new System.Windows.Forms.Button();
            this.btnDiscardChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewChanges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReviewChanges
            // 
            this.dgvReviewChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviewChanges.Location = new System.Drawing.Point(12, 25);
            this.dgvReviewChanges.Name = "dgvReviewChanges";
            this.dgvReviewChanges.RowHeadersWidth = 51;
            this.dgvReviewChanges.RowTemplate.Height = 24;
            this.dgvReviewChanges.Size = new System.Drawing.Size(916, 451);
            this.dgvReviewChanges.TabIndex = 0;
            // 
            // btnCommitChanges
            // 
            this.btnCommitChanges.Location = new System.Drawing.Point(201, 511);
            this.btnCommitChanges.Name = "btnCommitChanges";
            this.btnCommitChanges.Size = new System.Drawing.Size(139, 23);
            this.btnCommitChanges.TabIndex = 1;
            this.btnCommitChanges.Text = "Commit Changes";
            this.btnCommitChanges.UseVisualStyleBackColor = true;
            this.btnCommitChanges.Click += new System.EventHandler(this.BtnCommitChanges_Click);
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.Location = new System.Drawing.Point(396, 511);
            this.btnDiscardChanges.Name = "btnDiscardChanges";
            this.btnDiscardChanges.Size = new System.Drawing.Size(106, 23);
            this.btnDiscardChanges.TabIndex = 2;
            this.btnDiscardChanges.Text = "Discard Changes";
            this.btnDiscardChanges.UseVisualStyleBackColor = true;
            // 
            // ReviewChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 558);
            this.Controls.Add(this.btnDiscardChanges);
            this.Controls.Add(this.btnCommitChanges);
            this.Controls.Add(this.dgvReviewChanges);
            this.Name = "ReviewChanges";
            this.Text = "ReviewChanges";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewChanges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReviewChanges;
        private System.Windows.Forms.Button btnCommitChanges;
        private System.Windows.Forms.Button btnDiscardChanges;
    }
}