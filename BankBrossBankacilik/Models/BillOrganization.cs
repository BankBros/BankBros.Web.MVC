using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Newtonsoft.Json;

namespace BankBros.Backend.Entity.Concrete
{

    public class BillOrganization 
    {
        public BillOrganization()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
  
        public decimal Charge { get; set; }

      
        public virtual ICollection<Bill> Bills { get; set; }

     
    }
}
