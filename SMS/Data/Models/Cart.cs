using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Cart
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
