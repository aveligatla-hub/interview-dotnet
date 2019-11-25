﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.DTO
{
    public class Item
    {
        [Required]
        public Guid ProductId { get; set; }        

        [Required]
        public int Quantity { get; set; }
    }
}
