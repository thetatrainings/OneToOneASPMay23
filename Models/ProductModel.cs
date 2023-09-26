﻿namespace EcommerceStore.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Price { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
    }
}
