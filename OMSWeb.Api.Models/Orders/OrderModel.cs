using System;
using System.Collections.Generic;

namespace OMSWeb.Data.Model.Orders
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }

    }
    //public partial class OrderDetail
    //{
    //    public int OrderId { get; set; }
    //    public int ProductId { get; set; }
    //    public decimal UnitPrice { get; set; }
    //    public short Quantity { get; set; }
    //    public float Discount { get; set; }

    //    public virtual Order Order { get; set; }
    //    public virtual Product Product { get; set; }
    //}
    public class OrderDetailModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }

}