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
        public List<Book> Books = new List<Book>();
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
            Books = LoadData();
        }

        public List<string> GetCategories()
        {
            return Books.Select(x => x.Category).Distinct().ToList();

        }

        public List<Book> GetDataByCategory(string category)
        {
            return Books.FindAll(x => x.Category == category);
        }
    }
}