using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using EFCodeFirstApprochExample.Filters;
using ServiceContracts;

namespace EFCodeFirstApprochExample.Controllers
{
    public class ProductsController : Controller
    {
        IProductsService productsService;
        public ProductsController(IProductsService products) { 
            this.productsService = products;
        }
        // GET: Products
        [MyAuthenticationFilter]
        [CustomerAuthorization]
        [MyActionFilter]
        public ActionResult Index()
        {
            List<Product> products = productsService.GetProducts();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult DisplayProduct(Product p)
        {
            return PartialView("MyProduct", p);
        }
    }

    
}