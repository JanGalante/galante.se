using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace galante.se.Controllers
{
    public class BaseController : Controller
    {
        public CultureInfo CurrentCulture { 
            get 
            {
                return CultureInfo.CreateSpecificCulture("sv-SE");
                //return CultureInfo.CreateSpecificCulture("en-US");
            } 
        }
    }
}