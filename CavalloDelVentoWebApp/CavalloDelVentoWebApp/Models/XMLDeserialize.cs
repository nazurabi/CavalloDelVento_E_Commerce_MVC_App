using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Models
{
    public class XMLDeserialize
    {
        public int sendID { get; set; }
        public string brandName { get; set; }
        public string categoryName { get; set; }
        public string productItemNumber { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public short sendQuantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal subTotalPrice { get; set; }
        public decimal tax { get; set; }
        public decimal totalPrice {get;set;}
        public decimal discountedPrice { get; set; }
        public string imageName { get; set; }

    }
}