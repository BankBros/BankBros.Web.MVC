using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankBrossBankacilik.Models
{
    public class VirementRequest
    {
        public int SenderAccountNumber;       
        public int TargetAccountNumber;
        public decimal Amount;
    }
}