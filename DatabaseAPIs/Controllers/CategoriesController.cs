using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;

using DatabaseAPIs.Backend;
using DatabaseAPIs.Models;

namespace DatabaseAPIs.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        CategoryDatabase db = CategoryDatabase.instantiateDB();

        [HttpGet]
        public HttpResponseMessage GetData()
        {
            try
            {
                List<string> data = db.GetCategories();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetData(string CatID)
        {
            try
            {
                List<SubCategory> data = db.GetSubCategories(CatID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
        }
    }
}