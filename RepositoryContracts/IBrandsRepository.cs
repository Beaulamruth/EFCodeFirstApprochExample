using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IBrandsRepository
    {
        List<Brand> GetBrands();
        Brand GetBrand(long brandId);
        void PostBrand(Brand newBrand);
        void PutBrand(Brand brand);
        void DeleteBrand(long brandId);
    }
}
