﻿using System;
using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
