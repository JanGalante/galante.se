using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace galante.se
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication //NinjectHttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();  
        }

        //protected override Ninject.IKernel CreateKernel()
        //{
        //    //throw new NotImplementedException();
        //    var kernel = new StandardKernel();
        //    RegisterServices(kernel);
        //    return kernel;
        //}

        ///// <summary>
        ///// Load your modules or register your services here!
        ///// </summary>
        ///// <param name="kernel">The kernel.</param>
        //private void RegisterServices(IKernel kernel)
        //{
        //    // e.g. kernel.Load(Assembly.GetExecutingAssembly());
        //}
    }
}