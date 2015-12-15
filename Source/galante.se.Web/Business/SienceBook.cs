using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace galante.se.Business
{
    public class ScienceBook : IBook
    {

        public string Title
        {
            get { return "Domain Driven Design"; }
        }

        public string Author
        {
            get { return "Robbie Fowler"; }
        }
    }
}