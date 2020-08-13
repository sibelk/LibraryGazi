using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime VerisTarihi { get; set; }
        public string UserName { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}