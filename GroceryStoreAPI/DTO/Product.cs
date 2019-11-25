﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.DTO
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }        

        [Required]
        public decimal Price { get; set; }
    }
}
