using galante.se.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace galante.se.Controllers
{
    public class BookController : Controller
    {
        private IBook _book;

        /// <summary>
        /// Konstruktor med dependency injection
        /// </summary>
        /// <param name="book"></param>
        public BookController(IBook book)
        {
            this._book = book;
        }

        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(_book);
        }

    }
}
