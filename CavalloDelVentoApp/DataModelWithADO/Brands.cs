﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    public class Brands
    {
        public int brandID { get; set; }
        public string brandName { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }
    }
}
