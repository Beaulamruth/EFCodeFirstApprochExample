using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainModels;
using DataLayer;
using ServiceContracts;

namespace EFDbFirstApprochExample.ApiControllers
{
    public class BrandsController : ApiController
    {
        IBrandsService brandsService;

        public BrandsController(IBrandsService brands)
        {
            this.brandsService = brands;
        }
        public List<Brand> GetBrands()
        {
            List<Brand> brands=brandsService.GetBrands();
            return brands;
        }

        public Brand GetBrandByBrandId(long brandId)
        {
            Brand brand=brandsService.GetBrand(brandId);
            return brand;
        }

        public void PostBrand(Brand newBrand)
        {
            brandsService.PostBrand(newBrand);
        }
        public void PutBrand(Brand brand)
        {
            brandsService.PutBrand(brand);
        }
        public void DeleteBrand(long brandId)
        {
            brandsService.DeleteBrand(brandId);
        }
    }
}
