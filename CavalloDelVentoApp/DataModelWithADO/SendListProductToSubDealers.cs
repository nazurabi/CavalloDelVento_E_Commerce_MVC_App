using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataModelWithADO
{
    public class SendListProductToSubDealers
    {
        public int sendID { get; set; }
        [XmlIgnore]
        public int brandIDFK { get; set; }
        public string brandName { get; set; }
        [XmlIgnore]
        public int categoryIDFK { get; set; }
        public string categoryName { get; set; }
        [XmlIgnore]
        public int productIDFK { get; set; }
        public string productItemNumber { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        [XmlIgnore]
        public int mainUserIDFK { get; set; }
        [XmlIgnore]
        public int subDealerUserIDFK { get; set; }
        public string subDealerName { get; set; }
        public DateTime sendDate { get; set; }
        public short sendQuantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal subTotalPrice { get; set; }
        public decimal tax { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discountedPrice { get; set; }
        public string description { get; set; }
        public string productImageName { get; set; }
    }
}
