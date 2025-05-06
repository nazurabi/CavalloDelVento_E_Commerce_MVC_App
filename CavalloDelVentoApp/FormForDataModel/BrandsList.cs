using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class BrandsList : Form
    {
        DataModel dm = new DataModel();
        List<Brands> listOfBrands = new List<Brands>();
        List<ExportedImages> listOfSendedImages = new List<ExportedImages>();
        DataTable dt = new DataTable();
        string imageName = "";
        string imageLocation = "";
        string imageFullPath = "";
        string imageDestinationPath = "";
        public BrandsList()
        {
            InitializeComponent();
        }

        private void BrandsList_Load(object sender, EventArgs e)
        {
            BrandList();
        }

        private void BrandList()
        {
            dt.Clear();
            listOfSendedImages.Clear();
            dt = dm.brandDataBind();
            if (dt.Rows.Count != 0)
            {

                dgv_brandList.DataSource = dt;
                dgv_brandList.RowHeadersVisible = false;
                dgv_brandList.Columns["Brand Image Name"].Visible = false;

                foreach (DataGridViewColumn column in dgv_brandList.Columns)
                {
                    if (column.Name == "S/N")
                    {
                        column.Width = 50;
                    }
                    if (column.Name == "Brand Image")
                    {
                        DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_brandList.RowTemplate.Height = 100;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ExportedImages img = new ExportedImages();
                    img.expImages = dr["Brand Image Name"].ToString();
                    listOfSendedImages.Add(img);
                }
            }
            else
            {
                MessageBox.Show("No records were found for the date range you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgv_brandList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_brandList.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }


        private void btn_exportListToXml_Click(object sender, EventArgs e)
        {
            listOfBrands.Clear();
            BrandList(dt);
            if (listOfBrands.Count != 0)
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
                                XmlSerializer sralz = new XmlSerializer(typeof(List<Brands>));
                                sralz.Serialize(swr, listOfBrands);
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
            listOfBrands.Clear();
            BrandList(dt);
            if (listOfBrands.Count != 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "Brand list.xlsx";

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
                        worksheet.Name = "Brand list";

                        worksheet.Cells[1, 1] = "BrandID";
                        worksheet.Cells[1, 2] = "Brand Name";
                        worksheet.Cells[1, 3] = "Is Deleted";
                        worksheet.Cells[1, 4] = "Is Brand Active For Sale";
                        worksheet.Cells[1, 5] = "ImageFileName";

                        Excel.Range headerRange = worksheet.get_Range("A1", "E1");
                        headerRange.Font.Bold = true;
                        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        for (int i = 0; i < listOfBrands.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1] = listOfBrands[i].brandID;
                            worksheet.Cells[i + 2, 2] = listOfBrands[i].brandName;
                            worksheet.Cells[i + 2, 3] = listOfBrands[i].isDeleted;
                            worksheet.Cells[i + 2, 4] = listOfBrands[i].isActive;
                            worksheet.Cells[i + 2, 5] = listOfBrands[i].image;

                        }
                        Excel.Range dataRange = worksheet.get_Range("A2", $"E{listOfBrands.Count + 1}");
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
                                imageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages");
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

        private void BrandList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                Brands brand = new Brands();
                brand.brandID = Convert.ToInt32(dr["BrandID"]);
                brand.brandName = dr["Brand Name"].ToString();
                brand.isActive = Convert.ToBoolean((dr["Is Brand Active For Sale"].ToString()) == "Yes" ? true : false);
                brand.isDeleted = Convert.ToBoolean((dr["Is Deleted"].ToString()) == "Yes" ? true : false);
                brand.image = dr["Brand Image Name"].ToString();
                listOfBrands.Add(brand);
            }
        }
    }
}

