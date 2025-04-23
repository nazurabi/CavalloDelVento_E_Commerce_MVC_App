namespace FormForDataModel
{
    partial class CategoriesEdit
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
            this.lbl_editCategories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_editCategories
            // 
            this.lbl_editCategories.AutoSize = true;
            this.lbl_editCategories.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_editCategories.Location = new System.Drawing.Point(12, 9);
            this.lbl_editCategories.Name = "lbl_editCategories";
            this.lbl_editCategories.Size = new System.Drawing.Size(190, 35);
            this.lbl_editCategories.TabIndex = 1;
            this.lbl_editCategories.Text = "Edit Categories";
            // 
            // CategoriesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_editCategories);
            this.Name = "CategoriesEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_editCategories;
    }
}