using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.DTO
{
    public class Order
    {
        /// <summary>
        /// The unique order id
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The customer id
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Items included in an order
        /// </summary>
        [Required]
        public IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The date the item(s) are ordered
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
