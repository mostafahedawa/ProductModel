using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Domain.Entities
{
  public  class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int VendorID { get; set; }
        public Vendor Vendor { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public byte[] Photo { set; get; }
        public string PhotoName { get; set; }

        public int DietaryID { get; set; }
        public DietaryFlags DietaryFlag { get; set; }

        public int NumberOfViews { get; set; }


    }
}
