using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RealNorthwindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            try
            {
                // TODO: call business logic layer to retrieve product
                Product product = new Product();
                product.ProductID = id;
                product.ProductName =
                "fake product name from service layer";
                product.UnitPrice = 10.0m;
                product.QuantityPerUnit = "fake QPU";
                return product;
                //throw new FaultException<ProductFault>(new ProductFault("fake"), "fake exception");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string reason = "GetProduct Exception";
                throw new FaultException<ProductFault>(new ProductFault(msg), reason);
            }
            
            
        }

        public bool UpdateProduct(Product product, ref string message)
        {
            try
            {
                bool result = true;
                // first check to see if it is a valid price
                if (product.UnitPrice <= 0)
                {
                    message = "Price cannot be <= 0";
                    result = false;
                }
                // ProductName can't be empty
                else if (string.IsNullOrEmpty(product.ProductName))
                {
                    message = "Product name cannot be empty";
                    result = false;
                }
                // QuantityPerUnit can't be empty
                else if (string.IsNullOrEmpty(product.QuantityPerUnit))
                {
                    message = "Quantity cannot be empty";
                    result = false;
                }
                else
                {
                    // TODO: call business logic layer to update product
                    message = "Product updated successfully";
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string reason = "UpdateProduct Exception";
                throw new FaultException<ProductFault>(new ProductFault(msg), reason);
            }
        }

    }
}
