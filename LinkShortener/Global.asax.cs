using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LinkShortener
{
    using Controllers;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InjectionConfig.RegisterControllers();
        }

        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            var userCookie = HttpContext.Current.Request.Cookies[LinksController.UserKey];
            if (userCookie == null)
            {
                userCookie = new HttpCookie(LinksController.UserKey)
                {
                    Value = Guid.NewGuid().ToString(),
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Request.Cookies.Add(userCookie);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
            else
            {
                Guid userkey;
                if (!Guid.TryParse(userCookie.Value, out userkey))
                {
                    userCookie.Value = Guid.NewGuid().ToString();
                    HttpContext.Current.Response.Cookies[LinksController.UserKey].Value = userCookie.Value;
                }
            }
        }
    }
}
