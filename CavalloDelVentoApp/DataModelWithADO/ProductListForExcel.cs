using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataModelWithADO
{
    public class ProductListForExcel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string productItemNumber { get; set; }
        public string brandName { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string quantityPerUnit { get; set; }
        public decimal unitPrice { get; set; }
        public short unitsInStock { get; set; }
        public short unitsOnOrder { get; set; }
        public short reorderLevel { get; set; }
        public bool discontinued { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }
    }
}
