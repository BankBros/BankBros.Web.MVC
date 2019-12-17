using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{
    
    public partial class CustomerDetail 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TCKN { get; set; }
        public string Address { get; set; }
        
        public virtual Customer Customer { get; set; }
        
        
    }
}
