﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    public class MainUser
    {
        public int mainUserID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userType { get; set; }
        public bool isDeleted { get; set; }
    }
}
