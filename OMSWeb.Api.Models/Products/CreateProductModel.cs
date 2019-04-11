using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OMSWeb.Api.Models.Products
{
    public class CreateProductModel
    {
        [Required]
        [Range(1, 40)]
        public string ProductName { get; set; }

        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        [Range(1,20)]
        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }

        [Required][DefaultValue(false)]
        public bool Discontinued { get; set; }
    }
}
