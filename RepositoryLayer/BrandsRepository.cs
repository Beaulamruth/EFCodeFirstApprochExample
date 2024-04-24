using DataLayer;
using DomainModels;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class BrandsRepository : IBrandsRepository
    {
        CFDBContext db;
        public BrandsRepository() { 
            this.db = new CFDBContext();    
        }
        public List<Brand> GetBrands()
        {
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }

        public Brand GetBrand(long brandId)
        {
            Brand brand = db.Brands.Where(b=>b.BrandID== brandId).FirstOrDefault();
            return brand;
        }

        public void PostBrand(Brand newBrand)
        {
            db.Brands.Add(newBrand);
            db.SaveChanges();
        }

        public void PutBrand(Brand brand)
        {
            Brand existingBrand=db.Brands.Where(b=>b.BrandID==brand.BrandID).FirstOrDefault();
            if (existingBrand!=null)
            {
                existingBrand.BrandName = brand.BrandName;
                db.Brands.Add(existingBrand);
                db.SaveChanges();
            }
        }

        public void DeleteBrand(long brandId)
        {
            Brand existingBrand=db.Brands.Where(b=>b.BrandID== brandId).FirstOrDefault();
            if(existingBrand!=null)
            {
                db.Brands.Remove(existingBrand);
                db.SaveChanges();
            }
        }
    }
}
