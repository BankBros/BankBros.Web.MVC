using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{

    public  class TransactionResult 
    {
        public TransactionResult()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Transaction> Transactions { get; set; }
      
   
    }
}
