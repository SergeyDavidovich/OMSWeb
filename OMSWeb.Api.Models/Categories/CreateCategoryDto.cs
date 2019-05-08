using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMSWeb.Api.Models.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
