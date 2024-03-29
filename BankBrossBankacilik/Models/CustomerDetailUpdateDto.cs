﻿using System;
using System.Collections.Generic;


namespace BankBros.Backend.Entity.Dtos
{
    public class CustomerDetailUpdateDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string PhoneNumber { get; set; }
    }
}
