﻿using System;
using System.Collections.Generic;

#nullable disable

namespace tienda_pamys_api.models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? Active { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int? IdRol { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
