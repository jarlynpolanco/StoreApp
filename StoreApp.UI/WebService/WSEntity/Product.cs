using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.UI.WebService.WSEntity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductDescription { get; set; }
    }
}