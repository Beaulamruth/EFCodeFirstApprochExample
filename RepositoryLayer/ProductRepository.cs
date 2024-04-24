using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using DataLayer;

namespace RepositoryLayer
{
    public class ProductRepository: IProductRepository
    {
        CFDBContext db;
        public ProductRepository()
        {
            db = new CFDBContext();
        }
        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(ProductName)).ToList();
            return products;
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product product = db.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();
            return product;
        }
        public void InsertProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product existingProduct = db.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.DateOfPurchase = product.DateOfPurchase;
            existingProduct.AvailabilityStatus = product.AvailabilityStatus;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.BrandID = product.BrandID;
            existingProduct.Active = true;
            existingProduct.Photo = product.Photo;
            db.SaveChanges();
        }
        public void DeleteProduct(long ProductID)
        {
            Product existingProduct = db.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
        }
    }
}
