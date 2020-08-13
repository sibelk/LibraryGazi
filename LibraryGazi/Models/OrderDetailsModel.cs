using LibraryGazi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime VerisTarihi { get; set; }
        public string UserName { get; set; }
        public virtual List<OrderLineModel> OrderLines { get; set; }
    }

    public class OrderLineModel
    {
        
        public string BookName { get; set; }

        public int BookId { get; set; }
        
    }
}