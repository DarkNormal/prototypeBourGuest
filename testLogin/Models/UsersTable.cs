﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class UsersTable
    {
        public string id { get; set; }
        public string password { get; set; }
        public bool accountVerified { get; set; }
    }
}