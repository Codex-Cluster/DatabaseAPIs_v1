using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPIs.Models
{
    public class SubCategory
    {
        public string SubID { get; set; }
        public string SubName { get; set; }
        public string SubDescription { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string CatID { get; set; }
    }
}