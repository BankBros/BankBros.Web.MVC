using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace BankBros.Backend.Entity.Dtos
{
    public class PayBillDto 
    {
        public int AccountNumber { get; set; }     
        public decimal Amount { get; set; }
    }
}