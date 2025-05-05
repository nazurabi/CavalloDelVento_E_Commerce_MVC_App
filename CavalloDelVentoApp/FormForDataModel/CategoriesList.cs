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
using DataModelWithADO;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormForDataModel
{
    public partial class CategoriesList : Form
    {
        DataModel dm = new DataModel();
        List<CategoryListForExcel> listOfCategory = new List<CategoryListForExcel>();
        List<ExportedImages> listOfSendedImages = new List<ExportedImages>();
        DataTable dt = new DataTable();
        string imageName = "";
        string imageLocation = "";
        string imageFullPath = "";
        string imageDestinationPath = "";
        public CategoriesList()
        {
            InitializeComponent();
        }

        private void CategoriesList_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void CategoryList()
        {
            dt.Clear();
            listOfSendedImages.Clear();
            dt = dm.categoryDataBind();
            if (dt.Rows.Count != 0)
            {
                dgv_categoryList.DataSource = dt;
                dgv_categoryList.RowHeadersVisible = false;
                dgv_categoryList.Columns["BrandIDFK"].Visible = false;
                dgv_categoryList.Columns["Category Image Name"].Visible = false;

                foreach (DataGridViewColumn column in dgv_categoryList.Columns)
                {
                    if (column.Name == "S/N")
                    {
                        column.Width = 50;
                    }
                    if (column.Name == "Category Image")
                    {
                        DataGridViewImageColumn imageCol = (DataGridViewImageColumn)column;
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.Width = 100;
                        dgv_categoryList.RowTemplate.Height = 100;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ExportedImages img = new ExportedImages();
                    img.expImages = dr["Category Image Name"].ToString();
                    listOfSendedImages.Add(img);
                }
            }
            else
            {
                MessageBox.Show("No records were found for the date range you specified!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_categoryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow rows in dgv_categoryList.Rows)
            {
                if (rows.Cells["Is Deleted"].Value.ToString() == "Yes")
                {
                    rows.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btn_exportListToXml_Click(object sender, EventArgs e)
        {
            listOfCategory.Clear();
            CatList(dt);
            if (listOfCategory.Count != 0)
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
                                XmlSerializer sralz = new XmlSerializer(typeof(List<CategoryListForExcel>));
                                sralz.Serialize(swr, listOfCategory);
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
            listOfCategory.Clear();
            CatList(dt);
            if (listOfCategory.Count != 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "Category list.xlsx";

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
                        worksheet.Name = "Category list";

                        worksheet.Cells[1, 1] = "CategoryID";
                        worksheet.Cells[1, 2] = "Brand Name";
                        worksheet.Cells[1, 3] = "Category Name";
                        worksheet.Cells[1, 4] = "Category Description";
                        worksheet.Cells[1, 5] = "Is Deleted";
                        worksheet.Cells[1, 6] = "Is Product Active For Sale";
                        worksheet.Cells[1, 7] = "ImageFileName";

                        Excel.Range headerRange = worksheet.get_Range("A1", "G1");
                        headerRange.Font.Bold = true;
                        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        for (int i = 0; i < listOfCategory.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1] = listOfCategory[i].categoryID;
                            worksheet.Cells[i + 2, 2] = listOfCategory[i].brandName;
                            worksheet.Cells[i + 2, 3] = listOfCategory[i].categoryName;
                            worksheet.Cells[i + 2, 4] = listOfCategory[i].description;
                            worksheet.Cells[i + 2, 5] = listOfCategory[i].isDeleted;
                            worksheet.Cells[i + 2, 6] = listOfCategory[i].isActive;
                            worksheet.Cells[i + 2, 7] = listOfCategory[i].image;

                        }
                        Excel.Range dataRange = worksheet.get_Range("A2", $"G{listOfCategory.Count + 1}");
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
                                imageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages");
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

        private void CatList(DataTable sendDataInfo)
        {
            foreach (DataRow dr in sendDataInfo.Rows)
            {
                CategoryListForExcel cat = new CategoryListForExcel();
                cat.categoryID = Convert.ToInt32(dr["CategoryID"]);
                cat.brandName = dr["Brand Name"].ToString();
                cat.categoryName = dr["Category Name"].ToString();
                cat.description = dr["Description"].ToString();
                cat.isDeleted = Convert.ToBoolean((dr["Is Deleted"]) == "Yes" ? true : false);
                cat.isActive = Convert.ToBoolean((dr["Is Category Active For Sale"]) == "Yes" ? true : false);
                cat.image = dr["Category Image Name"].ToString();
                listOfCategory.Add(cat);
            }
        }
    }
}


