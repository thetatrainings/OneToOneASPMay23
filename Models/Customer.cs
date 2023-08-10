using System;
using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Image { get; set; }
        public string? Role { get; set; }
        public int? SystemUserId { get; set; }
    }
}
