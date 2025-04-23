using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    internal class SendToSubDealers
    {
        public int sendID { get; set; }
        public int brandIDFK { get; set; }
        public int categoryIDFK { get; set; }
        public int productIDFK { get; set; }
        public int settingIDFK { get; set; }
        public int userIDFK { get; set; }
        public DateTime sendDate { get; set; }
        public short sendQuantity { get; set; }
        public decimal subTotalPrice { get; set; }
        public decimal tax { get; set; }
        public decimal totalPrice { get; set; }
        public string description { get; set; }
    }
}
