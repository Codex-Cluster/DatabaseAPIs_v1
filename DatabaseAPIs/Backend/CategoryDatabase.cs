using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

using DatabaseAPIs.Models;
using DatabaseAPIs.Interfaces;

namespace DatabaseAPIs.Backend
{
    public class CategoryDatabase: DataLoadLogic, ICategoryDatabase
    {
        public List<Category> Categories = new List<Category>();
        public List<SubCategory> SubCategories = new List<SubCategory>(); 
        private static CategoryDatabase Instance = null;
        public static CategoryDatabase instantiateDB()
        {
            if (Instance == null)
            {
                Instance = new CategoryDatabase();
            }
            return Instance;
        }
        private CategoryDatabase()
        {
            Categories = LoadCategories();
            SubCategories = LoadSubcategories();
        }

        public List<string> GetCategories()
        {
            return Categories.Select(x => x.CatName).ToList();

        }

        public List<SubCategory> GetSubCategories(string CatID)
        {
            return SubCategories.FindAll(x => x.CatID == CatID);
        }
    }
}