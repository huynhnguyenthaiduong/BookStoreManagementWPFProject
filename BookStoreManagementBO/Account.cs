﻿using System;
using System.Collections.Generic;

namespace BookStoreManagementBO
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
