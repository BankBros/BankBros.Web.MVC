﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace BankBros.Backend.Entity.Dtos
{
    public class DrawDto 
    {
        
        public decimal Amount { get; set; }
        public int AccountNumber { get; set; }
    }
}
