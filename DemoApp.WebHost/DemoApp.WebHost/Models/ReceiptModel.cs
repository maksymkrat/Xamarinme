﻿using System;
using System.Collections.Generic;

namespace DemoApp.WebHost.Models
{
    public class ReceiptModel
    {
        
        public DateTime DateTime { get; set; }
        public List<ReceiptItemModel> products { get; set; }
        public float Suma { get; set;}
        
    }
}