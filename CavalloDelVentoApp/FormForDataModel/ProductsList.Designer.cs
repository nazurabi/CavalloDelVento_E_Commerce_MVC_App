namespace FormForDataModel
{
    partial class ProductsList
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
            this.lbl_listProducts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_listProducts
            // 
            this.lbl_listProducts.AutoSize = true;
            this.lbl_listProducts.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_listProducts.Location = new System.Drawing.Point(12, 9);
            this.lbl_listProducts.Name = "lbl_listProducts";
            this.lbl_listProducts.Size = new System.Drawing.Size(164, 35);
            this.lbl_listProducts.TabIndex = 3;
            this.lbl_listProducts.Text = "List Products";
            // 
            // ProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_listProducts);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "ProductsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "List Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_listProducts;
    }
}