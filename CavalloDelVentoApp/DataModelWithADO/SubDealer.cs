using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    internal class SubDealer
    {
        public int subDealerUserID { get; set; }
        public string subDealerName { get; set; }
        public string subDealerMail { get; set; }
        public int discountIDFK { get; set; }
        public string subDealerAdress { get; set; }
        public string subDealerCity { get; set; }
        public string subDealerPostalCode { get; set; }
        public string subDealerCountry { get; set; }

    }
}
