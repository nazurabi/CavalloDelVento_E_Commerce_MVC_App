using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataModelWithADO
{
    public class Product
    {
        public int productID { get; set; }
        public int brandIDFK { get; set; }
        public int categoryIDFK { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string quantityPerUnit { get; set; }
        public decimal money { get; set; }
        public short unitsInStock { get; set; }
        public short unitsOnOrder { get; set; }
        public short reorderLevel { get; set; }
        public bool discontinued { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }


    }
}
