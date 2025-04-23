using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    internal class MainDealer
    {
        public int settingID { get; set; }
        public string dealerName { get; set; }
        public string mail { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public byte invoiceTaxAmount { get; set; }
        
    }
}
