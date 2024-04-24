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
    public class CategoriesRepository : ICategoriesRepository
    {
        CFDBContext db;
        public CategoriesRepository() { 
            db = new CFDBContext();
        }
        public List<Category> GetCategories()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
    }
}
