using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class Colors2Controller : ApiController
    {
        INTECEcommerceEntities db = new INTECEcommerceEntities();

        // GET: Colors2
        public IQueryable<Color> GetColor()
        {
            return db.Color;
        }
    }
}