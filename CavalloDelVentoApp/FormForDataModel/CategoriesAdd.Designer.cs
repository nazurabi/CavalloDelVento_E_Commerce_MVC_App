namespace FormForDataModel
{
    partial class CategoriesAdd
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
            this.lbl_addCategories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_addCategories
            // 
            this.lbl_addCategories.AutoSize = true;
            this.lbl_addCategories.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_addCategories.Location = new System.Drawing.Point(12, 9);
            this.lbl_addCategories.Name = "lbl_addCategories";
            this.lbl_addCategories.Size = new System.Drawing.Size(191, 35);
            this.lbl_addCategories.TabIndex = 1;
            this.lbl_addCategories.Text = "Add Categories";
            // 
            // CategoriesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_addCategories);
            this.Name = "CategoriesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_addCategories;
    }
}