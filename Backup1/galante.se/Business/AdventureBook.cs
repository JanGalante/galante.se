using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace galante.se.Business
{
    public class AdventureBook : IBook
    {
        public string Title
        {
            get { return "En världsomsegling på 24 dagar"; }
        }

        public string Author
        {
            get { return "Julie Verne"; }
        }
    }
}