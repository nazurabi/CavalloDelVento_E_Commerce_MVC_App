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
            this.btn_list = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_exportListToXml = new System.Windows.Forms.Button();
            this.lbl_endDate = new System.Windows.Forms.Label();
            this.lbl_startDate = new System.Windows.Forms.Label();
            this.lbl__SubDealerName = new System.Windows.Forms.Label();
            this.lbl_productListSentToSubDealer = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgv_productListSentToSubDealer = new System.Windows.Forms.DataGridView();
            this.btn_sendImages = new System.Windows.Forms.Button();
            this.gb_productListSentToSubDealer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productListSentToSubDealer)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_productListSentToSubDealer
            // 
            this.gb_productListSentToSubDealer.Controls.Add(this.dtp_endDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.dtp_startDate);
            this.gb_productListSentToSubDealer.Controls.Add(this.cbb_subDealerName);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_list);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_sendImages);
            this.gb_productListSentToSubDealer.Controls.Add(this.btn_print);
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
            this.dtp_endDate.Location = new System.Drawing.Point(599, 76);
            this.dtp_endDate.Name = "dtp_endDate";
            this.dtp_endDate.Size = new System.Drawing.Size(205, 36);
            this.dtp_endDate.TabIndex = 7;
            // 
            // dtp_startDate
            // 
            this.dtp_startDate.Location = new System.Drawing.Point(378, 76);
            this.dtp_startDate.Name = "dtp_startDate";
            this.dtp_startDate.Size = new System.Drawing.Size(205, 36);
            this.dtp_startDate.TabIndex = 6;
            // 
            // cbb_subDealerName
            // 
            this.cbb_subDealerName.FormattingEnabled = true;
            this.cbb_subDealerName.Location = new System.Drawing.Point(35, 76);
            this.cbb_subDealerName.Name = "cbb_subDealerName";
            this.cbb_subDealerName.Size = new System.Drawing.Size(326, 36);
            this.cbb_subDealerName.TabIndex = 5;
            this.cbb_subDealerName.SelectedIndexChanged += new System.EventHandler(this.cbb_subDealerName_SelectedIndexChanged);
            // 
            // btn_list
            // 
            this.btn_list.Location = new System.Drawing.Point(827, 76);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(201, 36);
            this.btn_list.TabIndex = 8;
            this.btn_list.Text = "List";
            this.btn_list.UseVisualStyleBackColor = true;
            this.btn_list.Click += new System.EventHandler(this.btn_list_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(449, 133);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(201, 36);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "print";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Location = new System.Drawing.Point(242, 133);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(201, 36);
            this.btn_exportExcel.TabIndex = 10;
            this.btn_exportExcel.Text = "Export to Excel";
            this.btn_exportExcel.UseVisualStyleBackColor = true;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // btn_exportListToXml
            // 
            this.btn_exportListToXml.Location = new System.Drawing.Point(35, 133);
            this.btn_exportListToXml.Name = "btn_exportListToXml";
            this.btn_exportListToXml.Size = new System.Drawing.Size(201, 36);
            this.btn_exportListToXml.TabIndex = 9;
            this.btn_exportListToXml.Text = "Export To XML";
            this.btn_exportListToXml.UseVisualStyleBackColor = true;
            this.btn_exportListToXml.Click += new System.EventHandler(this.btn_exportListToXml_Click);
            // 
            // lbl_endDate
            // 
            this.lbl_endDate.AutoSize = true;
            this.lbl_endDate.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_endDate.Location = new System.Drawing.Point(594, 45);
            this.lbl_endDate.Name = "lbl_endDate";
            this.lbl_endDate.Size = new System.Drawing.Size(96, 28);
            this.lbl_endDate.TabIndex = 4;
            this.lbl_endDate.Text = "End Date";
            // 
            // lbl_startDate
            // 
            this.lbl_startDate.AutoSize = true;
            this.lbl_startDate.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.lbl_startDate.Location = new System.Drawing.Point(373, 45);
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
            this.dgv_productListSentToSubDealer.Size = new System.Drawing.Size(1847, 715);
            this.dgv_productListSentToSubDealer.TabIndex = 12;
            // 
            // btn_sendImages
            // 
            this.btn_sendImages.Location = new System.Drawing.Point(1034, 76);
            this.btn_sendImages.Name = "btn_sendImages";
            this.btn_sendImages.Size = new System.Drawing.Size(210, 36);
            this.btn_sendImages.TabIndex = 11;
            this.btn_sendImages.Text = "Export Images Files";
            this.btn_sendImages.UseVisualStyleBackColor = true;
            this.btn_sendImages.Click += new System.EventHandler(this.btn_sendImages_Click);
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DateTimePicker dtp_endDate;
        private System.Windows.Forms.DateTimePicker dtp_startDate;
        private System.Windows.Forms.Label lbl_endDate;
        private System.Windows.Forms.Label lbl_startDate;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.Button btn_list;
        private System.Windows.Forms.DataGridView dgv_productListSentToSubDealer;
        private System.Windows.Forms.Button btn_sendImages;
    }
}