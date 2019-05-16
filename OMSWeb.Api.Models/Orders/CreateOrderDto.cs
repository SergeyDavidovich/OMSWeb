using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using OMSWeb.Data.Model;
using OMSWeb.Api.Models.OrderDetails;

namespace OMSWeb.Api.Models.Orders
{
    public class CreateOrderDto
    {
        [MaxLength(5)]
        [MinLength(5)]
        public string CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }

        [StringLength(40)] public string ShipName { get; set; }
        [StringLength(60)] public string ShipAddress { get; set; }
        [StringLength(15)] public string ShipCity { get; set; }
        [StringLength(15)] public string ShipRegion { get; set; }
        [StringLength(10)] public string ShipPostalCode { get; set; }
        [StringLength(15)] public string ShipCountry { get; set; }

        public virtual ICollection<OrderDetailDto> OrderDetailDto { get; set; }
    }
}

//public partial class Order
//{
//    public Order()
//    {
//        OrderDetails = new HashSet<OrderDetail>();
//    }

//    public int OrderId { get; set; }
//    public string CustomerId { get; set; }
//    public int? EmployeeId { get; set; }
//    public DateTime? OrderDate { get; set; }
//    public DateTime? RequiredDate { get; set; }
//    public DateTime? ShippedDate { get; set; }
//    public int? ShipVia { get; set; }
//    public decimal? Freight { get; set; }
//    public string ShipName { get; set; }
//    public string ShipAddress { get; set; }
//    public string ShipCity { get; set; }
//    public string ShipRegion { get; set; }
//    public string ShipPostalCode { get; set; }
//    public string ShipCountry { get; set; }

//    public virtual Customer Customer { get; set; }
//    public virtual Employee Employee { get; set; }
//    public virtual Shipper ShipViaNavigation { get; set; }
//    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
//}
