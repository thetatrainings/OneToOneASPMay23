﻿using System;
using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CategoryId { get; set; }
        public int? Price { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
    }
}
