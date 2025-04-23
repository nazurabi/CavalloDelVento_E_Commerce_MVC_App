using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    internal class Categories
    {
        public int categoryID { get; set; }
        public int brandIDFK { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
    }
}
