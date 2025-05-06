using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
    public partial class ProductsList : Form
    {
        DataModel dm = new DataModel();
        List<ProductListForExcel> listForExcelAndXML = new List<ProductListForExcel>();
        List<ExportedImages> listOfSendedImages = new List<ExportedImages>();
        DataTable dt = new DataTable();
        string imageName = "";
        string imageLocation = "";
        string imageFullPath = "";
        string imageDestinationPath = "";
        public ProductsList()
        {
            InitializeComponent();
        }

        private void ProductsList_Load(object sender, EventArgs e)
        {
            ProductList();
        }

        private void ProductList()
        {
            dt.Clear();
            listOfSendedImages.Clear();
            dt = dm.productsDataBind();
            if (dt.Rows.Count != 0)
            {
                dgv_productList.DataSource = dt;
                dgv_productList.RowHeadersVisible = false;
                dgv_productList.Columns["ProductID"].Visible = false;
                dgv_productList.Columns["BrandIDFK"].Visible = false;
                dgv_productList.Columns["CategoryIDFK"].Visible = false;
                dgv_productList.Columns["Product Image Name"].Visible = false;

                int dgvaddBrandColumnWidth = dgv_productList.Width - 100; // 100 = Image Column Width
                int otherColumnCount = dgv_productList.Columns.Count - 6; // (6 --> S/N, ProductID, BrandIDFK, CategoryIDFK, Image, Image Name Column)
                int columnWidth = dgvaddBrandColumnWidth / otherColumnCount;

                for (int i = 0; i < otherColumnCount; i++)
                {
                    dgv_productList.Columns[i].Width = columnWidth;
                }
                foreach (DataGridViewColumn column in dgv_productList.Columns)
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
                        dgv_productList.RowTemplate.Height = 100;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ExportedImages img = new ExportedImages();
                    img.expImages = dr["Product Image Name"].ToString();
                    listOfSendedImages.Add(img);
                }

            }
            else
            {
                MessageBox.Show("No records were found for the date range you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_productList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_productList.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btn_exportListToXml_Click(object sender, EventArgs e)
        {
            listForExcelAndXML.Clear();
            ProList(dt);
            if (listForExcelAndXML.Count != 0)
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
                                XmlSerializer sralz = new XmlSerializer(typeof(List<ProductListForExcel>));
                                sralz.Serialize(swr, listForExcelAndXML);
                            }
                            MessageBox.Show("Export completed successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Export not completed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No records were found for export you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            listForExcelAndXML.Clear();
            ProList(dt);
            if (listForExcelAndXML.Count != 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "Product list.xlsx";

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
                        worksheet.Name = "Product list";

                        worksheet.Cells[1, 1] = "ProductID";
                        worksheet.Cells[1, 2] = "Product Item Number";
                        worksheet.Cells[1, 3] = "Product Name";
                        worksheet.Cells[1, 4] = "Brand Name";
                        worksheet.Cells[1, 5] = "Category Name";
                        worksheet.Cells[1, 6] = "Product Description";
                        worksheet.Cells[1, 7] = "Quantity Per Unit";
                        worksheet.Cells[1, 8] = "Unit Price";
                        worksheet.Cells[1, 9] = "Units In Stock";
                        worksheet.Cells[1, 10] = "Units On Order";
                        worksheet.Cells[1, 11] = "Reorder Level";
                        worksheet.Cells[1, 12] = "Discontinued";
                        worksheet.Cells[1, 13] = "Is Deleted";
                        worksheet.Cells[1, 14] = "Is Product Active For Sale";
                        worksheet.Cells[1, 15] = "ImageFileName";

                        Excel.Range headerRange = worksheet.get_Range("A1", "P1");
                        headerRange.Font.Bold = true;
                        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        for (int i = 0; i < listForExcelAndXML.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1] = listForExcelAndXML[i].productID;
                            worksheet.Cells[i + 2, 2] = listForExcelAndXML[i].productItemNumber;
                            worksheet.Cells[i + 2, 3] = listForExcelAndXML[i].productName;
                            worksheet.Cells[i + 2, 4] = listForExcelAndXML[i].brandName;
                            worksheet.Cells[i + 2, 5] = listForExcelAndXML[i].categoryName;
                            worksheet.Cells[i + 2, 6] = listForExcelAndXML[i].description;
                            worksheet.Cells[i + 2, 7] = listForExcelAndXML[i].quantityPerUnit;
                            worksheet.Cells[i + 2, 8] = listForExcelAndXML[i].unitPrice;
                            worksheet.Cells[i + 2, 9] = listForExcelAndXML[i].unitsInStock;
                            worksheet.Cells[i + 2, 10] = listForExcelAndXML[i].unitsOnOrder;
                            worksheet.Cells[i + 2, 11] = listForExcelAndXML[i].reorderLevel;
                            worksheet.Cells[i + 2, 12] = listForExcelAndXML[i].discontinued;
                            worksheet.Cells[i + 2, 13] = listForExcelAndXML[i].isDeleted;
                            worksheet.Cells[i + 2, 14] = listForExcelAndXML[i].isActive;
                            worksheet.Cells[i + 2, 15] = listForExcelAndXML[i].image;
                        }
                        Excel.Range dataRange = worksheet.get_Range("A2", $"P{listForExcelAndXML.Count + 1}");
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

        private void ProList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                ProductListForExcel prod = new ProductListForExcel();
                prod.productID = Convert.ToInt32(dr["ProductID"]);
                prod.productItemNumber = "MD" + dr["ProductID"];
                prod.productName = dr["Product Name"].ToString();
                prod.brandName = dr["Brand Name"].ToString();
                prod.categoryName = dr["Category Name"].ToString();
                prod.description = dr["Description"].ToString();
                prod.quantityPerUnit = dr["Quantity Per Unit"].ToString();
                prod.unitPrice = Convert.ToDecimal(dr["Unit Price"]);
                prod.unitsInStock = Convert.ToInt16(dr["Units In Stock"]);
                prod.unitsOnOrder = Convert.ToInt16(dr["Units On Order"]);
                prod.reorderLevel = Convert.ToInt16(dr["Reorder Level"]);
                prod.discontinued = Convert.ToBoolean((dr["Discontinued"].ToString()) == "Yes" ? true : false);
                prod.isDeleted = Convert.ToBoolean((dr["Is Deleted"].ToString()) == "Yes" ? true : false);
                prod.isActive = Convert.ToBoolean((dr["Is Product Active For Sale"].ToString()) == "Yes" ? true : false);
                prod.image = dr["Product Image Name"].ToString();
                listForExcelAndXML.Add(prod);
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
    }
}
