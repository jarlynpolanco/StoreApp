using StoreApp.UI.Models;
using StoreApp.UI.WebService.WSEntity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace StoreApp.UI.WebService
{
    /// <summary>
    /// Summary description for SalesProducts
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SalesProducts : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Product> GetAllSalesProducts()
        {
            StoreEntities db = new StoreEntities();
            var salesProductList = db.SalesProducts.ToList();
            List<Product> productsList = new List<Product>();
            foreach (var item in salesProductList) 
            {
                Product product = new Product()
                {
                    Id = item.Id,
                    ProductDescription = item.Product_Description,
                    ProductName = item.Product_Name,
                    ProductPrice = item.Product_Price,
                    ProductQuantity = item.Product_Quantity
                };
                productsList.Add(product);
            }
            db.Dispose();
            return productsList;
        }

        [WebMethod]
        public Product GetSaleProductById(int productId)
        {
            StoreEntities db = new StoreEntities();
            var item = db.SalesProducts.ToList().Where(x => x.Id == productId).FirstOrDefault();
            Product product = new Product()
            {
                Id = item.Id,
                ProductDescription = item.Product_Description,
                ProductName = item.Product_Name,
                ProductPrice = item.Product_Price,
                ProductQuantity = item.Product_Quantity
            };
            db.Dispose();
            return product;
        }
    }
}
