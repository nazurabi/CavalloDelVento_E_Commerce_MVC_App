﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataModelWithADO
{
    public class Categories
    {
        public int categoryID { get; set; }
        [XmlIgnore]
        public int brandIDFK { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; } 
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }
    }
}
