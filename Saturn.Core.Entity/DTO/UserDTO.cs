﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
    }
}
