using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApprochExample.Filters;
using ServiceLayer;
using ServiceContracts;

namespace EFCodeFirstApprochExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categories)
        {
            categoriesService = categories;
        }
        // GET: Admin/Categories
        public ActionResult Index()
        {
            List<Category> categories = categoriesService.GetCategories();
            return View(categories);
        }
    }
}