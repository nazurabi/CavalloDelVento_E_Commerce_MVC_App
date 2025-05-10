namespace FormForDataModel
{
    partial class SendedList
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
            this.gb_productListSentToSubDealer = new System.Windows.Forms.GroupBox();
            this.dtp_endDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_startDate = new System.Windows.Forms.DateTimePicker();
            this.cbb_subDealerName = new System.Windows.Forms.ComboBox();
            this.btn_deletedList = new System.Windows.Forms.Button();
            this.btn_activeList = new System.Windows.Forms.Button();
            this.btn_sendImages = new System.Windows.Forms.Button();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_exportListToXml = new System.Windows.Forms.Button();
            this.lbl_endDate = new System.Windows.Forms.Label();
            this.lbl_startDate = new System.Windows.Forms.Label();
            this.lbl__SubDealerName = new System.Windows.Forms.Label();
            this.lbl_productListSentToSubDealer = new System.Windows.Forms.Label();
            this.dgv_productListSentToSubDealer = new System.Windows.Forms.DataGridView();
            this.gb_productListSentToSubDealer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productListSentToSubDealer)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_productListSentToSubDealer
            // 
            this.gb_productListSentToSubDealer.Controls.Add(this.dtp_endDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.dtp_startDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.cbb_subDealerName);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_deletedList);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_activeList);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_sendImages);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_exportExcel);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_exportListToXml);
            this.gb_productListSentToSubDealer.Controls.Add(this.lbl_endDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.lbl_startDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.lbl__SubDealerName);
            this.gb_productListSentToSubDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb_productListSentToSubDealer.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gb_productListSentToSubDealer.Location = new System.Drawing.Point(12, 47);
            this.gb_productListSentToSubDealer.Name = "gb_productListSentToSubDealer";
            this.gb_productListSentToSubDealer.Size = new System.Drawing.Size(1847, 187);
            this.gb_productListSentToSubDealer.TabIndex = 1;
            this.gb_productListSentToSubDealer.TabStop = false;
            this.gb_productListSentToSubDealer.Text = "Shipment Information";
            // 
            // dtp_endDate
            // 
            this.dtp_endDate.Location = new System.Drawing.Point(668, 76);
            this.dtp_endDate.Name = "dtp_endDate";
            this.dtp_endDate.Size = new System.Drawing.Size(205, 36);
            this.dtp_endDate.TabIndex = 7;
            // 
            // dtp_startDate
            // 
            this.dtp_startDate.Location = new System.Drawing.Point(457, 76);
            this.dtp_startDate.Name = "dtp_startDate";
            this.dtp_startDate.Size = new System.Drawing.Size(205, 36);
            this.dtp_startDate.TabIndex = 6;
            // 
            // cbb_subDealerName
            // 
            this.cbb_subDealerName.FormattingEnabled = true;
            this.cbb_subDealerName.Location = new System.Drawing.Point(35, 76);
            this.cbb_subDealerName.Name = "cbb_subDealerName";
            this.cbb_subDealerName.Size = new System.Drawing.Size(416, 36);
            this.cbb_subDealerName.TabIndex = 5;
            this.cbb_subDealerName.SelectedIndexChanged += new System.EventHandler(this.cbb_subDealerName_SelectedIndexChanged);
            // 
            // btn_deletedList
            // 
            this.btn_deletedList.Location = new System.Drawing.Point(1121, 76);
            this.btn_deletedList.Name = "btn_deletedList";
            this.btn_deletedList.Size = new System.Drawing.Size(227, 36);
            this.btn_deletedList.TabIndex = 9;
            this.btn_deletedList.Text = "List Deleted Sends";
            this.btn_deletedList.UseVisualStyleBackColor = true;
            this.btn_deletedList.Click += new System.EventHandler(this.btn_deletedList_Click);
            // 
            // btn_activeList
            // 
            this.btn_activeList.Location = new System.Drawing.Point(888, 76);
            this.btn_activeList.Name = "btn_activeList";
            this.btn_activeList.Size = new System.Drawing.Size(227, 36);
            this.btn_activeList.TabIndex = 8;
            this.btn_activeList.Text = "List Active Sends";
            this.btn_activeList.UseVisualStyleBackColor = true;
            this.btn_activeList.Click += new System.EventHandler(this.btn_activeList_Click);
            // 
            // btn_sendImages
            // 
            this.btn_sendImages.Location = new System.Drawing.Point(457, 133);
            this.btn_sendImages.Name = "btn_sendImages";
            this.btn_sendImages.Size = new System.Drawing.Size(205, 36);
            this.btn_sendImages.TabIndex = 12;
            this.btn_sendImages.Text = "Export Images Files";
            this.btn_sendImages.UseVisualStyleBackColor = true;
            this.btn_sendImages.Click += new System.EventHandler(this.btn_sendImages_Click);
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Location = new System.Drawing.Point(246, 133);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(205, 36);
            this.btn_exportExcel.TabIndex = 11;
            this.btn_exportExcel.Text = "Export to Excel";
            this.btn_exportExcel.UseVisualStyleBackColor = true;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // btn_exportListToXml
            // 
            this.btn_exportListToXml.Location = new System.Drawing.Point(35, 133);
            this.btn_exportListToXml.Name = "btn_exportListToXml";
            this.btn_exportListToXml.Size = new System.Drawing.Size(205, 36);
            this.btn_exportListToXml.TabIndex = 10;
            this.btn_exportListToXml.Text = "Export To XML";
            this.btn_exportListToXml.UseVisualStyleBackColor = true;
            this.btn_exportListToXml.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // lbl_endDate
            // 
            this.lbl_endDate.AutoSize = true;
            this.lbl_endDate.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_endDate.Location = new System.Drawing.Point(663, 45);
            this.lbl_endDate.Name = "lbl_endDate";
            this.lbl_endDate.Size = new System.Drawing.Size(96, 28);
            this.lbl_endDate.TabIndex = 4;
            this.lbl_endDate.Text = "End Date";
            // 
            // lbl_startDate
            // 
            this.lbl_startDate.AutoSize = true;
            this.lbl_startDate.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_startDate.Location = new System.Drawing.Point(452, 45);
            this.lbl_startDate.Name = "lbl_startDate";
            this.lbl_startDate.Size = new System.Drawing.Size(107, 28);
            this.lbl_startDate.TabIndex = 3;
            this.lbl_startDate.Text = "Start Date";
            // 
            // lbl__SubDealerName
            // 
            this.lbl__SubDealerName.AutoSize = true;
            this.lbl__SubDealerName.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl__SubDealerName.Location = new System.Drawing.Point(30, 45);
            this.lbl__SubDealerName.Name = "lbl__SubDealerName";
            this.lbl__SubDealerName.Size = new System.Drawing.Size(112, 28);
            this.lbl__SubDealerName.TabIndex = 2;
            this.lbl__SubDealerName.Text = "Sub Dealer";
            // 
            // lbl_productListSentToSubDealer
            // 
            this.lbl_productListSentToSubDealer.AutoSize = true;
            this.lbl_productListSentToSubDealer.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_productListSentToSubDealer.Location = new System.Drawing.Point(12, 9);
            this.lbl_productListSentToSubDealer.Name = "lbl_productListSentToSubDealer";
            this.lbl_productListSentToSubDealer.Size = new System.Drawing.Size(376, 35);
            this.lbl_productListSentToSubDealer.TabIndex = 0;
            this.lbl_productListSentToSubDealer.Text = "Product list sent to sub-dealers";
            // 
            // dgv_productListSentToSubDealer
            // 
            this.dgv_productListSentToSubDealer.AllowUserToAddRows = false;
            this.dgv_productListSentToSubDealer.AllowUserToDeleteRows = false;
            this.dgv_productListSentToSubDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productListSentToSubDealer.Location = new System.Drawing.Point(12, 240);
            this.dgv_productListSentToSubDealer.Name = "dgv_productListSentToSubDealer";
            this.dgv_productListSentToSubDealer.ReadOnly = true;
            this.dgv_productListSentToSubDealer.RowHeadersWidth = 51;
            this.dgv_productListSentToSubDealer.RowTemplate.Height = 100;
            this.dgv_productListSentToSubDealer.Size = new System.Drawing.Size(1847, 650);
            this.dgv_productListSentToSubDealer.TabIndex = 13;
            // 
            // SendedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_productListSentToSubDealer);
            this.Controls.Add(this.gb_productListSentToSubDealer);
            this.Controls.Add(this.lbl_productListSentToSubDealer);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "SendedList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SendedList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SendedList_Load);
            this.gb_productListSentToSubDealer.ResumeLayout(false);
            this.gb_productListSentToSubDealer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productListSentToSubDealer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_productListSentToSubDealer;
        private System.Windows.Forms.Button btn_exportListToXml;
        private System.Windows.Forms.Label lbl__SubDealerName;
        private System.Windows.Forms.Label lbl_productListSentToSubDealer;
        private System.Windows.Forms.ComboBox cbb_subDealerName;
        private System.Windows.Forms.DateTimePicker dtp_endDate;
        private System.Windows.Forms.DateTimePicker dtp_startDate;
        private System.Windows.Forms.Label lbl_endDate;
        private System.Windows.Forms.Label lbl_startDate;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.Button btn_activeList;
        private System.Windows.Forms.DataGridView dgv_productListSentToSubDealer;
        private System.Windows.Forms.Button btn_sendImages;
        private System.Windows.Forms.Button btn_deletedList;
    }
}