using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DatabaseAPIs.Models;
using DatabaseAPIs.Backend;

namespace DatabaseAPIs.Backend
{
    public class SubCategoryDatabase : DataLoadLogic
    {
        public List<SubCategory> SubCategories = new List<SubCategory>();
        public List<Book> Books = new List<Book>();
        private static SubCategoryDatabase Instance = null;
        public static SubCategoryDatabase instantiateDB()
        {
            if (Instance == null)
            {
                Instance = new SubCategoryDatabase();
            }
            return Instance;
        }
        private SubCategoryDatabase()
        {
            SubCategories = LoadSubcategories();
            Books = LoadBooks();
        }

        public List<string> GetSubCategories()
        {
            return SubCategories.Select(x => x.SubName).ToList();

        }

        public List<Book> GetBooks(string SubID)
        {
            return Books.FindAll(x => x.SubID == SubID);
        }
    }
}