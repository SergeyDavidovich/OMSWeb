using OMSWeb.Api.Models.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWeb.Api.Models.Orders
{
    public class OrderInvoiceDto
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? OrderDate { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; }

    }
}
