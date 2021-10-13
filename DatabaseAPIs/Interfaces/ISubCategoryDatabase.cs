using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseAPIs.Models;

namespace DatabaseAPIs.Interfaces
{
    interface ISubCategoryDatabase
    {
        List<string> GetSubCategories();
        List<Book> GetBooks(string SubID);
    }
}
