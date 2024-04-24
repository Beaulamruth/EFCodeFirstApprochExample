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
    public class CategoriesService: ICategoriesService
    {
        ICategoriesRepository categoriesRepository;
        public CategoriesService(ICategoriesRepository categories) {
            categoriesRepository=categories;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = categoriesRepository.GetCategories();
            return categories;
        }
    }
}
