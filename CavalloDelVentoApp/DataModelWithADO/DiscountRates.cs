using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    public class DiscountRates
    {
        public int discountID { get; set; }
        public string discountType { get; set; }
        public byte discountAmount { get; set; }

    }
}
