using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;

namespace ServiceContracts
{
    public interface IBrandsService
    {
        List<Brand> GetBrands();
        Brand GetBrand(long brandId);
        void PostBrand(Brand newBrand);
        void PutBrand(Brand brand);
        void DeleteBrand(long brandId);
    }
}
