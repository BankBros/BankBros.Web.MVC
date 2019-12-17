using System;


namespace BankBros.Backend.Entity.Concrete
{
    
    public partial class CustomerCreditRequest 
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CreditRequestId { get; set; }

        public DateTime Date { get; set; }
        
        public virtual CreditRequest CreditRequest { get; set; }
       
        public virtual Customer Customer { get; set; }
        
    }
}
