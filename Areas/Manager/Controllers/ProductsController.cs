using DataLayer;
using DomainModels;
using ServiceContracts;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApprochExample.Filters;

namespace EFDbFirstApprochExample.Areas.Manager.Controllers
{
    [ManagerAuthorization]
    public class ProductsController : Controller
    {
        CFDBContext db;
        IProductsService productsService;

        public ProductsController(IProductsService products)
        {
            this.db = new CFDBContext();
            this.productsService = products;
        }
        // GET: Admin/Products/Index
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            ViewBag.ProductName = search;
            List<Product> products = productsService.SearchProducts(search);

            /* Sorting */
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.ProductID).ToList();
                else
                    products = products.OrderByDescending(p => p.ProductID).ToList();
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.ProductName).ToList();
                else
                    products = products.OrderByDescending(p => p.ProductName).ToList();
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Price).ToList();
                else
                    products = products.OrderByDescending(p => p.Price).ToList();
            }
            else if (SortColumn == "DateOfPurchase")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(p => p.DateOfPurchase).ToList();
            }
            else if (SortColumn == "AvailabilityStatus")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(p => p.AvailabilityStatus).ToList();
            }
            else if (SortColumn == "CategoryID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(p => p.Category.CategoryName).ToList();
            }
            else if (SortColumn == "BrandID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(p => p.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(p => p.Brand.BrandName).ToList();
            }

            /* Paging */

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }

        //GET: Admin/Products/Details/ProductId
        public ActionResult Details(long id)
        {
            Product product = productsService.GetProductByProductID(id);
            return View(product);
        }

        public ActionResult Create()
        {

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Used for CSRF security
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,DateOfPurchase,AvailabilityStatus,CategoryID,BrandID,Active,Photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        var imageByte = new Byte[file.ContentLength - 1];
                        file.InputStream.Read(imageByte, 0, file.ContentLength - 1);
                        var base64String = Convert.ToBase64String(imageByte, 0, imageByte.Length);
                        product.Photo = base64String;
                    }
                }
                product.Active = true;
                productsService.InsertProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            Product existingProduct = productsService.GetProductByProductID(id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var base64String = string.Empty;
                Product existingProduct = productsService.GetProductByProductID(product.ProductID);
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    if (file.ContentLength > 1)
                    {
                        var imageByte = new Byte[file.ContentLength - 1];
                        file.InputStream.Read(imageByte, 0, file.ContentLength - 1);
                        base64String = Convert.ToBase64String(imageByte, 0, imageByte.Length);
                        existingProduct.Photo = base64String;
                    }
                }

                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.DateOfPurchase = product.DateOfPurchase;
                existingProduct.AvailabilityStatus = product.AvailabilityStatus;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.BrandID = product.BrandID;
                existingProduct.Active = true;
                productsService.UpdateProduct(existingProduct);

            }
            return RedirectToAction("Index", "Products");
        }

    }
}