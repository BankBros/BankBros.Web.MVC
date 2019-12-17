using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{

    public class BalanceType
    {
        public BalanceType()
        {
            Accounts = new HashSet<Account>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        
        public decimal Currency { get; set; }
        public string Symbol { get; set; }
       
        public virtual ICollection<Account> Accounts { get; set; }
        
    }

}
