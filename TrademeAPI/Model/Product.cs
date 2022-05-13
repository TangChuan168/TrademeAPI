using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeAPI.Model
{
    public class Product
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ClosingDate { get; set; }
        public string Time { get; set; }
        public string numOfBits { get; set; }
        public string ExpectedDeliveryDays { get; set; }
        public string Quantity { get; set; }
        public string CateStructure { get; set; }
        public List<string> Imgs { get; set; }
        public string SellerName { get; set; }
        public string Location { get; set; }
        public string numOfFeedback { get; set; }
        public string MemberSince { get; set; }
    }
}
