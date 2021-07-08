﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }      
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime MfgDate { get; set; }

    }
}
