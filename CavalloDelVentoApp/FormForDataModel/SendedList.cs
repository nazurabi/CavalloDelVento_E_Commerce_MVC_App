using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DataModelWithADO;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormForDataModel
{
    public partial class SendedList : Form
    {
        DataModel dm = new DataModel();
        List<SendListProductToSubDealers> listOfSendedProduct = new List<SendListProductToSubDealers>();
        List<ExportedImages> listOfSendedImages = new List<ExportedImages>();
        List<SendedListForExcel> listForExcel = new List<SendedListForExcel>();
        DataTable dt = new DataTable();
        DateTime checkDateStart;
        DateTime checkDateEnd;
        string imageName = "";
        string imageLocation = "";
        string imageFullPath = "";
        string imageDestinationPath = "";

        string selectedSubDealerID = "";
        public SendedList()
        {
            InitializeComponent();
        }

        private void SendedList_Load(object sender, EventArgs e)
        {
            ComboBoxSubDealersLoad();
        }

        private void ComboBoxSubDealersLoad()
        {
            List<SubDealer> subDealers = dm.getSubDealers();
            subDealers.Insert(0, new SubDealer { subDealerUserID = 0, subDealerName = "---All---" });
            cbb_subDealerName.DataSource = subDealers;
            cbb_subDealerName.DisplayMember = "subDealerName";
            cbb_subDealerName.ValueMember = "subDealerUserID";
            cbb_subDealerName.SelectedItem = 0;
        }

        private void cbb_subDealerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_subDealerName.SelectedIndex != 0 && cbb_subDealerName.SelectedValue != null)
            {
                if (int.TryParse(cbb_subDealerName.SelectedValue.ToString(), out int id))
                {
                    selectedSubDealerID = id.ToString();
                }
            }
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            if (cbb_subDealerName.SelectedIndex != 0 && cbb_subDealerName.SelectedValue != null)
            {
                SendListDataBindWithSubDealerID();
            }
            else
            {
                SendListDataBind();
            }
        }
        private void SendListDataBind()
        {
            dt.Clear();
            listOfSendedImages.Clear();
            checkDateStart = dtp_startDate.Value;
            checkDateEnd = dtp_endDate.Value;
            dt = dm.SendToSubDealerListDataBind(checkDateStart, checkDateEnd);
            if (dt.Rows.Count != 0)
            {
                dgv_productListSentToSubDealer.DataSource = dt;
                dgv_productListSentToSubDealer.Columns["BrandIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["CategoryIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["ProductIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["MainUserIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["SubDealerIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["ImageFileName"].Visible = false;

                int dgvaddBrandColumnWidth = dgv_productListSentToSubDealer.Width - 100; // 100 = Image Column Width
                int otherColumnCount = dgv_productListSentToSubDealer.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
                int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

                for (int i = 0; i < otherColumnCount; i++)
                {
                    dgv_productListSentToSubDealer.Columns[i].Width = columnWidth;
                }
                foreach (DataGridViewColumn column in dgv_productListSentToSubDealer.Columns)
                {
                    if (column.Name == "S/N")
                    {
                        column.Width = 50;
                    }
                    if (column.Name == "Product Image")
                    {
                        DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_productListSentToSubDealer.RowTemplate.Height = 100;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ExportedImages img = new ExportedImages();
                    img.expImages = dr["ImageFileName"].ToString();
                    listOfSendedImages.Add(img);
                }
            }
            else
            {
                MessageBox.Show("No records were found for the date range you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendListDataBindWithSubDealerID()
        {
            dt.Clear();
            listOfSendedImages.Clear();
            checkDateStart = dtp_startDate.Value;
            checkDateEnd = dtp_endDate.Value;
            dt = dm.SendToSubDealerListDataBind(checkDateStart, checkDateEnd, selectedSubDealerID);
            if (dt.Rows.Count != 0)
            {
                dgv_productListSentToSubDealer.DataSource = dt;
                dgv_productListSentToSubDealer.Columns["BrandIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["CategoryIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["ProductIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["MainUserIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["SubDealerIDFK"].Visible = false;
                dgv_productListSentToSubDealer.Columns["ImageFileName"].Visible = false;

                int dgvaddBrandColumnWidth = dgv_productListSentToSubDealer.Width - 100; // 100 = Image Column Width
                int otherColumnCount = dgv_productListSentToSubDealer.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
                int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

                for (int i = 0; i < otherColumnCount; i++)
                {
                    dgv_productListSentToSubDealer.Columns[i].Width = columnWidth;
                }
                foreach (DataGridViewColumn column in dgv_productListSentToSubDealer.Columns)
                {
                    if (column.Name == "S/N")
                    {
                        column.Width = 50;
                    }
                    if (column.Name == "Product Image")
                    {
                        DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_productListSentToSubDealer.RowTemplate.Height = 100;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ExportedImages img = new ExportedImages();
                    img.expImages = dr["ImageFileName"].ToString();
                    listOfSendedImages.Add(img);
                }
            }
            else
            {
                MessageBox.Show("No records were found for the date range you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportListToXml_Click(object sender, EventArgs e)
        {
            listOfSendedProduct.Clear();
            ListOfProductsForSubDealers(dt);
            if (listOfSendedProduct.Count != 0)
            {
                try
                {
                    using (SaveFileDialog sf = new SaveFileDialog())
                    {
                        sf.Title = "Save XML File";
                        sf.Filter = "XML dosyası (*.xml)|*.xml";
                        DialogResult result = sf.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string filePath = sf.FileName;
                            using (StreamWriter swr = new StreamWriter(filePath))
                            {
                                XmlSerializer sralz = new XmlSerializer(typeof(List<SendListProductToSubDealers>));
                                sralz.Serialize(swr, listOfSendedProduct);
                            }
                            MessageBox.Show("Export completed successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Export not complited!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No records were found for export you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListOfProductsForSubDealers(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                SendListProductToSubDealers sendListElement = new SendListProductToSubDealers();
                sendListElement.sendID = Convert.ToInt32(dr["Shipment Number"]);
                sendListElement.brandName = dr["Brand Name"].ToString();
                sendListElement.categoryName = dr["Category Name"].ToString();
                sendListElement.productItemNumber = dr["Product Item Number"].ToString();
                sendListElement.productName = dr["Product Name"].ToString();
                sendListElement.productDescription = dr["Product Description"].ToString();
                sendListElement.subDealerName = dr["Sub Dealer Name"].ToString();
                sendListElement.sendDate = Convert.ToDateTime(dr["Send Date"]);
                sendListElement.sendQuantity = Convert.ToInt16(dr["Send Quantity"]);
                sendListElement.unitPrice = Convert.ToDecimal(dr["Unit Price"]);
                sendListElement.subTotalPrice = Convert.ToDecimal(dr["Sub Total Price"]);
                sendListElement.tax = Convert.ToDecimal(dr["Tax"]);
                sendListElement.totalPrice = Convert.ToDecimal(dr["Total Price"]);
                sendListElement.discountedPrice = Convert.ToDecimal(dr["Discounted Price"]);
                sendListElement.productDescription = dr["Description"].ToString();
                sendListElement.productImageName = dr["ImageFileName"].ToString();
                listOfSendedProduct.Add(sendListElement);
            }
        }

        private void btn_sendImages_Click(object sender, EventArgs e)
        {
            if (listOfSendedImages.Count != 0)
            {
                bool isCopy = false;
                try
                {
                    using (FolderBrowserDialog fd = new FolderBrowserDialog())
                    {
                        DialogResult result = fd.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            imageDestinationPath = fd.SelectedPath;
                            foreach (ExportedImages imgName in listOfSendedImages)
                            {
                                imageName = imgName.expImages;
                                imageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages");
                                imageLocation = Path.GetFullPath(imageLocation);
                                imageFullPath = Path.Combine(imageLocation, imageName);
                                File.Copy(imageFullPath, Path.Combine(imageDestinationPath, imageName), overwrite: true);
                                isCopy = true;
                            }
                        }
                    }
                    if (isCopy)
                    {
                        MessageBox.Show("Images copy completed successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Images copy not completed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("The selected path is a directory, not a file. Please select file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No records were found for export you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            listForExcel.Clear();
            ProductListForExcel(dt);
            if (listForExcel.Count != 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "Sended list of products.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        Excel.Application excelApp = new Excel.Application();
                        if (excelApp == null)
                        {
                            MessageBox.Show("Please install Microsoft Excel!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                        worksheet.Name = "Sended product list";

                        worksheet.Cells[1, 1] = "Shipment Number";
                        worksheet.Cells[1, 2] = "Brand Name";
                        worksheet.Cells[1, 3] = "Category Name";
                        worksheet.Cells[1, 4] = "Product Name";
                        worksheet.Cells[1, 5] = "Product Item Number";
                        worksheet.Cells[1, 6] = "Product Description";
                        worksheet.Cells[1, 7] = "Sub Dealer Name";
                        worksheet.Cells[1, 8] = "Send Date";
                        worksheet.Cells[1, 9] = "Send Quantity";
                        worksheet.Cells[1, 10] = "Unit Price";
                        worksheet.Cells[1, 11] = "Sub Total Price";
                        worksheet.Cells[1, 12] = "Tax";
                        worksheet.Cells[1, 13] = "Total Price";
                        worksheet.Cells[1, 14] = "Discounted Price";
                        worksheet.Cells[1, 15] = "Description";
                        worksheet.Cells[1, 16] = "ImageFileName";

                        Excel.Range headerRange = worksheet.get_Range("A1", "P1");
                        headerRange.Font.Bold = true;
                        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        for (int i = 0; i < listForExcel.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1] = listForExcel[i].sendID;
                            worksheet.Cells[i + 2, 2] = listForExcel[i].brandName;
                            worksheet.Cells[i + 2, 3] = listForExcel[i].categoryName;
                            worksheet.Cells[i + 2, 4] = listForExcel[i].productName;
                            worksheet.Cells[i + 2, 5] = listForExcel[i].productItemNumber;
                            worksheet.Cells[i + 2, 6] = listForExcel[i].productDescription;
                            worksheet.Cells[i + 2, 7] = listForExcel[i].subDealerName;
                            worksheet.Cells[i + 2, 8] = listForExcel[i].sendDate;
                            worksheet.Cells[i + 2, 9] = listForExcel[i].sendQuantity;
                            worksheet.Cells[i + 2, 10] = listForExcel[i].unitPrice;
                            worksheet.Cells[i + 2, 11] = listForExcel[i].subTotalPrice;
                            worksheet.Cells[i + 2, 12] = listForExcel[i].tax;
                            worksheet.Cells[i + 2, 13] = listForExcel[i].totalPrice;
                            worksheet.Cells[i + 2, 14] = listForExcel[i].discountedPrice;
                            worksheet.Cells[i + 2, 15] = listForExcel[i].description;
                            worksheet.Cells[i + 2, 16] = listForExcel[i].productImageName;
                        }
                        Excel.Range dataRange = worksheet.get_Range("A2", $"P{listForExcel.Count + 1}");
                        dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        workbook.SaveAs(saveFileDialog.FileName);
                        workbook.Close();
                        excelApp.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        MessageBox.Show("Excel file exported succesfully!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Excel file can not exported!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No records were found for export you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductListForExcel(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                SendedListForExcel lfe = new SendedListForExcel();
                lfe.sendID = Convert.ToInt32(dr["Shipment Number"]);
                lfe.brandName = dr["Brand Name"].ToString();
                lfe.categoryName = dr["Category Name"].ToString();
                lfe.productItemNumber = dr["Product Item Number"].ToString();
                lfe.productName = dr["Product Name"].ToString();
                lfe.productDescription = dr["Product Description"].ToString();
                lfe.subDealerName = dr["Sub Dealer Name"].ToString();
                lfe.sendDate = Convert.ToDateTime(dr["Send Date"]);
                lfe.sendQuantity = Convert.ToInt16(dr["Send Quantity"]);
                lfe.unitPrice = Convert.ToDecimal(dr["Unit Price"]);
                lfe.subTotalPrice = Convert.ToDecimal(dr["Sub Total Price"]);
                lfe.tax = Convert.ToDecimal(dr["Tax"]);
                lfe.totalPrice = Convert.ToDecimal(dr["Total Price"]);
                lfe.discountedPrice = Convert.ToDecimal(dr["Discounted Price"]);
                lfe.productDescription = dr["Description"].ToString();
                lfe.productImageName = dr["ImageFileName"].ToString();
                listForExcel.Add(lfe);
            }
        }

    }
}

//public void serilestirmeDeneme()
//{
//    sendedList = dm.SendToSubDealerDataBind();
//    DataTable dtdn = new DataTable();
//    dtdn.Columns.Add("Shipment Number");
//    dtdn.Columns.Add("Brand Name");
//    dtdn.Columns.Add("Category Name");
//    dtdn.Columns.Add("Product Item Number");
//    dtdn.Columns.Add("Product Name");
//    dtdn.Columns.Add("Product Description");
//    dtdn.Columns.Add("Sub Dealer Name");
//    dtdn.Columns.Add("Send Date");
//    dtdn.Columns.Add("Send Quantity");
//    dtdn.Columns.Add("Unit Price");
//    dtdn.Columns.Add("Sub Total Price");
//    dtdn.Columns.Add("Tax");
//    dtdn.Columns.Add("Total Price");
//    dtdn.Columns.Add("Discounted Price");
//    dtdn.Columns.Add("Description");
//    dtdn.Columns.Add("ImageFileName");

//    foreach (SendListProductToSubDealers sndlist in sendedList)
//    {

//        dtdn.Rows.Add(sndlist.sendID, sndlist.brandName, sndlist.categoryName, sndlist.productItemNumber, sndlist.productName, sndlist.productDescription, sndlist.subDealerName, sndlist.sendDate, sndlist.sendQuantity, sndlist.unitPrice, sndlist.subTotalPrice, sndlist.tax, sndlist.totalPrice, sndlist.discountedPrice, sndlist.description, sndlist.productImageName);
//    }
//    dgv_productListSentToSubDealer.DataSource = dtdn;
//}