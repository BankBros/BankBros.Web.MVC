using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{
   
    public  class Transaction 
    {
        public int Id { get; set; }
       
        public decimal Amount { get; set; }

       
        public decimal ActualAmount { get; set; }
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TransactionResultId { get; set; }
        public int TransactionTypeId { get; set; }
     
        public virtual Account Sender { get; set; }
       
        public virtual Account Receiver { get; set; }
        public virtual TransactionResult TransactionResult { get; set; }
        public virtual TransactionType TransactionType { get; set; }
      
        
    }
}
