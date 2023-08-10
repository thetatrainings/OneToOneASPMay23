using System;
using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public string? OrderDetail { get; set; }
        public int? CustomerId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Status { get; set; }
    }
}
