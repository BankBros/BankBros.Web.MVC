using System;
using System.Collections.Generic;
using System.Text;


namespace BankBros.Backend.Entity.Dtos
{
    public class TransferDto
    {
        public int SenderCustomerId;
        public int SenderAccountNumber;
        public int TargetCustomerId;
        public int TargetAccountNumber;
        public decimal Amount;
    }
}
