
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankBros.Backend.Entity.Concrete
{
   
    public class CreditRequest 
    {
        public CreditRequest()
        {
            CustomerCreditRequests = new HashSet<CustomerCreditRequest>();
        }

        public int Id { get; set; }

 
        public decimal Amount { get; set; }

        public int Age { get; set; }

        public bool HasHouse { get; set; }

        public bool HasCredit { get; set; }

        public bool HasPhone { get; set; }

        public bool Result { get; set; }
        
        public virtual ICollection<CustomerCreditRequest> CustomerCreditRequests { get; set; }
       
    }
}
