using DomainModels;
using RepositoryContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BrandsService : IBrandsService
    {

        IBrandsRepository brandsRepository;
        public BrandsService(IBrandsRepository brands)
        {
            this.brandsRepository = brands;
        }
        public List<Brand> GetBrands()
        {
            List<Brand> brands = brandsRepository.GetBrands();
            return brands;
        }

        public Brand GetBrand(long brandId)
        {
            Brand brand = brandsRepository.GetBrand(brandId);
            return brand;
        }

        public void PostBrand(Brand newBrand)
        {
            brandsRepository.PostBrand(newBrand);
        }
        public void PutBrand(Brand brand)
        {
            brandsRepository.PutBrand(brand);
        }

        public void DeleteBrand(long brandId)
        {
            brandsRepository.DeleteBrand(brandId);
        }
    }
}
