namespace FormForDataModel
{
    partial class LevelIntegrationOrders
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
            this.lbl_levelIntegrationOrders = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_levelIntegrationOrders
            // 
            this.lbl_levelIntegrationOrders.AutoSize = true;
            this.lbl_levelIntegrationOrders.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_levelIntegrationOrders.Location = new System.Drawing.Point(12, 9);
            this.lbl_levelIntegrationOrders.Name = "lbl_levelIntegrationOrders";
            this.lbl_levelIntegrationOrders.Size = new System.Drawing.Size(294, 35);
            this.lbl_levelIntegrationOrders.TabIndex = 1;
            this.lbl_levelIntegrationOrders.Text = "Level Integration Orders";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(806, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bu kısım kodlanacak (Stok miktarı biten ürün için sipariş takip kısmı olucak)";
            // 
            // LevelIntegrationOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_levelIntegrationOrders);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "LevelIntegrationOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Level Integration Orders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_levelIntegrationOrders;
        private System.Windows.Forms.Label label1;
    }
}