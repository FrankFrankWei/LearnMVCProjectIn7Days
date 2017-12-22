using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();// then we can custom url of action methods, like [Route("Employee/List/{id:int}")] on an action

            routes.MapRoute(
                name: "Upload",
                url: "Employee/BulkUpload",
                defaults: new { controller = "BulkUpload", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
