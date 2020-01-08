using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Entities
{
    public class Vendor
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Products> ProductList { get; set; }
    }
}