using System;
using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Image { get; set; }
        public string? Status { get; set; }
        public int? SystemUserId { get; set; }
    }
}
