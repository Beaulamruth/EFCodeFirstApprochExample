using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApprochExample.Filters;
using ServiceContracts;
using ServiceLayer;

namespace EFCodeFirstApprochExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        IBrandsService brandsService;
        public BrandsController(IBrandsService brands)
        {
            this.brandsService = brands;

        }

        // GET: Admin/Brands
        public ActionResult Index()
        {
            //List<Brand> brands = brandsService.GetBrands();
            //return View(brands);

            //writting ajax call to read data from Brands Api controller
            return View();
        }
    }
}