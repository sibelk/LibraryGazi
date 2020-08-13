using LibraryGazi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime VerisTarihi { get; set; }
        public int Count { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}