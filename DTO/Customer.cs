using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.DTO
{
    public class Customer
    {
        /// <summary>
        /// The customer's unique id
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The customer's Name
        /// </summary>
        [Required]
        public string Name { get; set; }        
    }
}
