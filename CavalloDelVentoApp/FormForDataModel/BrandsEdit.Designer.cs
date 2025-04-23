namespace FormForDataModel
{
    partial class BrandsEdit
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
            this.lbl_editBrand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_editBrand
            // 
            this.lbl_editBrand.AutoSize = true;
            this.lbl_editBrand.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_editBrand.Location = new System.Drawing.Point(12, 9);
            this.lbl_editBrand.Name = "lbl_editBrand";
            this.lbl_editBrand.Size = new System.Drawing.Size(136, 35);
            this.lbl_editBrand.TabIndex = 1;
            this.lbl_editBrand.Text = "Edit Brand";
            // 
            // BrandsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_editBrand);
            this.Name = "BrandsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Brand";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_editBrand;
    }
}