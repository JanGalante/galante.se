using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Web.Routing;
using System.Web.Compilation;
//using System.Web.contextbase;

namespace janlundholm.eu
{
    public class CustomRouteHandler : IRouteHandler
    {
        public CustomRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }



        public string VirtualPath { get; private set; }



        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            //foreach (var urlParm in requestContext.RouteData.Values)
            //{
            //    requestContext.HttpContext.Items[urlParm.Key] = urlParm.Value;
            //}
            
            //System.Web.Routing.RequestContext.  //requestContext.HttpContext.Items
            //requestContext.HttpContext.Items
            //requestContext.HttpContext.User = System.Web.HttpContext.Current.User;
            //requestContext.HttpContext = System.Web.HttpContext;

            var page = BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page)) as IHttpHandler;
            return page;
        }
    }
}
