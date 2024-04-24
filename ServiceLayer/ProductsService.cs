using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts;
using DomainModels;
using RepositoryContracts;

namespace ServiceLayer
{
    public class ProductsService : IProductsService
    {
        IProductRepository productRepository;
        public ProductsService(IProductRepository products)
        {
            this.productRepository = products;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = productRepository.GetProducts();
            return products;
        }
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = productRepository.SearchProducts(ProductName);
            return products;
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product product = productRepository.GetProductByProductID(ProductID);
            return product;
        }
        public void InsertProduct(Product product)
        {
            if (product.Price < 1000000)
            {
                productRepository.InsertProduct(product);
            }
            else
            {
                throw new Exception("Price exceeds the limit");
            }
        }
        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
        public void DeleteProduct(long ProductID)
        {
            productRepository.DeleteProduct(ProductID);
        }
    }
}
