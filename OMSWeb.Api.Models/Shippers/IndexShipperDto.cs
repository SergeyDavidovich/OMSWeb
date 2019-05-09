using System;
using System.Collections.Generic;
using System.Text;

namespace OMSWeb.Api.Models.Shippers
{
    public class IndexShipperDto
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }

    //public partial class Shipper
    //{
    //    public Shipper()
    //    {
    //        Orders = new HashSet<Order>();
    //    }

    //    public int ShipperId { get; set; }
    //    public string CompanyName { get; set; }
    //    public string Phone { get; set; }

    //    public virtual ICollection<Order> Orders { get; set; }
    //}
}
