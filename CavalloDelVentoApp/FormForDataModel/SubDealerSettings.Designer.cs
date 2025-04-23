namespace FormForDataModel
{
    partial class SubDealerSettings
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
            this.lbl_subDealerSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_subDealerSettings
            // 
            this.lbl_subDealerSettings.AutoSize = true;
            this.lbl_subDealerSettings.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_subDealerSettings.Location = new System.Drawing.Point(12, 9);
            this.lbl_subDealerSettings.Name = "lbl_subDealerSettings";
            this.lbl_subDealerSettings.Size = new System.Drawing.Size(238, 35);
            this.lbl_subDealerSettings.TabIndex = 3;
            this.lbl_subDealerSettings.Text = "Sub Dealer Settings";
            // 
            // SubDealerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_subDealerSettings);
            this.Name = "SubDealerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sub Dealer Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_subDealerSettings;
    }
}