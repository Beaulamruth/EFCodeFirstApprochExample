﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;

namespace ServiceContracts
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string ProductName);

        Product GetProductByProductID(long ProductID);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long ProductID);
    }
}
