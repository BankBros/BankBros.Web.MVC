using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{
    
    public class Bill 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaymentAt { get; set; }
        public DateTime? LastDateToPay { get; set; }
        public bool Status { get; set; }
       
        public decimal Amount { get; set; }

      
        public virtual Customer Customer { get; set; }
        public virtual BillOrganization Organization { get; set; }

       
    }
}
